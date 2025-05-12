using C_Entidades;
using C_Negocios;
using System.Globalization;
using System.Text;

namespace C_Presentacion
{
    public partial class RegProd : Form
    {
        private CategoriaNeg categoriaNeg;
        private ProductoNeg productoNeg;
        private List<Talla> tallasDisponibles;
        private Inicio formInicio;

        public RegProd(Inicio formInicio)
        {
            InitializeComponent();
            this.formInicio = formInicio;
            categoriaNeg = new CategoriaNeg();
            productoNeg = new ProductoNeg();
            CargarCategorias();
            CargarTallas();
            ConfigurarDataGridView();
            CargarTallasEnGrid();
        }

        private void CargarCategorias()
        {
            try
            {
                List<Categoria> categorias = categoriaNeg.ObtenerCategorias();

                cbCategoriaReg.Items.Clear();

                cbCategoriaReg.DataSource = categorias;
                cbCategoriaReg.DisplayMember = "Nombre";
                cbCategoriaReg.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorías: " + ex.Message);
            }
        }

        private void CargarTallas()
        {
            try
            {
                tallasDisponibles = productoNeg.ObtenerTodasLasTallas()
                    .OrderBy(t => t.Id_Talla)
                    .ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar tallas: " + ex.Message);
            }
        }

        private void ConfigurarDataGridView()
        {
            dataGridRegProducto.Columns.Clear();

            // Columna para Talla (solo lectura)
            DataGridViewTextBoxColumn colTalla = new DataGridViewTextBoxColumn();
            colTalla.HeaderText = "Talla";
            colTalla.Name = "Talla";
            colTalla.ReadOnly = true;
            dataGridRegProducto.Columns.Add(colTalla);

            // Columna para Cantidad (editable)
            DataGridViewTextBoxColumn colCantidad = new DataGridViewTextBoxColumn();
            colCantidad.HeaderText = "Cantidad";
            colCantidad.Name = "Cantidad";
            dataGridRegProducto.Columns.Add(colCantidad);

            // Configurar validación numérica para la columna Cantidad
            dataGridRegProducto.EditingControlShowing += (s, e) =>
            {
                if (e.Control is TextBox tb && dataGridRegProducto.CurrentCell.ColumnIndex == 1)
                {
                    tb.KeyPress += (sender, ev) =>
                    {
                        if (!char.IsControl(ev.KeyChar) && !char.IsDigit(ev.KeyChar))
                        {
                            ev.Handled = true;
                        }
                    };
                }
            };
        }

        private void CargarTallasEnGrid()
        {
            dataGridRegProducto.Rows.Clear();

            foreach (var talla in tallasDisponibles)
            {
                int rowIndex = dataGridRegProducto.Rows.Add();
                dataGridRegProducto.Rows[rowIndex].Cells["Talla"].Value = talla.Descripcion;
                dataGridRegProducto.Rows[rowIndex].Cells["Cantidad"].Value = 0;
                dataGridRegProducto.Rows[rowIndex].Tag = talla.Id_Talla;
            }
        }
        private bool ValidarCamposProducto()
        {
            if (string.IsNullOrWhiteSpace(tbNombreProdReg.Text))
            {
                MessageBox.Show("Ingrese el nombre del producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cbCategoriaReg.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una categoría.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!decimal.TryParse(tbPrecioRegProd.Text, out decimal precio) || precio <= 0)
            {
                MessageBox.Show("Ingrese un precio válido mayor a 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private void LimpiarFormulario()
        {
            tbNombreProdReg.Clear();
            tbPrecioRegProd.Clear();
            cbCategoriaReg.SelectedIndex = -1;
            CargarTallasEnGrid();
        }

        private void btnGuardarRegProd_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposProducto())
                return;

            btnGuardarRegProd.Enabled = false;
            List<Producto> productos = new List<Producto>();
            StringBuilder errores = new StringBuilder();

            try
            {
                string nombreProd = tbNombreProdReg.Text;
                if (cbCategoriaReg.SelectedItem == null || !(cbCategoriaReg.SelectedItem is Categoria))
                {
                    MessageBox.Show("Debe seleccionar una categoría válida");
                    return;
                }

                int categoriaId = ((Categoria)cbCategoriaReg.SelectedItem).Id;


                string precioTexto = tbPrecioRegProd.Text.Trim();
                precioTexto = precioTexto.Replace("$", "").Replace(",", "");

                if (!decimal.TryParse(precioTexto, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal precio) || precio <= 0)
                {
                    MessageBox.Show("Ingrese un precio válido mayor a 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Procesar cada talla
                foreach (DataGridViewRow row in dataGridRegProducto.Rows)
                {
                    if (row.IsNewRow || row.Cells["Cantidad"].Value == null)
                        continue;
                    try
                    {
                        int tallaId = row.Tag != null ? (int)row.Tag : 0;
                        int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value ?? 0);

                        if (cantidad > 0)
                        {
                            productos.Add(new Producto
                            {
                                Nombre = nombreProd,
                                Categoria = new Categoria { Id = categoriaId },
                                Precio = precio,
                                Talla = new Talla { Id_Talla = tallaId },
                                Stock = cantidad
                            });
                        }
                    }
                    catch (Exception ex)
                    {
                        errores.AppendLine($"Error en talla {row.Cells["Talla"].Value}: {ex.Message}");
                    }
                }

                if (errores.Length > 0)
                {
                    MessageBox.Show($"Errores encontrados:\n{errores}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (productos.Count == 0)
                {
                    MessageBox.Show("Debe ingresar cantidad mayor a 0 en al menos una talla.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Guardar productos
                productoNeg.AgregarProductos(productos);
                MessageBox.Show($"Producto registrado con {productos.Count} tallas.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
                formInicio.CargarProductos();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnGuardarRegProd.Enabled = true;
            }
        }

        private void tbNombreProdReg_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloLetras(e);
        }

        private void tbPrecioRegProd_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite: números, punto decimal, backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Solo permite un punto decimal
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
    }
}
