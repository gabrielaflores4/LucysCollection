using C_Entidades;
using C_Negocios;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;

namespace C_Presentacion
{
    public partial class VistaProductos : Form
    {
        public event Action<Producto> ProductoSeleccionado;
        private ProductoNeg productoNeg = new ProductoNeg();
        public VistaProductos()
        {
            InitializeComponent();
            CargarProductos();
        }

        public void CargarProductos()
        {
            try
            {
                string filtro = tbBusquedaProductos.Text.Trim();
                List<Producto> productos = productoNeg.ObtenerProductos();

                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    productos = productos.Where(p =>
                        p.Nombre.Contains(filtro, StringComparison.OrdinalIgnoreCase) ||
                        (p.Categoria?.Nombre?.Contains(filtro, StringComparison.OrdinalIgnoreCase) == true) ||
                        p.Precio.ToString("0.##").Contains(filtro))
                        .ToList(); // Fixed placement of .ToList()
                }

                // Configuración robusta del DataGridView
                dataGridProductos.AutoGenerateColumns = false;
                dataGridProductos.Columns.Clear();

                // Columna ID (oculta)
                dataGridProductos.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "Id_Prod",
                    HeaderText = "ID",
                    Name = "colIdProd",
                    Visible = false
                });

                // Columna Nombre
                dataGridProductos.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "Nombre",
                    HeaderText = "Producto",
                    Name = "colNombre"
                });

                // Asignar los datos
                dataGridProductos.DataSource = new BindingList<Producto>(productos);
                dataGridProductos.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarDataGrid(DataGridView dataGrid, object data, Dictionary<string, string> columnas)
        {
            dataGrid.AutoGenerateColumns = false;
            dataGrid.Columns.Clear();

            foreach (var columna in columnas)
            {
                dataGrid.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = columna.Key,
                    HeaderText = columna.Value
                });
            }

            dataGrid.DataSource = data;
        }


        private void dataGridProductos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    var producto = (Producto)dataGridProductos.Rows[e.RowIndex].DataBoundItem;

                    // Crear una nueva instancia para evitar problemas de referencia
                    var productoSeleccionado = new Producto
                    {
                        Id_Prod = producto.Id_Prod,
                        Nombre = producto.Nombre,
                        Precio = producto.Precio,
                        // Copiar otras propiedades necesarias
                    };

                    // Disparar el evento
                    ProductoSeleccionado?.Invoke(productoSeleccionado);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al seleccionar producto: {ex.Message}");
                }
            }
        }
    }
}

