using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_Datos;

namespace C_Negocios
{
    public class UsuarioNeg
    {
        private UsuarioDatos usuarioDatos;
        private Hash hash;

        // Constructor que inicializa las clases necesarias
        public UsuarioNeg()
        {
            usuarioDatos = new UsuarioDatos();
            hash = new Hash();
        }

        // Método para verificar el login de un usuario
        public bool VerificarLogin(string usuario, string contraseña)
        {
            // Hash de la contraseña proporcionada
            string passwordHash = hash.HashContraseña(contraseña);

            // Llamar a la clase de datos para verificar el login
            return usuarioDatos.VerificarLogin(usuario, passwordHash);
        }

        public int CrearUsuario(string nombre, string apellido, string telefono, string correo, string username, string contraseña, string rol)
        {
            // Hash de la contraseña proporcionada
            string passwordHash = hash.HashContraseña(contraseña);

            // Llamar a la clase de datos para crear el usuario
            return usuarioDatos.CrearUsuario(nombre, apellido, telefono, correo, username, passwordHash, rol);
        }
    }
}
