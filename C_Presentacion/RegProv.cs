using C_Entidades;
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
    public partial class RegProv : Form
    {
        private ProveedorNeg proveedorNeg;


        public RegProv()
        {
            InitializeComponent();
            proveedorNeg = new ProveedorNeg();
            ValidarCampo();
        }
        private bool EsFormularioValido()
        {
            BorrarErrorProvider();

            bool esValido = true;

            if (string.IsNullOrWhiteSpace(tbNombreProv.Text))
            {
                errorProveedores.SetError(tbNombreProv, "Ingresar nombre");
                esValido = false;
            }

            if (string.IsNullOrWhiteSpace(tbDireccionProv.Text))
            {
                errorProveedores.SetError(tbDireccionProv, "Ingresar apellido");
                esValido = false;
            }

            if (string.IsNullOrWhiteSpace(tbCorreoProv.Text) || !tbCorreoProv.Text.EndsWith("@gmail.com"))
            {
                errorProveedores.SetError(tbCorreoProv, "Correo inválido. Debe terminar en @gmail.com");
                esValido = false;
            }

            if (string.IsNullOrWhiteSpace(tbTelefonoProv.Text) || tbTelefonoProv.Text.Length != 8)
            {
                errorProveedores.SetError(tbTelefonoProv, "Teléfono debe tener 8 dígitos");
                esValido = false;
            }

            return esValido;
        }
        private void btnRegistrarProv_Click(object sender, EventArgs e)
        {
            if (!EsFormularioValido())
            {
                MessageBox.Show("Por favor, corrige los errores antes de continuar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Crear el objeto proveedor con los datos del formulario
            Proveedor proveedor = new Proveedor
            {
                NombreProv = tbNombreProv.Text,
                Direccion = tbDireccionProv.Text,
                Correo = tbCorreoProv.Text,
                Telefono = tbTelefonoProv.Text
            };

            try
            {
                bool resultado = proveedorNeg.AgregarProveedor(proveedor);

                if (resultado)
                {
                    MessageBox.Show("Proveedor creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbNombreProv.Clear();
                    tbDireccionProv.Clear();
                    tbCorreoProv.Clear();
                    tbTelefonoProv.Clear();
                }
                else
                {
                    MessageBox.Show("No se pudo crear el proveedor. Intenta de nuevo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ValidarCampo()
        {
            if (tbNombreProv.Text == "")
            {
                errorProveedores.SetError(tbNombreProv, "Ingresar nombre");
            }
            if (tbDireccionProv.Text == "")
            {
                errorProveedores.SetError(tbDireccionProv, "Ingresar Apellido");
            }
            if (tbCorreoProv.Text == "")
            {
                errorProveedores.SetError(tbCorreoProv, "Ingresar Correo");
            }
            if (tbTelefonoProv.Text == "")
            {
                errorProveedores.SetError(tbTelefonoProv, "Ingrese Telefono");
            }
            return;
        }

        private void BorrarErrorProvider()
        {
            errorProveedores.SetError(tbNombreProv, "");
            errorProveedores.SetError(tbDireccionProv, "");
            errorProveedores.SetError(tbCorreoProv, "");
            errorProveedores.SetError(tbTelefonoProv, "");

        }

        private void tbNombreProv_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloLetras(e);
        }

        private void tbDireccionProv_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.LetrasYNumeros(e);
        }

        private void tbCorreoProv_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.ParaCorreo(e, tbCorreoProv);
        }

        private void tbTelefonoProv_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.ParaTelefono(e, tbTelefonoProv);
        }

        private void btnCancelarProveedor_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
