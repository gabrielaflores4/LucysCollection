﻿using C_Entidades;
using C_Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_Presentacion
{
    public partial class EditarMP : Form
    {
        public int MateriaPrimaId { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Stock { get; set; }
        public int ProveedorId { get; set; }

        private Inicio formInicio;
        private ProveedorNeg _proveedorNeg = new ProveedorNeg();

        public EditarMP(Inicio inicio)
        {
            InitializeComponent();
            this.formInicio = inicio;
        }

        private void EditarMP_Load_1(object sender, EventArgs e)
        {
            // Configurar controles básicos
            nbCantidad.Minimum = 0;
            nbCantidad.Maximum = 10000;
            tbNombreProdAct.Text = this.Nombre;
            tbPrecioRegAct.Text = this.PrecioUnitario.ToString("0.00", CultureInfo.InvariantCulture);
            nbCantidad.Value = this.Stock;

            // Cargar proveedores UNA sola vez
            CargarProveedores();

        }

        private void CargarProveedores()
        {
            try
            {
                var proveedores = _proveedorNeg.ObtenerProveedores();
                cbProvAct.DataSource = proveedores;
                cbProvAct.DisplayMember = "NombreProv";
                cbProvAct.ValueMember = "IdProveedor";

                // Asignar SelectedValue DESPUÉS de cargar los datos
                cbProvAct.SelectedValue = this.ProveedorId;

                // Debug: Verificar valores
                Console.WriteLine($"ProveedorID a seleccionar: {this.ProveedorId}");
                Console.WriteLine($"Valor seleccionado: {cbProvAct.SelectedValue}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar proveedores: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbNombreProdAct_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloLetras(e);
        }

        private void tbPrecioRegAct_KeyPress(object? sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumerosDecimales(e, tbPrecioRegAct);
        }

        private void btnGuardarActMP_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                // Asignar nuevos valores  
                Nombre = tbNombreProdAct.Text;
                
                if (!Validaciones.TryParseDecimal(tbPrecioRegAct.Text, out decimal precioValidado))
                {
                    MessageBox.Show("El precio ingresado no es válido", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                PrecioUnitario = precioValidado;
                
                Stock = (int)nbCantidad.Value;

                // Manejo de posible valor Nulo 
                if (cbProvAct.SelectedValue is int selectedProveedorId)
                {
                    ProveedorId = selectedProveedorId;
                }
                else
                {
                    MessageBox.Show("Error al obtener el ID del proveedor seleccionado.", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Mostrar confirmación con los datos actualizados  
                MessageBox.Show(
                    "¡Actualización exitosa!\n\n" +
                    $"Nombre: {Nombre}\n" +
                    $"Precio: {PrecioUnitario:C}\n" +
                    $"Stock: {Stock}\n" +
                    $"Proveedor ID: {ProveedorId}",
                    "Datos Actualizados",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                this.DialogResult = DialogResult.OK;
                formInicio.CargarMateriasPrimas();
                this.Close();
            }
        }

        private void btnCancelarActMP_Click(object sender, EventArgs e)
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

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(tbNombreProdAct.Text))
            {
                MessageBox.Show("El nombre no puede estar vacío", "Validación",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            decimal precio;
            if (!decimal.TryParse(tbPrecioRegAct.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out precio) || precio <= 0)
            {
                MessageBox.Show("Ingrese un precio unitario válido mayor a cero", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbPrecioRegAct.Focus();
                return false;
            }

            if (nbCantidad.Value <= 0)
            {
                MessageBox.Show("El stock debe ser mayor a cero", "Validación",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nbCantidad.Focus();
                return false;
            }

            if (cbProvAct.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un proveedor válido", "Validación",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}
