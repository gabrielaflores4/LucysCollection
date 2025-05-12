using System.Data;
using System.Diagnostics;
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
        private CategoriaNeg categoriaNeg = new CategoriaNeg();
        private List<Talla> tallasDisponibles;
        private ProductoNeg productoNeg = new ProductoNeg();
        private Inicio formInicio;
        private Producto productoOriginal;
        private bool esEdicion = false;

        public EditarProducto(Inicio inicio)
        {

            InitializeComponent();
            this.formInicio = inicio;
            categorias = new List<Categoria>();
            tallasDisponibles = new List<Talla>();
            ConfigurarDataGridView();
        }

        private void EditarProducto_Load(object sender, EventArgs e)
        {
            CargarDatosIniciales();
        }


        private void ConfigurarDataGridView()
        {
            dataGridProductoDet.AutoGenerateColumns = false;
            dataGridProductoDet.Columns.Clear();

            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.Name = "IdProducto";
            colId.DataPropertyName = "IdProducto";
            colId.Visible = false;
            dataGridProductoDet.Columns.Add(colId);

            // Columna Talla
            DataGridViewTextBoxColumn colTalla = new DataGridViewTextBoxColumn();
            colTalla.Name = "Talla";
            colTalla.DataPropertyName = "Talla";
            colTalla.HeaderText = "Talla";
            colTalla.Width = 150;
            dataGridProductoDet.Columns.Add(colTalla);

            // Columna Stock
            DataGridViewTextBoxColumn colStock = new DataGridViewTextBoxColumn();
            colStock.Name = "Stock";
            colStock.DataPropertyName = "Stock";
            colStock.HeaderText = "Stock";
            colStock.Width = 100;
            dataGridProductoDet.Columns.Add(colStock);
        }

        private void CargarCategorias()
        {
            try
            {
                categorias = categoriaNeg.ObtenerCategorias();

                // Guardar el índice seleccionado actual si existe
                var selectedIndex = cbCategoriaAct.SelectedIndex;

                cbCategoriaAct.DataSource = null;
                cbCategoriaAct.DataSource = categorias;
                cbCategoriaAct.DisplayMember = "Nombre";
                cbCategoriaAct.ValueMember = "Id";

                // Restaurar la selección si era válida
                if (selectedIndex >= 0 && selectedIndex < cbCategoriaAct.Items.Count)
                {
                    cbCategoriaAct.SelectedIndex = selectedIndex;
                }
                else if (CategoriaId > 0)
                {
                    cbCategoriaAct.SelectedValue = CategoriaId;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar categorías: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosIniciales()
        {
            try
            {
                //Cargar categorías
                CargarCategorias();

                //Cargar tallas disponibles
                tallasDisponibles = productoNeg.ObtenerTodasLasTallas();

                if (tallasDisponibles == null || !tallasDisponibles.Any())
                {
                    MessageBox.Show("No se encontraron tallas en la base de datos", "Advertencia",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Configurar el ComboBox de tallas
                cbTallasRegAct.DataSource = tallasDisponibles;
                cbTallasRegAct.DisplayMember = "Descripcion";
                cbTallasRegAct.ValueMember = "Id_Talla";

                // Si ya tenemos un ProductoId, cargar sus datos
                if (ProductoId > 0)
                {
                    CargarProducto();
                }
                // Si tenemos un nombre de producto, realizar búsqueda
                else if (!string.IsNullOrEmpty(Nombre))
                {
                    CargarProductosPorNombre(Nombre);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos iniciales: {ex.Message}", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CargarProducto()
        {
            if (ProductoId <= 0) return;

            try
            {
                productoOriginal = productoNeg.ObtenerProductoPorId(ProductoId)!;

                if (productoOriginal == null)
                {
                    MessageBox.Show("El producto no fue encontrado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Primero cargar todas las categorías y tallas
                CargarCategorias();
                CargarTallas();

                // Luego asignar los valores a los controles
                lblDetalleProd.Text = $"Producto: {productoOriginal.Nombre}";
                tbNombreProdAct.Text = productoOriginal.Nombre;
                tbPrecioRegAct.Text = productoOriginal.Precio.ToString("0.00", CultureInfo.InvariantCulture);
                nbCantidad.Value = productoOriginal.Stock;

                // Asignar categoría con verificación robusta
                if (productoOriginal.Categoria != null)
                {
                    var categoriaEncontrada = categorias.FirstOrDefault(c => c.Id == productoOriginal.Categoria.Id);
                    if (categoriaEncontrada != null)
                    {
                        cbCategoriaAct.SelectedValue = categoriaEncontrada.Id;
                    }
                    else
                    {
                        Debug.WriteLine($"Categoría no encontrada: ID {productoOriginal.Categoria.Id}");
                    }
                }

                // Asignar talla con verificación robusta
                if (productoOriginal.Talla != null)
                {
                    var tallaEncontrada = tallasDisponibles.FirstOrDefault(t => t.Id_Talla == productoOriginal.Talla.Id_Talla);
                    if (tallaEncontrada != null)
                    {
                        cbTallasRegAct.SelectedValue = tallaEncontrada.Id_Talla;
                    }
                    else
                    {
                        Debug.WriteLine($"Talla no encontrada: ID {productoOriginal.Talla.Id_Talla}");
                    }
                }

                CargarTodasVariantesProducto(productoOriginal.Nombre);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error en CargarProducto: {ex.Message}");
                MessageBox.Show($"Error al cargar producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarTallas()
        {
            try
            {
                tallasDisponibles = productoNeg.ObtenerTodasLasTallas();

                // Guardar el índice seleccionado actual si existe
                var selectedIndex = cbTallasRegAct.SelectedIndex;

                cbTallasRegAct.DataSource = null;
                cbTallasRegAct.DataSource = tallasDisponibles;
                cbTallasRegAct.DisplayMember = "Descripcion";
                cbTallasRegAct.ValueMember = "Id_Talla";

                // Restaurar la selección si era válida
                if (selectedIndex >= 0 && selectedIndex < cbTallasRegAct.Items.Count)
                {
                    cbTallasRegAct.SelectedIndex = selectedIndex;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error en CargarTallas: {ex.Message}");
                MessageBox.Show($"Error al cargar tallas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarProductosPorNombre(string nombreProducto)
        {
            try
            {
                var productos = productoNeg.ObtenerProductosConTallasPorNombre(nombreProducto);

                //Desactivar generación automática de columnas
                dataGridProductoDet.AutoGenerateColumns = false;

                //Limpiar columnas existentes
                dataGridProductoDet.Columns.Clear();

                dataGridProductoDet.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "colTalla",
                    DataPropertyName = "Talla",
                    HeaderText = "Talla",
                    Width = 150
                });

                dataGridProductoDet.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "colStock",
                    DataPropertyName = "Stock",
                    HeaderText = "Stock",
                    Width = 100
                });

                // Asignar datos
                dataGridProductoDet.DataSource = productos.Select(p => new
                {
                    Talla = p.Talla?.Descripcion ?? "Sin talla",
                    Stock = p.Stock
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarTodasVariantesProducto(string nombreProducto)
        {
            try
            {
                var productos = productoNeg.ObtenerProductosConTallasPorNombre(nombreProducto);

                // Reutilizamos la configuración del DataGridView
                dataGridProductoDet.AutoGenerateColumns = false;

                // Si ya hay columnas, no las volvemos a crear
                if (dataGridProductoDet.Columns.Count == 0)
                {
                    dataGridProductoDet.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        Name = "colTalla",
                        DataPropertyName = "Talla",
                        HeaderText = "Talla",
                        Width = 150
                    });

                    dataGridProductoDet.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        Name = "colStock",
                        DataPropertyName = "Stock",
                        HeaderText = "Stock",
                        Width = 100
                    });
                }

                dataGridProductoDet.DataSource = productos.Select(p => new
                {
                    IdProducto = p.Id_Prod,
                    Talla = p.Talla?.Descripcion ?? "Sin talla",
                    p.Stock
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar variantes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardarActProd_Click(object sender, EventArgs e)
        {
            try
            {
                //Validar que hay un producto seleccionado
                if (dataGridProductoDet.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccione un producto para editar", "Advertencia",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //Obtener ID del producto seleccionado
                var selectedRow = dataGridProductoDet.SelectedRows[0];
                int productoId = Convert.ToInt32(selectedRow.Cells["IdProducto"].Value);
                Debug.WriteLine($"ProductoID a editar: {productoId}");

                //Obtener valores actuales de la base de datos
                var productoBD = productoNeg.ObtenerProductoPorId(productoId);
                if (productoBD == null)
                {
                    MessageBox.Show("Producto no encontrado en la base de datos", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Debug.WriteLine("Valores actuales en BD:");
                Debug.WriteLine($"- Nombre: {productoBD.Nombre}");
                Debug.WriteLine($"- Precio: {productoBD.Precio}");
                Debug.WriteLine($"- TallaID: {productoBD.Talla?.Id_Talla}");
                Debug.WriteLine($"- Stock: {productoBD.Stock}");
                Debug.WriteLine($"- CategoríaID: {productoBD.Categoria?.Id}");
                

                //Obtener nuevos valores del formulario
                decimal nuevoPrecio;
                if (!decimal.TryParse(tbPrecioRegAct.Text.Replace("$", "").Replace(",", ""), NumberStyles.Any, CultureInfo.InvariantCulture, out nuevoPrecio) || nuevoPrecio <= 0)
                {
                    MessageBox.Show("Ingrese un precio válido mayor a cero", "Error",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int nuevaTallaId = (int)cbTallasRegAct.SelectedValue;
                int nuevoStock = (int)nbCantidad.Value;
                int nuevaCategoriaId = (cbCategoriaAct.SelectedItem as Categoria)?.Id ?? 0;
                string nuevoNombre = tbNombreProdAct.Text.Trim();

                //Comparación de cambios
                bool cambioNombre = !productoBD.Nombre.Equals(nuevoNombre, StringComparison.OrdinalIgnoreCase);
                bool cambioPrecio = Math.Abs(productoBD.Precio - nuevoPrecio) > 0.001m;
                bool cambioCategoria = productoBD.Categoria?.Id != nuevaCategoriaId;
                bool cambioTalla = productoBD.Talla?.Id_Talla != nuevaTallaId;
                bool cambioStock = productoBD.Stock != nuevoStock;

                Debug.WriteLine($"Comparación de cambios - " +
               $"Nombre: {cambioNombre} (BD: '{productoBD.Nombre}' vs Form: '{nuevoNombre}'), " +
               $"Precio: {cambioPrecio} (BD: {productoBD.Precio} vs Form: {nuevoPrecio}), " +
               $"Categoría: {cambioCategoria} (BD: {productoBD.Categoria?.Id} vs Form: {nuevaCategoriaId}), " +
               $"Talla: {cambioTalla} (BD: {productoBD.Talla?.Id_Talla} vs Form: {nuevaTallaId}), " +
               $"Stock: {cambioStock} (BD: {productoBD.Stock} vs Form: {nuevoStock})");


                bool resultado = false;
                string mensajeExito = string.Empty;
                string mensajeError = string.Empty;

                //Solo cambio de stock
                if (!cambioNombre && !cambioPrecio && !cambioCategoria && !cambioTalla && cambioStock)
                {
                    int diferencia = nuevoStock - productoBD.Stock;
                    Debug.WriteLine(diferencia);
                    resultado = productoNeg.ActualizarStock(productoId, diferencia);
                    Debug.WriteLine($"Resultado de actualización de stock: {resultado}");   
                    mensajeExito = "Stock actualizado correctamente";
                    mensajeError = "No se pudo actualizar el stock";
                }
                //Cambio de talla y stock
                else if (!cambioNombre && !cambioPrecio && !cambioCategoria && cambioTalla && cambioStock)
                {
                    resultado = productoNeg.ActualizarTallaYStock(productoId, nuevaTallaId, nuevoStock);
                    mensajeExito = "Talla y stock actualizados correctamente";
                    mensajeError = "No se pudieron actualizar talla y stock";
                }
                else
                {
                    bool aplicarCambiosGlobales = cambioNombre || cambioPrecio || cambioCategoria;
                    if (aplicarCambiosGlobales)
                    {
                        var confirmacion = MessageBox.Show(
                            "¿Desea aplicar los cambios de nombre, precio o categoría a TODOS los productos con este nombre?",
                            "Confirmar cambios globales",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        aplicarCambiosGlobales = confirmacion == DialogResult.Yes;
                    }

                    resultado = productoNeg.ActualizarProducto(
                        productoId,
                        nuevoNombre,
                        nuevaTallaId,
                        nuevoPrecio,
                        nuevoStock,
                        nuevaCategoriaId,
                        aplicarCambiosGlobales);

                    mensajeExito = "Producto actualizado correctamente";
                    mensajeError = "No se pudo actualizar el producto";
                }

                //Mostrar resultado y actualizar vista si fue exitoso
                if (resultado)
                {
                    MessageBox.Show(mensajeExito, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarTodasVariantesProducto(nuevoNombre);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show(mensajeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar cambios: {ex.Message}", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void LimpiarControles()
        {
            // Limpiar campos de texto
            tbNombreProdAct.Text = string.Empty;
            tbPrecioRegAct.Text = "0.00";

            // Resetear valores numéricos
            nbCantidad.Value = 0;

            // Deseleccionar items en combobox
            if (cbCategoriaAct.Items.Count > 0) cbCategoriaAct.SelectedIndex = -1;

            if (cbTallasRegAct.Items.Count > 0) cbTallasRegAct.SelectedIndex = -1;
        }

        private void btnEditarProd_Click(object sender, EventArgs e)
        {
            esEdicion = !esEdicion;

            if (esEdicion)
            {
                // Configurar controles para edición
                dataGridProductoDet.SuspendLayout();
                dataGridProductoDet.Dock = DockStyle.None;
                dataGridProductoDet.Size = new Size(872, 500);
                dataGridProductoDet.Location = new Point(479, 145);
                dataGridProductoDet.ResumeLayout(true);

                btnEditarProd.Enabled = false;
                LimpiarControles();
            }
            else{}
        }

        private void dataGridProductoDet_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dataGridProductoDet.Rows[e.RowIndex];
            ProductoId = Convert.ToInt32(row.Cells[0].Value);

            // Cargar el producto completo desde la base de datos
            productoOriginal = productoNeg.ObtenerProductoPorId(ProductoId)!;

            if (productoOriginal != null)
            {
                nbCantidad.Value = Convert.ToInt32(row.Cells["Stock"].Value);
                tbNombreProdAct.Text = productoOriginal.Nombre;

                // Seleccionar categoría si existe
                if (productoOriginal.Categoria != null && cbCategoriaAct.Items.Count > 0)
                {
                    cbCategoriaAct.SelectedValue = productoOriginal.Categoria.Id;
                }

                // Buscar y seleccionar la talla correspondiente
                string tallaDescripcion = row.Cells["Talla"].Value?.ToString() ?? string.Empty;
                foreach (var item in cbTallasRegAct.Items)
                {
                    if (item is Talla talla && talla.Descripcion.Equals(tallaDescripcion))
                    {
                        cbTallasRegAct.SelectedItem = item;
                        break;
                    }
                }

                tbPrecioRegAct.Text = productoOriginal.Precio.ToString("0.00", CultureInfo.InvariantCulture);
            }
        }

        private void btnCancelarDetallePr_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbPrecioRegAct_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumerosDecimales(e, (TextBox)sender);
        }
    }
}
