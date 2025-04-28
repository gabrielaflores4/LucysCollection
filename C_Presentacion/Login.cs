using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using C_Entidades;
using C_Negocios;

namespace C_Presentacion
{
    public partial class Login : Form
    {
        private UsuarioNeg usuarioNegocio;


        public Login()
        {
            InitializeComponent();
            usuarioNegocio = new UsuarioNeg();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = tbUsername.Text;
            string password = tbPassword.Text;

            // Verificar las credenciales
            Usuario usuarioActivo = usuarioNegocio.VerificarLogin(usuario, password);

            if (usuarioActivo != null)
            {
                // Iniciar sesión con el usuario
                Sesion.IniciarSesion(usuarioActivo);

                // Crear el formulario principal (Inicio)
                Inicio formInicio = new Inicio();

                // Pasar la información del usuario al formulario Inicio
                formInicio.ActualizarInfoUsuario(usuarioActivo);
                formInicio.AplicarPermisosPorRol();

                // Mostrar el formulario principal y ocultar el login
                formInicio.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o Contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validaciones.LetrasYNumeros(e);
        }

        private void tbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validaciones.LetrasYNumeros(e);
        }
    }
}
