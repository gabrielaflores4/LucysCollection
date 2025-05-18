using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_Entidades;
using iTextSharp.text.pdf.codec.wmf;

namespace C_Datos
{
    public class ClienteDatos
    {


        // Método para crear un Cliente
        public int CrearCliente(string nombre, string apellido, string correo, string telefono, DateTime fechaRegistro)
        {
            using (var conexion = Conexion.ObtenerConexion())
            {
                using (var transaccion = conexion.BeginTransaction()) // Iniciar una transacción
                {
                    try
                    {
                        //Insertar en la tabla Personas
                        int idPersona;
                        using (var cmdPersona = new NpgsqlCommand(
                            @"INSERT INTO Personas (nombre, apellido, correo, telefono) VALUES (@nombre, @apellido, @correo, @telefono) RETURNING id_persona",
                            conexion))
                        {
                            cmdPersona.Parameters.AddWithValue("@nombre", nombre);
                            cmdPersona.Parameters.AddWithValue("@apellido", apellido);
                            cmdPersona.Parameters.AddWithValue("@correo", correo);
                            cmdPersona.Parameters.AddWithValue("@telefono", telefono);

                            idPersona = Convert.ToInt32(cmdPersona.ExecuteScalar()); // Obtener el ID generado
                        }

                        //Insertar en la tabla Clientes
                        int idCliente;
                        using (var cmdCliente = new NpgsqlCommand(
                            @"INSERT INTO Cliente (id_persona, fecha_registro) VALUES (@id_persona, @fecha_registro) RETURNING id_Cliente",
                            conexion))
                        {
                            cmdCliente.Parameters.AddWithValue("@id_persona", idPersona);
                            cmdCliente.Parameters.AddWithValue("@fecha_registro", fechaRegistro);

                            idCliente = Convert.ToInt32(cmdCliente.ExecuteScalar()); // Obtener el ID del Cliente
                        }

                        transaccion.Commit();
                        return idCliente;
                    }
                    catch
                    {
                        transaccion.Rollback();
                        Console.WriteLine($"Error: ");
                        throw;
                    }
                }
            }
        }

        public List<string> ObtenerNombresClientes()
        {
            var nombresClientes = new List<string>();

            using (var conexion = Conexion.ObtenerConexion())
            {
                using (var cmd = new NpgsqlCommand("SELECT p.nombre, p.apellido FROM Cliente c JOIN Personas p ON c.id_persona = p.id_persona", conexion))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var nombre = reader.GetString(reader.GetOrdinal("nombre"));
                        var apellido = reader.GetString(reader.GetOrdinal("apellido"));
                        nombresClientes.Add(nombre + " " + apellido);
                    }
                }
            }

