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
    public partial class EditarEmpleados : Form
    {
        public int EmpleadoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Rol { get; set; }

        private Inicio formInicio;

        public EditarEmpleados(Inicio inicio)
        {
            InitializeComponent();
            this.formInicio = inicio;
        }

        public EditarEmpleados()
        {
            InitializeComponent();
        }

        private void EditarEmpleados_Load(object sender, EventArgs e)
        {
            tbNombreEmpAct.Text = Nombre;   
            tbApellidoEmpAct.Text = Apellido;
            tbCorreoEmpAct.Text = Correo;
            tbTelefonoEmpAct.Text = Telefono;
            cbRolEmpAct.SelectedItem = Rol;
        }

        private void btnGuardarActEmp_Click(object sender, EventArgs e)
        {
            Nombre = tbNombreEmpAct.Text;
            Apellido = tbApellidoEmpAct.Text;
            Correo = tbCorreoEmpAct.Text;
            Telefono = tbTelefonoEmpAct.Text;
            Rol = cbRolEmpAct.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelarActEmp_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
