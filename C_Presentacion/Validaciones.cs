using System;
using System.Globalization;
using System.Windows.Forms;

namespace C_Presentacion
{
    public static class Validaciones
    {
        // Solo letras (A-Z, a-z), backspace y espacio
        public static void SoloLetras(KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 32))
            {
                e.Handled = true;
            }
        }

        // Letras y números (para usernames)
        public static void LetrasYNumeros(KeyPressEventArgs e)
        {
            if (!(char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 32))
            {
                e.Handled = true;
            }
        }

        // Letras con tildes y ñ (para nombres completos)
        public static void LetrasConTildes(KeyPressEventArgs e)
        {
            // Permitir letras (incluye tildes y ñ), backspace y espacio
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 32))
            {
                e.Handled = true;
            }
        }

        public static void ParaCorreo(KeyPressEventArgs e, TextBox textBox)
        {
            // Caracteres permitidos: letras, números, @ . _ -
            if (!(char.IsLetterOrDigit(e.KeyChar) ||
                  e.KeyChar == 8 ||     // Backspace
                  e.KeyChar == 64 ||   // @
                  e.KeyChar == 46 ||   // .
                  e.KeyChar == 95 ||   // _
                  e.KeyChar == 45))   // -
            {
                e.Handled = true;
                return;
            }

            string texto = textBox.Text;
            int seleccionStart = textBox.SelectionStart;

            // Restricciones adicionales
            if (e.KeyChar == '@' && (texto.Contains('@') || seleccionStart == 0))
            {
                e.Handled = true;
                return;
            }

            if (e.KeyChar == '.' && seleccionStart == 0)
            {
                e.Handled = true;
                return;
            }

            // Evitar modificación después de @gmail.com
            if (texto.EndsWith("@gmail.com") && seleccionStart >= texto.IndexOf("@"))
            {
                e.Handled = true;
            }
        }

        // Teléfono: solo números, 8 dígitos máximo
        public static void ParaTelefono(KeyPressEventArgs e, TextBox textBox)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
                return;
            }

            // Limitar a 8 dígitos (sin contar borrados)
            if (char.IsDigit(e.KeyChar) && textBox.Text.Length >= 8 && textBox.SelectionLength == 0)
            {
                e.Handled = true;
            }
        }

        // Validación para números enteros positivos
        public static void SoloNumerosEnteros(KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8) // 8 = Backspace
            {
                e.Handled = true;
            }
        }

        public static void SoloNumerosDecimales(KeyPressEventArgs e, TextBox textBox)
        {
            // Permitir: dígitos, backspace, y un solo punto decimal
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }

            // Validar que solo haya un punto decimal
            if (e.KeyChar == '.' && textBox.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
                return;
            }

            // Opcional: Validar formato cultural
            if (e.KeyChar == ',' && CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator == ".")
            {
                e.Handled = true;
                return;
            }

            // Opcional: Validar máximo 2 decimales
            if (char.IsDigit(e.KeyChar) && textBox.Text.Contains("."))
            {
                int decimalPosition = textBox.Text.IndexOf('.');
                string decimalPart = textBox.Text.Substring(decimalPosition + 1);

                if (decimalPart.Length >= 2 && textBox.SelectionStart > decimalPosition)
                {
                    e.Handled = true;
                }
            }
        }

        public static bool TryParseDecimal(string input, out decimal result)
        {
            // Limpiar el input (quitar $, comas, espacios)
            string cleanInput = input.Replace("$", "").Replace(",", "").Trim();

            return decimal.TryParse(cleanInput, NumberStyles.Any,
                                 CultureInfo.InvariantCulture, out result);
        }
    }
}
