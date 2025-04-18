using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using C_Entidades;
using C_Negocios;

namespace C_Presentacion
{
    public partial class Ventas : Form
    {
        private VentaNeg ventaNeg;
        private List<DetalleVenta> detallesVenta;
        private ProductoNeg productoNeg = new ProductoNeg();
        private ClienteNeg clienteNeg = new ClienteNeg();
        private List<int> idsClientes;

        public Ventas()
        {
            InitializeComponent();
            cbClientes.Visible = false;
            detallesVenta = new List<DetalleVenta>();
            ventaNeg = new VentaNeg(); // Inicializa primero ventaNeg
            ActualizarDataGrid();
            CargarProductos(); // Ahora puedes llamar a CargarProductos
            CargarTallasDisponibles(); // Cargar tallas disponibles
            idsClientes = clienteNeg.ObtenerIdsClientes();
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
            List<string> nombresClientes = clienteNeg.ObtenerNombresClientes();
            cbClientes.DataSource = nombresClientes;
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
            MessageBox.Show("Producto eliminado de la venta.","Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                ventaNeg.RegistrarVenta(clienteId, detallesVenta);

                MessageBox.Show("Venta registrada exitosamente", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar después de registrar
                detallesVenta.Clear();
                ActualizarDataGrid();
                LimpiarControles();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar venta: {ex.Message}","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
