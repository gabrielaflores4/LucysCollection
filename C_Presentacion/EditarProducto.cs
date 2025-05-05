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

        private ProductoNeg productoNeg = new ProductoNeg();

        private Inicio formInicio;

        public EditarProducto(Inicio inicio)
        {
            InitializeComponent();
            this.formInicio = inicio;
        }

        public EditarProducto() : this(new Inicio()) {}

        private void EditarProducto_Load(object sender, EventArgs e)
        {
            lblDetalleProd.Text = "Producto: " + Nombre;

            // === CÓDIGO NUEVO === //
            // Cargar categorías con verificación
            var categorias = new CategoriaNeg().ObtenerCategorias().ToList(); // Convertir a lista para evitar modificaciones

            if (categorias.Count == 0)
            {
                MessageBox.Show("No hay categorías disponibles", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            cbCategoriaAct.DataSource = categorias;
            cbCategoriaAct.DisplayMember = "Nombre";
            cbCategoriaAct.ValueMember = "Id";

            // Verificar si la categoría original existe
            if (categorias.Any(c => c.Id == CategoriaId))
            {
                cbCategoriaAct.SelectedValue = CategoriaId;
            }
            else
            {
                cbCategoriaAct.SelectedIndex = 0;
                MessageBox.Show("La categoría original no está disponible. Se seleccionó una por defecto.",
                              "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            // === FIN CÓDIGO NUEVO === //

            CargarTallasYStock();

            // Cargar tallas (29-42)
            for (int talla = 29; talla <= 42; talla++)
            {
                cbTallasRegAct.Items.Add(talla.ToString());
            }

        }

        private void CargarTallasYStock()
        {
            // Las tallas y el Stock del producto seleccionado  
            var productos = productoNeg.ObtenerProductos()
                .Where(p => p.Nombre == Nombre)
                .OrderBy(p => p.Talla)
                .ToList();

            // Configurar el DataGridView  
            dataGridProductoDet.AutoGenerateColumns = false;
            dataGridProductoDet.Columns.Clear();

            // Agregar columnas  
            dataGridProductoDet.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Talla",
                HeaderText = "Talla",
                ReadOnly = true
            });

            dataGridProductoDet.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Stock",
                HeaderText = "Stock"
            });

            // Asignar los datos  
            dataGridProductoDet.DataSource = productos;
        }

        private void CargarCategorias()
        {
            try
            {
                cbCategoriaAct.DataSource = new CategoriaNeg().ObtenerCategorias();
                cbCategoriaAct.DisplayMember = "Nombre";
                cbCategoriaAct.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar categorías: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardarActProd_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Validaciones básicas del formulario
                if (string.IsNullOrWhiteSpace(tbNombreProdAct.Text))
                {
                    MessageBox.Show("El nombre del producto es requerido", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cbTallasRegAct.SelectedItem == null)
                {
                    MessageBox.Show("Seleccione una talla válida", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(tbPrecioRegAct.Text, out decimal nuevoPrecio) || nuevoPrecio <= 0)
                {
                    MessageBox.Show("Ingrese un precio válido mayor a cero", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. Obtener valores del formulario
                string nuevoNombre = tbNombreProdAct.Text.Trim();
                int nuevaTalla = Convert.ToInt32(cbTallasRegAct.SelectedItem);
                int nuevoStock = (int)nbCantidad.Value;

                // 3. Validación de categoría seleccionada
                if (!(cbCategoriaAct.SelectedItem is Categoria categoriaSeleccionada))
                {
                    MessageBox.Show("Seleccione una categoría válida", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int nuevaCategoriaId = categoriaSeleccionada.Id;

                // 4. Verificación directa en BD de que la categoría existe
                if (!new CategoriaNeg().VerificarExistenciaCategoria(nuevaCategoriaId))
                {
                    MessageBox.Show("La categoría seleccionada no existe en la base de datos", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CargarCategorias(); // Recargar el ComboBox por si hubo cambios
                    return;
                }

                // 5. Verificar si ya existe el mismo producto+talla (excepto el actual)
                if (productoNeg.ExisteProductoConMismaTalla(nuevoNombre, nuevaTalla, ProductoId))
                {
                    MessageBox.Show($"Ya existe un producto {nuevoNombre} con talla {nuevaTalla}",
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 6. Obtener producto actual (si es edición)
                var productoActual = ProductoId > 0 ? productoNeg.ObtenerProductoPorId(ProductoId) : null;

                // 7. Determinar si hay cambios globales (para mostrar advertencia)
                bool cambiosGlobales = productoActual != null &&
                    (!productoActual.Nombre.Equals(nuevoNombre, StringComparison.OrdinalIgnoreCase) ||
                     Math.Abs(productoActual.Precio - nuevoPrecio) > 0.001m ||
                     productoActual.Categoria.Id != nuevaCategoriaId);

                // 8. Mostrar advertencia si hay cambios globales
                if (cambiosGlobales && productoActual != null)
                {
                    var respuesta = MessageBox.Show(
                        "¿Está seguro de actualizar estos campos para TODOS los productos con este nombre?\n\n" +
                        $"• Nombre: {productoActual.Nombre} → {nuevoNombre}\n" +
                        $"• Precio: {productoActual.Precio:C} → {nuevoPrecio:C}\n" +
                        $"• Categoría: {productoActual.Categoria.Nombre} → {categoriaSeleccionada.Nombre}",
                        "Confirmar cambios globales",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Exclamation);

                    if (respuesta != DialogResult.Yes) return;
                }

                // 9. Ejecutar actualización
                bool resultado = productoNeg.ActualizarProducto(
                    ProductoId,
                    nuevoNombre,
                    nuevaTalla,
                    nuevoPrecio,
                    nuevoStock,
                    nuevaCategoriaId,
                    actualizarCamposComunes: cambiosGlobales);

                if (resultado)
                {
                    MessageBox.Show("Producto actualizado correctamente", "Éxito",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el producto", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Formato de datos inválido", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnEditarProd_Click(object sender, EventArgs e)
        {
            //Redimencionar el DataGridView  
            dataGridProductoDet.SuspendLayout();
            dataGridProductoDet.Dock = DockStyle.None;
            dataGridProductoDet.Size = new Size(872, 500);
            dataGridProductoDet.Location = new Point(479, 145);
            dataGridProductoDet.ResumeLayout(true);

            btnEditarProd.Enabled = false;
        }

        private void dataGridProductoDet_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Obtener la fila seleccionada  
            DataGridViewRow fila = dataGridProductoDet.Rows[e.RowIndex];

            // Obtener el ID del producto  
            //int idProducto = Convert.ToInt32(fila.Cells[0].Value);  
            int talla = Convert.ToInt32(fila.Cells[0].Value);
            int stock = Convert.ToInt32(fila.Cells[1].Value);

            tbNombreProdAct.Text = Nombre;
            cbTallasRegAct.SelectedItem = talla.ToString();
            nbCantidad.Value = stock;
            tbPrecioRegAct.Text = Precio.ToString();
            cbCategoriaAct.SelectedValue = CategoriaId;
        }

        private void btnCancelarDetallePr_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
