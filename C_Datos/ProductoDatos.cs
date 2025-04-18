using C_Entidades;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Datos
{
    public class ProductoDatos
    {
        // Método para agregar un producto
        public void AgregarProducto(Producto producto)
        {
            try
            {
                using (var conexion = Conexion.ObtenerConexion()) // Obtener la conexión a la base de datos
                {
                    // Iniciar la transacción
                    using (var transaction = conexion.BeginTransaction())
                    {
                        //Verificar si el producto ya existe con la misma talla y cantidad de stock
                        if (ProductoConTallaYStockExiste(conexion, producto.Nombre, producto.Talla, producto.Stock))
                        {
                            Console.WriteLine($"El producto {producto.Nombre} con talla {producto.Talla} y cantidad de {producto.Stock} ya existe.");
                            return; // Salir si el producto ya existe
                        }

                        //Verificar si el producto ya está asociado a otra categoría
                        if (ProductoEnOtraCategoria(conexion, producto.Nombre, producto.Categoria.Id))
                        {
                            Console.WriteLine($"El producto {producto.Nombre} ya está registrado en otra categoría.");
                            return; // Salir si el producto está en otra categoría
                        }

                        //Verificar si el precio del producto es consistente para todas las tallas
                        if (!PrecioConsistente(conexion, producto.Nombre, producto.Precio))
                        {
                            Console.WriteLine($"El precio del producto {producto.Nombre} no es consistente para todas las tallas.");
                            return; // Salir si el precio no es consistente
                        }

                        //Insertar el producto en la base de datos
                        using (var cmd = new NpgsqlCommand(
                            "INSERT INTO Producto (nombre_prod, talla, precio_unit, stock, fecha_ingreso, fecha_act, id_categoria) " +
                            "VALUES (@nombre, @talla, @precio, @stock, NOW(), NOW(), @categoriaId)", conexion))
                        {
                            cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
                            cmd.Parameters.AddWithValue("@talla", producto.Talla);
                            cmd.Parameters.AddWithValue("@precio", producto.Precio);
                            cmd.Parameters.AddWithValue("@stock", producto.Stock);
                            cmd.Parameters.AddWithValue("@categoriaId", producto.Categoria.Id);

                            cmd.ExecuteNonQuery(); // Ejecutar la consulta para insertar el producto
                        }

                        // Confirmar la transacción si todo salió bien
                        transaction.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                // En caso de error, hacer rollback de la transacción
                using (var conexion = Conexion.ObtenerConexion())
                {
                    using (var transaction = conexion.BeginTransaction())
                    {
                        transaction.Rollback();
                    }
                }

                // Lanza una excepción con el mensaje de error
                throw new Exception("Error al agregar producto: " + ex.Message, ex);
            }
        }


        private bool ProductoConTallaYStockExiste(NpgsqlConnection conexion, string nombreProducto, int talla, int stock)
        {
            using (var cmd = new NpgsqlCommand(
                "SELECT COUNT(*) FROM Producto WHERE nombre_prod = @nombreProducto AND talla = @talla AND stock = @stock", conexion))
            {
                cmd.Parameters.AddWithValue("@nombreProducto", nombreProducto);
                cmd.Parameters.AddWithValue("@talla", talla);
                cmd.Parameters.AddWithValue("@stock", stock);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;  // Si count > 0, significa que ya existe
            }
        }

        // Verificar si el producto ya está registrado en otra categoría
        private bool ProductoEnOtraCategoria(NpgsqlConnection conexion, string nombreProducto, int categoriaId)
        {
            using (var cmd = new NpgsqlCommand(
                "SELECT COUNT(*) FROM Producto WHERE nombre_prod = @nombreProducto AND id_categoria != @categoriaId", conexion))
            {
                cmd.Parameters.AddWithValue("@nombreProducto", nombreProducto);
                cmd.Parameters.AddWithValue("@categoriaId", categoriaId);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;  // Si count > 0, significa que ya está en otra categoría
            }
        }

        // Verificar si el precio del producto es consistente para todas las tallas
        private bool PrecioConsistente(NpgsqlConnection conexion, string nombreProducto, decimal precio)
        {
            using (var cmd = new NpgsqlCommand(
                "SELECT COUNT(*) FROM Producto WHERE nombre_prod = @nombreProducto AND precio_unit != @precio", conexion))
            {
                cmd.Parameters.AddWithValue("@nombreProducto", nombreProducto);
                cmd.Parameters.AddWithValue("@precio", precio);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count == 0;  // Si count == 0, significa que todos los precios son consistentes
            }
        }


        // Método para verificar si el producto ya existe
        private bool ProductoExiste(NpgsqlConnection conexion, string nombre, int talla)
        {
            using (var cmd = new NpgsqlCommand(
                "SELECT COUNT(*) FROM Producto WHERE nombre_prod = @nombre AND talla = @talla", conexion))
            {
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@talla", talla);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;  // Si count > 0, significa que ya existe
            }
        }

        // Método para obtener todos los productos
        public List<Producto> ObtenerProductos()
        {
            var productos = new List<Producto>();
            using (var conexion = Conexion.ObtenerConexion())
            {
                using (var cmd = new NpgsqlCommand(
                @"SELECT p.id_producto, 
                     p.nombre_prod AS nombre, 
                     p.talla AS talla,
                     p.precio_unit AS precio,
                     p.stock AS stock,
                     c.nombre AS categoria
                FROM Producto p 
                INNER JOIN Categorias c ON p.id_categoria = c.id_categoria
                ORDER BY p.id_producto ASC",
                    conexion))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var productoInfo = new Producto
                        {
                            Id_Prod = reader.GetInt32(reader.GetOrdinal("id_producto")),
                            Nombre = reader.GetString(reader.GetOrdinal("nombre")),
                            Talla = reader.GetInt32(reader.GetOrdinal("talla")),
                            Precio = reader.GetDecimal(reader.GetOrdinal("precio")),
                            Stock = reader.GetInt32(reader.GetOrdinal("stock")),
                            Categoria = new Categoria
                            {
                                Nombre = reader.GetString(reader.GetOrdinal("categoria"))
                            }
                        };
                        productos.Add(productoInfo);
                    }
                }
            }
            return productos;
        }

        // Método para actualizar un producto
        public bool ActualizarProducto(int id, string nombre, int talla, decimal precio, int stock, int categoriaId)
        {
            using (var conexion = Conexion.ObtenerConexion())
            {
                using (var cmd = new NpgsqlCommand(
                    @"UPDATE producto SET nombre_prod = @nombre, talla = @talla, precio_unit = @precio, stock = @stock, fecha_act = NOW(), id_categoria = @id_categoria WHERE id_producto = @id",
                    conexion))
                {
                    // Parámetros con todos los campos necesarios
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@talla", talla);
                    cmd.Parameters.AddWithValue("@precio", precio);
                    cmd.Parameters.AddWithValue("@stock", stock);
                    cmd.Parameters.AddWithValue("@id_categoria", categoriaId);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // Método para eliminar un producto
        public bool EliminarProducto(int id)
        {
            using (var conexion = Conexion.ObtenerConexion())
            {
                using (var cmd = new NpgsqlCommand("DELETE FROM Producto WHERE id_producto = @id", conexion))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        public List<string> ObtenerNombresProductos()
        {
            var nombresProductos = new List<string>();
            using (var conexion = Conexion.ObtenerConexion())
            {
                using (var cmd = new NpgsqlCommand("SELECT nombre_prod FROM Producto", conexion))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var nombre = reader.GetString(reader.GetOrdinal("nombre_prod"));
                        nombresProductos.Add(nombre);
                    }
                }
            }
            return nombresProductos;
        }
    }
}
