using C_Entidades;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Datos
{
    public class CategoriaDatos
    {
        // Método para obtener todas las categorías
        public List<Categoria> ObtenerCategorias()
        {
            var categorias = new List<Categoria>();
            using (var conexion = Conexion.ObtenerConexion())
            {
                using (var cmd = new NpgsqlCommand("SELECT id_categoria, nombre FROM Categorias", conexion))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var categoria = new Categoria
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("id_categoria")),
                            Nombre = reader.GetString(reader.GetOrdinal("nombre"))
                        };
                        categorias.Add(categoria);
                    }
                }
            }
            return categorias;
        }

        public int ObtenerIdPorNombre(string nombre)
        {
            using (var conexion = Conexion.ObtenerConexion())
            {
                using (var cmd = new NpgsqlCommand("SELECT id_categoria FROM Categorias WHERE nombre = @nombre", conexion))
                {
                    // Especifica el tipo de dato del parámetro (NpgsqlDbType.Varchar)
                    cmd.Parameters.Add(new NpgsqlParameter("@nombre", NpgsqlDbType.Varchar)
                    {
                        Value = nombre ?? (object)DBNull.Value // Maneja valores null si es necesario
                    });

                    var result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : -1;
                }
            }
        }

        public bool VerificarExistenciaCategoria(int idCategoria)
        {
            using (var conexion = Conexion.ObtenerConexion())
            {
                using (var cmd = new NpgsqlCommand("SELECT COUNT(1) FROM Categorias WHERE id_categoria = @idCategoria", conexion))
                {
                    cmd.Parameters.AddWithValue("@idCategoria", idCategoria);
                    var result = cmd.ExecuteScalar();
                    return Convert.ToInt32(result) > 0;
                }
            }
        }

    }
}
