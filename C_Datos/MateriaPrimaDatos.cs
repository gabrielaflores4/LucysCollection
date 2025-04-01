using C_Entidades;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Datos
{
    public class MateriaPrimaDatos
    {
        public List<MateriaPrima> ObtenerMateriasPrimas()
        {
            var materias = new List<MateriaPrima>();
            using (var conexion = Conexion.ObtenerConexion())
            {
                using (var cmd = new NpgsqlCommand(
                    @"SELECT mp.*, p.nombre_prov 
                      FROM materia_prima mp
                      INNER JOIN Proveedores p ON mp.id_proveedor = p.id_proveedor
                      ORDER BY mp.id_materiaPrima", conexion))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        materias.Add(new MateriaPrima
                        {
                            IdMateriaPrima = reader.GetInt32(reader.GetOrdinal("id_materiaPrima")),
                            IdProveedor = reader.GetInt32(reader.GetOrdinal("id_proveedor")),
                            Nombre = reader.GetString(reader.GetOrdinal("nombre")),
                            PrecioUnit = reader.GetDecimal(reader.GetOrdinal("precio_unit")),
                            Stock = reader.GetInt32(reader.GetOrdinal("stock")),
                            FechaIngreso = reader.GetDateTime(reader.GetOrdinal("fecha_ingreso")),
                            FechaAct = reader.GetDateTime(reader.GetOrdinal("fecha_act")),
                            Proveedor = new Proveedor
                            {
                                IdProveedor = reader.GetInt32(reader.GetOrdinal("id_proveedor")),
                                NombreProv = reader.GetString(reader.GetOrdinal("nombre_prov"))
                            }
                        });
                    }
                }
            }
            return materias;
        }

        public bool AgregarMateriaPrima(MateriaPrima materia)
        {
            using (var conexion = Conexion.ObtenerConexion())
            {
                using (var cmd = new NpgsqlCommand(
                    @"INSERT INTO materia_prima 
                      (id_proveedor, nombre, precio_unit, stock, fecha_ingreso, fecha_act) 
                      VALUES (@idProv, @nombre, @precio, @stock, NOW(), NOW())", conexion))
                {
                    cmd.Parameters.AddWithValue("@idProv", materia.IdProveedor);
                    cmd.Parameters.AddWithValue("@nombre", materia.Nombre);
                    cmd.Parameters.AddWithValue("@precio", materia.PrecioUnit);
                    cmd.Parameters.AddWithValue("@stock", materia.Stock);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool ActualizarMateriaPrima(MateriaPrima materia)
        {
            using (var conexion = Conexion.ObtenerConexion())
            {
                using (var cmd = new NpgsqlCommand(
                    @"UPDATE materia_prima SET 
                        id_proveedor = @idProv, 
                        nombre = @nombre, 
                        precio_unit = @precio, 
                        stock = @stock, 
                        fecha_act = NOW()
                      WHERE id_materiaPrima = @id", conexion))
                {
                    cmd.Parameters.AddWithValue("@id", materia.IdMateriaPrima);
                    cmd.Parameters.AddWithValue("@idProv", materia.IdProveedor);
                    cmd.Parameters.AddWithValue("@nombre", materia.Nombre);
                    cmd.Parameters.AddWithValue("@precio", materia.PrecioUnit);
                    cmd.Parameters.AddWithValue("@stock", materia.Stock);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool EliminarMateriaPrima(int id)
        {
            using (var conexion = Conexion.ObtenerConexion())
            {
                using (var cmd = new NpgsqlCommand(
                    "DELETE FROM materia_prima WHERE id_materiaPrima = @id", conexion))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
        }
    }
