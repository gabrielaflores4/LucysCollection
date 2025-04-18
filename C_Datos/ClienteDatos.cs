using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_Entidades;

namespace C_Datos
{
    public class ClienteDatos
    {
        

        // Método para crear un Cliente
        public int CrearCliente(string nombre, string apellido, string correo,string telefono, DateTime fechaRegistro)
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
    }

}
