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
                        .ToList();
                }

                // Configuración del DataGridView
                dataGridProductos.AutoGenerateColumns = false;
                dataGridProductos.Columns.Clear();

                dataGridProductos.Columns.Add("Id_Prod", "ID");
                dataGridProductos.Columns["Id_Prod"].Visible = false; 

                dataGridProductos.Columns.Add("Nombre", "Nombre");
                dataGridProductos.Columns.Add("Categoria", "Categoría");
                dataGridProductos.Columns.Add("Precio", "Precio");

                // Formatear columna de precio
                dataGridProductos.Columns["Precio"].DefaultCellStyle.Format = "C2";
                dataGridProductos.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                // Llenar el DataGridView
                foreach (var producto in productos)
                {
                    dataGridProductos.Rows.Add(
                        producto.Id_Prod, 
                        producto.Nombre,
                        producto.Categoria?.Nombre ?? "Sin categoría",
                        producto.Precio
                    );
                }
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

        private void dataGridProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Validar índice de fila
            if (e.RowIndex < 0 || e.RowIndex >= dataGridProductos.Rows.Count)
                return;

            // Obtener la fila
            var row = dataGridProductos.Rows[e.RowIndex];

            // Validar que no sea fila nueva
            if (row.IsNewRow) return;

            try
            {
                // Crear nuevo producto
                var producto = new Producto();

                // ID 
                if (row.Cells[0].Value != null && int.TryParse(row.Cells[0].Value.ToString(), out int id))
                {
                    producto.Id_Prod = id;
                }
                else
                {
                    MessageBox.Show("El ID del producto no es válido", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Nombre 
                producto.Nombre = row.Cells[1].Value?.ToString() ?? string.Empty;

                // Categoría 
                if (row.Cells[2].Value != null)
                {
                    producto.Categoria = new Categoria
                    {
                        Nombre = row.Cells[2].Value.ToString()
                    };
                }

                // Precio 
                if (row.Cells[3].Value != null && decimal.TryParse(row.Cells[3].Value.ToString(), out decimal precio))
                {
                    producto.Precio = precio;
                }
                else
                {
                    MessageBox.Show("El precio del producto no es válido", "Error",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ProductoSeleccionado?.Invoke(producto);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al seleccionar producto: {ex.Message}\n\nDetalles técnicos:\n{ex.StackTrace}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

