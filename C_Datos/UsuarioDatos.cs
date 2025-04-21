using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_Entidades;
using C_Datos;

namespace C_Datos
{
    public class UsuarioDatos
    {
        // Método para verificar login con nombre de username y password
        public Usuario VerificarLogin(string username, string password)
        {
            using (var conexion = Conexion.ObtenerConexion())
            {
                using (var cmd = new NpgsqlCommand(
                    @"SELECT u.id_usuario, p.nombre, p.apellido, u.rol
                      FROM Usuarios u
                      INNER JOIN Personas p ON u.id_persona = p.id_persona
                      WHERE u.username = @username AND u.password = @password",
                    conexion))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Usuario(
                                reader.GetInt32(reader.GetOrdinal("id_usuario")),  // id_usuario
                                reader.GetString(reader.GetOrdinal("nombre")),    // nombre
                                reader.GetString(reader.GetOrdinal("apellido")),  // apellido
                                reader.GetString(reader.GetOrdinal("rol"))        // rol
                            );
                        }
                    }
                }
            }
            return null;  // Si las credenciales son incorrectas o no se encuentra el usuario
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

        public List<Usuario> ObtenerUsuarios()
        {
            var usuarios = new List<Usuario>();
            using (var conexion = Conexion.ObtenerConexion())
            {
                using (var cmd = new NpgsqlCommand(
                    @"SELECT p.nombre, p.apellido, p.correo, p.telefono,
                             u.id_usuario, u.rol
                      FROM Personas p
                      INNER JOIN Usuarios u ON p.id_persona = u.id_persona",
                    conexion))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            usuarios.Add(new Usuario(
                                reader.GetInt32(reader.GetOrdinal("id_usuario")),
                                reader.GetString(reader.GetOrdinal("nombre")),
                                reader.GetString(reader.GetOrdinal("apellido")),
                                reader.GetString(reader.GetOrdinal("telefono")),
                                reader.GetString(reader.GetOrdinal("correo")),
                                reader.GetString(reader.GetOrdinal("rol"))
                            ));
                        }
                    }
                }
            }
            return usuarios;
        }

        public bool EliminarUsuario(int idUsuario)
        {
            using (var conexion = Conexion.ObtenerConexion())
            {
                using (var transaction = conexion.BeginTransaction())
                {
                    try
                    {
                        // Obtener el ID de la persona asociada antes de eliminar el usuario
                        int idPersona;
                        using (var cmdPersona = new NpgsqlCommand(
                            "SELECT id_persona FROM Usuarios WHERE id_usuario = @idUsuario", conexion))
                        {
                            cmdPersona.Parameters.AddWithValue("@idUsuario", idUsuario);
                            idPersona = Convert.ToInt32(cmdPersona.ExecuteScalar());
                        }

                        // Eliminar el usuario
                        using (var cmdEliminarUsuario = new NpgsqlCommand(
                            "DELETE FROM Usuarios WHERE id_usuario = @idUsuario", conexion))
                        {
                            cmdEliminarUsuario.Parameters.AddWithValue("@idUsuario", idUsuario);
                            cmdEliminarUsuario.ExecuteNonQuery();
                        }

                        // Eliminar la persona asociada
                        using (var cmdEliminarPersona = new NpgsqlCommand(
                            "DELETE FROM Personas WHERE id_persona = @idPersona", conexion))
                        {
                            cmdEliminarPersona.Parameters.AddWithValue("@idPersona", idPersona);
                            cmdEliminarPersona.ExecuteNonQuery();
                        }

                        // Confirmar la transacción
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }

        public bool ActualizarEmpleado(int idUsuario, string nombre, string apellido, string correo, string telefono, string rol)
        {
            using (var conexion = Conexion.ObtenerConexion())
            {
                try
                {
                    int idPersona;
                    using (var cmdGetPersona = new NpgsqlCommand(
                        "SELECT id_persona FROM Usuarios WHERE id_usuario = @idUsuario", conexion))
                    {
                        cmdGetPersona.Parameters.AddWithValue("@idUsuario", idUsuario);
                        idPersona = Convert.ToInt32(cmdGetPersona.ExecuteScalar());
                    }

                    using (var cmdPersona = new NpgsqlCommand(
                        @"UPDATE Personas SET nombre = @nombre, apellido = @apellido,correo = @correo, telefono = @telefono 
                        WHERE id_persona = @idPersona", conexion))
                    {
                        cmdPersona.Parameters.AddWithValue("@idPersona", idPersona);
                        cmdPersona.Parameters.AddWithValue("@nombre", nombre);
                        cmdPersona.Parameters.AddWithValue("@apellido", apellido);
                        cmdPersona.Parameters.AddWithValue("@correo", correo);
                        cmdPersona.Parameters.AddWithValue("@telefono", telefono);
                        cmdPersona.ExecuteNonQuery();
                    }

                    using (var cmdUsuario = new NpgsqlCommand(
                        "UPDATE Usuarios SET rol = @rol WHERE id_usuario = @idUsuario", conexion))
                    {
                        cmdUsuario.Parameters.AddWithValue("@idUsuario", idUsuario);
                        cmdUsuario.Parameters.AddWithValue("@rol", rol);
                        cmdUsuario.ExecuteNonQuery();
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al actualizar empleado: {ex.Message}");
                    return false;
                }
            }
        }

        public List<Usuario> BuscarEmpleados(string texto)
        {
            List<Usuario> lista = new List<Usuario>();
            using (NpgsqlConnection conn = Conexion.ObtenerConexion())
            {
                string query = @"SELECT e.id_usuario, p.nombre, p.apellido, p.correo, p.telefono, e.rol
                         FROM usuarios e
                         JOIN personas p ON p.id_persona = e.id_persona
                         WHERE 
                            CAST(e.id_usuario AS TEXT) ILIKE @filtro OR
                            p.nombre ILIKE @filtro OR
                            p.apellido ILIKE @filtro OR
                            p.correo ILIKE @filtro OR
                            p.telefono ILIKE @filtro OR
                            e.rol ILIKE @filtro";

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@filtro", "%" + texto + "%");
                    using (NpgsqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Usuario
                            {
                                IdUsuario = Convert.ToInt32(dr[0]),
                                Nombre = dr[1].ToString(),
                                Apellido = dr[2].ToString(),
                                Correo = dr[3].ToString(),
                                Telefono = dr[4].ToString(),
                                Rol = dr[5].ToString()
                            });
                        }
                    }
                }
            }
            return lista;
        }
    }
}
