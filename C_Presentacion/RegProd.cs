using C_Entidades;
using C_Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_Presentacion
{
    public partial class RegProd : Form
    {
        private CategoriaNeg categoriaNeg;
        private ProductoNeg productoNeg;

        public RegProd()
        {
            InitializeComponent();
            categoriaNeg = new CategoriaNeg();
            productoNeg = new ProductoNeg();
            CargarCategorias();
        }

        private void CargarCategorias()
        {
            try
            {
                List<Categoria> categorias = categoriaNeg.ObtenerCategorias();

                cbCategoriaReg.Items.Clear();

                cbCategoriaReg.DataSource = categorias;
                cbCategoriaReg.DisplayMember = "Nombre";  
                cbCategoriaReg.ValueMember = "Id";  
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorías: " + ex.Message);
            }
        }

        private void btnAgregarRegProd_Click(object sender, EventArgs e)
        {
            string nombreProd = tbNombreProdReg.Text;
            Categoria categoriaSeleccionada = (Categoria)cbCategoriaReg.SelectedItem;
            string nombreCategoria = categoriaSeleccionada.Nombre;
            decimal precio = Convert.ToDecimal(tbPrecioRegProd.Text);
            int talla = Convert.ToInt32(cbTallasRegProd.SelectedItem);
            int cantidad = Convert.ToInt32(nbCantidad.Value);

            // Verificar si el producto con la misma talla ya existe en la DataGridView
            bool productoExistente = false;
            foreach (DataGridViewRow row in dataGridRegProducto.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == nombreProd &&
                    row.Cells[1].Value != null && Convert.ToInt32(row.Cells[1].Value) == talla)
                {
                    productoExistente = true;
                    break;
                }
            }

            // Si no existe, agregarlo
            if (!productoExistente)
            {
                dataGridRegProducto.Rows.Add(nombreProd, talla, cantidad, nombreCategoria, precio);
            }
            else
            {
                MessageBox.Show("Este producto con la talla especificada ya ha sido agregado.");
            }
        }

        private void btnGuardarRegProd_Click(object sender, EventArgs e)
        {
            btnGuardarRegProd.Enabled = false;
            List<Producto> productos = new List<Producto>();
            StringBuilder errores = new StringBuilder();

            foreach (DataGridViewRow row in dataGridRegProducto.Rows)
            {
                if (row.IsNewRow) continue;

                try
                {
                    string nombreProd = row.Cells[0].Value?.ToString() ?? "";
                    int tallaId = Convert.ToInt32(row.Cells[1].Value);
                    int cantidad = Convert.ToInt32(row.Cells[2].Value);
                    string categoriaNombre = row.Cells[3].Value?.ToString() ?? "";
                    decimal precio = Convert.ToDecimal(row.Cells[4].Value);

                    // Obtener ID de la categoría
                    int categoriaId = categoriaNeg.ObtenerCategoriaIdPorNombre(categoriaNombre);
                    Talla talla = new Talla { Id_Talla = tallaId };

                    if (categoriaId == -1)
                    {
                        errores.AppendLine($"Categoría '{categoriaNombre}' no encontrada para '{nombreProd}'.");
                        continue;
                    }

                    Producto producto = new Producto
                    {
                        Nombre = nombreProd,
                        Categoria = new Categoria { Id = categoriaId },
                        Precio = precio,
                        Talla = talla,
                        Stock = cantidad
                    };

                    productos.Add(producto);
                }
                catch (Exception ex)
                {
                    errores.AppendLine($"Error en fila {row.Index + 1}: {ex.Message}");
                }
            }

            if (errores.Length > 0)
            {
                MessageBox.Show($"Errores encontrados:\n{errores}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnGuardarRegProd.Enabled = true;
                return;
            }

            try
            {
                productoNeg.AgregarProductos(productos);
                MessageBox.Show("Productos guardados exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridRegProducto.Rows.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnGuardarRegProd.Enabled = true;
            }
        }

        private void tbNombreProdReg_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloLetras(e);
        }

        private void tbPrecioRegProd_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumerosDecimales(e, tbPrecioRegProd);  
        }
    }
}
