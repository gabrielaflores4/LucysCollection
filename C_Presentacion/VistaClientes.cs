using C_Entidades;
using C_Negocios;

namespace C_Presentacion
{
    public partial class VistaClientes : Form
    {
        public Cliente ClienteSeleccionado { get; private set; }
        public VistaClientes()
        {
            InitializeComponent();
            ConfigurarDataGrid();
            CargarClientesEnDataGrid();
        }

        private void ConfigurarDataGrid()
        {
            // Limpiar columnas existentes
            dataGridClientes.Columns.Clear();

            // Configuración básica del DataGrid
            dataGridClientes.AutoGenerateColumns = false;
            dataGridClientes.AllowUserToAddRows = false;
            dataGridClientes.AllowUserToDeleteRows = false;
            dataGridClientes.ReadOnly = true;
            dataGridClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridClientes.MultiSelect = false;
            dataGridClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridClientes.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                Name = "colId",
                Visible = false
            });

            dataGridClientes.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Nombre",
                HeaderText = "Nombre",
                Name = "colNombre",
                Width = 150
            });

            dataGridClientes.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Apellido",
                HeaderText = "Apellido",
                Name = "colApellido",
                Width = 150
            });

            dataGridClientes.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Telefono",
                HeaderText = "Teléfono",
                Name = "colTelefono",
                Width = 100
            });

            dataGridClientes.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Correo",
                HeaderText = "Correo",
                Name = "colCorreo",
                Width = 200
            });

            dataGridClientes.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "FechaRegistro",
                HeaderText = "Fecha Registro",
                Name = "colFechaRegistro",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Format = "dd/MM/yyyy"
                }
            });
        }

        private void CargarClientesEnDataGrid()
        {
            try
            {
                ClienteNeg clienteNeg = new ClienteNeg();
                List<Cliente> listaClientes = clienteNeg.ObtenerClientes();
                dataGridClientes.DataSource = listaClientes;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message, "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SeleccionarCliente();
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dataGridClientes.SelectedRows.Count > 0)
            {
                SeleccionarCliente();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un cliente", "Advertencia",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void SeleccionarCliente()
        {
            ClienteSeleccionado = (Cliente)dataGridClientes.SelectedRows[0].DataBoundItem;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
