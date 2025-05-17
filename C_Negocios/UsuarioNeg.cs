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

        public int CrearUsuario(string nombre, string apellido, string telefono, string correo,
                              string username, string contraseña, string rol)
        {
            // Validaciones de parámetros
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre no puede estar vacío", nameof(nombre));

            if (string.IsNullOrWhiteSpace(apellido))
                throw new ArgumentException("El apellido no puede estar vacío", nameof(apellido));

            if (string.IsNullOrWhiteSpace(telefono) || telefono.Length != 8 || !telefono.All(char.IsDigit))
                throw new ArgumentException("El teléfono debe tener exactamente 8 dígitos", nameof(telefono));

            if (string.IsNullOrWhiteSpace(correo) || !correo.Contains("@"))
                throw new ArgumentException("El correo no es válido", nameof(correo));

            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("El nombre de usuario no puede estar vacío", nameof(username));

            if (string.IsNullOrWhiteSpace(contraseña) || contraseña.Length < 6)
                throw new ArgumentException("La contraseña debe tener al menos 6 caracteres", nameof(contraseña));

            if (string.IsNullOrWhiteSpace(rol))
                throw new ArgumentException("Debe seleccionar un rol", nameof(rol));

            try
            {
                string passwordHash = hash.HashContraseña(contraseña);
                return _usuarioDatos.CrearUsuario(nombre, apellido, telefono, correo, username, passwordHash, rol);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear usuario: {ex.Message}");
                throw; 
            }
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