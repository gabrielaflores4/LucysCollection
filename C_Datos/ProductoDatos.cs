using C_Entidades;
using Npgsql;

namespace C_Datos
{
    public class ProductoDatos
    {
        // Método para agregar un producto
        public void AgregarProductos(List<Producto> productos)
        {
            if (productos == null || productos.Count == 0)
                throw new ArgumentException("La lista de productos no puede estar vacía");

            try
            {
                using (var conexion = Conexion.ObtenerConexion())
                using (var transaction = conexion.BeginTransaction())
                {
                    string nombreProducto = productos[0].Nombre;

                    if (ExisteProducto(conexion, nombreProducto))
                    {
                        throw new InvalidOperationException($"El producto '{nombreProducto}' ya existe en el sistema");
                    }

                    if (!MismaCategoriaParaTodos(conexion, productos))
                    {
                        throw new InvalidOperationException("Todas las tallas deben pertenecer a la misma categoría");
                    }

                    if (!PrecioConsistente(productos))
                    {
                        throw new InvalidOperationException("Todas las tallas deben tener el mismo precio");
                    }

                    var productosConStock = productos.Where(p => p.Stock > 0).ToList();

                    if (productosConStock.Count == 0)
                    {
                        throw new InvalidOperationException("Debe haber al menos una talla con stock positivo");
                    }

                    foreach (var producto in productosConStock)
                    {
                        InsertarProducto(conexion, producto);
                    }

                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar productos: " + ex.Message, ex);
            }
        }

        private void InsertarProducto(NpgsqlConnection conexion, Producto producto)
        {
            using (var cmd = new NpgsqlCommand(
                "INSERT INTO Producto (nombre_prod, id_talla, precio_unit, stock, fecha_ingreso, fecha_act, id_categoria) " +
                "VALUES (@nombre, @talla, @precio, @stock, NOW(), NOW(), @categoriaId)", conexion))
            {
                cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
                cmd.Parameters.AddWithValue("@talla", producto.Talla.Id_Talla);
                cmd.Parameters.AddWithValue("@precio", producto.Precio);
                cmd.Parameters.AddWithValue("@stock", producto.Stock);
                cmd.Parameters.AddWithValue("@categoriaId", producto.Categoria.Id);

                cmd.ExecuteNonQuery();
            }
        }

        private bool PrecioConsistente(List<Producto> productos)
        {
            if (productos.Count == 0) return true;
            decimal precio = productos[0].Precio;
            return productos.All(p => p.Precio == precio);
        }

        private bool MismaCategoriaParaTodos(NpgsqlConnection conexion, List<Producto> productos)
        {
            if (productos.Count == 0) return true;
            int categoriaId = productos[0].Categoria.Id;
            return productos.All(p => p.Categoria.Id == categoriaId);
        }

        private bool ExisteProducto(NpgsqlConnection conexion, string nombreProducto)
        {
            using (var cmd = new NpgsqlCommand(
                "SELECT COUNT(*) FROM Producto WHERE nombre_prod = @nombre", conexion))
            {
                cmd.Parameters.AddWithValue("@nombre", nombreProducto);
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        public List<Producto> ObtenerProductos()
        {
            List<Producto> lista = new List<Producto>();

            using (var conexion = Conexion.ObtenerConexion())
            {
                using (var cmd = new NpgsqlCommand(
                @"SELECT 
                    p.id_producto, 
                    p.nombre_prod AS nombre, 
                    p.id_talla, 
                    t.descripcion AS talla, 
                    p.precio_unit AS precio, 
                    p.stock AS stock, 
                    p.fecha_ingreso, 
                    p.fecha_act, 
                    p.id_categoria,
                    c.nombre AS categoria
                FROM Producto p 
                INNER JOIN Tallas t ON p.id_talla = t.id_talla
                INNER JOIN Categorias c ON p.id_categoria = c.id_categoria
                ORDER BY p.nombre_prod",
                    conexion))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Producto
                            {
                                Id_Prod = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                
                                Talla = new Talla
                                {
                                    Id_Talla = reader.GetInt32(2),
                                    Descripcion = reader.GetString(3)
                                },
                                Precio = reader.GetDecimal(4),
                                Stock = reader.GetInt32(5),
                                FechaIngreso = reader.GetDateTime(6),
                                FechaAct = reader.GetDateTime(7),
                                Categoria = new Categoria
                                {
                                    Id = reader.GetInt32(8),
                                    Nombre = reader.GetString(9)
                                }
                            });
                        }
                    }
                }
            }

            return lista;
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

