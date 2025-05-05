using C_Entidades;
using C_Negocios;
using System.Data;
using System.Globalization;
using System.Windows.Forms.DataVisualization.Charting;


namespace C_Presentacion
{
    public partial class Inicio : Form
    {
        private ProductoNeg productoNeg = new ProductoNeg();
        private UsuarioNeg usuarioNeg = new UsuarioNeg();
        private ProveedorNeg _proveedorNeg = new ProveedorNeg();
        private MateriaPrimaNeg _materiaPrimaNeg = new MateriaPrimaNeg();
        private ClienteNeg clienteNeg = new ClienteNeg();

        public Inicio()
        {
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            if (Sesion.EstaLogueado())
            {
                Usuario usuarioLogueado = Sesion.UsuarioActivo;
                lblNombreUsuario.Text = $"{usuarioLogueado.Nombre} {usuarioLogueado.Apellido}";
                lblRolUser.Text = usuarioLogueado.Rol;
            }
            else
            {
                MessageBox.Show("No hay un usuario logueado. Inicie sesión primero.");

                Login frmLogin = new Login();
                frmLogin.ShowDialog();
            }

            // Form MP
            InicializarComboBox(cmbPrecio, new[] { "Todos", "Mayor precio", "Menor precio" });
            InicializarComboBox(cmbStock, new[] { "Todos", "Mayor", "Menor", "Sin stock" });

            // Form Inventario
            InicializarComboBox(cmbTalla, new[] { "Todos", "29", "30", "35", "38", "39" });
            InicializarComboBox(cmbStockk, new[] { "Todos", "Mayor", "Menor", "Sin stock" });
            InicializarComboBox(cmbCategoria, new[] { "Todos", "Botas", "Sandalias", "Zapatillas bordadas", "Zapatos casuales", "Calzado infantil" });
            InicializarComboBox(cmbPrecioUnit, new[] { "Todos", "Mayor precio", "Menor precio" });

            ConfigurarGrafico();
            CargarEstadisticas();
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
                AjustarDataGridViews();
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
        }

        private void CargarEmpleados()
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
                string nombreProducto = fila.Cells[1].Value.ToString() ?? string.Empty;

                // Mostramos confirmación con más información
                DialogResult resultado = MessageBox.Show($"¿Desea eliminar el producto: {nombreProducto}?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dataGridInventarioProducto.Rows[e.RowIndex];

            // Obtener datos del producto seleccionado
            int idProducto = Convert.ToInt32(fila.Cells[0].Value);
            string nombreProducto = fila.Cells[1].Value?.ToString() ?? string.Empty;
            string categoriaNombre = fila.Cells[2].Value?.ToString() ?? string.Empty;
            decimal precio = decimal.Parse(fila.Cells[3].Value?.ToString() ?? "0", NumberStyles.Currency,CultureInfo.CurrentCulture);

            // Obtener categoría ID usando el método existente
            int categoriaId = productoNeg.ObtenerCategoriaIdPorNombre(categoriaNombre);

            // Obtener tallas usando el método existente
            var tallasDisponibles = productoNeg.ObtenerTallasPorProducto(idProducto);

            // Obtener stock para la primera talla disponible (adaptación)
            var productos = productoNeg.ObtenerProductos();
            int stock = 0;

            if (tallasDisponibles.Any())
            {
                var productoConTalla = productos.FirstOrDefault(p =>
                    p.Id_Prod == idProducto && p.Talla == tallasDisponibles.First());
                stock = productoConTalla?.Stock ?? 0;
            }

            using (var formEdicion = new EditarProducto(this))
            {
                // Pasar todos los datos necesarios
                formEdicion.ProductoId = idProducto;
                formEdicion.Nombre = nombreProducto;
                formEdicion.Precio = precio;
                formEdicion.CategoriaId = categoriaId;

                // Pasar la primera talla y su stock si existen
                if (tallasDisponibles.Any())
                {
                    formEdicion.Talla = tallasDisponibles.First();
                    formEdicion.Stock = stock;
                }

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
                frmLogin.Show();
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

                // 5. Crear y mostrar formulario de edición
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
            reporte_De_Ventas.Show();
        }
        private void FiltrarMateriaPrima()
        {
            List<MateriaPrima> materiaPrimas = _materiaPrimaNeg.ObtenerMateriasPrimas();

            string filtroStock = cmbStock.SelectedItem?.ToString() ?? string.Empty;

            if (filtroStock == "Sin stock")
            {
                materiaPrimas = materiaPrimas.Where(p => p.Stock == 0).ToList();
            }

            IOrderedEnumerable<MateriaPrima> ordenado;
            switch (filtroStock)
            {
                case "Mayor":
                    ordenado = materiaPrimas.OrderByDescending(p => p.Stock);
                    break;
                case "Menor":
                    ordenado = materiaPrimas.OrderBy(p => p.Stock);
                    break;
                default:
                    ordenado = materiaPrimas.OrderBy(p => p.IdMateriaPrima);
                    break;
            }

            string filtroPrecio = cmbPrecio.SelectedItem?.ToString() ?? string.Empty;
            switch (filtroPrecio)
            {
                case "Mayor precio":
                    ordenado = ordenado.ThenByDescending(p => p.PrecioUnit);
                    break;
                case "Menor precio":
                    ordenado = ordenado.ThenBy(p => p.PrecioUnit);
                    break;
            }

            dataGridMP.DataSource = ordenado.Select(mp => new
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
            List<Producto> productos = productoNeg.ObtenerProductos();

            string filtroStock = cmbStockk.SelectedItem?.ToString() ?? string.Empty;
            if (filtroStock == "Sin stock")
                productos = productos.Where(p => p.Stock == 0).ToList();

            string filtroCategoria = cmbCategoria.SelectedItem?.ToString() ?? string.Empty;
            if (filtroCategoria != "Todos")
                productos = productos.Where(p => p.Categoria.Nombre == filtroCategoria).ToList();

            string filtroTalla = cmbTalla.SelectedItem?.ToString() ?? string.Empty;

            if (filtroTalla != "Todos" && int.TryParse(filtroTalla, out int tallaFiltrada))
            {
                productos = productos.Where(p => p.Talla == tallaFiltrada).ToList();
            }

            IOrderedEnumerable<Producto> ordenado;
            switch (filtroStock)
            {
                case "Mayor":
                    ordenado = productos.OrderByDescending(p => p.Stock);
                    break;
                case "Menor":
                    ordenado = productos.OrderBy(p => p.Stock);
                    break;
                default:
                    ordenado = productos.OrderBy(p => p.Id_Prod);
                    break;
            }

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

            dataGridInventarioProducto.DataSource = ordenado.Select(p => new
            {
                p.Id_Prod,
                p.Nombre,
                p.Talla,
                p.Stock,
                Categoria = p.Categoria.Nombre,
                p.Precio
            }).ToList();
        }

        private void cmbStock_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarMateriaPrima();
        }

        private void cmbPrecio_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarMateriaPrima();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarInventario();
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarInventario();
        }

        private void cmbStockk_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarInventario();
        }

        private void cmbTalla_SelectedIndexChanged(object sender, EventArgs e)
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
    }
}