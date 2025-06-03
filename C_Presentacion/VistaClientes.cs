using C_Entidades;
using C_Negocios;

namespace C_Presentacion
{
    public partial class VistaClientes : Form
    {
        public Cliente? ClienteSeleccionado { get; private set; }
        private string _rolUsuario;
        public VistaClientes(string rolUsuario)
        {
            InitializeComponent();
           
            _rolUsuario = rolUsuario;
            CargarClientesEnDataGrid();
            ConfigurarVisibilidadBotones();
        }

        private void ConfigurarVisibilidadBotones()
        {
            // Mostrar/ocultar botones según el rol
            bool esAdministrador = _rolUsuario == "Administrador";

            btnAgregarCli.Visible = esAdministrador;
            btnEditarCli.Visible = esAdministrador;
            btnEliminarCli.Visible = esAdministrador;

            if (!esAdministrador)
            {
                this.Width -= 150; // Reducir ancho
            }
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
                MessageBox.Show("Por favor, seleccione un cliente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btnEliminarCli_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada
            if (dataGridClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un cliente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener el cliente seleccionado
            var clienteSeleccionado = (Cliente)dataGridClientes.SelectedRows[0].DataBoundItem;

            // Mostrar confirmación de eliminación
            DialogResult confirmacion = MessageBox.Show(
                $"¿Está seguro que desea eliminar permanentemente al cliente {clienteSeleccionado.Nombre} {clienteSeleccionado.Apellido}?\n",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            // Si el usuario confirma
            if (confirmacion == DialogResult.Yes)
            {
                // Ejecutar eliminación
                var (success, message) = new ClienteNeg().EliminarCliente(clienteSeleccionado.Id);

                // Mostrar resultado
                MessageBox.Show(message, success ? "Éxito" : "Error", MessageBoxButtons.OK, success ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                // Actualizar la lista si fue exitoso
                if (success)
                {
                    CargarClientesEnDataGrid();
                }
            }
        }

        private void btnEditarCli_Click(object sender, EventArgs e)
        {
            if (dataGridClientes.SelectedRows.Count == 0) return;

            var fila = dataGridClientes.SelectedRows[0];
            var cliente = new Cliente
            {
                Id = Convert.ToInt32(fila.Cells["colId"].Value),
                Nombre = fila.Cells["colNombre"].Value?.ToString() ?? string.Empty,
                Apellido = fila.Cells["colApellido"].Value?.ToString() ?? string.Empty,
                Telefono = fila.Cells["colTelefono"].Value?.ToString() ?? string.Empty,
                Correo = fila.Cells["colCorreo"].Value?.ToString() ?? string.Empty,
                FechaRegistro = fila.Cells["colFechaRegistro"].Value != null
                    ? Convert.ToDateTime(fila.Cells["colFechaRegistro"].Value)
                    : DateTime.MinValue
            };

            using (var frm = new EditarClientes(cliente))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarClientesEnDataGrid();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Estás seguro que deseas cancelar?",
                "Confirmar cancelación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
