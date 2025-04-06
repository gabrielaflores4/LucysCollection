using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_Presentacion
{
    public static class Validaciones
    {
        // Solo letras (A-Z y a-z), backspace y espacio
        public static void SoloLetras(KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= 65 && e.KeyChar <= 90) ||      // Letras mayúsculas
                  (e.KeyChar >= 97 && e.KeyChar <= 122) ||     // Letras minúsculas
                  e.KeyChar == 8 ||                            // Backspace
                  e.KeyChar == 32))                            // Espacio
            {
                e.Handled = true;
            }
        }

        // Solo números (0-9) y backspace //Para lo del DUI cuando se agregue a la BD
        public static void SoloNumeros(KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        // Números con punto decimal // Para lo del precio
        public static void SoloNumerosDecimales(KeyPressEventArgs e, TextBox textBox)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 46)) // 46 = punto
            {
                e.Handled = true;
            }

            // Evitar más de un punto
            if (e.KeyChar == 46 && textBox.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        // Letras y números // Para lo del username
        public static void LetrasYNumeros(KeyPressEventArgs e)
        {
            if (!(char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 32))
            {
                e.Handled = true;
            }
        }

        // Letras con tildes y ñ // Para lo del nombre y apellido de alguna persona con nombre como toña
        public static void LetrasConTildes(KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 32))
            {
                e.Handled = true;
            }
        }

        // Correo electrónico con restricción a @gmail.com // Para definir un solo dominio
        public static void ParaCorreo(KeyPressEventArgs e, TextBox textBox)
        {
            // Permitir letras, números, @, ., _, -
            if (!(char.IsLetterOrDigit(e.KeyChar) ||
                  e.KeyChar == 8 ||     // Backspace
                  e.KeyChar == 64 ||    // @
                  e.KeyChar == 46 ||    // .
                  e.KeyChar == 95 ||    // _
                  e.KeyChar == 45))     // -
            {
                e.Handled = true;
            }

            // Restringir a solo un @
            if (e.KeyChar == '@' && textBox.Text.Contains("@"))
            {
                e.Handled = true;
            }

            // Evitar escribir más después de @gmail.com
            if (textBox.Text.EndsWith("@gmail.com"))
            {
                e.Handled = true;
            }
              return;
        }

        // Teléfono: solo números, 8 dígitos máximo
        public static void ParaTelefono(KeyPressEventArgs e, TextBox textBox)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }

            if (char.IsDigit(e.KeyChar) && textBox.Text.Length >= 8)
            {
                e.Handled = true;
            }
        }

        // Edad: solo 2 dígitos enteros
        public static void ParaEdad(KeyPressEventArgs e, TextBox textBox)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }

            if (char.IsDigit(e.KeyChar) && textBox.Text.Length >= 2)
            {
                e.Handled = true;
            }
        }
    }
}
