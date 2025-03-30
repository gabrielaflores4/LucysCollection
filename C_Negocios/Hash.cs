using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace C_Negocios
{
    public class Hash
    {
        // Método para generar el hash de una contraseña
        public string HashContraseña(string contraseña)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Convertir la contraseña a bytes y luego generar el hash
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(contraseña));

                // Convertir el hash a una cadena hexadecimal
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString();  // Retornar el hash como string
            }
        }
    }
}
