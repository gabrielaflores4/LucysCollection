using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace C_Datos
{
    public class Conexion
    {
        public static NpgsqlConnection ObtenerConexion()
        {
            try
            {
                //Obtiene cadena de conexión desde App.config
                var connectionSettings = ConfigurationManager.ConnectionStrings["PostgreSQLConnection"];

                if (connectionSettings == null || string.IsNullOrEmpty(connectionSettings.ConnectionString))
                {
                    throw new ConfigurationErrorsException("La cadena de conexión 'PostgreSQLConnection' no está configurada en App.config");
                }

                string cadenaConexion = connectionSettings.ConnectionString;

                //Validar configuración
                if (string.IsNullOrWhiteSpace(cadenaConexion))
                {
                    throw new ArgumentNullException(
                        "Cadena de conexión no configurada en App.config. " + "Verifique la sección <connectionStrings>");
                }

                //Crear y abrir conexión
                var conexion = new NpgsqlConnection(cadenaConexion);
                conexion.Open();

                return conexion;
            }
            catch (ConfigurationErrorsException ex)
            {
                throw new Exception("Error en el archivo de configuración: " + ex.Message,ex);
            }
            catch (NpgsqlException)
            {
                throw;
            }
        }
    }
}