        public List<int> ObtenerTallasDisponibles()
        {
            var tallas = new List<int>();
            using (var conexion = Conexion.ObtenerConexion())
            {
                using (var cmd = new NpgsqlCommand(
                    "SELECT DISTINCT id_talla FROM producto ORDER BY id_talla", conexion)) 
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tallas.Add(reader.GetInt32(0));
                    }
                }
            }
            return tallas;
        }

        public List<Talla> ObtenerTallasPorProducto(int idProducto)
        {
            var tallas = new List<Talla>();
            using (var conexion = Conexion.ObtenerConexion())
            {
                using (var cmd = new NpgsqlCommand(
                    @"SELECT DISTINCT t.id_talla, t.descripcion 
                        FROM Producto p
                        JOIN Tallas t ON p.id_talla = t.id_talla
                        WHERE p.nombre_prod = (SELECT nombre_prod FROM Producto WHERE id_producto = @idProducto)
                        ORDER BY t.id_talla", conexion))
                {
                    cmd.Parameters.AddWithValue("@idProducto", idProducto);

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
            }
            return tallas;
        }
        public bool ActualizarCamposComunes(string nombre, decimal precio, int categoriaId)
        {
            using (var conexion = Conexion.ObtenerConexion())
            {
                using (var cmd = new NpgsqlCommand(
                    @"UPDATE producto SET 
                        precio_unit = @precio, 
                        fecha_act = NOW(), 
                        id_categoria = @id_categoria 
                    WHERE nombre_prod = @nombre",
                    conexion))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@precio", precio);
                    cmd.Parameters.AddWithValue("@id_categoria", categoriaId);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool ActualizarTallaYStock(int id, int talla, int stock)
        {
            using (var conexion = Conexion.ObtenerConexion())
            {
                using (var cmd = new NpgsqlCommand(
                    @"UPDATE producto SET 
                        talla = @talla, 
                        stock = @stock, 
                        fecha_act = NOW() 
                    WHERE id_producto = @id",
                    conexion))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@talla", talla);
                    cmd.Parameters.AddWithValue("@stock", stock);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public Producto? ObtenerProductoPorId(int id)
        {
            using (var conexion = Conexion.ObtenerConexion())
            {
                using (var cmd = new NpgsqlCommand(
                    @"SELECT 
                        p.id_producto, 
                        p.nombre_prod, 
                        p.id_talla, 
                        t.descripcion,
                        p.precio_unit, 
                        p.stock,
                        p.id_categoria,
                        c.nombre AS categoria_nombre
                    FROM Producto p
                    INNER JOIN Tallas t ON p.id_talla = t.id_talla
                    INNER JOIN Categorias c ON p.id_categoria = c.id_categoria
                    WHERE p.id_producto = @id",
                    conexion))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Producto
                            {
                                Id_Prod = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Talla = new Talla
                                {
                                    Id_Talla = reader.GetInt32(2),
                                    Descripcion = reader.GetString(3)
                                },
                                Precio = reader.GetDecimal(4),
                                Stock = reader.GetInt32(5),
                                Categoria = new Categoria
                                {
                                    Id = reader.GetInt32(6),
                                    Nombre = reader.GetString(7)
                                }
                            };
                        }
                    }
                }
            }
            return null;
        }
        public bool ActualizarProducto(int id, string nombre, int talla, decimal precio, int stock, int categoriaId, bool actualizarCamposComunes)
        {
            using (var conexion = Conexion.ObtenerConexion())
            {
                using (var transaction = conexion.BeginTransaction())
                {
                    try
                    {
                        string sql = actualizarCamposComunes
                        ? @"UPDATE producto SET 
                            nombre_prod = @nombre,
                            id_talla = @talla,
                            precio_unit = @precio,
                            stock = @stock,
                            id_categoria = @categoriaId,
                            fecha_act = NOW()
                        WHERE id_producto = @id"
                            : @"UPDATE producto SET 
                            id_talla = @talla,
                            stock = @stock,
                            fecha_act = NOW()
                        WHERE id_producto = @id";

                        using (var cmd = new NpgsqlCommand(sql, conexion, transaction))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.Parameters.AddWithValue("@talla", talla);
                            cmd.Parameters.AddWithValue("@stock", stock);

                            if (actualizarCamposComunes)
                            {
                                cmd.Parameters.AddWithValue("@nombre", nombre);
                                cmd.Parameters.AddWithValue("@precio", precio);
                                cmd.Parameters.AddWithValue("@categoriaId", categoriaId);
                            }

                            int filasAfectadas = cmd.ExecuteNonQuery();
                            transaction.Commit();
                            return filasAfectadas > 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Error al actualizar producto: " + ex.Message, ex);
                    }
                }
            }
        }

        public bool ActualizarStock(int productoId, int cantidadModificada)
        {
            using (var conexion = Conexion.ObtenerConexion())
            {
                using (var cmd = new NpgsqlCommand(
                    "UPDATE Producto SET stock = stock + @cantidad, fecha_act = NOW() " +
                    "WHERE id_producto = @productoId", conexion))
                {
                    cmd.Parameters.AddWithValue("@productoId", productoId);
                    cmd.Parameters.AddWithValue("@cantidad", cantidadModificada);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public List<Talla> ObtenerTodasLasTallas()
        {
            var tallas = new List<Talla>();
            using (var conexion = Conexion.ObtenerConexion())
            {
                using (var cmd = new NpgsqlCommand("SELECT id_talla, descripcion FROM Tallas ORDER BY id_talla", conexion))
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
    }
}       
