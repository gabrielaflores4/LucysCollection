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
            tbBusquedaProductos.TextChanged += tbBusquedaProductos_TextChanged;
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
                        (p.Nombre?.Contains(filtro, StringComparison.OrdinalIgnoreCase) == true) ||
                        (p.Categoria?.Nombre?.Contains(filtro, StringComparison.OrdinalIgnoreCase) == true) ||
                        p.Precio.ToString("0.##").Contains(filtro)
                    ).ToList();
                }

                dataGridProductos.SuspendLayout();
                dataGridProductos.AutoGenerateColumns = false;
                dataGridProductos.Columns.Clear();

                // Columnas con índices explícitos
                dataGridProductos.Columns.Add("Id_Prod", "ID");
                dataGridProductos.Columns.Add("Nombre", "Nombre");
                dataGridProductos.Columns.Add("Categoria", "Categoría");
                dataGridProductos.Columns.Add("Precio", "Precio");

                dataGridProductos.Columns[0].Visible = false;
                dataGridProductos.Columns[3].DefaultCellStyle.Format = "C2";
                dataGridProductos.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                // Limpiar filas existentes
                dataGridProductos.Rows.Clear();

                // Llenar datos usando índices
                foreach (var producto in productos)
                {
                    int rowIndex = dataGridProductos.Rows.Add();
                    DataGridViewRow row = dataGridProductos.Rows[rowIndex];

                    // Asignar valores por índice
                    row.Cells[0].Value = producto.Id_Prod;
                    row.Cells[1].Value = producto.Nombre;
                    row.Cells[2].Value = producto.Categoria?.Nombre ?? "Sin categoría";
                    row.Cells[3].Value = producto.Precio;
                }

                dataGridProductos.ResumeLayout();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    MessageBox.Show("El precio del producto no es válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ProductoSeleccionado?.Invoke(producto);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al seleccionar producto: {ex.Message}\n\nDetalles técnicos:\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbBusquedaProductos_TextChanged(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void btnCancelarAyuda_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Estás seguro que deseas cancelar?",
                "Confirmar cancelación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}

