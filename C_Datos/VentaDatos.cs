using C_Entidades;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Datos
{
    public class VentaDatos
    {
        public int RegistrarVenta(Venta venta, int idUsuario, NpgsqlConnection conexion, NpgsqlTransaction transaction)
        {
            if (conexion.State != ConnectionState.Open)
                conexion.Open();

            try
            {
                int ventaId;

                using (var cmd = new NpgsqlCommand(
                    @"INSERT INTO venta (id_usuario, id_cliente, fecha) 
            VALUES (@idUsuario, @idCliente, @fecha)
            RETURNING id_venta;", conexion, transaction))
                {
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                    cmd.Parameters.AddWithValue("@idCliente", venta.ClienteId);
                    cmd.Parameters.AddWithValue("@fecha", venta.Fecha);

                    ventaId = Convert.ToInt32(cmd.ExecuteScalar());
                }

                foreach (var detalle in venta.Detalles)
                {
                    InsertarVentaDetalle(ventaId, detalle, conexion, transaction); 
                }

                return ventaId;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al registrar la venta: {ex.Message}");
            }
        }

        public void InsertarVentaDetalle(int idVenta, DetalleVenta detalle, NpgsqlConnection conexion, NpgsqlTransaction transaction)
        {
            try
            {
                using (var cmd = new NpgsqlCommand(
                    @"INSERT INTO detalle_venta (id_venta, id_producto, cantidad) 
            VALUES (@idVenta, @idProducto, @cantidad);", conexion, transaction))
                {
                    cmd.Parameters.AddWithValue("@idVenta", idVenta);
                    cmd.Parameters.AddWithValue("@idProducto", detalle.ProductoId);
                    cmd.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al insertar detalle de venta: {ex.Message}");
            }
        }

        public void InsertarComprobante(int idVenta, NpgsqlConnection conexion, NpgsqlTransaction transaction)
        {
            try
            {
                string numComprobante;
                using (var cmd = new NpgsqlCommand(
                    @"SELECT COALESCE(MAX(CAST(num_comprobante AS INTEGER)), 0) + 1 FROM comprobante", conexion, transaction))
                {
                    int numero = Convert.ToInt32(cmd.ExecuteScalar());
                    numComprobante = numero.ToString("D4");
                }

                using (var cmd = new NpgsqlCommand(
                    @"INSERT INTO comprobante (id_venta, num_comprobante, fecha) 
            VALUES (@idVenta, @numComprobante, @fecha);", conexion, transaction))
                {
                    cmd.Parameters.AddWithValue("@idVenta", idVenta);
                    cmd.Parameters.AddWithValue("@numComprobante", numComprobante);
                    cmd.Parameters.AddWithValue("@fecha", DateTime.Now);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al insertar comprobante: {ex.Message}");
            }
        }

        public void ActualizarStock(int productoId, int cantidadVendida, NpgsqlConnection conexion, NpgsqlTransaction transaction)
        {
            try
            {
                using (var cmdCheckStock = new NpgsqlCommand(
                    @"SELECT stock FROM producto WHERE id_producto = @idProducto;", conexion, transaction))
                {
                    cmdCheckStock.Parameters.AddWithValue("@idProducto", productoId);
                    int stockActual = Convert.ToInt32(cmdCheckStock.ExecuteScalar());

                    if (stockActual < cantidadVendida)
                    {
                        throw new Exception("No hay suficiente stock para realizar la venta.");
                    }
                }

                using (var cmd = new NpgsqlCommand(
                    @"UPDATE producto 
            SET stock = stock - @cantidad 
            WHERE id_producto = @idProducto;", conexion, transaction))
                {
                    cmd.Parameters.AddWithValue("@cantidad", cantidadVendida);
                    cmd.Parameters.AddWithValue("@idProducto", productoId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar stock: {ex.Message}");
            }
        }

        // Obtener el último número de ticket (comprobante)
        public int ObtenerUltimoTicket()
        {
            string query = "SELECT MAX(num_comprobante) FROM Comprobante";

            using (NpgsqlConnection connection = Conexion.ObtenerConexion())
            {
                using (var cmd = new NpgsqlCommand(query, connection))
                {
                    var result = cmd.ExecuteScalar();
                    return result != DBNull.Value ? Convert.ToInt32(result) : 0;
                }
            }
        }
    }
}
