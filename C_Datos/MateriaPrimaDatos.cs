﻿using C_Entidades;
using Npgsql;
using NpgsqlTypes;

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

        public bool AgregarMateriasPrimas(List<MateriaPrima> materias)
        {
            const string query = @"INSERT INTO materia_prima 
                             (id_proveedor, nombre, precio_unit, stock, fecha_ingreso, fecha_act) 
                             VALUES (@idProv, @nombre, @precio, @stock, NOW(), NOW())";

            using (var conexion = Conexion.ObtenerConexion())
            {
                using (var transaccion = conexion.BeginTransaction())
                {
                    try
                    {
                        foreach (var materia in materias)
                        {
                            using (var cmd = new NpgsqlCommand(query, conexion, transaccion))
                            {
                                cmd.Parameters.AddWithValue("@idProv", materia.IdProveedor);
                                cmd.Parameters.AddWithValue("@nombre", materia.Nombre);
                                cmd.Parameters.AddWithValue("@precio", materia.PrecioUnit);
                                cmd.Parameters.AddWithValue("@stock", materia.Stock);

                                if (cmd.ExecuteNonQuery() <= 0)
                                {
                                    transaccion.Rollback();
                                    return false;
                                }
                            }
                        }
                        transaccion.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        transaccion.Rollback();
                        throw;
                    }
                }
            }
        }

        public bool ActualizarMateriaPrima(MateriaPrima materia)
        {
            const string query = @"UPDATE materia_prima SET 
                        id_proveedor = @idProv, 
                        nombre = @nombre, 
                        precio_unit = @precio, 
                        stock = @stock,
                        fecha_act = @fechaAct
                        WHERE id_materiaPrima = @id";

            try
            {
                using (var conexion = Conexion.ObtenerConexion())
                {
                    using (var cmd = new NpgsqlCommand(query, conexion))
                    {
                        // Configuración explícita de tipos Npgsql
                        cmd.Parameters.Add("@id", NpgsqlDbType.Integer).Value = materia.IdMateriaPrima;
                        cmd.Parameters.Add("@idProv", NpgsqlDbType.Integer).Value = materia.IdProveedor;
                        cmd.Parameters.Add("@nombre", NpgsqlDbType.Text).Value = materia.Nombre;
                        cmd.Parameters.Add("@precio", NpgsqlDbType.Numeric).Value = materia.PrecioUnit;
                        cmd.Parameters.Add("@stock", NpgsqlDbType.Integer).Value = materia.Stock;
                        cmd.Parameters.Add("@fechaAct", NpgsqlDbType.Timestamp).Value = DateTime.Now;

                        // Debug: Ver parámetros
                        Console.WriteLine($"Ejecutando actualización para ID: {materia.IdMateriaPrima}");

                        int filasAfectadas = cmd.ExecuteNonQuery();
                        Console.WriteLine($"Filas afectadas: {filasAfectadas}");
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Npgsql.PostgresException ex)
            {
                Console.WriteLine($"Error PostgreSQL (Código: {ex.SqlState}): {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex}");
                return false;
            }
        }

        public bool EliminarMP(int idMateriaPrima)
        {
            using (var conexion = Conexion.ObtenerConexion())
            using (var cmd = new NpgsqlCommand(
                "DELETE FROM materia_prima WHERE id_materiaPrima = @id", conexion))
            {
                cmd.Parameters.AddWithValue("@id", idMateriaPrima);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}