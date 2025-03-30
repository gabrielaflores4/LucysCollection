using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_Entidades;

namespace C_Datos
{
    public class UsuarioDatos
    {
        // Método para verificar login con nombre de username y password
        public bool VerificarLogin(string username, string password)
        {
            using (var conexion = Conexion.ObtenerConexion())
            {
                using (var cmd = new NpgsqlCommand(
                    "SELECT COUNT(1) FROM usuarios WHERE username = @username AND password = @password",
                    conexion))
                {
                    cmd.Parameters.AddWithValue("@username", username);  // Buscar por username
                    cmd.Parameters.AddWithValue("@password", password);  // Verificar password

                    return Convert.ToInt32(cmd.ExecuteScalar()) == 1;  // Retorna true si el username y password son correctos
                }
            }
        }
    }
}
