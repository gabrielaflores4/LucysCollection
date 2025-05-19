using C_Entidades;
using C_Negocios;
using System.Globalization;
using System.Text;

namespace C_Presentacion
{
    public partial class RegMP : Form
    {
        private readonly ProveedorNeg proveedorNegocio = new ProveedorNeg();
        private readonly MateriaPrimaNeg materiaPrimaNegocio = new MateriaPrimaNeg();
        private Inicio _formularioPadre;
        public event Action? DatosGuardados;

        public RegMP(Inicio formularioPadre)
        {
            InitializeComponent();
            ConfigurarControles();
            _formularioPadre = formularioPadre;
        }

        private void ConfigurarDataGridView()
        {
            dataGridRegMP.Columns.Clear();

            // Configuración básica
            dataGridRegMP.AllowUserToAddRows = false;
            dataGridRegMP.AutoGenerateColumns = false;

            // Columna OCULTA para el ID del proveedor
            DataGridViewTextBoxColumn colIdProveedor = new DataGridViewTextBoxColumn();
            colIdProveedor.Name = "IdProveedor";
            colIdProveedor.DataPropertyName = "IdProveedor";
            colIdProveedor.Visible = false;
            dataGridRegMP.Columns.Add(colIdProveedor);

            // Columnas visibles
            DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn();
            colNombre.Name = "Nombre";
            colNombre.HeaderText = "Nombre";
            colNombre.Width = 150;
            dataGridRegMP.Columns.Add(colNombre);

            DataGridViewTextBoxColumn colPrecio = new DataGridViewTextBoxColumn();
            colPrecio.Name = "PrecioUnit";
            colPrecio.HeaderText = "Precio Unitario";
            colPrecio.DefaultCellStyle.Format = "C2"; 
            dataGridRegMP.Columns.Add(colPrecio);

            DataGridViewTextBoxColumn colStock = new DataGridViewTextBoxColumn();
            colStock.Name = "Stock";
            colStock.HeaderText = "Cantidad";
            dataGridRegMP.Columns.Add(colStock);

            DataGridViewTextBoxColumn colProveedor = new DataGridViewTextBoxColumn();
            colProveedor.Name = "NombreProveedor";
            colProveedor.HeaderText = "Proveedor";
            colProveedor.ReadOnly = true;
            dataGridRegMP.Columns.Add(colProveedor);
        }

        private void MostrarError(string mensaje, Control? control = null)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            control?.Focus();
        }

