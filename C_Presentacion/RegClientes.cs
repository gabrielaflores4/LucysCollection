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
        }

        private void btnRegistraCliente_Click(object sender, EventArgs e)
        {
            string nombre = tbNombreClien.Text;
            string apellido = tbApellidoCliente.Text;
            string correo = tbCorreoCliente.Text;
            string telefono = tbTelefonoCliente.Text;

            try
            {
                // Crear una instancia de ClienteNeg
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
    }
}
