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

            if (usuarioNegocio.VerificarLogin(usuario, password))
            {
                // Si el login es exitoso, muestra el formulario principal
                Inicio formInicio = new Inicio();
                formInicio.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o Contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