        private void MostrarExito(string mensaje)
        {
            MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void ConfigurarControles()
        {
            // Configuración del NumericUpDown
            nbCantidadMP.Minimum = 1;
            nbCantidadMP.Maximum = 9999;
            nbCantidadMP.Value = 1;
            nbCantidadMP.TextAlign = HorizontalAlignment.Right;

            // Configuración inicial de otros controles
            tbNombreMP.MaxLength = 100;
            tbPrecioMP.MaxLength = 10;
        }

        private void CargarProveedores()
        {
            try
            {
                var proveedores = proveedorNegocio.ObtenerProveedores();

                cbProvMP.BeginUpdate();
                cbProvMP.DataSource = null;
                cbProvMP.DataSource = proveedores;
                cbProvMP.DisplayMember = "NombreProv";
                cbProvMP.ValueMember = "IdProveedor";
                cbProvMP.EndUpdate();

                cbProvMP.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MostrarError($"Error al cargar proveedores: {ex.Message}");
            }
        }

        private void tbNombreMP_KeyPress(object? sender, KeyPressEventArgs e)
        {
            Validaciones.SoloLetras(e);
        }

        private void tbPrecioMP_KeyPress(object? sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumerosDecimales(e, tbPrecioMP);
        }

        private void btnCancelarMP_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Estás seguro que deseas cancelar?", "Confirmar cancelación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private bool ValidarFormulario()
        {
            // Validar nombre
            if (string.IsNullOrWhiteSpace(tbNombreMP.Text))
            {
                MostrarError("Ingrese el nombre de la materia prima", tbNombreMP);
                return false;
            }

            // Validar proveedor
            if (cbProvMP.SelectedIndex == -1)
            {
                MostrarError("Seleccione un proveedor", cbProvMP);
                return false;
            }

            // Validar precio (acepta formato de moneda o número puro)
            string precioTexto = tbPrecioMP.Text.Replace("$", "").Replace(",", "").Trim();
            if (!decimal.TryParse(precioTexto, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal precio) || precio <= 0)
            {
                MostrarError("Ingrese un precio válido mayor a 0", tbPrecioMP);
                return false;
            }

            return true;
        }

        private void LimpiarFormulario()
        {
            tbNombreMP.Clear();
            tbPrecioMP.Text = "0.00";
            nbCantidadMP.Value = nbCantidadMP.Minimum;
            cbProvMP.SelectedIndex = -1;
            tbNombreMP.Focus();
        }

        private void btnGuardarMP_Click(object sender, EventArgs e)
        {
            try
            {
                var materias = new List<MateriaPrima>();

                foreach (DataGridViewRow row in dataGridRegMP.Rows)
                {
                    if (row.IsNewRow) continue;

                    materias.Add(new MateriaPrima
                    {
                        IdProveedor = Convert.ToInt32(row.Cells["IdProveedor"].Value),
                        Nombre = row.Cells["Nombre"].Value?.ToString() ?? string.Empty,
                        PrecioUnit = Convert.ToDecimal(row.Cells["PrecioUnit"].Value),
                        Stock = Convert.ToInt32(row.Cells["Stock"].Value)
                    });
                }

                if (materias.Count == 0)
                {
                    MostrarError("No hay materias primas para guardar");
                    return;
                }

                var resultado = new MateriaPrimaNeg().AgregarMateriasPrimas(materias);

                if (resultado)
                {
                    MostrarExito($"Se guardaron {materias.Count} materias primas correctamente");
                    dataGridRegMP.Rows.Clear();
                    if (resultado)
                    {
                        DatosGuardados?.Invoke();
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    MostrarError("Ocurrió un error al guardar los registros");
                }
            }
            catch (ArgumentException ex)
            {
                MostrarError(ex.Message);
            }
            catch (Exception ex)
            {
                MostrarError($"Error inesperado: {ex.Message}");
            }
        }

        private void btnAgregarMP_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario())
                return;

            try
            {
                if (cbProvMP.SelectedItem is not Proveedor proveedor)
                {
                    MostrarError("Seleccione un proveedor válido", cbProvMP);
                    return;
                }

                // Convertir el precio quitando símbolos de moneda
                string precioTexto = tbPrecioMP.Text.Replace("$", "").Replace(",", "").Trim();
                if (!decimal.TryParse(precioTexto, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal precio))
                {
                    MostrarError("Formato de precio inválido");
                    return;
                }

                int rowIndex = dataGridRegMP.Rows.Add();
                DataGridViewRow row = dataGridRegMP.Rows[rowIndex];

                // Asignar valores a las celdas
                row.Cells["Nombre"].Value = tbNombreMP.Text.Trim();
                row.Cells["PrecioUnit"].Value = precio; 
                row.Cells["Stock"].Value = (int)nbCantidadMP.Value;
                row.Cells["NombreProveedor"].Value = proveedor.NombreProv;
                row.Cells["IdProveedor"].Value = proveedor.IdProveedor;

                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MostrarError($"Error al agregar: {ex.Message}");
            }
        }

        private void RegMP_Load(object sender, EventArgs e)
        {
            CargarProveedores();
            ConfigurarDataGridView();
        }

        private void dataGridRegMP_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnEliminarMP_Click(object sender, EventArgs e)
        {
            if (dataGridRegMP.SelectedRows.Count == 0)
            {
                MostrarError("Seleccione un elemento para eliminar");
                return;
            }

            // Obtener la fila seleccionada
            DataGridViewRow selectedRow = dataGridRegMP.SelectedRows[0];

            // Confirmar eliminación
            DialogResult result = MessageBox.Show(
                "¿Está seguro que desea eliminar esta materia prima?","Confirmar eliminación",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Eliminar la fila del DataGridView
                    dataGridRegMP.Rows.Remove(selectedRow);
                    MostrarExito("Materia prima eliminada correctamente");
                }
                catch (Exception ex)
                {
                    MostrarError($"Error al eliminar: {ex.Message}");
                }
            }
        }
    }
}
