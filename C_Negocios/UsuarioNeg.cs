using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_Datos;
using C_Entidades;
using Npgsql;

namespace C_Negocios
{

    public class UsuarioNeg
    {
        private UsuarioDatos usuarioDatos;
        private Hash hash;
        private UsuarioDatos _usuarioDatos = new UsuarioDatos();

        // Constructor que inicializa las clases necesarias
        public UsuarioNeg()
        {
            usuarioDatos = new UsuarioDatos();
            hash = new Hash();
        }

        // Método para verificar el login de un usuario
        public Usuario VerificarLogin(string usuario, string contraseña)
        {
            string passwordHash = hash.HashContraseña(contraseña);
            return usuarioDatos.VerificarLogin(usuario, passwordHash);
        }

        public int CrearUsuario(string nombre, string apellido, string telefono, string correo, string username, string contraseña, string rol)
        {
            // Hash de la contraseña proporcionada
            string passwordHash = hash.HashContraseña(contraseña);

            // Llamar a la clase de datos para crear el usuario
            return usuarioDatos.CrearUsuario(nombre, apellido, telefono, correo, username, passwordHash, rol);
        }

        public List<Usuario> ObtenerUsuarios()
        {
            return _usuarioDatos.ObtenerUsuarios();
        }


        public bool EliminarUsuario(int id)
        {
            return usuarioDatos.EliminarUsuario(id);
        }


        public bool ActualizarEmpleado(int id, string nombre, string apellido, string correo, string telefono, string rol)
        {
            using (var conexion = Conexion.ObtenerConexion())
            {
                using (var transaction = conexion.BeginTransaction())
                {
                    try
                    {
                        // Actualizar los datos en la tabla Personas
                        using (var cmdPersona = new NpgsqlCommand(
                            "UPDATE Personas SET nombre = @nombre, apellido = @apellido, correo = @correo, telefono = @telefono WHERE id_persona = @id;",
                            conexion))
                        {
                            cmdPersona.Parameters.AddWithValue("@id", id);
                            cmdPersona.Parameters.AddWithValue("@nombre", nombre);
                            cmdPersona.Parameters.AddWithValue("@apellido", apellido);
                            cmdPersona.Parameters.AddWithValue("@correo", correo);
                            cmdPersona.Parameters.AddWithValue("@telefono", telefono);
                            cmdPersona.ExecuteNonQuery();
                        }

                        // Actualizar el rol en la tabla Usuarios
                        using (var cmdUsuario = new NpgsqlCommand(
                            "UPDATE Usuarios SET rol = @rol WHERE id_persona = @id;",
                            conexion))
                        {
                            cmdUsuario.Parameters.AddWithValue("@id", id);
                            cmdUsuario.Parameters.AddWithValue("@rol", rol);
                            cmdUsuario.ExecuteNonQuery();
                        }

                        // Confirmar la transacción
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        // Revertir si hay error
                        transaction.Rollback();
                        Console.WriteLine("Error al actualizar el empleado: " + ex.Message);
                        return false;
                    }
                }
            }
        }
    }
}