using C_Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_Presentacion
{
    public partial class FrmRegClientes : Form
    {
        private ClienteNeg clienteNeg;
        public FrmRegClientes()
        {
            InitializeComponent();
            clienteNeg = new ClienteNeg();
            ValidarCampo();

        }
        private bool EsFormularioValido()
        {
            BorrarErrorProvider(); // Limpiar errores antes

            bool esValido = true;

            if (string.IsNullOrWhiteSpace(tbNombreClien.Text))
            {
                errorIconoClientes.SetError(tbNombreClien, "Ingresar nombre");
                esValido = false;
            }

            if (string.IsNullOrWhiteSpace(tbApellidoCliente.Text))
            {
                errorIconoClientes.SetError(tbApellidoCliente, "Ingresar apellido");
                esValido = false;
            }

            if (string.IsNullOrWhiteSpace(tbCorreoCliente.Text) || !tbCorreoCliente.Text.EndsWith("@gmail.com"))
            {
                errorIconoClientes.SetError(tbCorreoCliente, "Correo inválido. Debe terminar en @gmail.com");
                esValido = false;
            }

            if (string.IsNullOrWhiteSpace(tbTelefonoCliente.Text) || tbTelefonoCliente.Text.Length != 8)
            {
                errorIconoClientes.SetError(tbTelefonoCliente, "Teléfono debe tener 8 dígitos");
                esValido = false;
            }

            return esValido;
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
                    MessageBox.Show($"Usuario creado exitosamente. ID: {idCliente}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbNombreClien.Clear();
                    tbApellidoCliente.Clear();
                    tbCorreoCliente.Clear();
                    tbTelefonoCliente.Clear();
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
    }
}
