using C_Datos;
using C_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Negocios
{
    public static class Sesion
    {
        public static Usuario UsuarioActivo { get; private set; }

        // Inicia la sesión con el usuario
        public static void IniciarSesion(Usuario usuario)
        {
            UsuarioActivo = usuario;
        }

        // Cierra la sesión (puedes limpiar la referencia)
        public static void CerrarSesion()
        {
            UsuarioActivo = null;
        }

        // Verifica si el usuario está logueado
        public static bool EstaLogueado()
        {
            return UsuarioActivo != null;
        }

        // Verifica si el usuario tiene el rol indicado
        public static bool TieneRol(string rol)
        {
            return UsuarioActivo != null && UsuarioActivo.Rol == rol;
        }
    }
}
