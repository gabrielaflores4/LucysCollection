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
        public bool VerificarLogin(string usuario, string contraseña)
        {
            string passwordHash = hash.HashContraseña(contraseña);
            Usuario usuarioLogueado = usuarioDatos.VerificarLogin(usuario, passwordHash);

            if (usuarioLogueado != null)
            {
                Sesion.IniciarSesion(usuarioLogueado); 
                return true;
            }
            else
            {
                Sesion.CerrarSesion(); 
                return false;
            }
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
            try
            {
                return usuarioDatos.ActualizarEmpleado(id, nombre, apellido, correo, telefono, rol);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar empleado: {ex.Message}");
                return false;
            }
        }


        public List<Usuario> BuscarEmpleados(string texto)
        {
            return usuarioDatos.BuscarEmpleados(texto);
        }
    }
}