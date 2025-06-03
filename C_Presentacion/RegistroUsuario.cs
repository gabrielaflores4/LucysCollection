using System.Data;
using C_Negocios;

namespace C_Presentacion
{
    public partial class RegistroUsuario : Form
    {
        private UsuarioNeg usuarioNegocio;
        private Inicio _formInicio;

        public RegistroUsuario(Inicio formInicio)
        {
            InitializeComponent();
            usuarioNegocio = new UsuarioNeg();
            _formInicio = formInicio;
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
            // Validar el formulario completo
            if (!EsFormularioValido())
            {
                MessageBox.Show("Por favor complete todos los campos correctamente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Limpieza y validación del teléfono
            string telefono = new string(tbTelefonoUser.Text.Where(char.IsDigit).ToArray());

            if (telefono.Length != 8)
            {
                errorIconoUsuarios.SetError(tbTelefonoUser, "Debe tener 8 dígitos exactos");
                MessageBox.Show("El teléfono debe contener exactamente 8 dígitos numéricos", "Error en teléfono", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbTelefonoUser.Focus();
                return;
            }

            try
            {
                // Registrar el usuario
                int idUsuario = usuarioNegocio.CrearUsuario(
                    tbNombreUser.Text.Trim(),
                    tbApellidoUser.Text.Trim(),
                    telefono,
                    tbCorreoUser.Text.Trim(),
                    tbUsername.Text.Trim(),
                    tbPassword.Text,
                    cbRol.SelectedItem?.ToString() ?? string.Empty
                );

                if (idUsuario > 0)
                {
                    MessageBox.Show($"Usuario registrado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimpiarFormulario();

                    if (_formInicio != null)
                    {
                        _formInicio.CargarEmpleados();
                    }

                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo crear el usuario. Por favor intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (ArgumentException ex)
            {
                // Manejo específico para errores de validación
                MessageBox.Show(ex.Message, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Npgsql.PostgresException ex) when (ex.SqlState == "23505")
            {
                MessageBox.Show("El nombre de usuario o correo ya existe",
                              "Error de duplicado",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); Console.WriteLine($"Error al registrar usuario: {ex}");
            }
        }

        private void LimpiarFormulario()
        {
            // Limpiar campos
            tbNombreUser.Clear();
            tbApellidoUser.Clear();
            tbCorreoUser.Clear();
            tbTelefonoUser.Clear();
            tbUsername.Clear();
            tbPassword.Clear();
            cbRol.SelectedIndex = -1;
            BorrarErrorProvider();
            tbNombreUser.Focus();
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Estás seguro que deseas cancelar?",
                "Confirmar cancelación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );      

            if (resultado == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
