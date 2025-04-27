using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_Entidades;
using Npgsql;

namespace C_Datos
{
    public class EstadisticasDatos
    {
        //Resumen de stock
        public (int Disponible, int BajoStock, int SinStock) ObtenerResumenStock()
        {
            using (var connection = Conexion.ObtenerConexion())
            {
                string query = @"
                SELECT 
                    SUM(CASE WHEN stock > 10 THEN 1 ELSE 0 END) AS Disponible,
                    SUM(CASE WHEN stock <= 10 AND stock > 0 THEN 1 ELSE 0 END) AS BajoStock,
                    SUM(CASE WHEN stock = 0 THEN 1 ELSE 0 END) AS SinStock
                FROM Producto";

                using (var cmd = new NpgsqlCommand(query, connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        return reader.Read() ?
                            (reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2)) : (0, 0, 0);
                    }
                }
            }
        }
        public Dictionary<string, decimal> ObtenerVentasPorMes()
        {
            var ventas = new Dictionary<string, decimal>();
            using (var connection = Conexion.ObtenerConexion())
            {
                string query = @"
                SELECT 
                    TO_CHAR(v.fecha, 'YYYY-MM') AS mes_anio,
                    SUM(dv.cantidad * p.precio_unit) AS total
                FROM Venta v
                JOIN detalle_venta dv ON v.id_venta = dv.id_venta
                JOIN Producto p ON dv.id_producto = p.id_producto
                GROUP BY TO_CHAR(v.fecha, 'YYYY-MM')
                ORDER BY TO_CHAR(v.fecha, 'YYYY-MM')";

                using (var cmd = new NpgsqlCommand(query, connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ventas.Add(reader.GetString(0), reader.GetDecimal(1));
                        }
                    }
                }
            }
            return ventas;
        }

        //Producto más vendido
        public string ObtenerProductoTop()
        {
            using (var connection = Conexion.ObtenerConexion())
            {
                string query = @"
                SELECT p.nombre_prod
                FROM detalle_venta dv
                JOIN Producto p ON dv.id_producto = p.id_producto
                GROUP BY p.nombre_prod
                ORDER BY SUM(dv.cantidad) DESC
                LIMIT 1";

                using (var cmd = new NpgsqlCommand(query, connection))
                {
                    var result = cmd.ExecuteScalar();
                    return result?.ToString() ?? "N/A";
                }
            }
        }
        public decimal ObtenerVentasDiarias()
        {
            using (var connection = Conexion.ObtenerConexion())
            {
                string query = 
                @"SELECT COALESCE(SUM(dv.cantidad * p.precio_unit), 0)
                FROM Venta v
                JOIN detalle_venta dv ON v.id_venta = dv.id_venta
                JOIN Producto p ON dv.id_producto = p.id_producto
                WHERE v.fecha::DATE = CURRENT_DATE";

                using (var cmd = new NpgsqlCommand(query, connection))
                {
                    return Convert.ToDecimal(cmd.ExecuteScalar());
                }
            }
        }

        public int ObtenerTotalProductos()
        {
            using (var connection = Conexion.ObtenerConexion())
            {
                string query = "SELECT COUNT(*) FROM Producto";
                using (var cmd = new NpgsqlCommand(query, connection))
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
    }
}