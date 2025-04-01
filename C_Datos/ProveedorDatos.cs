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
            using (var conexion = Conexion.ObtenerConexion())
            {
                using (var cmd = new NpgsqlCommand(
                    @"UPDATE Proveedores SET 
                        nombre_prov = @nombre, 
                        telefono = @telefono, 
                        correo = @correo, 
                        direccion = @direccion 
                      WHERE id_proveedor = @id", conexion))
                {
                    cmd.Parameters.AddWithValue("@id", proveedor.IdProveedor);
                    cmd.Parameters.AddWithValue("@nombre", proveedor.NombreProv);
                    cmd.Parameters.AddWithValue("@telefono", proveedor.Telefono);
                    cmd.Parameters.AddWithValue("@correo", proveedor.Correo);
                    cmd.Parameters.AddWithValue("@direccion", proveedor.Direccion);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool EliminarProveedor(int id)
        {
            using (var conexion = Conexion.ObtenerConexion())
            {
                using (var cmd = new NpgsqlCommand(
                    "DELETE FROM Proveedores WHERE id_proveedor = @id", conexion))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }

}