            return nombresClientes;
        }
        public List<int> ObtenerIdsClientes()
        {
            var idsClientes = new List<int>();

            using (var conexion = Conexion.ObtenerConexion())
            {
                using (var cmd = new NpgsqlCommand("SELECT id_Cliente FROM Cliente ORDER BY id_Cliente", conexion))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        idsClientes.Add(reader.GetInt32(0));
                    }
                }
            }

            return idsClientes;
        }

        public Cliente? ObtenerClientePorId(int clienteId) // Use nullable reference type
        {
            using (var conexion = Conexion.ObtenerConexion())
            {
                string query = @"SELECT c.id_cliente, p.nombre, p.apellido, p.telefono, p.correo, c.fecha_registro 
                        FROM Cliente c 
                        JOIN Personas p ON c.id_persona = p.id_persona
                        WHERE c.id_cliente = @id_cliente";

                using (var cmd = new NpgsqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@id_cliente", clienteId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Cliente
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("id_cliente")),
                                Nombre = reader.GetString(reader.GetOrdinal("nombre")),
                                Apellido = reader.GetString(reader.GetOrdinal("apellido")),
                                Telefono = reader.GetString(reader.GetOrdinal("telefono")),
                                Correo = reader.GetString(reader.GetOrdinal("correo")),
                                FechaRegistro = reader.GetDateTime(reader.GetOrdinal("fecha_registro"))
                            };
                        }
                    }
                }
            }
            return null; // Explicitly allow null return
        }

        public List<Cliente> ObtenerClientes()
        {
            var listaClientes = new List<Cliente>();

            using (var conexion = Conexion.ObtenerConexion())
            {
                string query = @"SELECT c.id_cliente, p.nombre, p.apellido, p.telefono, p.correo, c.fecha_registro 
                         FROM Cliente c 
                         JOIN Personas p ON c.id_persona = p.id_persona";

                using (var cmd = new NpgsqlCommand(query, conexion))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var cliente = new Cliente
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("id_cliente")),
                            Nombre = reader.GetString(reader.GetOrdinal("nombre")),
                            Apellido = reader.GetString(reader.GetOrdinal("apellido")),
                            Telefono = reader.GetString(reader.GetOrdinal("telefono")),
                            Correo = reader.GetString(reader.GetOrdinal("correo")),
                            FechaRegistro = reader.GetDateTime(reader.GetOrdinal("fecha_registro"))
                        };

                        listaClientes.Add(cliente);
                    }
                }
            }

            return listaClientes;
        }
        public bool EliminarCliente(int idCliente)
        {
            using (var conexion = Conexion.ObtenerConexion())
            {
                using (var transaccion = conexion.BeginTransaction())
                {
                    try
                    {
                        //Obtener el id_persona asociado al cliente
                        int idPersona;
                        using (var cmdGetPersona = new NpgsqlCommand(
                            "SELECT id_persona FROM Cliente WHERE id_cliente = @id_cliente",
                            conexion, transaccion))
                        {
                            cmdGetPersona.Parameters.AddWithValue("@id_cliente", idCliente);
                            idPersona = Convert.ToInt32(cmdGetPersona.ExecuteScalar());
                        }

                        //Eliminar comprobantes asociados a ventas del cliente
                        using (var cmdDeleteComprobantes = new NpgsqlCommand(
                            @"DELETE FROM comprobante 
                      WHERE id_venta IN (
                          SELECT id_venta FROM Venta WHERE id_cliente = @id_cliente
                      )",
                            conexion, transaccion))
                        {
                            cmdDeleteComprobantes.Parameters.AddWithValue("@id_cliente", idCliente);
                            cmdDeleteComprobantes.ExecuteNonQuery();
                        }

                        //Eliminar detalles de venta asociados
                        using (var cmdDeleteDetallesVenta = new NpgsqlCommand(
                            @"DELETE FROM detalle_venta 
                      WHERE id_venta IN (
                          SELECT id_venta FROM Venta WHERE id_cliente = @id_cliente
                      )",
                            conexion, transaccion))
                        {
                            cmdDeleteDetallesVenta.Parameters.AddWithValue("@id_cliente", idCliente);
                            cmdDeleteDetallesVenta.ExecuteNonQuery();
                        }

                        //Eliminar las ventas del cliente
                        using (var cmdDeleteVentas = new NpgsqlCommand(
                            "DELETE FROM Venta WHERE id_cliente = @id_cliente",
                            conexion, transaccion))
                        {
                            cmdDeleteVentas.Parameters.AddWithValue("@id_cliente", idCliente);
                            cmdDeleteVentas.ExecuteNonQuery();
                        }

                        //Eliminar el registro del cliente
                        using (var cmdDeleteCliente = new NpgsqlCommand(
                            "DELETE FROM Cliente WHERE id_cliente = @id_cliente",
                            conexion, transaccion))
                        {
                            cmdDeleteCliente.Parameters.AddWithValue("@id_cliente", idCliente);
                            int filasAfectadasCliente = cmdDeleteCliente.ExecuteNonQuery();

                            if (filasAfectadasCliente == 0)
                            {
                                transaccion.Rollback();
                                return false;
                            }
                        }

                        //Eliminar la persona asociada
                        using (var cmdDeletePersona = new NpgsqlCommand(
                            "DELETE FROM Personas WHERE id_persona = @id_persona",
                            conexion, transaccion))
                        {
                            cmdDeletePersona.Parameters.AddWithValue("@id_persona", idPersona);
                            int filasAfectadasPersona = cmdDeletePersona.ExecuteNonQuery();

                            if (filasAfectadasPersona == 0)
                            {
                                transaccion.Rollback();
                                return false;
                            }
                        }

                        transaccion.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaccion.Rollback();
                        throw new Exception("Error al eliminar cliente y sus registros asociados: " + ex.Message);
                    }
                }
            }
        }
        public bool TieneVentasAsociadas(int idCliente)
        {
            using (var conexion = Conexion.ObtenerConexion())
            {
                using (var cmd = new NpgsqlCommand(
                    "SELECT COUNT(*) FROM Venta WHERE id_cliente = @id_cliente",
                    conexion))
                {
                    cmd.Parameters.AddWithValue("@id_cliente", idCliente);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        public bool ActualizarCliente(Cliente cliente)
        {
            using (var conexion = Conexion.ObtenerConexion())
            {
                using (var cmd = new NpgsqlCommand(
                    @"UPDATE Personas SET 
                nombre = @nombre, 
                apellido = @apellido,
                telefono = @telefono,
                correo = @correo
              WHERE id_persona = (
                  SELECT id_persona FROM Cliente WHERE id_cliente = @id_cliente
              )", conexion))
                {
                    cmd.Parameters.AddWithValue("@nombre", cliente.Nombre);
                    cmd.Parameters.AddWithValue("@apellido", cliente.Apellido);
                    cmd.Parameters.AddWithValue("@telefono", cliente.Telefono);
                    cmd.Parameters.AddWithValue("@correo", cliente.Correo);
                    cmd.Parameters.AddWithValue("@id_cliente", cliente.Id);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
