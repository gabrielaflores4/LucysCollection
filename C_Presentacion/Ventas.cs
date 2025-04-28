using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
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
        private decimal montoPagado;  // Variable para almacenar el monto pagado


        public Ventas()
        {
            InitializeComponent();
            cbClientes.Visible = false;
            detallesVenta = new List<DetalleVenta>();
            ventaNeg = new VentaNeg();
            ActualizarDataGrid();
            CargarProductos();
            CargarTallasDisponibles(); // Cargar tallas disponibles
            idsClientes = clienteNeg.ObtenerIdsClientes();
            ultimoTicket = ventaDatos.ObtenerUltimoTicket();


        }

        private void LimpiarControles()
        {
            cbProductos.SelectedIndex = -1;
            cbTallasRegProd.SelectedIndex = -1;
            nbCantidad.Value = 1;
            rbCliNuevo.Checked = false;
            rbCliAntiguo.Checked = false;
            cbClientes.Visible = false;
            cbClientes.SelectedIndex = -1;
            dataGridVentaProducto.Rows.Clear();
            lblStockDisponible.Text = "Stock: 0";
            ActualizarTotal();
        }


        private bool ValidarControles()
        {
            // Validar ComboBoxes
            if (cbProductos.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbProductos.Focus();
                return false;
            }

            if (cbTallasRegProd.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar una talla", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbTallasRegProd.Focus();
                return false;
            }

            if (cbClientes.Visible && cbClientes.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un cliente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbClientes.Focus();
                return false;
            }

            // Validar NumericUpDown
            if (nbCantidad.Value <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a cero", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nbCantidad.Focus();
                return false;
            }

            // Validar RadioButtons (solo si son obligatorios)
            if (!rbCliNuevo.Checked && !rbCliAntiguo.Checked)
            {
                MessageBox.Show("Debe seleccionar un tipo de cliente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validar DataGridView
            if (dataGridVentaProducto.Rows.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un producto a la venta", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
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
                cbProductos.DisplayMember = "Nombre";  // Mostrar el nombre del producto
                cbProductos.ValueMember = "Id_Prod";   // Usar el ID del producto como valor asociado
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
            CargarClientes();
        }

        private void rbCliNuevo_CheckedChanged(object sender, EventArgs e)
        {
            FrmRegClientes frmRegClientes = new FrmRegClientes();
            frmRegClientes.Show();
        }

        private void rbCliAntiguo_CheckedChanged(object sender, EventArgs e)
        {
            cbClientes.Visible = true;
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
                    detalle.Producto.Talla,  // Mostrar la talla
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
                Producto productoSeleccionado = (Producto)cbProductos.SelectedItem;
                int cantidad = (int)nbCantidad.Value;

                // Verificar si ya existe este producto con la misma talla en la venta
                bool tallaRepetida = detallesVenta.Any(d =>
                    d.Producto.Id_Prod == productoSeleccionado.Id_Prod &&
                    d.Producto.Talla == productoSeleccionado.Talla);

                if (tallaRepetida)
                {
                    MessageBox.Show("¡Este producto con la talla seleccionada ya fue agregado!");
                    return;
                }

                DetalleVenta detalle = new DetalleVenta
                {
                    ProductoId = productoSeleccionado.Id_Prod,
                    Cantidad = cantidad,
                    PrecioUnitario = productoSeleccionado.Precio,
                    Producto = productoSeleccionado
                };

                detallesVenta.Add(detalle);
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
                lblStockDisponible.Text = $"Stock: {productoSeleccionado.Stock}";

                //Obtener y cargar tallas disponibles para el producto seleccionado
                List<int> tallasDelProducto = productoNeg.ObtenerTallasPorProducto(productoSeleccionado.Id_Prod);
                cbTallasRegProd.DataSource = tallasDelProducto;
                cbTallasRegProd.SelectedIndex = -1; // Resetear selección



                //Configurar el NumericUpDown según el stock
                nbCantidad.Minimum = 1;
                nbCantidad.Maximum = productoSeleccionado.Stock;
                nbCantidad.Value = Math.Min(1, productoSeleccionado.Stock); // Tomar el menor entre 1 y el stock

                //Deshabilitar controles si no hay stock
                bool hayStock = productoSeleccionado.Stock > 0;
                nbCantidad.Enabled = hayStock;
                btnAgregarRegProd.Enabled = hayStock;
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
                d.Producto.Talla == tallaProducto);

            // Actualizar el DataGridView
            ActualizarDataGrid();
            MessageBox.Show("Producto eliminado de la venta.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ActualizarTotal();
        }

        private void btnGuardarRegProd_Click(object sender, EventArgs e)
        {
            if (!ValidarControles()) return;

            try
            {
                int clienteId = 0;

                if (rbCliAntiguo.Checked && cbClientes.SelectedItem != null)
                {
                    // Obtener el ID usando el índice seleccionado
                    int selectedIndex = cbClientes.SelectedIndex;

                    if (selectedIndex >= 0 && selectedIndex < idsClientes.Count)
                    {
                        clienteId = idsClientes[selectedIndex];
                    }
                    else
                    {
                        throw new Exception("Índice de cliente no válido");
                    }
                }

                else if (rbCliNuevo.Checked)
                {
                    // Llamar a la ventana de registro de cliente si se selecciona un cliente nuevo
                    FrmRegClientes frmRegClientes = new FrmRegClientes();
                    frmRegClientes.ShowDialog();
                }


                ventaNeg.RegistrarVenta(clienteId, detallesVenta);

                MessageBox.Show("Venta registrada exitosamente", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar después de registrar
                detallesVenta.Clear();
                ActualizarDataGrid();
                LimpiarControles();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            string input = Microsoft.VisualBasic.Interaction.InputBox("¿Con cuánto pagó el cliente?", "", "");

            // Valida que el valor ingresado sea un número válido
            if (decimal.TryParse(input, out decimal montoPagado))
            {
                // Guarda el monto pagado en una variable
                this.montoPagado = montoPagado;

                // Impresión del ticket//
                printDocumentVenta = new System.Drawing.Printing.PrintDocument();
                PrinterSettings printerSettings = new PrinterSettings();
                printDocumentVenta.PrinterSettings = printerSettings;
                printDocumentVenta.PrintPage += Imprimir;
                printDocumentVenta.Print();
            }
            else
            {
                MessageBox.Show("Por favor ingrese un monto válido.");
            }

            ImprimirTicketConVistaPrevia();
        }

        private void btnFacturaVenta_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("¿Con cuánto pagó el cliente?", "", "");

            // Valida que el valor ingresado sea un número válido
            if (decimal.TryParse(input, out decimal montoPagado))
            {
                // Guarda el monto pagado en una variable
                this.montoPagado = montoPagado;

                // Impresión del ticket//
                printDocumentVenta = new System.Drawing.Printing.PrintDocument();
                PrinterSettings printerSettings = new PrinterSettings();
                printDocumentVenta.PrinterSettings = printerSettings;
                printDocumentVenta.PrintPage += Imprimir;
                printDocumentVenta.Print();
            }
            else
            {
                MessageBox.Show("Por favor ingrese un monto válido.");
            }

            ImprimirTicketConVistaPrevia();
        }
        private void ImprimirTicketConVistaPrevia()
        {
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += new PrintPageEventHandler(Imprimir);

            PrintPreviewDialog vistaPrevia = new PrintPreviewDialog();
            vistaPrevia.Document = doc;
            vistaPrevia.ShowDialog(); // Ventana de visualización de ticket para las pruebas//
        }
        private void Imprimir(object sender, PrintPageEventArgs e)
        {

            Cliente clienteSeleccionado = (Cliente)cbClientes.SelectedItem;

            if (cbClientes.SelectedItem == null || cbClientes.Items.Count == 0)
            {
                MessageBox.Show("No hay cliente seleccionado para imprimir el ticket.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.HasMorePages = false;
                return;
            }

            Cliente ClienteSeleccionado = (Cliente)cbClientes.SelectedItem;

            if (clienteSeleccionado == null)
            {
                MessageBox.Show("El cliente seleccionado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.HasMorePages = false;
                return;
            }

            string nombreCliente = clienteSeleccionado.NombreCompleto;
            int idCliente = clienteSeleccionado.Id;

            Graphics g = e.Graphics;
            Font monoFont = new Font("Courier New", 12); // Fuente bonita para ticket
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
            g.DrawString($"ID Cliente: {idCliente}", monoFont, Brushes.Black, 10, yPos); yPos += 20;
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
        private void cbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cliente clienteSeleccionado = cbClientes.SelectedItem as Cliente;

            if (cbClientes.SelectedItem != null)
            {
                Cliente ClienteSeleccionado = (Cliente)cbClientes.SelectedItem;
                string nombreCliente = clienteSeleccionado.NombreCompleto;
                int idCliente = clienteSeleccionado.Id;
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un cliente antes de imprimir.");
            }
        }
        private void CargarClientes()
        {
            cbClientes.DataSource = clienteNeg.ObtenerClientes();
            cbClientes.DisplayMember = "NombreCompleto";
            cbClientes.ValueMember = "Id";
        }

        private void btnCancelarRegProd_Click(object sender, EventArgs e)
        {
            this.Close();
            Inicio inicio = new Inicio();
            inicio.Show();
        }
    }
}
