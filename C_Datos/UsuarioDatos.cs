using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_Entidades;

namespace C_Datos
{
    public class UsuarioDatos
    {
        // Método para verificar login con nombre de username y password
        public bool VerificarLogin(string username, string password)
        {
            using (var conexion = Conexion.ObtenerConexion())
            {
                using (var cmd = new NpgsqlCommand(
                    "SELECT COUNT(1) FROM usuarios WHERE username = @username AND password = @password",
                    conexion))
                {
                    cmd.Parameters.AddWithValue("@username", username);  // Buscar por username
                    cmd.Parameters.AddWithValue("@password", password);  // Verificar password

                    return Convert.ToInt32(cmd.ExecuteScalar()) == 1;  // Retorna true si el username y password son correctos
                }
            }
        }

        // Método para crear un usuario
        public int CrearUsuario(string nombre, string apellido, string telefono, string correo, string username, string password, string rol)
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

                        //Insertar en la tabla Usuarios
                        int idUsuario;
                        using (var cmdUsuario = new NpgsqlCommand(
                            @"INSERT INTO Usuarios (id_persona, username, password, rol) VALUES (@id_persona, @username, @password, @rol) RETURNING id_usuario",
                            conexion))
                        {
                            cmdUsuario.Parameters.AddWithValue("@id_persona", idPersona);
                            cmdUsuario.Parameters.AddWithValue("@username", username);
                            cmdUsuario.Parameters.AddWithValue("@password", password);
                            cmdUsuario.Parameters.AddWithValue("@rol", rol);

                            idUsuario = Convert.ToInt32(cmdUsuario.ExecuteScalar()); // Obtener el ID del usuario
                        }

                        transaccion.Commit(); 
                        return idUsuario;
                    }
                    catch
                    {
                        transaccion.Rollback(); 
                        throw;
                    }
                }
            }
        }



    }
}
