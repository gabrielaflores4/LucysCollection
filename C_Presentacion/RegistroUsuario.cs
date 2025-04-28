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

        private bool EsFormularioValido()
        {
            BorrarErrorProvider(); 

            bool esValido = true;

            if (string.IsNullOrWhiteSpace(tbNombreUser.Text))
            {
                errorIconoUsuarios.SetError(tbNombreUser, "Ingresar nombre");
                esValido = false;
            }

            if (string.IsNullOrWhiteSpace(tbApellidoUser.Text))
            {
                errorIconoUsuarios.SetError(tbApellidoUser, "Ingresar apellido");
                esValido = false;
            }

            if (string.IsNullOrWhiteSpace(tbCorreoUser.Text) || !tbCorreoUser.Text.EndsWith("@gmail.com"))
            {
                errorIconoUsuarios.SetError(tbCorreoUser, "Correo inválido. Debe terminar en @gmail.com");
                esValido = false;
            }

            if (string.IsNullOrWhiteSpace(tbTelefonoUser.Text) || tbTelefonoUser.Text.Length != 8)
            {
                errorIconoUsuarios.SetError(tbTelefonoUser, "Teléfono debe tener 8 dígitos");
                esValido = false;
            }

            if (string.IsNullOrWhiteSpace(tbUsername.Text))
            {
                errorIconoUsuarios.SetError(tbUsername, "Ingresar nombre de usuario");
                esValido = false;
            }

            if (string.IsNullOrWhiteSpace(tbPassword.Text))
            {
                errorIconoUsuarios.SetError(tbPassword, "Ingresar contraseña");
                esValido = false;
            }

            if (cbRol.SelectedIndex == -1) 
            {
                errorIconoUsuarios.SetError(cbRol, "Seleccionar un rol");
                esValido = false;
            }

            return esValido;
        }

        private void BorrarErrorProvider()
        {
            errorIconoUsuarios.SetError(tbNombreUser, "");
            errorIconoUsuarios.SetError(tbApellidoUser, "");
            errorIconoUsuarios.SetError(tbCorreoUser, "");
            errorIconoUsuarios.SetError(tbTelefonoUser, "");
            errorIconoUsuarios.SetError(tbUsername, "");
            errorIconoUsuarios.SetError(tbPassword, "");

        }
        private void btnRegistrarUsuarios_Click(object sender, EventArgs e)
        {
            if (!EsFormularioValido())
            {
                MessageBox.Show("Por favor, corrige los errores antes de continuar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string nombre = tbNombreUser.Text;
            string apellido = tbApellidoUser.Text;
            string correo = tbCorreoUser.Text;
            string telefono = tbTelefonoUser.Text;
            string username = tbUsername.Text;
            string contraseña = tbPassword.Text;


            try
            {
                int idUsuario = usuarioNegocio.CrearUsuario(nombre, apellido, correo, telefono, correo, username, contraseña);

                if (idUsuario > 0)
                {
                    MessageBox.Show($"Usuario creado exitosamente. ID: {idUsuario}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbNombreUser.Clear();
                    tbApellidoUser.Clear();
                    tbCorreoUser.Clear();
                    tbTelefonoUser.Clear();
                    tbUsername.Clear();
                    tbPassword.Clear();
                }
                else
                {
                    MessageBox.Show("No se pudo crear el cliente. Intenta de nuevo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                // Crear una instancia de UsuarioNeg
                UsuarioNeg usuarioNeg = new UsuarioNeg();

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
            Validaciones.SoloLetras(e);
        }

        private void tbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.LetrasYNumeros(e);
        }
    }
}
