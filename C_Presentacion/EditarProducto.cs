using System.Data;
using System.Globalization;
using C_Entidades;
using C_Negocios;

    namespace C_Presentacion
    {
        public partial class EditarProducto : Form
        {
            public int ProductoId { get; set; }
            public string Nombre { get; set; } = string.Empty;
            public int Talla { get; set; }
            public decimal Precio { get; set; }
            public int Stock { get; set; }
            public int CategoriaId { get; set; }

            private List<Categoria> categorias;
            private List<Talla> tallasDisponibles;
            private ProductoNeg productoNeg = new ProductoNeg();
            private Inicio formInicio;

        public EditarProducto(Inicio inicio)
        {
            InitializeComponent();
            this.formInicio = inicio;
            categorias = new List<Categoria>();
            tallasDisponibles = new List<Talla>();
        }

        public EditarProducto() : this(new Inicio()) {}

        private void EditarProducto_Load(object sender, EventArgs e)
        {
            CargarDatosIniciales();
        }

        private void CargarDatosIniciales()
        {
            try
            {
                // Cargar tallas
                tallasDisponibles = productoNeg.ObtenerTodasLasTallas();

                // Verificar que se obtuvieron datos
                if (tallasDisponibles == null || !tallasDisponibles.Any())
                {
                    MessageBox.Show("No se encontraron tallas en la base de datos", "Advertencia",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Configurar el ComboBox
                cbTallasRegAct.DataSource = tallasDisponibles;
                cbTallasRegAct.DisplayMember = "Descripcion";
                cbTallasRegAct.ValueMember = "Id_Talla";
                cbTallasRegAct.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar tallas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CargarProducto()
        {
            if (ProductoId <= 0) return;

            try
            {
                // Obtener el producto completo
                var producto = productoNeg.ObtenerProductoPorId(ProductoId);
                if (producto == null) return;

                // Asignar valores a los controles
                lblDetalleProd.Text = $"Producto: {producto.Nombre}";
                tbNombreProdAct.Text = producto.Nombre;
                tbPrecioRegAct.Text = producto.Precio.ToString("0.00", CultureInfo.InvariantCulture);
                nbCantidad.Value = producto.Stock;

                // Seleccionar categoría y talla
                if (producto.Categoria != null)
                {
                    cbCategoriaAct.SelectedValue = producto.Categoria.Id;
                }

                if (producto.Talla != null)
                {
                    cbTallasRegAct.SelectedValue = producto.Talla.Id_Talla;
                }

                CargarTallasYStock();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar producto: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarTallasYStock()
        {
            try
            {
                // Obtener productos con tallas
                var productos = productoNeg.ObtenerProductos()
                    .Where(p => p.Nombre.Equals(Nombre, StringComparison.OrdinalIgnoreCase))
                    .OrderBy(p => p.Talla?.Id_Talla)
                    .ToList();

                var datosParaGrid = productos.Select(p => new
                {
                    TallaDescripcion = p.Talla?.Descripcion ?? "Sin talla",
                    p.Stock,
                    ProductoCompleto = p
                }).ToList();

                dataGridProductoDet.AutoGenerateColumns = false;
                dataGridProductoDet.Columns.Clear();

                dataGridProductoDet.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "TallaDescripcion",
                    HeaderText = "Talla",
                    ReadOnly = true
                });

                dataGridProductoDet.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Stock",
                    HeaderText = "Stock"
                });

                dataGridProductoDet.DataSource = datosParaGrid;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar tallas y stock: {ex.Message}", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardarActProd_Click(object sender, EventArgs e)
            {
            try
            {
                // Validaciones básicas
                if (string.IsNullOrWhiteSpace(tbNombreProdAct.Text))
                {
                    MessageBox.Show("El nombre del producto es requerido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(tbPrecioRegAct.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal nuevoPrecio) || nuevoPrecio <= 0)
                {
                    MessageBox.Show("Ingrese un precio válido mayor a cero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cbTallasRegAct.SelectedValue == null || !int.TryParse(cbTallasRegAct.SelectedValue.ToString(), out int nuevaTalla))
                {
                    MessageBox.Show("Seleccione una talla válida", "Error",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int nuevoStock = (int)nbCantidad.Value;
                int nuevaCategoriaId = (cbCategoriaAct.SelectedItem as Categoria)?.Id ?? 0;

                // Verificar existencia de producto con misma talla
                if (productoNeg.ExisteProductoConMismaTalla(tbNombreProdAct.Text.Trim(), nuevaTalla, ProductoId))
                {
                    MessageBox.Show("Ya existe un producto con ese nombre y talla", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Determinar si hay cambios globales
                var productoActual = ProductoId > 0 ? productoNeg.ObtenerProductoPorId(ProductoId) : null;
                bool cambiosGlobales = productoActual != null &&
                                     (productoActual.Nombre != tbNombreProdAct.Text.Trim() ||
                                      productoActual.Precio != nuevoPrecio ||
                                      productoActual.Categoria?.Id != nuevaCategoriaId);

                // Mostrar confirmación para cambios globales
                if (cambiosGlobales)
                {
                    var confirmacion = MessageBox.Show("¿Desea aplicar estos cambios a todos los productos con este nombre?","Confirmar cambios globales",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                    if (confirmacion != DialogResult.Yes) return;
                }

                // Actualizar el producto
                bool resultado = productoNeg.ActualizarProducto(
                    ProductoId,
                    tbNombreProdAct.Text.Trim(),
                    nuevaTalla,
                    nuevoPrecio,
                    nuevoStock,
                    nuevaCategoriaId,
                    cambiosGlobales);

                if (resultado)
                {
                    MessageBox.Show("Producto actualizado correctamente", "Éxito",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el producto", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }

            private void btnCancelarActProd_Click(object sender, EventArgs e)
            {
                this.Close();
            }

            private void tbNombreProdAct_KeyPress(object sender, KeyPressEventArgs e)
            {
                Validaciones.SoloLetras(e);
            }

            private void tbPrecioRegAct_KeyPress(object sender, KeyPressEventArgs e)
            {
                Validaciones.SoloNumerosDecimales(e, tbPrecioRegAct);
            }

        private void LimpiarControles()
        {
            // Limpiar campos de texto
            tbNombreProdAct.Text = string.Empty;
            tbPrecioRegAct.Text = "0.00";

            // Resetear valores numéricos
            nbCantidad.Value = 0;

            // Deseleccionar items en combobox
            if (cbCategoriaAct.Items.Count > 0)
                cbCategoriaAct.SelectedIndex = -1;

            if (cbTallasRegAct.Items.Count > 0)
                cbTallasRegAct.SelectedIndex = -1;
        }

        private void btnEditarProd_Click(object sender, EventArgs e)
            {
                //Redimencionar el DataGridView  
                dataGridProductoDet.SuspendLayout();
                dataGridProductoDet.Dock = DockStyle.None;
                dataGridProductoDet.Size = new Size(872, 500);
                dataGridProductoDet.Location = new Point(479, 145);
                dataGridProductoDet.ResumeLayout(true);

                btnEditarProd.Enabled = false;
            LimpiarControles();
            }

            private void dataGridProductoDet_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
            {
                if (e.RowIndex < 0) return;
                var rowData = dataGridProductoDet.Rows[e.RowIndex].DataBoundItem;
                var propertyInfo = rowData.GetType().GetProperty("ProductoCompleto");

                if (propertyInfo?.GetValue(rowData) is Producto producto)
                {
                    // Actualizar los controles del formulario
                    tbNombreProdAct.Text = producto.Nombre;

                    // Seleccionar la talla correcta en el ComboBox
                    cbTallasRegAct.SelectedValue = producto.Talla.Id_Talla;

                    nbCantidad.Value = producto.Stock;
                    tbPrecioRegAct.Text = producto.Precio.ToString("C");
                    cbCategoriaAct.SelectedValue = producto.Categoria.Id;
                }
            }

            private void btnCancelarDetallePr_Click(object sender, EventArgs e)
            {
                this.Close();
            }
        }
    }
