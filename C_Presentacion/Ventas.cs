using System.Diagnostics;
using System.Drawing.Printing;
using System.Windows.Forms;
using C_Datos;
using C_Entidades;
using C_Negocios;

namespace C_Presentacion
{
    public partial class Ventas : Form
    {
        private VentaNeg ventaNeg;
        VentaDatos ventaDatos = new VentaDatos();
        private int ultimoTicket;
        private List<DetalleVenta> detallesVenta;
        private ProductoNeg productoNeg = new ProductoNeg();
        private ClienteNeg clienteNeg = new ClienteNeg();
        private List<int> idsClientes;
        private decimal montoPagado;
        private Cliente clienteSeleccionado;

        public Ventas(int clienteId = 0)
        {
            InitializeComponent();
            
            ignorarMensajeCliente = true;

            detallesVenta = new List<DetalleVenta>();
            ventaNeg = new VentaNeg();
            ActualizarDataGrid();
            CargarProductos();
            CargarTallasDisponibles();

            if (clienteId > 0)
            {
                SeleccionarClientePorId(clienteId);
            }

            this.Shown += (s, ev) => { ignorarMensajeCliente = false; };

            ultimoTicket = ventaDatos.ObtenerUltimoTicket();
        }

        private void LimpiarControles()
        {
            cbProductos.SelectedIndex = -1;
            cbTallasRegProd.SelectedIndex = -1;
            nbCantidad.Value = 1;
            rbCliNuevo.Checked = false;
            rbCliAntiguo.Checked = false;
            tbClientes.Visible = true;
            tbClientes.Text=string.Empty;
            dataGridVentaProducto.Rows.Clear();
            lblStockDisponible.Text = "Stock: 0";
            ActualizarTotal();
        }


        private bool ValidarControles()
        {
            // Validar ComboBox de productos
            if (cbProductos.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbProductos.Focus();
                return false;
            }

            // Validar ComboBox de tallas
            if (cbTallasRegProd.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar una talla", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbTallasRegProd.Focus();
                return false;
            }

            // Validar NumericUpDown de cantidad
            if (nbCantidad.Value <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a cero", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nbCantidad.Focus();
                return false;
            }

            // Validar DataGridView (productos agregados)
            if (dataGridVentaProducto.Rows.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un producto a la venta", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Si el textbox tiene texto pero no hay cliente seleccionado
            if (!string.IsNullOrWhiteSpace(tbClientes.Text) && clienteSeleccionado == null)
            {
                var respuesta = MessageBox.Show("El cliente no está registrado. ¿Desea registrarlo ahora?","Cliente no registrado",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    using (var frmRegClientes = new FrmRegClientes())
                    {
                        if (frmRegClientes.ShowDialog() == DialogResult.OK)
                        {
                            clienteSeleccionado = clienteNeg.ObtenerClientePorId(frmRegClientes.ClienteRegistradoId);
                            tbClientes.Text = clienteSeleccionado?.NombreCompleto ?? "Nuevo cliente";
                        }
                        else
                        {
                            tbClientes.Text = string.Empty;
                            return false;
                        }
                    }
                }
                else
                {
                    tbClientes.Text = string.Empty;
                }
            }
            return true;
        }

        private void ActualizarTotal()
        {
            decimal total = ventaNeg.CalcularTotalVenta(detallesVenta);
            lblTotalVenta.Text = $"Total: {total:C}";
        }

        private void CargarProductos()
        {
            try
            {
                // Obtener la lista de productos desde la capa de negocios
                List<Producto> productos = ventaNeg.ObtenerProductos();

                cbProductos.DataSource = productos;
                cbProductos.DisplayMember = "Nombre";  
                cbProductos.ValueMember = "Id_Prod";

                cbProductos.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cbProductos.AutoCompleteSource = AutoCompleteSource.ListItems;
                cbProductos.DropDownStyle = ComboBoxStyle.DropDown;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message);
            }
        }
        private void CargarTallasDisponibles()
        {
            try
            {
                List<int> tallas = productoNeg.ObtenerTallasDisponibles();
                var tallasUnicas = tallas.Distinct().ToList();

                cbTallasRegProd.DataSource = null;
                cbTallasRegProd.DataSource = tallasUnicas;
                cbTallasRegProd.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar tallas: " + ex.Message);
            }
        }

        private void Ventas_Load(object sender, EventArgs e)
        {
            
        }

