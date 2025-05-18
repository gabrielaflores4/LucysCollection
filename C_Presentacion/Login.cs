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
            this.AcceptButton = btnLogin;
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = tbUsername.Text;
            string password = tbPassword.Text;

            if (usuarioNegocio.VerificarLogin(usuario, password))
            {
                Usuario? usuarioLogueado = Sesion.UsuarioActivo;

                if (usuarioLogueado != null)
                {
                    Inicio inicio = new Inicio();
                    inicio.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Error: No se pudo obtener el usuario activo.");
                }
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
            }
        }

        private void tbUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloLetras(e);
        }

        private void tbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.LetrasYNumeros(e);
        }
    }
}
