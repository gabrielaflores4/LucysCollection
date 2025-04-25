using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using C_Entidades;
using C_Negocios;


namespace C_Presentacion
{
    public partial class Inicio : Form
    {
        private ProductoNeg productoNeg = new ProductoNeg();
        private UsuarioNeg usuarioNeg = new UsuarioNeg();
        private ProveedorNeg _proveedorNeg = new ProveedorNeg();
        private MateriaPrimaNeg _materiaPrimaNeg = new MateriaPrimaNeg();

        public Inicio() { 
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e) {
            AjustarDataGridViews();
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
        public void AjustarDataGridViews()
        {
            // Obtener la pestaña activa actual
            TabPage paginaActiva = tabControlInicio.SelectedTab;

            // Tamaño común para todos los DataGridViews
            int anchoGrid = paginaActiva.Width - 40; 
            int alturaGrid = paginaActiva.Height - 250; 
            int posicionY = 180; 

            // Posición horizontal centrada
            int centroX = (paginaActiva.Width - anchoGrid) / 2;

            // Aplicar a todos los DataGridViews
            AplicarTamañoYPosicion(dataGridInventarioProducto,
                                  tabInventario == paginaActiva,
                                  anchoGrid, alturaGrid, centroX, posicionY);

            AplicarTamañoYPosicion(dataGridProv,
                                  tabProveedores == paginaActiva,
                                  anchoGrid, alturaGrid, centroX, posicionY);

            AplicarTamañoYPosicion(dataGridMP,
                                  tabMateriaP == paginaActiva,
                                  anchoGrid, alturaGrid, centroX, posicionY);

            // Solo para administradores
            if (Sesion.TieneRol("admin"))
            {
                AplicarTamañoYPosicion(dataGridEmpleados,
                                      tabEmpleados == paginaActiva,
                                      anchoGrid, alturaGrid, centroX, posicionY);
            }
            else
            {
                dataGridEmpleados.Visible = false;
            }
        }

        private void AplicarTamañoYPosicion(DataGridView grid, bool mostrar,
                                           int width, int height, int x, int y)
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
            var productos = productoNeg.ObtenerProductos();
            var columnas = new Dictionary<string, string>
            {
                { "Id_Prod", "Id_Prod" },
                { "Nombre", "Producto" },
                { "Talla", "Talla" },
                { "Stock", "Stock" },
                { "Categoria", "Categoría" },
                { "Precio", "Precio" }
            };

            var productosConCategoria = productos.Select(p => new
            {
                p.Id_Prod,
                p.Nombre,
                p.Talla,
                p.Stock,
                Categoria = p.Categoria.Nombre,
                p.Precio,
            }).ToList();

            ConfigurarDataGrid(dataGridInventarioProducto, productosConCategoria, columnas);
        }

