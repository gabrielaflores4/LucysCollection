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
    }
}
