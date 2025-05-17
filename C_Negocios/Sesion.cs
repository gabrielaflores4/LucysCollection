using C_Entidades;

namespace C_Negocios
{
    public static class Sesion
    {
        public static Usuario? UsuarioActivo { get; private set; }

        public static void IniciarSesion(Usuario usuario)
        {
            UsuarioActivo = usuario;
        }

        public static void CerrarSesion()
        {
            UsuarioActivo = null;
        }

        public static bool EstaLogueado()
        {
            return UsuarioActivo != null;
        }

        public static bool TieneRol(string rol)
        {
            return UsuarioActivo != null && UsuarioActivo.Rol == rol;
        }
    }
}
