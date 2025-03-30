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

    }

}
