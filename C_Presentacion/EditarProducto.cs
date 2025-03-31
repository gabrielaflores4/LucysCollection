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
    public partial class EditarProducto : Form
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public int Talla { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public int CategoriaId { get; set; }

        private Inicio formInicio;

        public EditarProducto(Inicio inicio)
        {
            InitializeComponent();
            this.formInicio = inicio;
        }

        public EditarProducto()
        {
            InitializeComponent();
        }

        private void EditarProducto_Load(object sender, EventArgs e)
        {
            // Cargar valores 
            tbNombreProdAct.Text = Nombre;
            cbTallasRegAct.SelectedItem = Talla.ToString();
            tbPrecioRegAct.Text = Precio.ToString();
            nbCantidad.Value = Stock;

            // Cargar categorías
            var categoriaNeg = new CategoriaNeg();
            cbCategoriaAct.DataSource = categoriaNeg.ObtenerCategorias();
            cbCategoriaAct.DisplayMember = "Nombre";
            cbCategoriaAct.ValueMember = "Id";
            cbCategoriaAct.SelectedValue = CategoriaId;
        }

        private void btnGuardarActProd_Click(object sender, EventArgs e)
        {
            Nombre = tbNombreProdAct.Text;
            Talla = Convert.ToInt32(cbTallasRegAct.SelectedItem);
            Precio = decimal.Parse(tbPrecioRegAct.Text);
            Stock = Convert.ToInt32(nbCantidad.Value);
            CategoriaId = Convert.ToInt32(cbCategoriaAct.SelectedValue);

            this.DialogResult = DialogResult.OK;
            formInicio.CargarProductos();
            this.Close();
        }

        private void btnCancelarActProd_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