        private void CargarEmpleados()
        {
            var usuarios = usuarioNeg.ObtenerUsuarios();

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
            var proveedores = _proveedorNeg.ObtenerProveedores();

            var columnas = new Dictionary<string, string>
            {
                { "IdProveedor", "ID" },
                { "NombreProv", "Proveedor" },
                { "Telefono", "Teléfono" },
                { "Correo", "Correo" },
                { "Direccion", "Dirección" }
            };

            ConfigurarDataGrid(dataGridProv, proveedores, columnas);
        }
        public void CargarMateriasPrimas()
        {
            var materias = _materiaPrimaNeg.ObtenerMateriasPrimas();

            var materiasConProveedor = new List<object>();

            foreach (var m in materias)
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
                string nombreProducto = fila.Cells[1].Value.ToString();

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
            // Obtener la fila seleccionada
            DataGridViewRow fila = dataGridInventarioProducto.Rows[e.RowIndex];

            // Obtener los valores actuales
            int id = Convert.ToInt32(fila.Cells[0].Value);
            string nombre = fila.Cells[1].Value?.ToString();
            int talla = Convert.ToInt32(fila.Cells[2].Value);
            int stock = Convert.ToInt32(fila.Cells[3].Value);
            string categoriaNombre = fila.Cells[4].Value?.ToString();
            decimal precio = Convert.ToDecimal(fila.Cells[5].Value);

            // Obtener el ID de la categoría (necesitarás implementar este método)
            int categoriaId = productoNeg.ObtenerCategoriaIdPorNombre(categoriaNombre);

            // Crear y mostrar formulario de edición
            using (var formEdicion = new EditarProducto(this))
            {
                // Configurar los valores actuales en el formulario
                formEdicion.ProductoId = id;
                formEdicion.Nombre = nombre;
                formEdicion.Talla = talla;
                formEdicion.Precio = precio;
                formEdicion.Stock = stock;
                formEdicion.CategoriaId = categoriaId;

                if (formEdicion.ShowDialog() == DialogResult.OK)
                {
                    // Actualizar el producto si el usuario guardó los cambios
                    if (productoNeg.ActualizarProducto(
                        formEdicion.ProductoId,
                        formEdicion.Nombre,
                        formEdicion.Talla,
                        formEdicion.Precio,
                        formEdicion.Stock,
                        formEdicion.CategoriaId))
                    {
                        MessageBox.Show("Producto actualizado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarProductos();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
                string nombre = fila.Cells[1].Value.ToString();

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
            string nombre = fila.Cells[1].Value?.ToString();
            string apellido = fila.Cells[2].Value?.ToString();
            string correo = fila.Cells[3].Value?.ToString();
            string telefono = fila.Cells[4].Value?.ToString();
            string rol = fila.Cells[5].Value?.ToString();

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
            string nombreMP = fila.Cells[1].Value.ToString();

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
                string proveedorNombre = fila.Cells[4].Value?.ToString();

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
                            CargarMateriasPrimas(); //Refrescar datos
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en CellDoubleClick: {ex.Message}");
                MessageBox.Show("Error al cargar datos para edición", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbBusquedaEmpleados_TextChanged(object sender, EventArgs e)
        {
            busquedaTimer.Stop();
            busquedaTimer.Start();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string filtro = tbBusquedaEmpleados.Text.Trim();
            var empleados = usuarioNeg.BuscarEmpleados(filtro);

            var columnas = new Dictionary<string, string>
            {
                { "IdUsuario", "ID" },
                { "Nombre", "Nombre" },
                { "Apellido", "Apellido" },
                { "Correo", "Correo" },
                { "Telefono", "Teléfono" },
                { "Rol", "Rol" }

            };

            // Filtrar los empleados según el texto de búsqueda
            var usuarios = usuarioNeg.BuscarEmpleados(filtro);

            var datosParaMostrar = empleados.Select(u => new
            {
                IdUsuario = u.IdUsuario,
                Nombre = u.Nombre,
                Apellido = u.Apellido,
                Correo = u.Correo,
                Telefono = u.Telefono,
                Rol = u.Rol

            }).ToList();

            ConfigurarDataGrid(dataGridEmpleados, datosParaMostrar, columnas);
        }

        private void busquedaTimer_Tick(object sender, EventArgs e)
        {
            busquedaTimer.Stop();

            string filtro = tbBusquedaEmpleados.Text.Trim();
            var empleados = usuarioNeg.BuscarEmpleados(filtro);

            var columnas = new Dictionary<string, string>
        {
            { "IdUsuario", "ID" },
            { "Nombre", "Nombre" },
            { "Apellido", "Apellido" },
            { "Correo", "Correo" },
            { "Telefono", "Teléfono" },
            { "Rol", "Rol" }
        };

            var datosParaMostrar = empleados.Select(u => new
            {
                IdUsuario = u.IdUsuario,
                Nombre = u.Nombre,
                Apellido = u.Apellido,
                Correo = u.Correo,
                Telefono = u.Telefono,
                Rol = u.Rol

            }).ToList();

            ConfigurarDataGrid(dataGridEmpleados, datosParaMostrar, columnas);

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
            string nombre = fila.Cells[1].Value.ToString();

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
                NombreProv = fila.Cells[1].Value.ToString(),
                Telefono = fila.Cells[2].Value?.ToString(),
                Correo = fila.Cells[3].Value?.ToString(),
                Direccion = fila.Cells[4].Value?.ToString()
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
    }
}