        private void rbCliNuevo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCliNuevo.Checked && !ignorarMensajeCliente)
            {
                using (var frmRegClientes = new FrmRegClientes())
                {
                    if (frmRegClientes.ShowDialog() == DialogResult.OK)
                    {
                        // Obtener el ID del cliente recién registrado
                        int nuevoClienteId = frmRegClientes.ClienteRegistradoId;

                        if (nuevoClienteId > 0)
                        {
                            // Obtener los datos completos del cliente
                            clienteSeleccionado = clienteNeg.ObtenerClientePorId(nuevoClienteId);
                            tbClientes.Text = clienteSeleccionado?.NombreCompleto ?? "Nuevo cliente";
                        }
                    }
                }

                // Deseleccionar el RadioButton después de usar
                ignorarMensajeCliente = true;
                rbCliNuevo.Checked = false;
                ignorarMensajeCliente = false;
            }
        }

        private void rbCliAntiguo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCliAntiguo.Checked && !ignorarMensajeCliente)
            {
                AbrirVistaClientes();

                // Siempre deseleccionar después de cerrar el formulario
                ignorarMensajeCliente = true;
                rbCliAntiguo.Checked = false;
                ignorarMensajeCliente = false;
            }
        }

        private void AbrirVistaClientes()
        {
            using (var frmVistaClientes = new VistaClientes())
            {
                if (frmVistaClientes.ShowDialog() == DialogResult.OK &&
                    frmVistaClientes.ClienteSeleccionado != null)
                {
                    clienteSeleccionado = frmVistaClientes.ClienteSeleccionado;
                    tbClientes.Text = clienteSeleccionado.NombreCompleto;
                }
                else
                {
                    tbClientes.Text = string.Empty;
                    clienteSeleccionado = null;
                }
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            Reporte_de_ventas reporte_De_Ventas = new Reporte_de_ventas();
            reporte_De_Ventas.Show();
        }

        private void ActualizarDataGrid()
        {
            // Limpiar DataGridView y agregar los productos a mostrar
            dataGridVentaProducto.Rows.Clear();
            foreach (var detalle in detallesVenta)
            {
                dataGridVentaProducto.Rows.Add(
                    detalle.Producto.Id_Prod,
                    detalle.Producto.Nombre,
                    detalle.Producto.Talla.Descripcion,
                    detalle.Cantidad,
                    detalle.PrecioUnitario,
                    detalle.Cantidad * detalle.PrecioUnitario
                );
            }
        }

        private void btnAgregarRegProd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(cbProductos.SelectedItem is Producto productoSeleccionado) ||
                    !(cbTallasRegProd.SelectedItem is Talla tallaSeleccionada))
                {
                    MessageBox.Show("Debe seleccionar un producto y una talla válidos");
                    return;
                }

                int cantidad = (int)nbCantidad.Value;
                int stockDisponible = productoNeg.ObtenerStockPorProductoYTalla(
                    productoSeleccionado.Id_Prod,
                    tallaSeleccionada.Id_Talla);

                if (cantidad > stockDisponible)
                {
                    MessageBox.Show($"No hay suficiente stock. Stock disponible: {stockDisponible}");
                    return;
                }

                // Verificar si ya existe este producto con la misma talla en la venta
                var detalleExistente = detallesVenta.FirstOrDefault(d =>
                    d.Producto.Id_Prod == productoSeleccionado.Id_Prod &&
                    d.Producto.Talla.Id_Talla == tallaSeleccionada.Id_Talla);

                if (detalleExistente != null)
                {
                    // Si ya existe, actualizar la cantidad (si no supera el stock)
                    if (detalleExistente.Cantidad + cantidad > stockDisponible)
                    {
                        MessageBox.Show($"No hay suficiente stock para agregar más unidades. Stock disponible: {stockDisponible}");
                        return;
                    }
                    detalleExistente.Cantidad += cantidad;
                }
                else
                {
                    // Crear nuevo detalle
                    DetalleVenta detalle = new DetalleVenta
                    {
                        ProductoId = productoSeleccionado.Id_Prod,
                        Cantidad = cantidad,
                        PrecioUnitario = productoSeleccionado.Precio,
                        Producto = new Producto
                        {
                            Id_Prod = productoSeleccionado.Id_Prod,
                            Nombre = productoSeleccionado.Nombre,
                            Precio = productoSeleccionado.Precio,
                            Talla = tallaSeleccionada,
                            Stock = stockDisponible
                        }
                    };
                    detallesVenta.Add(detalle);
                }

                ActualizarDataGrid();
                ActualizarTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar producto: " + ex.Message);
            }
        }

        private void cbProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbProductos.SelectedItem is Producto productoSeleccionado)
            {
                try
                {
                    // Obtener tallas disponibles para el producto seleccionado
                    List<Talla> tallasDelProducto = productoNeg.ObtenerTallasPorProducto(productoSeleccionado.Id_Prod);

                    // Configurar el ComboBox de tallas
                    cbTallasRegProd.DataSource = null; // Limpiar primero
                    cbTallasRegProd.DataSource = tallasDelProducto;
                    cbTallasRegProd.DisplayMember = "Descripcion";  
                    cbTallasRegProd.ValueMember = "Id_Talla";       

                    // Seleccionar la primera talla por defecto si hay tallas disponibles
                    if (tallasDelProducto.Count > 0)
                    {
                        cbTallasRegProd.SelectedIndex = 0;
                    }
                    else
                    {
                        cbTallasRegProd.Text = "No hay tallas disponibles";
                        lblStockDisponible.Text = "Stock: 0";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar tallas: {ex.Message}");
                }
            }
        }

        private void btnEliminarRegProd_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada
            if (dataGridVentaProducto.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una fila para eliminar.");
                return;
            }

            // Obtener la fila seleccionada
            DataGridViewRow filaSeleccionada = dataGridVentaProducto.SelectedRows[0];

            int idProducto = Convert.ToInt32(filaSeleccionada.Cells["id_prod"].Value);
            int tallaProducto = Convert.ToInt32(filaSeleccionada.Cells["Talla"].Value);

            // Eliminar el detalle de la lista
            detallesVenta.RemoveAll(d =>
                d.Producto.Id_Prod == idProducto &&
                d.Producto.Talla.Id_Talla == tallaProducto);

            // Actualizar el DataGridView
            ActualizarDataGrid();
            MessageBox.Show("Producto eliminado de la venta.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ActualizarTotal();
        }
        private int ObtenerIdUsuario()
        {
            if (Sesion.EstaLogueado())
            {
                return Sesion.UsuarioActivo.IdUsuario;
            }
            else
            {
                throw new Exception("No hay un usuario logueado.");
            }
        }
        private void btnGuardarRegProd_Click(object sender, EventArgs e)
        {
            if (!ValidarControles()) return;

            try
            {
                int clienteId = 0;
                if (!string.IsNullOrWhiteSpace(tbClientes.Text))
                {
                    if (clienteSeleccionado == null)
                    {
                        // Preguntar si desea registrar un nuevo cliente
                        var respuesta = MessageBox.Show("¿Desea registrar este cliente antes de continuar?",
                                                     "Cliente no registrado",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question);

                        if (respuesta == DialogResult.Yes)
                        {
                            using (var frmRegClientes = new FrmRegClientes())
                            {
                                if (frmRegClientes.ShowDialog() == DialogResult.OK)
                                {
                                    clienteSeleccionado = clienteNeg.ObtenerClientePorId(frmRegClientes.ClienteRegistradoId);
                                    tbClientes.Text = clienteSeleccionado.NombreCompleto;
                                    clienteId = clienteSeleccionado.Id;
                                }
                                else
                                {
                                    return;
                                }
                            }
                        }
                    }
                    else
                    {
                        clienteId = clienteSeleccionado.Id;
                    }
                }

                //Validar que hay productos en la venta
                if (detallesVenta == null || detallesVenta.Count == 0)
                    throw new Exception("Debe agregar al menos un producto al detalle de la venta.");

                //Crear y registrar la venta
                Venta venta = new Venta
                {
                    ClienteId = clienteId,
                    Detalles = detallesVenta,
                    Fecha = DateTime.Now
                };

                int idUsuario = ObtenerIdUsuario();
                ventaNeg.RegistrarVentaConDetalles(venta, idUsuario);

                MessageBox.Show("Venta registrada exitosamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Manejar el pago
                string input = Microsoft.VisualBasic.Interaction.InputBox("¿Con cuánto pagó el cliente?", "", "");
                if (!decimal.TryParse(input, out montoPagado))
                {
                    MessageBox.Show("Monto inválido. No se imprimirá el ticket.");
                    return;
                }

                //Imprimir ticket
                printDocumentVenta = new PrintDocument();
                printDocumentVenta.PrintPage += Imprimir;
                printDocumentVenta.Print();

                //Mostrar vista previa y limpiar controles
                ImprimirTicketConVistaPrevia();
                detallesVenta.Clear();
                ActualizarDataGrid();
                LimpiarControles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la venta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ImprimirTicketConVistaPrevia()
        {
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += new PrintPageEventHandler(Imprimir);

            PrintPreviewDialog vistaPrevia = new PrintPreviewDialog();
            vistaPrevia.Document = doc;
            vistaPrevia.ShowDialog();
        }
        private void Imprimir(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            if (clienteSeleccionado == null)
            {
                MessageBox.Show("No hay cliente seleccionado para imprimir el ticket.", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.HasMorePages = false;
                return;
            }

            string nombreCliente = clienteSeleccionado.NombreCompleto;
            int idCliente = clienteSeleccionado.Id;

            Graphics g = e.Graphics;
            Font monoFont = new Font("Courier New", 12);
            int yPos = 30;

            g.DrawString("Lucy´s Collections", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, 100, yPos); yPos += 30;

            g.DrawString($"Ticket: #{ventaNeg.ObtenerNumeroTicket().ToString("D5")}", monoFont, Brushes.Black, 10, yPos);
            yPos += 20;
            g.DrawString($"Fecha: {DateTime.Now:dd/MM/yyyy}", monoFont, Brushes.Black, 10, yPos);
            yPos += 20;
            g.DrawString($"Hora: {DateTime.Now:HH:mm:ss}", monoFont, Brushes.Black, 10, yPos);
            yPos += 30;
            g.DrawString("NIT: 0614-080322-115-2", monoFont, Brushes.Black, 10, yPos); yPos += 20;
            g.DrawString("NRC: 316440-2", monoFont, Brushes.Black, 10, yPos); yPos += 20;
            g.DrawString("Dirección: Avenida 5 de noviembre, Atiquizaya, Ahuachapán", monoFont, Brushes.Black, 10, yPos); yPos += 30;

            //Datos del cliente//
            g.DrawString("Cliente:", new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, 10, yPos); yPos += 30;
            g.DrawString($"Nombre: {nombreCliente}", monoFont, Brushes.Black, 10, yPos); yPos += 20;
            //g.DrawString($"ID Cliente: {idCliente}", monoFont, Brushes.Black, 10, yPos); yPos += 20;
            g.DrawString($"Fecha Registro: {clienteSeleccionado.FechaRegistro:dd/MM/yyyy}", monoFont, Brushes.Black, 10, yPos); yPos += 30;



            g.DrawString("Productos:", new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, 10, yPos += 20);
            yPos += 30;

            // Cabeza de la tablita 
            string encabezado = string.Format("{0,-15} | {1,8} | {2,8} | {3,10}", "Producto", "Precio", "Cantidad", "Sub Total");
            g.DrawString(encabezado, monoFont, Brushes.Black, 10, yPos += 20);
            yPos += 20;

            // Información de los productos 
            foreach (var item in detallesVenta)
            {
                string linea = string.Format("{0,-15} | {1,8:C} | {2,8} | {3,10:C}",
                item.Producto.Nombre.Length > 15 ? item.Producto.Nombre.Substring(0, 15) : item.Producto.Nombre,
                item.PrecioUnitario,
                item.Cantidad,
                item.Cantidad * item.PrecioUnitario);
                g.DrawString(linea, monoFont, Brushes.Black, 10, yPos += 20);
                yPos += 30;
            }

            // Total
            decimal totalVenta = detallesVenta.Sum(d => d.PrecioUnitario * d.Cantidad);
            g.DrawString($"Total: {totalVenta:C}", monoFont, Brushes.Black, 10, yPos += 25);
            yPos += 20;

            //Pago y cambio//
            if (montoPagado >= totalVenta)
            {
                decimal cambio = montoPagado - totalVenta;
                g.DrawString($"Pago con: {montoPagado:C}", monoFont, Brushes.Black, 10, yPos);
                yPos += 20;
                g.DrawString($"Cambio: {cambio:C}", monoFont, Brushes.Black, 10, yPos);
                yPos += 20;
            }
            else
            {
                g.DrawString("Monto insuficiente para completar la compra.", monoFont, Brushes.Black, 10, yPos);
                yPos += 30;
            }
            g.DrawString("¡Gracias por su compra!", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, 80, yPos += 30);

        }
        private bool ignorarMensajeCliente = false;

        private void SeleccionarClientePorId(int clienteId)
        {
            try
            {
                // Obtener el cliente por ID usando la capa de negocio
                clienteSeleccionado = clienteNeg.ObtenerClientePorId(clienteId);

                if (clienteSeleccionado != null)
                {
                    // Mostrar el nombre del cliente en el TextBox
                    tbClientes.Text = clienteSeleccionado.NombreCompleto;
                    tbClientes.Visible = true;

                    // Actualizar solo el RadioButton si es necesario
                    if (rbCliAntiguo.Checked)
                    {
                        rbCliAntiguo.Checked = false;
                    }
                }
                else
                {
                    Debug.WriteLine($"Cliente con ID {clienteId} no encontrado");
                    tbClientes.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error seleccionando cliente: {ex.Message}");
                tbClientes.Text = "Error al cargar cliente";
            }
        }

        private void btnCancelarRegProd_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbTallasRegProd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTallasRegProd.SelectedItem is Talla tallaSeleccionada &&
                    cbProductos.SelectedItem is Producto productoSeleccionado)
            {
                try
                {
                    // Obtener el stock disponible
                    int stockDisponible = productoNeg.ObtenerStockPorProductoYTalla(
                        productoSeleccionado.Id_Prod,
                        tallaSeleccionada.Id_Talla);

                    // Actualizar la etiqueta de stock
                    lblStockDisponible.Text = $"Stock: {stockDisponible}";

                    // Configurar el NumericUpDown
                    nbCantidad.Minimum = 1; // Mínimo siempre 1
                    nbCantidad.Maximum = stockDisponible > 0 ? stockDisponible : 1; // Máximo según stock
                    nbCantidad.Value = stockDisponible > 0 ? 1 : 0; // Valor inicial

                    bool hayStock = stockDisponible > 0;
                    nbCantidad.Enabled = hayStock;
                    btnAgregarRegProd.Enabled = hayStock;

                    if (!hayStock)
                    {
                        MessageBox.Show("No hay stock disponible para esta talla", "Stock",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar stock: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    nbCantidad.Minimum = 1;
                    nbCantidad.Maximum = 100; 
                    nbCantidad.Value = 1;
                }
            }
            else
            {
                // Resetear valores
                nbCantidad.Minimum = 1;
                nbCantidad.Maximum = 100;
                nbCantidad.Value = 1;
                lblStockDisponible.Text = "Stock: 0";
            }
        }

        private void btnTodosProductos_Click(object sender, EventArgs e)
        {
            using (var frm = new VistaProductos())
            {
                frm.ProductoSeleccionado += producto =>
                {
                    if (producto != null)
                    {
                        // Verificar si el producto ya existe en el ComboBox
                        bool productoExiste = false;
                        if (cbProductos.DataSource is List<Producto> listaProductos)
                        {
                            productoExiste = listaProductos.Any(p => p.Id_Prod == producto.Id_Prod);
                        }

                        if (!productoExiste)
                        {
                            // Actualizar la lista de productos
                            var nuevaLista = new List<Producto>();
                            if (cbProductos.DataSource != null)
                            {
                                nuevaLista = ((List<Producto>)cbProductos.DataSource).ToList();
                            }
                            nuevaLista.Add(producto);

                            // Actualizar el ComboBox
                            cbProductos.DataSource = null;
                            cbProductos.DataSource = nuevaLista;
                            cbProductos.DisplayMember = "Nombre";
                            cbProductos.ValueMember = "Id_Prod";
                        }

                        // Seleccionar el producto recién agregado
                        cbProductos.SelectedValue = producto.Id_Prod;

                        // Cargar las tallas para el producto seleccionado
                        CargarTallasParaProductoSeleccionado(producto);
                    }
                };

                frm.ShowDialog();
            }
        }

        private void CargarTallasParaProductoSeleccionado(Producto producto)
        {
            if (producto != null)
            {
                try
                {
                    cbTallasRegProd.SelectedIndexChanged -= cbTallasRegProd_SelectedIndexChanged;

                    // Obtener tallas para el producto seleccionado
                    List<Talla> tallasDelProducto = productoNeg.ObtenerTallasPorProducto(producto.Id_Prod);

                    // Actualizar el ComboBox de tallas
                    cbTallasRegProd.DataSource = tallasDelProducto;
                    cbTallasRegProd.DisplayMember = "Descripcion";
                    cbTallasRegProd.ValueMember = "Id_Talla";

                    if (tallasDelProducto.Count > 0)
                    {
                        cbTallasRegProd.SelectedIndex = 0;
                    }

                    cbTallasRegProd.SelectedIndexChanged += cbTallasRegProd_SelectedIndexChanged;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar tallas: {ex.Message}");
                }
            }
        }
    }
}
