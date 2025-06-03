using System.Diagnostics;
using System.Drawing.Printing;
using System.Windows.Forms;
using C_Datos;
using C_Entidades;
using C_Negocios;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Globalization;

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
        private Cliente? clienteSeleccionado;
        private decimal montoPagadoGlobal;
        private decimal totalVentaGlobal;
        private decimal cambioGlobal;

        public Ventas(int clienteId = 0)
        {
            InitializeComponent();

            ignorarMensajeCliente = true;

            detallesVenta = new List<DetalleVenta>();
            ventaNeg = new VentaNeg();
            ActualizarDataGrid();
            CargarProductos();
            CargarTallasDisponibles();

            cbProductos.SelectedIndex = -1;
            btnAgregarRegProd.Enabled = false;
            btnGuardarRegProd.Enabled = false;
            btnEliminarRegProd.Enabled = false;
            cbTallasRegProd.Enabled = false;
            nbCantidad.Enabled = false;

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
            tbClientes.Text = string.Empty;
            lblStockDisponible.Text = "Stock: 0";

            ActualizarTotal();
        }

        private bool ValidarAgregarProducto()
        {
            // Validar producto seleccionado
            if (cbProductos.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un producto", "Validación",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbProductos.Focus();
                return false;
            }

            // Validar talla seleccionada
            if (cbTallasRegProd.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar una talla", "Validación",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbTallasRegProd.Focus();
                return false;
            }

            // Validar cantidad
            if (nbCantidad.Value <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a cero", "Validación",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nbCantidad.Focus();
                return false;
            }

            return true;
        }

        private bool ValidarGuardarVenta()
        {
            //Validar productos en la venta
            if (detallesVenta == null || detallesVenta.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un producto a la venta.",
                               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //Validación del cliente (según estado del TextBox)
            if (tbClientes.Visible && string.IsNullOrWhiteSpace(tbClientes.Text))
            {
                MessageBox.Show("Debe ingresar o seleccionar un cliente.",
                               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //Si hay texto en tbClientes pero no hay cliente seleccionado
            if (!string.IsNullOrWhiteSpace(tbClientes.Text) && clienteSeleccionado == null)
            {
                var respuesta = MessageBox.Show("El cliente no está registrado. ¿Desea registrarlo ahora?",
                                              "Cliente no válido",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    using (var frmRegClientes = new FrmRegClientes())
                    {
                        if (frmRegClientes.ShowDialog() == DialogResult.OK)
                        {
                            // Asignar el nuevo cliente
                            clienteSeleccionado = clienteNeg.ObtenerClientePorId(frmRegClientes.ClienteRegistradoId);
                            tbClientes.Text = clienteSeleccionado?.NombreCompleto ?? "Nuevo cliente";
                        }
                        else
                        {
                            MessageBox.Show("No se puede guardar la venta sin un cliente válido.",
                                           "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }
                else
                {
                    return false; 
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
                ignorarMensajeCliente = true;
                rbCliAntiguo.Checked = false;
                ignorarMensajeCliente = false;
            }
        }

        private void AbrirVistaClientes()
        {
            string rolUsuario = Sesion.UsuarioActivo?.Rol ?? "Empleado";
            using (var frmVistaClientes = new VistaClientes(rolUsuario))
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
                    clienteSeleccionado = null!;
                }
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            Reporte_de_ventas reporte_De_Ventas = new Reporte_de_ventas();
            reporte_De_Ventas.ShowDialog();
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
            if (!ValidarAgregarProducto()) return;

            try
            {
                if (!(cbProductos.SelectedItem is Producto productoSeleccionado) ||
                    !(cbTallasRegProd.SelectedItem is Talla tallaSeleccionada))
                {
                    MessageBox.Show("Debe seleccionar un producto y una talla válidos");
                    return;
                }

                int cantidad = (int)nbCantidad.Value;

                // Obtener lista de variantes del producto con stock por nombre
                var productosConStock = productoNeg.ObtenerProductosConTallasYStockPorNombre(productoSeleccionado.Nombre.Trim());

                Debug.WriteLine($"Productos con stock para '{productoSeleccionado.Nombre}': {productosConStock.Count}");
                foreach (var p in productosConStock)
                {
                    Debug.WriteLine($"ProductoId: {p.Id_Prod}, Nombre: {p.Nombre}, TallaId: {p.Talla.Id_Talla}, Stock: {p.Stock}");
                }

                // Buscar el producto con ID único que coincida con la talla seleccionada
                var productoConStock = productosConStock.FirstOrDefault(p =>
                    p.Talla.Id_Talla == tallaSeleccionada.Id_Talla);

                if (productoConStock == null)
                {
                    MessageBox.Show("No se encontró stock disponible para el producto y talla seleccionados.");
                    return;
                }

                int stockDisponible = productoConStock.Stock;

                if (cantidad > stockDisponible)
                {
                    MessageBox.Show($"No hay suficiente stock. Stock disponible: {stockDisponible}");
                    return;
                }

                // Verificar si ya existe este producto con esa talla exacta en los detalles
                var detalleExistente = detallesVenta.FirstOrDefault(d =>
                    d.ProductoId == productoConStock.Id_Prod);

                if (detalleExistente != null)
                {
                    // Si ya existe, sumar cantidad (si no supera el stock)
                    if (detalleExistente.Cantidad + cantidad > stockDisponible)
                    {
                        MessageBox.Show($"No hay suficiente stock para agregar más unidades. Stock disponible: {stockDisponible}");
                        return;
                    }
                    detalleExistente.Cantidad += cantidad;
                }
                else
                {
                    // Crear nuevo detalle con el ID único de ese producto+talla
                    DetalleVenta detalle = new DetalleVenta
                    {
                        ProductoId = productoConStock.Id_Prod,
                        Cantidad = cantidad,
                        PrecioUnitario = productoConStock.Precio,
                        Producto = new Producto
                        {
                            Id_Prod = productoConStock.Id_Prod,
                            Nombre = productoConStock.Nombre,
                            Precio = productoConStock.Precio,
                            Talla = productoConStock.Talla,
                            Stock = stockDisponible
                        }
                    };
                    detallesVenta.Add(detalle);
                }

                ActualizarDataGrid();
                LimpiarControles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar producto: " + ex.Message);
                Debug.WriteLine("Error en btnAgregarRegProd_Click: " + ex.ToString());
            }
        }

        private void cbProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbProductos.SelectedItem is Producto productoSeleccionado)
            {
                btnAgregarRegProd.Enabled = true;
                btnEliminarRegProd.Enabled = true;
                cbTallasRegProd.Enabled = true;
                nbCantidad.Enabled = true;

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
                        btnGuardarRegProd.Enabled = true;
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

            // Obtener el ID del producto
            int idProducto = Convert.ToInt32(filaSeleccionada.Cells["id_prod"].Value);

            // Obtener la descripción de la talla (asumiendo que es lo que se muestra)
            string descripcionTalla = filaSeleccionada.Cells["Talla"].Value.ToString();

            // Eliminar el detalle de la lista
            detallesVenta.RemoveAll(d =>
                d.Producto.Id_Prod == idProducto &&
                d.Producto.Talla.Descripcion == descripcionTalla);

            // Actualizar el DataGridView
            ActualizarDataGrid();
            MessageBox.Show("Producto eliminado de la venta.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ActualizarTotal();
        }
        private int ObtenerIdUsuario()
        {
            if (Sesion.EstaLogueado() && Sesion.UsuarioActivo != null)
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
            Debug.WriteLine($"Número de productos en detallesVenta: {detallesVenta.Count}");
            if (!ValidarGuardarVenta()) return;

            try
            {
                int clienteId = 0;
                if (!string.IsNullOrWhiteSpace(tbClientes.Text))
                {
                    if (clienteSeleccionado == null)
                    {
                        var respuesta = MessageBox.Show(
                            "¿Desea registrar este cliente antes de continuar?",
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

                if (detallesVenta == null || detallesVenta.Count == 0)
                    throw new Exception("Debe agregar al menos un producto al detalle de la venta.");

                // Calcular total
                decimal totalVenta = detallesVenta.Sum(d => d.PrecioUnitario * d.Cantidad);

                // Solicitar pago
                if (!SolicitarPagoConCambio(totalVenta, out decimal montoPagado, out decimal cambio))
                {
                    return; // Si el usuario cancela el pago
                }

                // Guardar valores globales para imprimir
                montoPagadoGlobal = montoPagado;
                totalVentaGlobal = totalVenta;
                cambioGlobal = cambio;

                // Registrar la venta
                Venta venta = new Venta
                {
                    ClienteId = clienteId,
                    Detalles = detallesVenta,
                    Fecha = DateTime.Now
                };

                int idUsuario = ObtenerIdUsuario();
                ventaNeg.RegistrarVentaConDetalles(venta, idUsuario);

                // Obtener ruta para guardar el comprobante
                string carpetaDestino = ObtenerRutaGuardadoTickets();
                DateTime fechaHoraActual = DateTime.Now;
                string marcaTiempo = fechaHoraActual.ToString("ddMMyyyy_HHmmss");
                string nombreArchivo = $"Comprobante_{marcaTiempo}.pdf";
                string rutaCompleta = Path.Combine(carpetaDestino, nombreArchivo);

                // Generar PDF (usar variables globales)
                GenerarComprobantePDF(rutaCompleta, fechaHoraActual, marcaTiempo, totalVentaGlobal, montoPagadoGlobal, cambioGlobal);

                MessageBox.Show(
                    $"Venta registrada exitosamente.\n\n" +
                    $"Total: {totalVentaGlobal:C}\n" +
                    $"Monto recibido: {montoPagadoGlobal:C}\n" +
                    $"Cambio: {cambioGlobal:C}\n\n" +
                    $"Comprobante guardado en:\n{rutaCompleta}",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                // Mostrar vista previa y limpiar
                ImprimirTicketConVistaPrevia();
                detallesVenta.Clear();
                ActualizarDataGrid();
                LimpiarControles();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la venta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool SolicitarPagoConCambio(decimal totalVenta, out decimal montoPagado, out decimal cambio)
        {
            montoPagado = 0;
            cambio = 0;
            string input;
            decimal tolerancia = 0.01m;

            do
            {
                input = Microsoft.VisualBasic.Interaction.InputBox(
                    $"=== DETALLE DE PAGO ===\n\n" +
                    $"Total a pagar: {totalVenta:C}\n" +
                    $"Ingrese el monto recibido:\n\n" +
                    $"{(montoPagado > 0 ? $"Cambio: {cambio:C}\n" : "")}",
                    "Registrar Pago",
                    montoPagado > 0 ? montoPagado.ToString("0.00") : "");

                if (string.IsNullOrEmpty(input))
                {
                    MessageBox.Show("Pago cancelado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                if (!decimal.TryParse(input, NumberStyles.Currency, CultureInfo.CurrentCulture, out montoPagado))
                {
                    MessageBox.Show("Formato inválido. Use solo números.\nEjemplo: 150.50", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }

                if (montoPagado <= 0)
                {
                    MessageBox.Show("El monto debe ser mayor a cero.", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }

                cambio = Math.Round(montoPagado, 2) - Math.Round(totalVenta, 2);
                Debug.WriteLine($"montoPagado: {montoPagado}");
                Debug.WriteLine($"totalVenta: {totalVenta}");
                Debug.WriteLine($"cambio calculado: {cambio}");

                if (cambio < -tolerancia)
                {
                    MessageBox.Show($"Monto insuficiente. Faltan {Math.Abs(cambio):C}", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    continue;
                }

                break;
            } while (true);

            return true;
        }

        // Métodos auxiliares adicionales
        private string ObtenerRutaGuardadoTickets()
        {
            string rutaBase = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                "LucyCollections", "Tickets");

            try
            {
                if (!Directory.Exists(rutaBase))
                {
                    Directory.CreateDirectory(rutaBase);
                }
                return rutaBase;
            }
            catch (UnauthorizedAccessException)
            {
                rutaBase = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    "LucyCollectionsTickets");

                if (!Directory.Exists(rutaBase))
                {
                    Directory.CreateDirectory(rutaBase);
                }
                return rutaBase;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo acceder a las ubicaciones estándar: {ex.Message}\nSe usará directorio temporal.",
                               "Advertencia",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);

                rutaBase = Path.Combine(Path.GetTempPath(), "LucyCollectionsTickets");
                if (!Directory.Exists(rutaBase))
                {
                    Directory.CreateDirectory(rutaBase);
                }
                return rutaBase;
            }
        }

        private void GenerarComprobantePDF(string rutaCompleta, DateTime fechaHoraActual, string marcaTiempo, decimal totalVenta, decimal montoPagado, decimal cambio)
        {
            BaseColor lightGray = new BaseColor(211, 211, 211);
            BaseColor orange = new BaseColor(255, 165, 0);     

            using (FileStream fs = new FileStream(rutaCompleta, FileMode.Create))
            {
                Document doc = new Document(PageSize.A4, 10, 10, 10, 10);
                PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                doc.Open();

                // Encabezado
                doc.Add(new Paragraph("Lucy´s Collections", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16)));
                doc.Add(new Paragraph($"Fecha: {fechaHoraActual:dd/MM/yyyy}    Hora: {fechaHoraActual:HH:mm:ss}"));
                doc.Add(new Paragraph("NIT: 0614-080322-115-2    NRC: 316440-2"));
                doc.Add(new Paragraph("Dirección: Avenida 5 de noviembre, Atiquizaya, Ahuachapán"));
                doc.Add(new Paragraph("\n"));

                if (clienteSeleccionado != null)
                {
                    doc.Add(new Paragraph($"Cliente: {clienteSeleccionado.NombreCompleto}"));
                    doc.Add(new Paragraph($"Fecha de Registro: {clienteSeleccionado.FechaRegistro:dd/MM/yyyy}"));
                    doc.Add(new Paragraph("\n"));
                }

                // Tabla de productos
                PdfPTable tabla = new PdfPTable(4);
                tabla.WidthPercentage = 100;

                // Agregar encabezados con fondo gris claro
                var headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
                string[] headers = { "Producto", "Precio", "Cantidad", "Subtotal" };
                foreach (var header in headers)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(header, headerFont));
                    cell.BackgroundColor = lightGray;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    tabla.AddCell(cell);
                }

                foreach (var item in detallesVenta)
                {
                    string nombreProd = item.Producto.Nombre.Length > 15 ? item.Producto.Nombre.Substring(0, 15) : item.Producto.Nombre;
                    tabla.AddCell(new PdfPCell(new Phrase(nombreProd)));
                    tabla.AddCell(new PdfPCell(new Phrase(item.PrecioUnitario.ToString("C"))) { HorizontalAlignment = Element.ALIGN_RIGHT });
                    tabla.AddCell(new PdfPCell(new Phrase(item.Cantidad.ToString())) { HorizontalAlignment = Element.ALIGN_CENTER });
                    decimal subtotal = item.PrecioUnitario * item.Cantidad;
                    tabla.AddCell(new PdfPCell(new Phrase(subtotal.ToString("C"))) { HorizontalAlignment = Element.ALIGN_RIGHT });
                }

                doc.Add(tabla);
                doc.Add(new Paragraph("\n"));
                doc.Add(new Paragraph($"Total: {totalVenta:C}", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)));

                // Información de pago
                if (montoPagado < totalVenta)
                {
                    doc.Add(new Paragraph("¡Monto insuficiente!", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, orange)));
                    doc.Add(new Paragraph($"Pagó con: {montoPagado:C}"));
                }
                else
                {
                    doc.Add(new Paragraph($"Pagó con: {montoPagado:C}"));
                    doc.Add(new Paragraph($"Cambio: {cambio:C}"));
                }

                // Pie de comprobante
                doc.Add(new Paragraph("\n"));
                doc.Add(new Paragraph($"N° Comprobante: {marcaTiempo}"));
                doc.Add(new Paragraph("¡Gracias por su compra!", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)));

                doc.Close();
            }
        }



        private void ImprimirTicketConVistaPrevia()
        {
            PrintDocument doc = new PrintDocument();

            // Establecer tamaño personalizado tipo ticket (80mm x 300mm)
            PaperSize ticketSize = new PaperSize("Ticket", 315, 1181); // 3.15in x 11.81in
            doc.DefaultPageSettings.PaperSize = ticketSize;
            doc.DefaultPageSettings.Margins = new Margins(5, 5, 5, 5); // márgenes pequeños

            doc.PrintPage += new PrintPageEventHandler(Imprimir);

            PrintPreviewDialog vistaPrevia = new PrintPreviewDialog
            {
                Document = doc,
                Width = 600,
                Height = 800
            };

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

            if (e.Graphics == null)
            {
                MessageBox.Show("Error al obtener el objeto Graphics para imprimir.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.HasMorePages = false;
                return;
            }

            Graphics g = e.Graphics;

            using (var monoFont = new System.Drawing.Font("Courier New", 9))
            using (var boldFont = new System.Drawing.Font("Courier New", 9, FontStyle.Bold))
            using (var headerFont = new System.Drawing.Font("Arial", 12, FontStyle.Bold))
            {
                int leftMargin = 10;
                int yPos = 10;

                // Encabezado
                g.DrawString("Lucy´s Collections", headerFont, Brushes.Black, leftMargin, yPos);
                yPos += 25;

                g.DrawString($"Ticket: #{ventaNeg.ObtenerNumeroTicket():D5}", monoFont, Brushes.Black, leftMargin, yPos);
                yPos += 15;
                g.DrawString($"Fecha: {DateTime.Now:dd/MM/yyyy}", monoFont, Brushes.Black, leftMargin, yPos);
                yPos += 15;
                g.DrawString($"Hora: {DateTime.Now:HH:mm:ss}", monoFont, Brushes.Black, leftMargin, yPos);
                yPos += 20;

                g.DrawString("NIT: 0614-080322-115-2", monoFont, Brushes.Black, leftMargin, yPos);
                yPos += 15;
                g.DrawString("NRC: 316440-2", monoFont, Brushes.Black, leftMargin, yPos);
                yPos += 15;

                g.DrawString("Dirección:", monoFont, Brushes.Black, leftMargin, yPos);
                yPos += 15;
                g.DrawString("Av. 5 de nov.,", monoFont, Brushes.Black, leftMargin + 10, yPos);
                yPos += 15;
                g.DrawString("Atiquizaya, Ahuachapán", monoFont, Brushes.Black, leftMargin + 10, yPos);
                yPos += 20;

                // Cliente
                g.DrawString("Cliente:", boldFont, Brushes.Black, leftMargin, yPos);
                yPos += 20;
                g.DrawString($"Nombre: {nombreCliente}", monoFont, Brushes.Black, leftMargin, yPos);
                yPos += 15;
                g.DrawString($"Registro: {clienteSeleccionado.FechaRegistro:dd/MM/yyyy}", monoFont, Brushes.Black, leftMargin, yPos);
                yPos += 20;

                // Productos
                g.DrawString("Productos:", boldFont, Brushes.Black, leftMargin, yPos);
                yPos += 20;
                g.DrawString("Producto       P.Unit  Cant Subtotal", monoFont, Brushes.Black, leftMargin, yPos);
                yPos += 15;

                foreach (var item in detallesVenta)
                {
                    string nombreProd = item.Producto.Nombre.Length > 12
                        ? item.Producto.Nombre.Substring(0, 12)
                        : item.Producto.Nombre;

                    string linea = string.Format("{0,-12} {1,6:C} {2,5} {3,8:C}",
                        nombreProd,
                        item.PrecioUnitario,
                        item.Cantidad,
                        item.Cantidad * item.PrecioUnitario);

                    g.DrawString(linea, monoFont, Brushes.Black, leftMargin, yPos);
                    yPos += 15;
                }

                yPos += 10;
                g.DrawString($"Total: {totalVentaGlobal:C}", boldFont, Brushes.Black, leftMargin, yPos);
                yPos += 20;

                if (montoPagadoGlobal >= totalVentaGlobal)
                {
                    g.DrawString($"Pago con: {montoPagadoGlobal:C}", monoFont, Brushes.Black, leftMargin, yPos);
                    yPos += 15;
                    g.DrawString($"Cambio: {cambioGlobal:C}", monoFont, Brushes.Black, leftMargin, yPos);
                    yPos += 15;
                }
                else
                {
                    g.DrawString("Monto insuficiente.", monoFont, Brushes.Black, leftMargin, yPos);
                    yPos += 20;
                }

                yPos += 10;
                g.DrawString("¡Gracias por su compra!", boldFont, Brushes.Black, leftMargin + 30, yPos);
            }

            e.HasMorePages = false;
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
            DialogResult resultado = MessageBox.Show(
                "¿Estás seguro que deseas cancelar esta VENTA?",
                "Confirmar cancelación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void cbTallasRegProd_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cbTallasRegProd.SelectedItem is Talla tallaSeleccionada &&
        cbProductos.SelectedItem is Producto productoSeleccionado)
            {
                try
                {
                    // Obtener lista actualizada de productos con tallas y stock para ese nombre
                    var productosConStock = productoNeg.ObtenerProductosConTallasYStockPorNombre(productoSeleccionado.Nombre);

                    // Buscar el stock para la talla seleccionada
                    int stockDisponible = productosConStock
                        .FirstOrDefault(p => p.Talla.Id_Talla == tallaSeleccionada.Id_Talla)?.Stock ?? 0;

                    // Verificar si hay stock en alguna talla
                    bool hayStockEnAlgunaTalla = productosConStock.Any();

                    // Actualizar UI
                    ActualizarControlesStock(stockDisponible, hayStockEnAlgunaTalla);
                }
                catch (Exception ex)
                {
                    ManejarErrorStock(ex);
                }
            }
            else
            {
                ResetearControlesStock();
            }
        }

        private void ActualizarControlesStock(int stockDisponible, bool hayStockEnAlgunaTalla)
        {
            // Actualizar etiqueta
            lblStockDisponible.Text = stockDisponible > 0
                ? $"Stock: {stockDisponible}"
                : "Stock: 0 (Agotado)";

            // Configurar NumericUpDown
            nbCantidad.Minimum = 1;
            nbCantidad.Maximum = Math.Max(stockDisponible, 1);
            nbCantidad.Value = stockDisponible > 0 ? Math.Min(nbCantidad.Value, nbCantidad.Maximum) : 1;

            // Habilitar/deshabilitar controles
            bool hayStock = stockDisponible > 0;
            nbCantidad.Enabled = hayStock;
            btnAgregarRegProd.Enabled = hayStock;

            // Mostrar mensajes
            if (!hayStockEnAlgunaTalla)
            {
                MessageBox.Show("No hay stock disponible para este producto en ninguna talla",
                              "Stock Agotado",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);
            }
        }

        private void ManejarErrorStock(Exception ex)
        {
            MessageBox.Show($"Error al actualizar stock: {ex.Message}",
                          "Error",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error);
            ResetearControlesStock();
        }

        private void ResetearControlesStock()
        {
            nbCantidad.Minimum = 1;
            nbCantidad.Maximum = 100;
            nbCantidad.Value = 1;
            lblStockDisponible.Text = "Stock: 0";
            nbCantidad.Enabled = false;
            btnAgregarRegProd.Enabled = false;
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
            if (producto == null) return;

            try
            {
                cbTallasRegProd.BeginUpdate();
                cbTallasRegProd.SelectedIndexChanged -= cbTallasRegProd_SelectedIndexChanged;

                // Usar método nuevo que ya filtra por stock y tallas del producto
                var productosConStock = productoNeg.ObtenerProductosConTallasYStockPorNombre(producto.Nombre);

                // Obtener las tallas únicas de esos productos (con stock > 0)
                var tallasConStock = productosConStock
                    .Select(p => p.Talla)
                    .Distinct()
                    .OrderBy(t => t.Id_Talla)
                    .ToList();

                // Configurar ComboBox
                cbTallasRegProd.DataSource = null;
                cbTallasRegProd.Items.Clear();

                if (tallasConStock.Any())
                {
                    cbTallasRegProd.DataSource = tallasConStock;
                    cbTallasRegProd.DisplayMember = "Descripcion";
                    cbTallasRegProd.ValueMember = "Id_Talla";
                    cbTallasRegProd.SelectedIndex = 0;
                    btnGuardarRegProd.Enabled = true;

                    // Actualizar stock disponible para la talla seleccionada
                    var tallaSeleccionada = (Talla)cbTallasRegProd.SelectedItem;
                    lblStockDisponible.Text = "Stock: " + productosConStock
                        .FirstOrDefault(p => p.Talla.Id_Talla == tallaSeleccionada.Id_Talla)?.Stock.ToString() ?? "0";
                }
                else
                {
                    cbTallasRegProd.Text = "No hay tallas con stock";
                    lblStockDisponible.Text = "Stock: 0";
                    btnGuardarRegProd.Enabled = false;
                    ResetearControlesStock();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar tallas: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine(ex.ToString());
                ResetearControlesStock();
            }
            finally
            {
                cbTallasRegProd.EndUpdate();
                cbTallasRegProd.SelectedIndexChanged += cbTallasRegProd_SelectedIndexChanged;
            }
        }

        private void tbClientes_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
