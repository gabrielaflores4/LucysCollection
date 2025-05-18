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
    public partial class EditarClientes : Form
    {
        private readonly Cliente clienteOriginal;
        public EditarClientes(Cliente cliente)
        {
            InitializeComponent();
            clienteOriginal = cliente;
            MostrarDatosActuales();
        }

        private void MostrarDatosActuales()
        {
            tbNombreCliAct.Text = clienteOriginal.Nombre;
            tbApellidoCliAct.Text = clienteOriginal.Apellido;
            tbTelefonoCliAct.Text = clienteOriginal.Telefono;
            tbCorreoCliAct.Text = clienteOriginal.Correo;
        }
        private bool ValidarDatos()
        {
            // Validar que el nombre no esté vacío
            if (string.IsNullOrWhiteSpace(tbNombreCliAct.Text))
            {
                MessageBox.Show("El nombre del cliente es obligatorio",
                              "Error de validación",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
                tbNombreCliAct.Focus();
                return false;
            }

            // Validar que el apellido no esté vacío
            if (string.IsNullOrWhiteSpace(tbApellidoCliAct.Text))
            {
                MessageBox.Show("El apellido del cliente es obligatorio",
                              "Error de validación",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
                tbApellidoCliAct.Focus();
                return false;
            }

            // Validar formato de teléfono (opcional)
            if (!string.IsNullOrWhiteSpace(tbTelefonoCliAct.Text) && !EsTelefonoValido(tbTelefonoCliAct.Text))
            {
                MessageBox.Show("El teléfono debe contener solo números (máx. 15 dígitos)",
                              "Error de validación",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
                tbTelefonoCliAct.Focus();
                return false;
            }

            // Validar formato de correo (opcional)
            if (!string.IsNullOrWhiteSpace(tbCorreoCliAct.Text) && !EsEmailValido(tbCorreoCliAct.Text))
            {
                MessageBox.Show("Ingrese un correo electrónico válido (ejemplo@dominio.com)",
                              "Error de validación",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
                tbCorreoCliAct.Focus();
                return false;
            }

            return true;
        }

        // Método para validar teléfono (versión mejorada)
        private bool EsTelefonoValido(string telefono)
        {
            // Eliminar espacios, guiones y paréntesis
            string telefonoLimpio = new string(telefono.Where(c => char.IsDigit(c)).ToArray());

            // Validar longitud (ajusta según tus necesidades)
            return telefonoLimpio.Length >= 7 && telefonoLimpio.Length <= 15;
        }

        // Método para validar email
        private bool EsEmailValido(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Usar System.Net.Mail para validación básica
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        private void btnActCli_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                try
                {
                    clienteOriginal.Nombre = tbNombreCliAct.Text.Trim();
                    clienteOriginal.Apellido = tbApellidoCliAct.Text.Trim();
                    clienteOriginal.Telefono = tbTelefonoCliAct.Text.Trim();
                    clienteOriginal.Correo = tbCorreoCliAct.Text.Trim();

                    // Cambio aquí: recibir ambos valores de la tupla
                    var (success, message) = new ClienteNeg().ActualizarCliente(clienteOriginal);

                    if (success)
                    {
                        DialogResult = DialogResult.OK;
                        MessageBox.Show(message, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                    else
                    {
                        MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
