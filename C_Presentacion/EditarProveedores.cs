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
    public partial class EditarProveedores : Form
    {
        public int ProveedorId { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }

        private Inicio _formInicio;

        public EditarProveedores()
        {
            InitializeComponent();
        }

        public EditarProveedores(Inicio formInicio)
        {
            InitializeComponent();
            _formInicio = formInicio;
        }

        private void EditarProveedores_Load(object sender, EventArgs e)
        {
            tbNombreProvAct.Text = this.Nombre;
            tbTelProvAct.Text = this.Telefono;
            tbCorreoProvAct.Text = this.Correo;
            tbDirecProvAct.Text = this.Direccion;
        }

        private void btnGuardarActProv_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                this.Nombre = tbNombreProvAct.Text;
                this.Telefono = tbTelProvAct.Text;
                this.Correo = tbCorreoProvAct.Text;
                this.Direccion = tbCorreoProvAct.Text;

                this.DialogResult = DialogResult.OK;
                this.Close();
                MessageBox.Show("Proveedor actualizado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Error al actualizar el proveedor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(tbNombreProvAct.Text))
            {
                MessageBox.Show("El nombre es obligatorio", "Error",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnCancelarActProv_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
