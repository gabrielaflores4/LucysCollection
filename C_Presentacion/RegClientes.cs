using C_Negocios;

namespace C_Presentacion
{
    public partial class FrmRegClientes : Form
    {
        private ClienteNeg clienteNeg;
        public int ClienteRegistradoId { get; private set; }
        public FrmRegClientes()
        {
            InitializeComponent();
            clienteNeg = new ClienteNeg();
            ValidarCampo();
            ClienteRegistradoId = 0;

        }
        private bool EsFormularioValido()
        {
            bool esValido = true;

            // Limpiar todos los errores primero
            errorIconoClientes.Clear();

            // Validar cada campo individualmente
            esValido &= ValidarNombre();
            esValido &= ValidarApellido();
            esValido &= ValidarCorreo();
            esValido &= ValidarTelefono();

            return esValido;
        }

        private bool ValidarNombre()
        {
            if (string.IsNullOrWhiteSpace(tbNombreClien.Text))
            {
                errorIconoClientes.SetError(tbNombreClien, "Ingresar nombre");
                return false;
            }
            return true;
        }

        private bool ValidarApellido()
        {
            if (string.IsNullOrWhiteSpace(tbApellidoCliente.Text))
            {
                errorIconoClientes.SetError(tbApellidoCliente, "Ingresar apellido");
                return false;
            }
            return true;
        }

        private bool ValidarCorreo()
        {
            if (string.IsNullOrWhiteSpace(tbCorreoCliente.Text) || !tbCorreoCliente.Text.EndsWith("@gmail.com"))
            {
                errorIconoClientes.SetError(tbCorreoCliente, "Correo inválido. Debe terminar en @gmail.com");
                return false;
            }
            return true;
        }

        private bool ValidarTelefono()
        {
            if (string.IsNullOrWhiteSpace(tbTelefonoCliente.Text) || tbTelefonoCliente.Text.Length != 8)
            {
                errorIconoClientes.SetError(tbTelefonoCliente, "Teléfono debe tener 8 dígitos");
                return false;
            }
            return true;
        }


        private void btnRegistraCliente_Click(object sender, EventArgs e)
        {

            if (!EsFormularioValido())
            {
                MessageBox.Show("Por favor, corrige los errores antes de continuar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string nombre = tbNombreClien.Text;
            string apellido = tbApellidoCliente.Text;
            string correo = tbCorreoCliente.Text;
            string telefono = tbTelefonoCliente.Text;

            try
            {
                int idCliente = clienteNeg.CrearCliente(nombre, apellido, correo, telefono, DateTime.Now);

                if (idCliente > 0)
                {
                    ClienteRegistradoId = idCliente;
                    MessageBox.Show($"Usuario creado exitosamente. ID: {idCliente}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    tbNombreClien.Clear();
                    tbApellidoCliente.Clear();
                    tbCorreoCliente.Clear();
                    tbTelefonoCliente.Clear();
                    this.Close();
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
        }
        private void ValidarCampo()
        {
            bool ok = true;

            if (tbNombreClien.Text == "")
            {
                ok = false;
                errorIconoClientes.SetError(tbNombreClien, "Ingresar nombre");
            }
            if (tbApellidoCliente.Text == "")
            {
                ok = false;
                errorIconoClientes.SetError(tbApellidoCliente, "Ingresar Apellido");
            }
            if (tbCorreoCliente.Text == "")
            {
                ok = false;
                errorIconoClientes.SetError(tbCorreoCliente, "Ingresar Correo");
            }
            if (tbTelefonoCliente.Text == "")
            {
                ok = false;
                errorIconoClientes.SetError(tbTelefonoCliente, "Ingrese Telefono");
            }
            return;
        }

        private void BorrarErrorProvider()
        {
            errorIconoClientes.SetError(tbNombreClien, "");
            errorIconoClientes.SetError(tbApellidoCliente, "");
            errorIconoClientes.SetError(tbCorreoCliente, "");
            errorIconoClientes.SetError(tbTelefonoCliente, "");


        }

        private void tbNombreClien_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloLetras(e);
        }

        private void tbCorreoCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.ParaCorreo(e, tbCorreoCliente);

        }

        private void tbApellidoCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloLetras(e);

        }

        private void tbTelefonoCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.ParaTelefono(e, tbTelefonoCliente);

        }

        private void btnCancelarCli_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BorrarMensajesError()
        {
            errorIconoClientes.Clear();
        }

    }
}
