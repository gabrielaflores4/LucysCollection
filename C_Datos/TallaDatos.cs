using C_Entidades;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Datos
{
    public class TallaDatos
    {
        public List<Talla> ObtenerTodasLasTallas()
        {
            var tallas = new List<Talla>();
            using (var conexion = Conexion.ObtenerConexion())
            {
                using (var cmd = new NpgsqlCommand(
                    "SELECT id_talla, descripcion FROM Tallas ORDER BY id_talla", conexion))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tallas.Add(new Talla
                        {
                            Id_Talla = reader.GetInt32(0),
                            Descripcion = reader.GetString(1)
                        });
                    }
                }
            }
            return tallas;
        }

        public Talla? ObtenerTallaPorId(int idTalla)
        {
            using (var conexion = Conexion.ObtenerConexion())
            {
                using (var cmd = new NpgsqlCommand(
                    "SELECT id_talla, descripcion FROM Tallas WHERE id_talla = @idTalla", conexion))
                {
                    cmd.Parameters.AddWithValue("@idTalla", idTalla);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Talla
                            {
                                Id_Talla = reader.GetInt32(0),
                                Descripcion = reader.GetString(1)
                            };
                        }
                    }
                }
            }
            return null;
        }

        public Talla? ObtenerTallaPorDescripcion(string descripcion)
        {
            using (var conexion = Conexion.ObtenerConexion())
            {
                using (var cmd = new NpgsqlCommand(
                    "SELECT id_talla, descripcion FROM Tallas WHERE descripcion = @descripcion", conexion))
                {
                    cmd.Parameters.AddWithValue("@descripcion", descripcion);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Talla
                            {
                                Id_Talla = reader.GetInt32(0),
                                Descripcion = reader.GetString(1)
                            };
                        }
                    }
                }
            }
            return null;
        }
    }

}
