using C_Entidades;
using C_Negocios;
using System.Text;


namespace C_Presentacion
{
    public partial class AgregarTallas : Form
    {

        private readonly ProductoNeg _productoNeg = new ProductoNeg();
        private readonly string _nombreProducto;
        private decimal? _precioProducto;
        private int? _categoriaId;

        public AgregarTallas(string nombreProducto, decimal? precio = null, int? categoriaId = null)
        {
            InitializeComponent();
            _nombreProducto = nombreProducto;
            _precioProducto = precio;
            _categoriaId = categoriaId;
        }

        private void AgregarTallas_Load(object sender, EventArgs e)
        {
            CargarTallasDisponibles();
            ConfigurarDataGridView();
        }

        private void ConfigurarDataGridView()
        {
            dataGridViewTallas.AutoGenerateColumns = false;
            dataGridViewTallas.AllowUserToAddRows = false;
            dataGridViewTallas.Columns.Clear();

            // Configuración de columnas sin la columna ID
            DataGridViewTextBoxColumn colDesc = new DataGridViewTextBoxColumn
            {
                Name = "Descripcion",
                DataPropertyName = "Descripcion",
                HeaderText = "Tallas Disponibles",
                Width = 150,
                ReadOnly = true
            };
            dataGridViewTallas.Columns.Add(colDesc);

            DataGridViewTextBoxColumn colStock = new DataGridViewTextBoxColumn
            {
                Name = "Stock",
                HeaderText = "Stock",
                Width = 100,
                ReadOnly = false
            };
            dataGridViewTallas.Columns.Add(colStock);

            if (dataGridViewTallas.DataSource != null)
            {
                var tallas = (List<Talla>)dataGridViewTallas.DataSource;
                dataGridViewTallas.DataSource = tallas.Select(t => new
                {
                    Descripcion = t.Descripcion,
                    Stock = 0
                }).ToList();
            }

            // Validación de stock
            dataGridViewTallas.CellValidating += (s, e) =>
            {
                if (e.ColumnIndex == colStock.Index)
                {
                    if (!int.TryParse(e.FormattedValue?.ToString(), out int stock) || stock < 0)
                    {
                        dataGridViewTallas.Rows[e.RowIndex].ErrorText = "Debe ser un número ≥ 0";
                        e.Cancel = true;
                    }
                }
            };

            dataGridViewTallas.CellEndEdit += (s, e) =>
            {
                if (e.ColumnIndex == colStock.Index)
                {
                    dataGridViewTallas.Rows[e.RowIndex].ErrorText = string.Empty;
                }
            };
        }

        private void ValidarStock(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewTallas.Columns["Stock"].Index)
            {
                if (!int.TryParse(e.FormattedValue?.ToString(), out int stock) || stock < 0)
                {
                    dataGridViewTallas.Rows[e.RowIndex].ErrorText = "Debe ser un número entero ≥ 0";
                    e.Cancel = true;
                }
            }
        }

        private void LimpiarError(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewTallas.Columns["Stock"].Index)
            {
                dataGridViewTallas.Rows[e.RowIndex].ErrorText = string.Empty;
            }
        }
        private void CargarTallasDisponibles()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                if (_precioProducto == null || _categoriaId == null)
                {
                    var productoBase = _productoNeg.ObtenerProductosConTallasPorNombre(_nombreProducto).FirstOrDefault();
                    if (productoBase != null)
                    {
                        _precioProducto ??= productoBase.Precio;
                        _categoriaId ??= productoBase.Categoria.Id;
                    }
                }

                var tallasDisponibles = _productoNeg.ObtenerTodasLasTallas()
                    .Where(t => !_productoNeg.ObtenerProductosConTallasPorNombre(_nombreProducto)
                        .Any(p => p.Talla.Id_Talla == t.Id_Talla))
                    .ToList();

                if (!tallasDisponibles.Any())
                {
                    MessageBox.Show("No hay tallas disponibles para agregar a este producto","Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                    return;
                }

                dataGridViewTallas.DataSource = tallasDisponibles;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar tallas: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
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

        private void btnAgregarTallas_Click(object sender, EventArgs e)
        {
            try
            {
                if (_precioProducto == null || _categoriaId == null)
                {
                    MessageBox.Show("El precio del producto o la categoría no están definidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var productosParaAgregar = new List<Producto>();
                var resumen = new StringBuilder();
                var tallasDisponibles = (List<Talla>)_productoNeg.ObtenerTodasLasTallas()
                    .Where(t => !_productoNeg.ObtenerProductosConTallasPorNombre(_nombreProducto)
                        .Any(p => p.Talla.Id_Talla == t.Id_Talla))
                    .ToList();

                for (int i = 0; i < dataGridViewTallas.Rows.Count; i++)
                {
                    var row = dataGridViewTallas.Rows[i];
                    var stockValue = row.Cells["Stock"].Value;

                    if (stockValue != null && int.TryParse(stockValue.ToString(), out int stock) && stock > 0)
                    {
                        var talla = tallasDisponibles[i];

                        productosParaAgregar.Add(new Producto(
                            nombre: _nombreProducto,
                            talla: new Talla(talla.Id_Talla, talla.Descripcion),
                            precio: _precioProducto.Value, 
                            stock: stock,
                            categoriaId: _categoriaId.Value 
                        ));

                        resumen.AppendLine($"- {talla.Descripcion}: {stock} unidades");
                    }
                }

                if (productosParaAgregar.Count == 0)
                {
                    MessageBox.Show("Ingrese stock mayor a 0 para al menos una talla", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirmacion = MessageBox.Show(
                    $"¿Agregar estas tallas a {_nombreProducto}?\n{resumen}", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmacion == DialogResult.Yes)
                {
                    _productoNeg.AgregarProductos(productosParaAgregar);
                    MessageBox.Show("Tallas agregadas correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
