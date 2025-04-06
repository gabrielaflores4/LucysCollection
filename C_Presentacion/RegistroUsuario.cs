using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using C_Negocios;

namespace C_Presentacion
{
    public partial class RegistroUsuario : Form
    {
        private UsuarioNeg usuarioNegocio;
        public RegistroUsuario()
        {
            InitializeComponent();
            usuarioNegocio = new UsuarioNeg();
        }

        private void lblDashboard_Click(object sender, EventArgs e)
        {

        }

        private void btnRegistrarUsuarios_Click(object sender, EventArgs e)
        {
            // Obtener datos del formulario
            string nombre = tbNombreUser.Text;
            string apellido = tbApellidoUser.Text;
            string correo = tbCorreoUser.Text;
            string telefono = tbTelefonoUser.Text;
            string usuario = tbUsername.Text;
            string password = tbPassword.Text;
            string rol = cbRol.Text;

            try
            {
                // Crear una instancia de UsuarioNeg
                UsuarioNeg usuarioNeg = new UsuarioNeg();

                // Llamar al método CrearUsuario de UsuarioNeg para crear el usuario
                int idUsuario = usuarioNeg.CrearUsuario(nombre, apellido, telefono, correo, usuario, password, rol);

                MessageBox.Show($"Usuario creado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar campos después de registrar
                tbNombreUser.Clear();
                tbApellidoUser.Clear();
                tbCorreoUser.Clear();
                tbTelefonoUser.Clear();
                tbUsername.Clear();
                tbPassword.Clear();
                cbRol.SelectedIndex = -1;
            }
            catch (Exception)
            {
                MessageBox.Show("Error al registrar usuario: ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RegistroUsuario_Load(object sender, EventArgs e)
        {

        }

        private void tbNombreUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloLetras(e);
        }

        private void tbApellidoUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloLetras(e);
        }

        private void tbCorreoUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.ParaCorreo(e, tbCorreoUser);
        }

        private void tbTelefonoUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.ParaTelefono(e, tbTelefonoUser);
        }

        private void tbUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.LetrasYNumeros(e);
        }

        private void tbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.LetrasYNumeros(e);
        }
    }
}
