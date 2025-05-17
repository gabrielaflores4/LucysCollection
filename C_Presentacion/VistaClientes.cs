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
            CargarClientesEnDataGrid();
        }
        private void ConfigurarDataGrid()
        {
            // Limpieza inicial
            dataGridClientes.Columns.Clear();
            dataGridClientes.DataSource = null;
            dataGridClientes.AutoGenerateColumns = false;
            dataGridClientes.AllowUserToAddRows = false;
            dataGridClientes.AllowUserToDeleteRows = false;
            dataGridClientes.ReadOnly = true;
            dataGridClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridClientes.MultiSelect = false;
            dataGridClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridClientes.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridClientes.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                Name = "colId",
                Visible = false,
                DisplayIndex = 0
            });

            dataGridClientes.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Nombre",
                HeaderText = "Nombre",
                Name = "colNombre",
                DisplayIndex = 1,
                FillWeight = 25
            });

            dataGridClientes.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Apellido",
                HeaderText = "Apellido",
                Name = "colApellido",
                DisplayIndex = 2,
                FillWeight = 25
            });

            dataGridClientes.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Telefono",
                HeaderText = "Teléfono",
                Name = "colTelefono",
                DisplayIndex = 3,
                FillWeight = 15
            });

            dataGridClientes.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Correo",
                HeaderText = "Correo",
                Name = "colCorreo",
                DisplayIndex = 4,
                FillWeight = 25
            });

            dataGridClientes.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "FechaRegistro",
                HeaderText = "Fecha Registro",
                Name = "colFechaRegistro",
                DisplayIndex = 5,
                FillWeight = 10,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Format = "dd/MM/yyyy",
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            });
        }

        private void CargarClientesEnDataGrid()
        {
            try
            {
                ClienteNeg clienteNeg = new ClienteNeg();
                List<Cliente> listaClientes = clienteNeg.ObtenerClientes();

                // Aplicar filtro si existe
                if (!string.IsNullOrWhiteSpace(tbBusquedaClientes.Text))
                {
                    string filtro = tbBusquedaClientes.Text.Trim();
                    listaClientes = listaClientes.Where(c =>
                        (c.Nombre?.Contains(filtro, StringComparison.OrdinalIgnoreCase) == true) ||
                        (c.Apellido?.Contains(filtro, StringComparison.OrdinalIgnoreCase) == true) ||
                        (c.Telefono?.Contains(filtro) == true) ||
                        (c.Correo?.Contains(filtro, StringComparison.OrdinalIgnoreCase) == true) ||
                        (c.FechaRegistro.ToString("dd/MM/yyyy").Contains(filtro))
                    ).ToList();
                }

                // Limpiar y volver a configurar para mantener orden
                ConfigurarDataGrid();
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

        private void tbBusquedaClientes_TextChanged(object sender, EventArgs e)
        {
            CargarClientesEnDataGrid();
        }

        private void btnAgregarCli_Click(object sender, EventArgs e)
        {
            FrmRegClientes frmRegClientes = new FrmRegClientes();
            frmRegClientes.ShowDialog();
        }

        private void VistaClientes_Load(object sender, EventArgs e)
        {

        }
    }
}
