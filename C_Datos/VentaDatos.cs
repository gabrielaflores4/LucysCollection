using C_Entidades;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Datos
{
    public class VentaDatos
    {

        public void RegistrarVenta(Venta venta, int idUsuario)
        {
            using (var conexion = Conexion.ObtenerConexion())
            {
                using (var transaction = conexion.BeginTransaction())
                {
                    try
                    {
                        // 1. Registrar venta principal
                        int ventaId;
                        using (var cmd = new NpgsqlCommand(
                            @"INSERT INTO Venta (id_usuario, id_cliente, fecha) 
                      VALUES (@idUsuario, @idCliente, @fecha)
                      RETURNING id_venta;",
                            conexion))
                        {
                            cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                            cmd.Parameters.AddWithValue("@idCliente", venta.ClienteId);
                            cmd.Parameters.AddWithValue("@fecha", venta.Fecha);

                            ventaId = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        // 2. Registrar detalles
                        foreach (var detalle in venta.Detalles)
                        {
                            using (var cmd = new NpgsqlCommand(
                                @"INSERT INTO detalle_venta 
                          (id_venta, id_producto, cantidad) 
                          VALUES (@ventaId, @productoId, @cantidad);",
                                conexion))
                            {
                                cmd.Parameters.AddWithValue("@ventaId", ventaId);
                                cmd.Parameters.AddWithValue("@productoId", detalle.ProductoId);
                                cmd.Parameters.AddWithValue("@cantidad", detalle.Cantidad);

                                cmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception($"Error en BD al registrar venta: {ex.Message}");

                    }
                }
            }
        }

        private string cadenaConexion = "Host=localhost;Port=5432;Username=postgres;Password=Lincon22;Database=lucyssdb";

        public int ObtenerUltimoTicket()
        {
            string query = "SELECT MAX(num_comprobante) FROM Comprobante";

            // Conexión y ejecución de la consulta usando Npgsql
            using (NpgsqlConnection connection = new NpgsqlConnection(cadenaConexion))
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand(query, connection)) // Usa NpgsqlCommand
                {
                    var result = cmd.ExecuteScalar();
                    return result != DBNull.Value ? Convert.ToInt32(result) : 0; // Si no hay tickets, devolvemos 0
                }

            }
        }
        public int InsertarComprobante(int idCliente)
        {
            try
            {
                // Crear una conexión a la base de datos (Asegúrate de tener tu conexión configurada)
                using (var conexion = new NpgsqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    // Crear el comando para insertar el comprobante
                    string query = "INSERT INTO comprobantes (id_cliente, fecha) VALUES (@idCliente, @fecha) RETURNING num_comprobante";

                    using (var cmd = new NpgsqlCommand(query, conexion))
                    {
                        // Agregar parámetros al comando
                        cmd.Parameters.AddWithValue("@idCliente", idCliente);
                        cmd.Parameters.AddWithValue("@fecha", DateTime.Now); // Asegúrate de que este valor sea el adecuado

                        // Ejecutar el comando y devolver el num_comprobante generado
                        int numComprobante = (int)cmd.ExecuteScalar();

                        return numComprobante;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al insertar comprobante: {ex.Message}");
            }
        }
        public void InsertarVentaDetalle(int numComprobante, DetalleVenta detalle)
        {
            try
            {
                using (var conexion = new NpgsqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    // Crear el comando para insertar un detalle de venta
                    string query = "INSERT INTO venta_detalles (num_comprobante, producto_id, cantidad, precio_unitario) " +
                                   "VALUES (@numComprobante, @productoId, @cantidad, @precioUnitario)";

                    using (var cmd = new NpgsqlCommand(query, conexion))
                    {
                        // Agregar parámetros al comando
                        cmd.Parameters.AddWithValue("@numComprobante", numComprobante);
                        cmd.Parameters.AddWithValue("@productoId", detalle.ProductoId);
                        cmd.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                        cmd.Parameters.AddWithValue("@precioUnitario", detalle.PrecioUnitario);

                        // Ejecutar el comando
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al insertar detalle de venta: {ex.Message}");
            }
        }

    }
}