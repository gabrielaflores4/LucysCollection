using C_Entidades;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Datos
{
    public class ProveedorDatos
    {
        public List<Proveedor> ObtenerProveedores()
        {
            var proveedores = new List<Proveedor>();
            using (var conexion = Conexion.ObtenerConexion())
            {
                using (var cmd = new NpgsqlCommand("SELECT * FROM Proveedores ORDER BY nombre_prov", conexion))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        proveedores.Add(new Proveedor
                        {
                            IdProveedor = reader.GetInt32(reader.GetOrdinal("id_proveedor")),
                            NombreProv = reader.GetString(reader.GetOrdinal("nombre_prov")),
                            Telefono = reader.GetString(reader.GetOrdinal("telefono")),
                            Correo = reader.GetString(reader.GetOrdinal("correo")),
                            Direccion = reader.GetString(reader.GetOrdinal("direccion"))
                        });
                    }
                }
            }
            return proveedores;
        }

        public bool AgregarProveedor(Proveedor proveedor)
        {
            using (var conexion = Conexion.ObtenerConexion())
            {
                using (var cmd = new NpgsqlCommand(
                    @"INSERT INTO Proveedores (nombre_prov, telefono, correo, direccion) 
                      VALUES (@nombre, @telefono, @correo, @direccion)", conexion))
                {
                    cmd.Parameters.AddWithValue("@nombre", proveedor.NombreProv);
                    cmd.Parameters.AddWithValue("@telefono", proveedor.Telefono);
                    cmd.Parameters.AddWithValue("@correo", proveedor.Correo);
                    cmd.Parameters.AddWithValue("@direccion", proveedor.Direccion);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool ActualizarProveedor(Proveedor proveedor)
        {
            const string query = @"UPDATE Proveedores SET 
                        nombre_prov = @nombre,
                        telefono = @telefono,
                        correo = @correo,
                        direccion = @direccion
                        WHERE id_proveedor = @id";

            using (var conexion = Conexion.ObtenerConexion())
            using (var cmd = new NpgsqlCommand(query, conexion))
            {
                cmd.Parameters.AddWithValue("@id", proveedor.IdProveedor);
                cmd.Parameters.AddWithValue("@nombre", proveedor.NombreProv);
                cmd.Parameters.AddWithValue("@telefono", proveedor.Telefono ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@correo", proveedor.Correo ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@direccion", proveedor.Direccion ?? (object)DBNull.Value);

                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
        }

        public bool EliminarProveedor(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID de proveedor inválido");

            using (var conexion = Conexion.ObtenerConexion())
            {
                using (var transaction = conexion.BeginTransaction())
                {
                    try
                    {
                        // Eliminar materias primas asociadas
                        using (var cmdEliminarMaterias = new NpgsqlCommand(
                            "DELETE FROM materia_prima WHERE id_proveedor = @id", conexion, transaction))
                        {
                            cmdEliminarMaterias.Parameters.AddWithValue("@id", id);
                            cmdEliminarMaterias.ExecuteNonQuery();
                        }

                        // Eliminar proveedor
                        using (var cmdEliminarProveedor = new NpgsqlCommand(
                            "DELETE FROM Proveedores WHERE id_proveedor = @id", conexion, transaction))
                        {
                            cmdEliminarProveedor.Parameters.AddWithValue("@id", id);
                            var result = cmdEliminarProveedor.ExecuteNonQuery() > 0;
                            transaction.Commit();
                            return result;
                        }
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public int ObtenerProveedorIdPorNombre(string nombreProveedor)
        {
            using (var conexion = Conexion.ObtenerConexion())
            {
                using (var cmd = new NpgsqlCommand(
                    @"SELECT id_proveedor FROM Proveedores 
              WHERE nombre_prov = @nombre",
                    conexion))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombreProveedor);

                    var resultado = cmd.ExecuteScalar();

                    if (resultado == null)
                    {
                        return 0;
                    }
                    return Convert.ToInt32(resultado);
                }
            }
        }
    }

}
