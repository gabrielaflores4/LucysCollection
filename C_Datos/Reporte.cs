using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using C_Datos;

namespace C_Datos
{
    public class Reportes
    {
        public static DataTable ObtenerReporteVentas(DateTime desdecompleto, DateTime hastacompleto)
        {
            DataTable dt = new DataTable();

            using (var con = new NpgsqlConnection(Conexion.cadenaConexion))
            {
                con.Open();

                string consulta = @"
                 SELECT 
                     p.nombre || ' ' || p.apellido AS empleado,
                     pc.nombre || ' ' || pc.apellido AS cliente,
                     pr.nombre_prod AS producto,
                     dv.cantidad,
                     pr.precio_unit,
                     (dv.cantidad * pr.precio_unit) AS total
                 FROM public.detalle_venta dv
                 JOIN public.producto pr ON pr.id_producto = dv.id_producto
                 JOIN public.venta v ON v.id_venta = dv.id_venta
                 JOIN public.usuarios u ON u.id_usuario = v.id_usuario
                 JOIN public.personas p ON p.id_persona = u.id_persona
                 JOIN public.cliente c ON c.id_cliente = v.id_cliente
                 JOIN public.personas pc ON pc.id_persona = c.id_persona
                 WHERE v.fecha BETWEEN @desdecompleto AND @hastacompleto
                 ORDER BY total DESC;";

                using (var cmd = new NpgsqlCommand(consulta, con))
                {
                    cmd.Parameters.AddWithValue("@desdecompleto", desdecompleto);
                    cmd.Parameters.AddWithValue("@hastacompleto", hastacompleto);

                    using (var da = new NpgsqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
               }
            }
            return dt;
        }
    }
}

