﻿using C_Entidades;
using C_Negocios;
using System.Data;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Globalization;
using System.Windows.Forms.DataVisualization.Charting;
using Tulpep.NotificationWindow;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace C_Presentacion
{
    public partial class Inicio : Form
    {
        private ProductoNeg productoNeg = new ProductoNeg();
        private UsuarioNeg usuarioNeg = new UsuarioNeg();
        private ProveedorNeg _proveedorNeg = new ProveedorNeg();
        private MateriaPrimaNeg _materiaPrimaNeg = new MateriaPrimaNeg();
        private ClienteNeg clienteNeg = new ClienteNeg();
        private System.Windows.Forms.Timer timerNotificaciones;

        public Inicio()
        {
            InitializeComponent();
            timerNotificaciones = new System.Windows.Forms.Timer();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            if (Sesion.EstaLogueado())
            {
                Usuario? usuarioLogueado = Sesion.UsuarioActivo;

                if (usuarioLogueado != null)
                {
                    lblNombreUsuario.Text = $"{usuarioLogueado.Nombre} {usuarioLogueado.Apellido}";
                    lblRolUser.Text = usuarioLogueado.Rol;
                    AplicarPermisosPorRol();
                }
                else
                {
                    MessageBox.Show("Error: Usuario no encontrado en la sesión.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                Login frmLogin = new Login();
                frmLogin.ShowDialog();
                return;
            }

            InicializarComboBox(cmbPrecioMP, new[] { "Todos", "Mayor precio", "Menor precio" });
            InicializarComboBox(cmbStockMP, new[] { "Todos", "Mayor", "Menor", "Sin stock" });
            InicializarComboBox(cmbCategoria, new[] { "Todos", "Botas", "Sandalias", "Zapatillas bordadas", "Zapatos casuales", "Calzado infantil" });
            InicializarComboBox(cmbPrecioUnit, new[] { "Todos", "Mayor precio", "Menor precio" });

            ConfigurarGrafico();
            CargarEstadisticas();

            timerNotificaciones.Interval = 300000;
            timerNotificaciones.Tick += TimerNotificacione_Tick;

            VerificarStockProductos();
            VerificarStockMateriaPrima();

            timerNotificaciones.Start();


        }

        private void Notificar(string tipo, string mensaje, Action onClickAction = null)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => Notificar(tipo, mensaje, onClickAction)));
                return;
            }

            var popup = new PopupNotifier()
            {
                TitleText = "Lucy's Collection",
                ContentText = mensaje,
                Delay = 5000,
                AnimationInterval = 10,
                AnimationDuration = 1000,
                ShowCloseButton = true
            };

            switch (tipo.ToLower())
            {
                case "exito":
                    popup.BodyColor = Color.FromArgb(76, 175, 80);
                    popup.TitleColor = Color.White;
                    popup.ContentColor = Color.White;
                    popup.Image = SystemIcons.Information.ToBitmap();
                    break;
                case "error":
                    popup.BodyColor = Color.FromArgb(244, 67, 54);
                    popup.TitleColor = Color.White;
                    popup.ContentColor = Color.White;
                    popup.Image = SystemIcons.Error.ToBitmap();
                    break;
                case "advertencia":
                    popup.BodyColor = Color.FromArgb(255, 193, 7);
                    popup.TitleColor = Color.Black;
                    popup.ContentColor = Color.Black;
                    popup.Image = SystemIcons.Warning.ToBitmap();
                    break;
                default: // Info
                    popup.BodyColor = Color.FromArgb(33, 150, 243);
                    popup.TitleColor = Color.White;
                    popup.ContentColor = Color.White;
                    popup.Image = SystemIcons.Information.ToBitmap();
                    break;
            }

            if (onClickAction != null)
            {
                popup.Click += (s, e) => onClickAction();
            }

            popup.Popup();
        }

        private async void VerificarStockProductos()
        {
            try
            {
                // Obtener productos con stock bajo
                var productos = productoNeg.ObtenerProductosConStock()
                                    .Where(p => p.Stock <= 5)
                                    .ToList();

                if (productos.Any())
                {
                    // Mostrar notificación resumen
                    Notificar("advertencia",
                             $"{productos.Count} productos con stock bajo",
                             () =>
                             {
                                 tabControlInicio.SelectedTab = tabInventario;
                                 // Forzar la actualización del DataGrid
                                 CargarProductos();
                             });

                    // Esperar antes de mostrar detalles
                    await Task.Delay(3000);

                    // Mostrar notificaciones individuales sin afectar la UI
                    foreach (var p in productos)
                    {
                        if (this.IsDisposed) return; // Verificar si el formulario sigue activo

                        Notificar("advertencia",
                                $"Stock bajo: {p.Nombre} ({p.Stock} unidades)",
                                () =>
                                {
                                    tabControlInicio.SelectedTab = tabInventario;
                                    // Resaltar el producto en el DataGrid
                                    ResaltarProductoEnDataGrid(p.Id_Prod);
                                });

                        await Task.Delay(1500);
                    }
                }
            }
            catch (Exception ex)
            {
                Notificar("error", $"Error al verificar stock: {ex.Message}");
            }
        }

        private void ResaltarProductoEnDataGrid(int idProducto)
        {
            if (dataGridInventarioProducto.InvokeRequired)
            {
                dataGridInventarioProducto.Invoke(new Action<int>(ResaltarProductoEnDataGrid), idProducto);
                return;
            }

            foreach (DataGridViewRow row in dataGridInventarioProducto.Rows)
            {
                // Acceder a la columna por índice (la columna 0 es Id_Prod)
                if (row.Cells[0].Value != null &&
                    Convert.ToInt32(row.Cells[0].Value) == idProducto)
                {
                    row.Selected = true;
                    dataGridInventarioProducto.FirstDisplayedScrollingRowIndex = row.Index;
                    break;
                }
            }
        }

        private async void VerificarStockMateriaPrima()
        {
            try
            {
                var materiasPrimas = _materiaPrimaNeg.ObtenerMateriasPrimas()
                                        .Where(m => m.Stock <= 5)
                                        .ToList();

                if (materiasPrimas.Any())
                {
                    // Notificación resumen
                    Notificar("advertencia",
                             $"{materiasPrimas.Count} materias primas con stock bajo",
                             () =>
                             {
                                 tabControlInicio.SelectedTab = tabMateriaP;
                                 CargarMateriasPrimas();
                             });

                    await Task.Delay(3000);

                    // Notificaciones individuales
                    foreach (var m in materiasPrimas)
                    {
                        if (this.IsDisposed) return;

                        Notificar("advertencia",
                                $"Stock bajo MP: {m.Nombre} ({m.Stock} unidades)",
                                () =>
                                {
                                    tabControlInicio.SelectedTab = tabMateriaP;
                                    ResaltarMateriaPrimaEnDataGrid(m.IdMateriaPrima);
                                });

                        await Task.Delay(1500);
                    }
                }
            }
            catch (Exception ex)
            {
                Notificar("error", $"Error al verificar stock MP: {ex.Message}");
            }
        }

        private void ResaltarMateriaPrimaEnDataGrid(int idMateriaPrima)
        {
            if (dataGridMP.InvokeRequired)
            {
                dataGridMP.Invoke(new Action<int>(ResaltarMateriaPrimaEnDataGrid), idMateriaPrima);
                return;
            }

            foreach (DataGridViewRow row in dataGridMP.Rows)
            {
                if (row.Cells["IdMateriaPrima"].Value != null &&
                    Convert.ToInt32(row.Cells["IdMateriaPrima"].Value) == idMateriaPrima)
                {
                    row.Selected = true;
                    dataGridMP.FirstDisplayedScrollingRowIndex = row.Index;
                    break;
                }
            }
        }

        private void InicializarComboBox(ComboBox comboBox, string[] items)
        {
            comboBox.Items.Clear();
            comboBox.Items.AddRange(items);
            comboBox.SelectedIndex = 0;
        }

        private void ConfigurarGrafico()
        {
            //Limpiar configuración previa
            chartVentas.Series.Clear();
            chartVentas.ChartAreas.Clear();

            //Área del gráfico
            ChartArea area = new ChartArea("VentasArea");
            area.AxisX.Title = "Meses";
            area.AxisY.Title = "Ventas ($)";
            area.AxisX.LabelStyle.Angle = -45;
            area.AxisX.Interval = 1;
            chartVentas.ChartAreas.Add(area);

            //Serie de columnas
            Series serie = new Series("Ventas Mensuales")
            {
                ChartType = SeriesChartType.Column,
                Color = ColorTranslator.FromHtml("#5a24a6"),
                IsValueShownAsLabel = true,
                LabelFormat = "C0"
            };
            chartVentas.Series.Add(serie);
        }

        private void CargarEstadisticas()
        {
            try
            {
                //Obtener datos de la capa de negocio
                var estadisticas = new EstadisticasNeg();

                //Datos para el gráfico (ventas por mes)
                var ventasMensuales = estadisticas.ObtenerVentasMensualesFormateadas();
                chartVentas.Series["Ventas Mensuales"].Points.DataBindXY(
                    ventasMensuales.Keys,
                    ventasMensuales.Values
                );

                //Actualizar labels
                var stock = estadisticas.ObtenerResumenStock();
                lblStockDisponible.Text = stock.Disponible.ToString("N0");
                lblStockBajo.Text = stock.BajoStock.ToString("N0");
                lblSinStock.Text = stock.SinStock.ToString("N0");
                lblProductoMasVendido.Text = estadisticas.ObtenerProductoMasVendido();
                lblVentasDiarias.Text = estadisticas.ObtenerVentasDiarias().ToString("C2");

                int total = estadisticas.ObtenerTotalProductos();
                lblTotalProductos.Text = total.ToString("N0");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ActualizarInfoUsuario(Usuario usuario)
        {
            lblNombreUsuario.Text = usuario.Nombre + " " + usuario.Apellido;
            lblRolUser.Text = usuario.Rol;
            AplicarPermisosPorRol();
        }

        public void AplicarPermisosPorRol()
        {
            if (Sesion.TieneRol("admin"))
            {
                // Funciones permitidas para administradores
                btnVentas.Visible = true;
                tabEmpleados.Visible = true;
                tabMateriaP.Visible = true;
                tabInventario.Visible = true;
                tabProveedores.Visible = true;
                AjustarDataGridViews();
                dataGridEmpleados.CellDoubleClick += dataGridEmpleados_CellDoubleClick;
                dataGridMP.CellDoubleClick += dataGridMP_CellDoubleClick;
                dataGridProv.CellDoubleClick += dataGridProv_CellDoubleClick;
            }
            else if (Sesion.TieneRol("empleado"))
            {
                // Funciones permitidas para empleados
                btnVentas.Visible = true;
                tabInventario.Visible = true;
                tabMateriaP.Visible = true;
                tabProveedores.Visible = true;
                btnAgregarInventario.Visible = false;
                btnEliminarInventario.Visible = false;
                btnAgregarMateriaP.Visible = false;
                btnEliminarMateriaP.Visible = false;
                btnAgregarProv.Visible = false;
                btnEliminarProv.Visible = false;
                btnEmpleados.Visible = false;
                btnReporte.Visible = false;
                AjustarDataGridViews();
                dataGridEmpleados.CellDoubleClick -= dataGridEmpleados_CellDoubleClick; 
                dataGridMP.CellDoubleClick -= dataGridMP_CellDoubleClick;
                dataGridProv.CellDoubleClick -= dataGridProv_CellDoubleClick; 
            }
        }
        private void AjustarDataGridViews()
        {
            // Obtener la pestaña activa actual
            TabPage? paginaActiva = tabControlInicio.SelectedTab;

            if (paginaActiva == null) { return; }

            if (Sesion.TieneRol("admin"))
            {
                dataGridEmpleados.SuspendLayout();
                dataGridEmpleados.Dock = DockStyle.None;
                dataGridEmpleados.Size = new Size(847, 488);
                dataGridEmpleados.Location = new Point(232, 189);
                dataGridEmpleados.Visible = (tabEmpleados == paginaActiva);
                dataGridEmpleados.ResumeLayout(true);
            }
            else
            {
                // Ajustar los DataGridViews generales
                int anchoGrid = paginaActiva.Width - 40;
                int alturaGrid = paginaActiva.Height - 250;
                int posicionY = 180;
                int centroX = (paginaActiva.Width - anchoGrid) / 2;

                AplicarTamañoYPosicion(dataGridInventarioProducto,
                                      tabInventario == paginaActiva,
                                      anchoGrid, alturaGrid, centroX, posicionY);

                AplicarTamañoYPosicion(dataGridProv,
                                      tabProveedores == paginaActiva,
                                      anchoGrid, alturaGrid, centroX, posicionY);

                AplicarTamañoYPosicion(dataGridMP,
                                      tabMateriaP == paginaActiva,
                                      anchoGrid, alturaGrid, centroX, posicionY);

                dataGridEmpleados.Visible = false;
            }
        }

        private void AplicarTamañoYPosicion(DataGridView grid, bool mostrar, int width, int height, int x, int y)
        {
            grid.SuspendLayout();
            grid.Dock = DockStyle.None;
            grid.Size = new Size(width, height);
            grid.Location = new Point(x, y);
            grid.Visible = mostrar;
            grid.ResumeLayout(true);
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
            string filtro = tbBusquedaInventario.Text.Trim();
            List<Producto> productos;

            if (string.IsNullOrWhiteSpace(filtro))
            {
                productos = productoNeg.ObtenerProductos();
            }
            else
            {
                productos = productoNeg.ObtenerProductos()
                    .Where(p => p.Nombre.Contains(filtro, StringComparison.OrdinalIgnoreCase) ||
                    p.Categoria.Nombre.Contains(filtro, StringComparison.OrdinalIgnoreCase) ||
                    p.Precio.ToString("0.##").Contains(filtro, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            var columnas = new Dictionary<string, string>
            {
                { "Id_Prod", "ID" },
                { "Nombre", "Producto" },
                { "Categoria", "Categoría" },
                { "Precio", "Precio Unitario" }
            };

            var productosMostrar = productos.Select(p => new
            {
                p.Id_Prod,
                p.Nombre,
                Categoria = p.Categoria.Nombre,
                Precio = p.Precio.ToString("C")
            }).ToList();

            ConfigurarDataGrid(dataGridInventarioProducto, productosMostrar, columnas);
            dataGridInventarioProducto.Columns[0].Visible = false;
        }

        public void CargarEmpleados()
        {
            string filtro = tbBusquedaEmpleados.Text.Trim();

            List<Usuario> empleados;

            if (string.IsNullOrWhiteSpace(filtro))
            {
                empleados = usuarioNeg.ObtenerUsuarios();
            }
            else
            {
                empleados = usuarioNeg.ObtenerUsuarios()
                .Where(u => u.Nombre.Contains(filtro, StringComparison.OrdinalIgnoreCase) ||
                 u.Apellido.Contains(filtro, StringComparison.OrdinalIgnoreCase) ||
                 u.Correo.Contains(filtro, StringComparison.OrdinalIgnoreCase) ||
                 u.Telefono.Contains(filtro, StringComparison.OrdinalIgnoreCase) ||
                 u.Rol.Contains(filtro, StringComparison.OrdinalIgnoreCase))
                 .ToList();
            }

            var usuarios = empleados;

            var columnas = new Dictionary<string, string>
            {
                { "IdUsuario", "ID" },
                { "Nombre", "Nombre" },
                { "Apellido", "Apellido" },
                { "Correo", "Correo" },
                { "Telefono", "Teléfono" },
                { "Rol", "Rol" }
            };

            var datosParaMostrar = usuarios.Select(u => new
            {
                u.IdUsuario,
                u.Nombre,
                u.Apellido,
                u.Correo,
                u.Telefono,
                u.Rol
            }).ToList();

            ConfigurarDataGrid(dataGridEmpleados, datosParaMostrar, columnas);
            dataGridEmpleados.Columns[0].Visible = false;
        }

        private void CargarProveedores()
        {
            string filtro = tbBusquedaProv.Text.Trim();

            List<Proveedor> proveedors;

            if (string.IsNullOrWhiteSpace(filtro))
            {
                proveedors = _proveedorNeg.ObtenerProveedores();
            }
            else
            {
                proveedors = _proveedorNeg.ObtenerProveedores()
                .Where(pr => pr.NombreProv.Contains(filtro, StringComparison.OrdinalIgnoreCase) ||
                 pr.Telefono.Contains(filtro, StringComparison.OrdinalIgnoreCase) ||
                 pr.Correo.Contains(filtro, StringComparison.OrdinalIgnoreCase) ||
                 pr.Direccion.Contains(filtro, StringComparison.OrdinalIgnoreCase))
                 .ToList();
            }

            var columnas = new Dictionary<string, string>
            {
                { "IdProveedor", "ID" },
                { "NombreProv", "Proveedor" },
                { "Telefono", "Teléfono" },
                { "Correo", "Correo" },
                { "Direccion", "Dirección" }
            };

            ConfigurarDataGrid(dataGridProv, proveedors, columnas);
            dataGridProv.Columns[0].Visible = false;
        }
        public void CargarMateriasPrimas()
        {
            string filtro = tbBusquedaMateriaPrima.Text.Trim();

            List<MateriaPrima> materiaPrimas;

            if (string.IsNullOrWhiteSpace(filtro))
            {
                materiaPrimas = _materiaPrimaNeg.ObtenerMateriasPrimas();
            }
            else
            {
                materiaPrimas = _materiaPrimaNeg.ObtenerMateriasPrimas()
            .Where(m => m.Nombre.Contains(filtro, StringComparison.OrdinalIgnoreCase) ||
                        m.PrecioUnit.ToString("0.##").Contains(filtro, StringComparison.OrdinalIgnoreCase) ||
                        m.Stock.ToString().Contains(filtro, StringComparison.OrdinalIgnoreCase) ||
                        m.Proveedor.NombreProv.Contains(filtro, StringComparison.OrdinalIgnoreCase) ||
                        m.FechaIngreso.ToString("yyyy-MM-dd").Contains(filtro))
            .ToList();
            }

            var materias = _materiaPrimaNeg.ObtenerMateriasPrimas();

            var materiasConProveedor = new List<object>();

            foreach (var m in materiaPrimas)
            {
                materiasConProveedor.Add(new
                {
                    IdMateriaPrima = m.IdMateriaPrima,
                    Nombre = m.Nombre,
                    PrecioUnit = m.PrecioUnit,
                    Stock = m.Stock,
                    Proveedor = m.Proveedor.NombreProv
                });
            }

            var columnas = new Dictionary<string, string>
            {
                { "IdMateriaPrima", "ID" },
                { "Nombre", "Material" },
                { "PrecioUnit", "Precio Unitario" },
                { "Stock", "Stock" },
                { "Proveedor", "Proveedor" }
            };

            ConfigurarDataGrid(dataGridMP, materiasConProveedor, columnas);
            dataGridMP.Columns[0].Visible = false;
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            tabControlInicio.SelectedTab = tabInventario;
            AjustarDataGridViews();
            CargarProductos();
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            tabControlInicio.SelectedTab = tabEmpleados;
            AjustarDataGridViews();
            CargarEmpleados();
        }

        private void btnMateriaPrima_Click(object sender, EventArgs e)
        {
            tabControlInicio.SelectedTab = tabMateriaP;
            AjustarDataGridViews();
            CargarMateriasPrimas();
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            tabControlInicio.SelectedTab = tabProveedores;
            AjustarDataGridViews();
            CargarProveedores();
        }

        private void lblDashboard_Click(object sender, EventArgs e)
        {
            tabControlInicio.SelectedTab = tabInicio;
            CargarEstadisticas();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            Ventas frmVenta = new Ventas();
            frmVenta.ShowDialog();
        }

        private void btnAgregarInventario_Click(object sender, EventArgs e)
        {
            RegProd frmRegProducto = new RegProd(this);
            frmRegProducto.ShowDialog();
        }

        private void btnAgregarEmpleados_Click(object sender, EventArgs e)
        {
            RegistroUsuario registroForm = new RegistroUsuario(this);
            registroForm.Show();
        }

        private void btnAgregarProv_Click(object sender, EventArgs e)
        {
            RegProv frmRegProv = new RegProv();
            frmRegProv.ShowDialog();
        }

        private void btnAgregarMateriaP_Click(object sender, EventArgs e)
        {
            RegMP frmRegMP = new RegMP(this);

            // Suscribirse al evento
            frmRegMP.DatosGuardados += () => CargarMateriasPrimas();

            frmRegMP.ShowDialog();

            // Opcional: Verificar si se guardó algo
            if (frmRegMP.DialogResult == DialogResult.OK)
            {
                CargarMateriasPrimas();
            }
        }

        private void btnEliminarInventario_Click(object sender, EventArgs e)
        {
            if (dataGridInventarioProducto.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un producto para eliminar todos los del mismo nombre.",
                              "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string? nombreProducto = dataGridInventarioProducto.SelectedRows[0].Cells[1].Value?.ToString();

            if (string.IsNullOrWhiteSpace(nombreProducto))
            {
                MessageBox.Show("No se pudo obtener el nombre del producto seleccionado.",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Confirmación importante
            var confirmacion = MessageBox.Show(
                $"¿Está seguro que desea eliminar TODOS los productos con el nombre: {nombreProducto}?",
                "Confirmar Eliminación Masiva",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    int eliminados = productoNeg.EliminarProductosPorNombre(nombreProducto);

                    MessageBox.Show($"Se eliminaron {eliminados} productos con el nombre: {nombreProducto}",
                                  "Resultado", MessageBoxButtons.OK,
                                  eliminados > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

                    CargarProductos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar productos: {ex.Message}",
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridInventarioProducto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dataGridInventarioProducto.Rows[e.RowIndex];

            // Obtener datos del producto seleccionado
            int idProducto = Convert.ToInt32(fila.Cells[0].Value);
            string nombreProducto = fila.Cells[1].Value?.ToString() ?? string.Empty;
            string categoriaNombre = fila.Cells[2].Value?.ToString() ?? string.Empty;
            string precioTexto = fila.Cells[3].Value?.ToString() ?? "0";

            // Limpieza segura del formato de moneda
            precioTexto = precioTexto.Replace("$", "").Trim();

            // Conversión robusta a decimal
            decimal precio;
            if (!Decimal.TryParse(precioTexto,
                                  NumberStyles.Currency | NumberStyles.AllowDecimalPoint,
                                  CultureInfo.CurrentCulture,
                                  out precio))
            {
                precioTexto = precioTexto.Replace(",", "");
                if (!Decimal.TryParse(precioTexto,
                                      NumberStyles.Number,
                                      CultureInfo.InvariantCulture,
                                      out precio))
                {
                    precio = 0;
                }
            }

            int categoriaId = productoNeg.ObtenerCategoriaIdPorNombre(categoriaNombre);
            var tallasDisponibles = productoNeg.ObtenerTallasPorProducto(idProducto);

            int stock = 0;
            Talla? primeraTalla = null; // Updated to nullable type

            if (tallasDisponibles.Any())
            {
                primeraTalla = tallasDisponibles.First();
                var productoConTalla = productoNeg.ObtenerProductos().FirstOrDefault(p =>
                    p.Id_Prod == idProducto &&
                    p.Talla.Id_Talla == primeraTalla.Id_Talla);

                stock = productoConTalla?.Stock ?? 0;
            }

            using (var formEdicion = new EditarProducto(this))
            {
                // Asignamos todos los datos
                formEdicion.ProductoId = idProducto;
                formEdicion.Nombre = nombreProducto;
                formEdicion.Precio = precio;
                formEdicion.CategoriaId = categoriaId;

                if (primeraTalla != null)
                {
                    formEdicion.Talla = primeraTalla.Id_Talla;
                    formEdicion.Stock = stock;
                }

                formEdicion.CargarProducto();

                if (formEdicion.ShowDialog() == DialogResult.OK)
                {
                    CargarProductos();
                }
            }
        }

        private void btnEliminarEmpleados_Click(object sender, EventArgs e)
        {
            if (dataGridEmpleados.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un empleado antes de eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataGridViewRow fila = dataGridEmpleados.SelectedRows[0];
                int id = Convert.ToInt32(fila.Cells[0].Value);
                string nombre = fila.Cells[1].Value.ToString() ?? string.Empty;

                DialogResult resultado = MessageBox.Show(
                    $"¿Desea eliminar al empleado: {nombre}?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    if (usuarioNeg.EliminarUsuario(id))
                    {
                        MessageBox.Show($"Empleado '{nombre}' eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarEmpleados();
                    }
                    else
                    {
                        MessageBox.Show($"No se pudo eliminar al empleado '{nombre}'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridEmpleados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Validar que la fila seleccionada es válida
            if (e.RowIndex < 0) return;

            // Obtener la fila seleccionada
            DataGridViewRow fila = dataGridEmpleados.Rows[e.RowIndex];

            // Obtener los valores actuales
            int id = Convert.ToInt32(fila.Cells[0].Value);
            string nombre = fila.Cells[1].Value?.ToString() ?? string.Empty;
            string apellido = fila.Cells[2].Value?.ToString() ?? string.Empty;
            string correo = fila.Cells[3].Value?.ToString() ?? string.Empty;
            string telefono = fila.Cells[4].Value?.ToString() ?? string.Empty;
            string rol = fila.Cells[5].Value?.ToString() ?? string.Empty;

            // Crear y mostrar formulario de edición
            using (var formEdicion = new EditarEmpleados(this))
            {
                // Configurar los valores actuales en el formulario
                formEdicion.EmpleadoId = id;
                formEdicion.Nombre = nombre;
                formEdicion.Apellido = apellido;
                formEdicion.Correo = correo;
                formEdicion.Telefono = telefono;
                formEdicion.Rol = rol;

                if (formEdicion.ShowDialog() == DialogResult.OK)
                {
                    // Actualizar el empleado si el usuario guardó los cambios
                    if (usuarioNeg.ActualizarEmpleado(
                        formEdicion.EmpleadoId,
                        formEdicion.Nombre,
                        formEdicion.Apellido,
                        formEdicion.Correo,
                        formEdicion.Telefono,
                        formEdicion.Rol))
                    { CargarEmpleados(); }
                }
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea cerrar sesión?", "Cerrar sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                Login frmLogin = new Login();
                frmLogin.ShowDialog();
            }
            else { }
        }

        private void btnEliminarMateriaP_Click(object sender, EventArgs e)
        {
            if (dataGridMP.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una materia prima", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var fila = dataGridMP.SelectedRows[0];
            int idMP = Convert.ToInt32(fila.Cells[0].Value);
            string nombreMP = fila.Cells[1].Value.ToString() ?? string.Empty;

            if (MessageBox.Show($"¿Eliminar {nombreMP}?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (_materiaPrimaNeg.EliminarMP(idMP))
                    {
                        MessageBox.Show("Eliminación exitosa", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarMateriasPrimas(); // Refrescar el listado
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridMP_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Verificar fila seleccionada
                if (e.RowIndex < 0) return;

                DataGridViewRow fila = dataGridMP.Rows[e.RowIndex];

                //Extraer valores del DataGridView
                int id = Convert.ToInt32(fila.Cells[0].Value);
                string nombre = fila.Cells[1].Value?.ToString() ?? string.Empty;
                decimal precioUnit = Convert.ToDecimal(fila.Cells[2].Value);
                int stock = Convert.ToInt32(fila.Cells[3].Value);
                string proveedorNombre = fila.Cells[4].Value?.ToString() ?? string.Empty; ;

                //Obtener ID del proveedor
                int proveedorId = _proveedorNeg.ObtenerProveedorIdPorNombre(proveedorNombre);

                //Crear y mostrar formulario de edición
                using (var formEdicion = new EditarMP(this))
                {
                    formEdicion.MateriaPrimaId = id;
                    formEdicion.Nombre = nombre;
                    formEdicion.PrecioUnitario = precioUnit;
                    formEdicion.Stock = stock;
                    formEdicion.ProveedorId = proveedorId;

                    if (formEdicion.ShowDialog() == DialogResult.OK)
                    {
                        //Ejecutar actualización
                        bool actualizado = _materiaPrimaNeg.ActualizarMateriaPrima(
                            formEdicion.MateriaPrimaId,
                            formEdicion.Nombre,
                            formEdicion.PrecioUnitario,
                            formEdicion.Stock,
                            formEdicion.ProveedorId);

                        Console.WriteLine($"Actualización exitosa: {actualizado}");

                        if (actualizado)
                        {
                            CargarMateriasPrimas();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en CellDoubleClick: {ex.Message}");
                MessageBox.Show("Error al cargar datos para edición", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarProv_Click(object sender, EventArgs e)
        {
            if (dataGridProv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un proveedor antes de eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var fila = dataGridProv.SelectedRows[0];
            int id = Convert.ToInt32(fila.Cells[0].Value);
            string nombre = fila.Cells[1].Value.ToString() ?? string.Empty;

            if (MessageBox.Show($"¿Eliminar al proveedor {nombre}? Se eliminarán todos sus productos", "Aviso",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (_proveedorNeg.EliminarProveedor(id))
                    {
                        MessageBox.Show("Proveedor eliminado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarProveedores();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }
        private void dataGridProv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dataGridProv.Rows[e.RowIndex];

            var proveedor = new Proveedor
            {
                IdProveedor = Convert.ToInt32(fila.Cells[0].Value),
                NombreProv = fila.Cells[1].Value.ToString() ?? string.Empty,
                Telefono = fila.Cells[2].Value?.ToString() ?? string.Empty,
                Correo = fila.Cells[3].Value?.ToString() ?? string.Empty,
                Direccion = fila.Cells[4].Value?.ToString() ?? string.Empty
            };

            using (var formEdicion = new EditarProveedores(this))
            {
                formEdicion.ProveedorId = proveedor.IdProveedor;
                formEdicion.Nombre = proveedor.NombreProv;
                formEdicion.Telefono = proveedor.Telefono;
                formEdicion.Correo = proveedor.Correo;
                formEdicion.Direccion = proveedor.Direccion;

                if (formEdicion.ShowDialog() == DialogResult.OK)
                {
                    if (_proveedorNeg.ActualizarProveedor(
                        formEdicion.ProveedorId,
                        formEdicion.Nombre,
                        formEdicion.Telefono,
                        formEdicion.Correo,
                        formEdicion.Direccion))
                    {
                        CargarProveedores();
                    }
                }
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            Reporte_de_ventas reporte_De_Ventas = new Reporte_de_ventas();
            reporte_De_Ventas.ShowDialog();
        }
        private void FiltrarMateriaPrima()
        {
            List<MateriaPrima> materiaPrimas = _materiaPrimaNeg.ObtenerMateriasPrimas();

            string filtroStock = cmbStockMP.SelectedItem?.ToString() ?? string.Empty;
            string filtroPrecio = cmbPrecioMP.SelectedItem?.ToString() ?? string.Empty;

            // Filtrar stock "Sin stock"
            if (filtroStock == "Sin stock")
            {
                materiaPrimas = materiaPrimas.Where(p => p.Stock == 0).ToList();
            }

            IEnumerable<MateriaPrima> resultado = materiaPrimas;

            // Ordenamiento por stock
            if (filtroStock == "Mayor")
            {
                resultado = resultado.OrderByDescending(p => p.Stock);
            }
            else if (filtroStock == "Menor")
            {
                resultado = resultado.OrderBy(p => p.Stock);
            }

            // Ordenamiento por precio (si ya está ordenado por stock, usamos ThenBy)
            if (filtroPrecio == "Mayor precio")
            {
                resultado = (resultado is IOrderedEnumerable<MateriaPrima> ordered)
                    ? ordered.ThenByDescending(p => p.PrecioUnit)
                    : resultado.OrderByDescending(p => p.PrecioUnit);
            }
            else if (filtroPrecio == "Menor precio")
            {
                resultado = (resultado is IOrderedEnumerable<MateriaPrima> ordered)
                    ? ordered.ThenBy(p => p.PrecioUnit)
                    : resultado.OrderBy(p => p.PrecioUnit);
            }

            dataGridMP.DataSource = resultado.Select(mp => new
            {
                mp.IdMateriaPrima,
                mp.Nombre,
                mp.PrecioUnit,
                mp.Stock,
                Proveedor = mp.Proveedor.NombreProv
            }).ToList();
        }


        private void FiltrarInventario()
        {
            // Obtener todos los productos
            List<Producto> productos = productoNeg.ObtenerProductos();

            // Filtrar por categoría si se ha seleccionado una específica
            string filtroCategoria = cmbCategoria.SelectedItem?.ToString() ?? string.Empty;

            if (filtroCategoria != "Todos" && !string.IsNullOrEmpty(filtroCategoria))
            {
                productos = productos.Where(p => p.Categoria.Nombre == filtroCategoria).ToList();
            }

            // Ordenar los productos
            IOrderedEnumerable<Producto> ordenado = productos.OrderBy(p => p.Id_Prod);

            // Aplicar ordenamiento por precio si se ha seleccionado
            string filtroPrecio = cmbPrecioUnit.SelectedItem?.ToString() ?? string.Empty;
            switch (filtroPrecio)
            {
                case "Mayor precio":
                    ordenado = ordenado.OrderByDescending(p => p.Precio);
                    break;
                case "Menor precio":
                    ordenado = ordenado.OrderBy(p => p.Precio);
                    break;
            }

            // Configurar el DataSource del DataGridView
            dataGridInventarioProducto.DataSource = ordenado.Select(p => new
            {
                p.Id_Prod,
                p.Nombre,
                Categoria = p.Categoria.Nombre,
                p.Precio,
                p.Stock  // Mantenido por si aún necesitas mostrar el stock
            }).ToList();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarInventario();
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarInventario();
        }

        private void tbBusquedaEmpleados_TextChanged(object sender, EventArgs e)
        {
            CargarEmpleados();
        }

        private void tbBusquedaProv_TextChanged(object sender, EventArgs e)
        {
            CargarProveedores();
        }

        private void tbBusquedaInventario_TextChanged(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void tbBusquedaMateriaPrima_TextChanged(object sender, EventArgs e)
        {
            CargarMateriasPrimas();
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            Ayuda ayudaFrm = new Ayuda();
            ayudaFrm.ShowDialog();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            string rolUsuario = Sesion.UsuarioActivo?.Rol ?? "Empleado"; // Valor por defecto si es null

            VistaClientes frmClientes = new VistaClientes(rolUsuario);
            frmClientes.ShowDialog();
        }

        private void cmbPrecioMP_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarMateriaPrima();
        }

        private void cmbStockMP_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarMateriaPrima();
        }

        private void TimerNotificacione_Tick(object? sender, EventArgs e)
        {
            try
            {
                VerificarStockProductos();
                VerificarStockMateriaPrima();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error en verificación periódica: {ex.Message}");
            }
        }

        private void GenerarPedidoMateriaPrimaPDF()
        {
            try
            {
                List<MateriaPrima> lista = new MateriaPrimaNeg().ObtenerMateriasPrimas();

                var bajoStock = lista.Where(mp => mp.Stock <= 10 && mp.Proveedor != null).ToList();

                if (!bajoStock.Any())
                {
                    MessageBox.Show("No hay materias primas con stock bajo.");
                    return;
                }

                // Agrupar por proveedor
                var gruposPorProveedor = bajoStock.GroupBy(mp => mp.Proveedor.NombreProv);

                // Crear carpeta de pedidos
                string carpetaBase = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "PedidosPorProveedor");
                Directory.CreateDirectory(carpetaBase);

                foreach (var grupo in gruposPorProveedor)
                {
                    string proveedorNombre = grupo.Key;
                    string nombreArchivo = $"Pedido_{proveedorNombre}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                    string ruta = Path.Combine(carpetaBase, nombreArchivo);

                    Document doc = new Document(PageSize.A4, 40, 40, 40, 40);
                    PdfWriter.GetInstance(doc, new FileStream(ruta, FileMode.Create));
                    doc.Open();

                    // Título
                    Paragraph titulo = new Paragraph($"Lucy’s Collections\nPEDIDO A PROVEEDOR: {proveedorNombre}", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16));
                    titulo.Alignment = Element.ALIGN_CENTER;
                    doc.Add(titulo);
                    doc.Add(new Paragraph(" "));
                    doc.Add(new Paragraph("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy")));
                    doc.Add(new Paragraph(" "));

                    // Tabla de productos
                    PdfPTable tabla = new PdfPTable(4);
                    tabla.WidthPercentage = 100;
                    tabla.SetWidths(new float[] { 3, 1, 1, 2 });

                    tabla.AddCell("Materia Prima");
                    tabla.AddCell("Stock");
                    tabla.AddCell("Unidad");
                    tabla.AddCell("Cantidad a Pedir");

                    foreach (var mp in grupo)
                    {
                        tabla.AddCell(mp.Nombre);
                        tabla.AddCell(mp.Stock.ToString());
                        tabla.AddCell("Unidad");
                        tabla.AddCell("_________");
                    }

                    doc.Add(tabla);

                    // Firma
                    doc.Add(new Paragraph("\n\nFirma del Encargado: ____________________________\n\n"));
                    doc.Add(new Paragraph($"Firma del Proveedor: ____________________________"));

                    doc.Close();
                }

                MessageBox.Show("Reportes generados correctamente.");
                System.Diagnostics.Process.Start("explorer.exe", carpetaBase);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar pedidos: " + ex.Message);
            }
        }

        private void btnReporteMP_Click(object sender, EventArgs e)
        {
            GenerarPedidoMateriaPrimaPDF();
        }

        private void lblVentasDiarias_Click(object sender, EventArgs e)
        {

        }
    }

}