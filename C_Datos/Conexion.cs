using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Datos
{
    public class Conexion
    {
        private static string cadenaConexion = "Host=localhost;Port=5432;Username=postgres;Password=postgress123;Database=lucysdb";

        public static NpgsqlConnection ObtenerConexion()
        {
            try
            {
                NpgsqlConnection conexion = new NpgsqlConnection(cadenaConexion);
                conexion.Open();
                return conexion;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al conectar con PostgreSQL: " + ex.Message);
            }
        }
    }
}
