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
    public partial class Inicio : Form
    {
        private ProductoNeg productoNeg = new ProductoNeg();
        public Inicio()
        {
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {

        }

        private void ConfigurarDataGrid(DataGridView dataGrid, object data, Dictionary<string, string> columnas)
        {
            dataGrid.AutoGenerateColumns = false;
            dataGrid.Columns.Clear();

            foreach (var columna in columnas)
            {
                dataGrid.Columns.Add(new DataGridViewTextBoxColumn
                {
                    // Nombre de la propiedad en la clase
                    DataPropertyName = columna.Key,
                    // Nombre de la propiedad en la clase
                    HeaderText = columna.Value
                });
            }

            dataGrid.DataSource = data;
        }

        public void CargarProductos()
        {
            var productos = productoNeg.ObtenerProductos();
            var columnas = new Dictionary<string, string>
            {
                { "Id_Prod", "Id_Prod" },
                { "Nombre", "Producto" },
                { "Talla", "Talla" },
                { "Stock", "Stock" },
                { "Categoria", "Categoría" },
                { "Precio", "Precio" }
            };

            var productosConCategoria = productos.Select(p => new
            {
                p.Id_Prod,
                p.Nombre,
                p.Talla,
                p.Stock,
                Categoria = p.Categoria.Nombre,
                p.Precio,
            }).ToList();

            ConfigurarDataGrid(dataGridInventarioProducto, productosConCategoria, columnas);
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            tabControlInicio.SelectedTab = tabInventario;
            CargarProductos();

        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            tabControlInicio.SelectedTab = tabEmpleados;
        }

        private void btnMateriaPrima_Click(object sender, EventArgs e)
        {
            tabControlInicio.SelectedTab = tabMateriaP;
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            tabControlInicio.SelectedTab = tabProveedores;
        }

        private void lblDashboard_Click(object sender, EventArgs e)
        {
            tabControlInicio.SelectedTab = tabInicio;
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            Ventas frmVenta = new Ventas();
            frmVenta.Show();
        }

        private void btnAgregarInventario_Click(object sender, EventArgs e)
        {
            RegProd frmRegProducto = new RegProd();
            frmRegProducto.Show();
        }

        private void btnAgregarEmpleados_Click(object sender, EventArgs e)
        {
            RegistroUsuario frmRegUsuarios = new RegistroUsuario();
            frmRegUsuarios.Show();
        }

        private void btnAgregarProv_Click(object sender, EventArgs e)
        {
            RegProv frmRegProv = new RegProv();
            frmRegProv.Show();
        }

        private void btnAgregarMateriaP_Click(object sender, EventArgs e)
        {
            RegMP frmRegMP = new RegMP();
            frmRegMP.Show();
        }

        private void btnEliminarInventario_Click(object sender, EventArgs e)
        {
            if (dataGridInventarioProducto.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una fila antes de eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Obtenemos la primera fila seleccionada
                DataGridViewRow fila = dataGridInventarioProducto.SelectedRows[0];
                int id = Convert.ToInt32(fila.Cells[0].Value);
                string nombreProducto = fila.Cells[1].Value.ToString();

                // Mostramos confirmación con más información
                DialogResult resultado = MessageBox.Show(
                    $"¿Desea eliminar el producto: {nombreProducto}?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    if (productoNeg.EliminarProducto(id))
                    {
                        MessageBox.Show($"Producto '{nombreProducto}' eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarProductos(); 
                    }
                    else
                    {
                        MessageBox.Show($"No se pudo eliminar el producto '{nombreProducto}'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridInventarioProducto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Obtener la fila seleccionada
            DataGridViewRow fila = dataGridInventarioProducto.Rows[e.RowIndex];

            // Obtener los valores actuales
            int id = Convert.ToInt32(fila.Cells[0].Value);
            string nombre = fila.Cells[1].Value?.ToString();
            int talla = Convert.ToInt32(fila.Cells[2].Value);
            int stock = Convert.ToInt32(fila.Cells[3].Value);
            string categoriaNombre = fila.Cells[4].Value?.ToString();
            decimal precio = Convert.ToDecimal(fila.Cells[5].Value);

            // Obtener el ID de la categoría (necesitarás implementar este método)
            int categoriaId = productoNeg.ObtenerCategoriaIdPorNombre(categoriaNombre);

            // Crear y mostrar formulario de edición
            using (var formEdicion = new EditarProducto(this))
            {
                // Configurar los valores actuales en el formulario
                formEdicion.ProductoId = id;
                formEdicion.Nombre = nombre;
                formEdicion.Talla = talla;
                formEdicion.Precio = precio;
                formEdicion.Stock = stock;
                formEdicion.CategoriaId = categoriaId;

                if (formEdicion.ShowDialog() == DialogResult.OK)
                {
                    // Actualizar el producto si el usuario guardó los cambios
                    if (productoNeg.ActualizarProducto(
                        formEdicion.ProductoId,
                        formEdicion.Nombre,
                        formEdicion.Talla,
                        formEdicion.Precio,
                        formEdicion.Stock,
                        formEdicion.CategoriaId))
                    {
                        MessageBox.Show("Producto actualizado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarProductos();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el producto", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
