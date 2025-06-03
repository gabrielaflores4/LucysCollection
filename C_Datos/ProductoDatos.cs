using C_Entidades;
using Npgsql;
using System.Diagnostics;
using System.Text;

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
                    // Eliminamos la validación de ExisteProducto que verifica solo por nombre

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

                    // Verificar duplicados por nombre + talla
                    foreach (var producto in productosConStock)
                    {
                        if (ExisteProductoConMismaTalla(conexion, producto.Nombre, producto.Talla.Id_Talla))
                        {
                            throw new InvalidOperationException($"Ya existe el producto '{producto.Nombre}' con la talla {producto.Talla.Id_Talla}");
                        }
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
                @"WITH ProductosUnicos AS (
                SELECT 
                    p.id_producto, 
                    p.nombre_prod AS nombre, 
                    p.id_talla, 
                    t.descripcion AS talla, 
                    p.precio_unit AS precio, 
                    p.stock AS stock, 
                    p.fecha_ingreso, 
                    p.fecha_act, 
                    p.id_categoria,
                    c.nombre AS categoria,
                    ROW_NUMBER() OVER (PARTITION BY p.nombre_prod ORDER BY p.id_producto) AS rn
                FROM Producto p 
                INNER JOIN Tallas t ON p.id_talla = t.id_talla
                INNER JOIN Categorias c ON p.id_categoria = c.id_categoria
                )
                SELECT 
                    id_producto, nombre, id_talla, talla, precio, stock, 
                    fecha_ingreso, fecha_act, id_categoria, categoria
                FROM ProductosUnicos
                WHERE rn = 1
                ORDER BY nombre",
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

        // En ProductoDatos
        public bool EliminarProductoForzado(int id)
        {
            using (var conexion = Conexion.ObtenerConexion())
            {
                using (var transaction = conexion.BeginTransaction())
                {
                    try
                    {
                        // 1. Eliminar primero los registros en detalle_venta
                        using (var cmdDetalles = new NpgsqlCommand(
                            "DELETE FROM detalle_venta WHERE id_producto = @id",
                            conexion, transaction))
                        {
                            cmdDetalles.Parameters.AddWithValue("@id", id);
                            cmdDetalles.ExecuteNonQuery();
                        }

                        // 2. Luego eliminar el producto
                        using (var cmdProducto = new NpgsqlCommand(
                            "DELETE FROM Producto WHERE id_producto = @id",
                            conexion, transaction))
                        {
                            cmdProducto.Parameters.AddWithValue("@id", id);
                            int result = cmdProducto.ExecuteNonQuery();
                            transaction.Commit();
                            return result > 0;
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


        public int EliminarProductosPorNombre(string nombreProducto)
        {
            using (var conexion = Conexion.ObtenerConexion())
            {
                using (var transaction = conexion.BeginTransaction())
                {
                    try
                    {
                        //Eliminar los detalles de venta relacionados
                        using (var cmdDetalles = new NpgsqlCommand(
                            "DELETE FROM detalle_venta WHERE id_producto IN " +
                            "(SELECT id_producto FROM Producto WHERE nombre_prod ILIKE @nombre)",
                            conexion, transaction))
                        {
                            cmdDetalles.Parameters.AddWithValue("@nombre", nombreProducto);
                            cmdDetalles.ExecuteNonQuery();
                        }

                        //Eliminar los productos
                        using (var cmdProductos = new NpgsqlCommand(
                            "DELETE FROM Producto WHERE nombre_prod ILIKE @nombre",
                            conexion, transaction))
                        {
                            cmdProductos.Parameters.AddWithValue("@nombre", nombreProducto);
                            int eliminados = cmdProductos.ExecuteNonQuery();
                            transaction.Commit();
                            return eliminados;
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

        public List<Producto> ObtenerProductosConTallasPorNombre(string nombreProducto, bool busquedaExacta = true)
        {
            // Validación del parámetro de entrada
            if (string.IsNullOrWhiteSpace(nombreProducto))
                throw new ArgumentException("El nombre del producto no puede estar vacío");

            List<Producto> productos = new List<Producto>();

            using (var conexion = Conexion.ObtenerConexion())
            {
                string query = @"SELECT 
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
                WHERE " + (busquedaExacta ? "p.nombre_prod = @nombreProducto" : "p.nombre_prod ILIKE @nombreProducto") +
                        " ORDER BY p.nombre_prod, t.descripcion";

                using (var cmd = new NpgsqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@nombreProducto", busquedaExacta ? nombreProducto : $"%{nombreProducto}%");

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            productos.Add(new Producto
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
                            });
                        }
                    }
                }
            }

            return productos;
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

        public Producto? ObtenerProductoPorNombre(string nombre, bool incluirTallas = false)
        {
            using (var conexion = Conexion.ObtenerConexion())
            {
                string query = @"SELECT 
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
                WHERE LOWER(p.nombre_prod) = LOWER(@nombre)
                ORDER BY p.id_producto
                LIMIT 1";

                using (var cmd = new NpgsqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre.Trim());

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

        public bool ExisteProductoConMismaTalla(NpgsqlConnection conexion, string nombre, int talla, int excluirId = 0)
        {
            using (var cmd = new NpgsqlCommand(
                @"SELECT COUNT(*) FROM producto 
                    WHERE nombre_prod = @nombre 
                    AND id_talla = @talla 
                    AND id_producto != @excluirId",
                conexion))
            {
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@talla", talla);
                cmd.Parameters.AddWithValue("@excluirId", excluirId);
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        public bool ExisteProductoConMismaTalla(string nombre, int talla, int excluirId = 0)
        {
            using (var conexion = Conexion.ObtenerConexion())
            {
                return ExisteProductoConMismaTalla(conexion, nombre, talla, excluirId);
            }
        }

        public bool ActualizarProductoCompleto(int id, string nombre, int talla, decimal precio,
                                             int stock, int categoriaId, bool actualizarCamposComunes)
        {


            using (var conexion = Conexion.ObtenerConexion())
            using (var transaction = conexion.BeginTransaction())
            {
                try
                {

                    //Obtener producto original
                    var productoOriginal = ObtenerProductoPorId(id);
                    if (productoOriginal == null)
                        throw new Exception("Producto no encontrado");

                    //Actualizar el producto específico
                    string sql = @"UPDATE producto SET 
                        nombre_prod = @nombre,
                        id_talla = @talla,
                        precio_unit = @precio,
                        stock = @stock,
                        id_categoria = @categoriaId,
                        fecha_act = NOW()
                        WHERE id_producto = @id";

                    using (var cmd = new NpgsqlCommand(sql, conexion, transaction))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@talla", talla);
                        cmd.Parameters.AddWithValue("@precio", precio);
                        cmd.Parameters.AddWithValue("@stock", stock);
                        cmd.Parameters.AddWithValue("@categoriaId", categoriaId);

                        int filasAfectadas = cmd.ExecuteNonQuery();

                        //Actualizar productos relacionados si es necesario
                        if (actualizarCamposComunes && filasAfectadas > 0)
                        {
                            // Determinar qué campos han cambiado
                            bool cambioNombre = nombre != productoOriginal.Nombre;
                            bool cambioPrecio = precio != productoOriginal.Precio;
                            bool cambioCategoria = categoriaId != productoOriginal.Categoria.Id;

                            var sqlRelacionados = new StringBuilder(@"UPDATE producto SET ");
                            var parametros = new List<NpgsqlParameter>();

                            if (cambioNombre)
                            {
                                sqlRelacionados.Append("nombre_prod = @nuevoNombre, ");
                                parametros.Add(new NpgsqlParameter("@nuevoNombre", nombre));
                            }

                            if (cambioPrecio)
                            {
                                sqlRelacionados.Append("precio_unit = @nuevoPrecio, ");
                                parametros.Add(new NpgsqlParameter("@nuevoPrecio", precio));
                            }

                            if (cambioCategoria)
                            {
                                sqlRelacionados.Append("id_categoria = @nuevaCategoriaId, ");
                                parametros.Add(new NpgsqlParameter("@nuevaCategoriaId", categoriaId));
                            }

                            sqlRelacionados.Append("fecha_act = NOW() WHERE nombre_prod = @nombreFiltro AND id_producto != @id");
                            parametros.Add(new NpgsqlParameter("@nombreFiltro", productoOriginal.Nombre));
                            parametros.Add(new NpgsqlParameter("@id", id));

                            using (var cmdRel = new NpgsqlCommand(sqlRelacionados.ToString(), conexion, transaction))
                            {
                                cmdRel.Parameters.AddRange(parametros.ToArray());
                                cmdRel.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        return filasAfectadas > 0;
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Debug.WriteLine($"Error al actualizar producto: {ex.Message}");
                    throw;
                }
            }
        }
        public bool ActualizarStock(int productoId, int cantidadModificada)
        {
            using (var conexion = Conexion.ObtenerConexion())
            using (var transaction = conexion.BeginTransaction())
            {
                try
                {
                    // Verificar stock actual
                    int stockActual = 0;
                    using (var cmdVerificar = new NpgsqlCommand(
                        "SELECT stock FROM producto WHERE id_producto = @id",
                        conexion, transaction))
                    {
                        cmdVerificar.Parameters.AddWithValue("@id", productoId);
                        stockActual = Convert.ToInt32(cmdVerificar.ExecuteScalar());
                    }

                    if (stockActual + cantidadModificada < 0)
                    {
                        throw new InvalidOperationException("No se puede tener stock negativo");
                    }

                    // Actualizar stock
                    using (var cmd = new NpgsqlCommand(
                        "UPDATE producto SET stock = stock + @cantidad, fecha_act = NOW() WHERE id_producto = @id",
                        conexion, transaction))
                    {
                        cmd.Parameters.AddWithValue("@id", productoId);
                        cmd.Parameters.AddWithValue("@cantidad", cantidadModificada);
                        int resultado = cmd.ExecuteNonQuery();
                        transaction.Commit();
                        return resultado > 0;
                    }
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public bool ActualizarCamposComunes(string nombreProducto, decimal? nuevoPrecio = null,
                                  int? nuevaCategoriaId = null, string nuevoNombre = null!)
        {
            using (var conexion = Conexion.ObtenerConexion())
            using (var transaction = conexion.BeginTransaction())
            {
                try
                {
                    // Validar que al menos un campo se va a actualizar
                    if (nuevoPrecio == null && nuevaCategoriaId == null && nuevoNombre == null)
                        throw new ArgumentException("Debe especificar al menos un campo a actualizar");

                    // Validar nombre único si se va a cambiar
                    if (nuevoNombre != null && nuevoNombre != nombreProducto &&
                        ExisteProductoConNombre(nuevoNombre))
                    {
                        throw new Exception("Ya existe un producto con ese nombre");
                    }

                    // Construir consulta dinámica
                    var sql = new StringBuilder("UPDATE producto SET ");
                    var parametros = new List<NpgsqlParameter>();

                    if (nuevoNombre != null)
                    {
                        sql.Append("nombre_prod = @nuevoNombre, ");
                        parametros.Add(new NpgsqlParameter("@nuevoNombre", nuevoNombre));
                    }

                    if (nuevoPrecio != null)
                    {
                        sql.Append("precio_unit = @nuevoPrecio, ");
                        parametros.Add(new NpgsqlParameter("@nuevoPrecio", nuevoPrecio));
                    }

                    if (nuevaCategoriaId != null)
                    {
                        sql.Append("id_categoria = @nuevaCategoriaId, ");
                        parametros.Add(new NpgsqlParameter("@nuevaCategoriaId", nuevaCategoriaId));
                    }

                    sql.Append("fecha_act = NOW() WHERE nombre_prod = @nombreProducto");
                    parametros.Add(new NpgsqlParameter("@nombreProducto", nombreProducto));

                    using (var cmd = new NpgsqlCommand(sql.ToString(), conexion, transaction))
                    {
                        cmd.Parameters.AddRange(parametros.ToArray());
                        int result = cmd.ExecuteNonQuery();

                        transaction.Commit();
                        return result > 0;
                    }
                }
                catch
                {
                    transaction.Rollback();
                    throw;
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
        public bool ExisteProductoConNombre(string nombre, int excluirId = 0)
        {
            using (var conexion = Conexion.ObtenerConexion())
            {
                using (var cmd = new NpgsqlCommand(
                    "SELECT COUNT(*) FROM Producto WHERE LOWER(nombre_prod) = LOWER(@nombre) AND id_producto != @excluirId",
                    conexion))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@excluirId", excluirId);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        public bool ActualizarTallaYStock(int id, int talla, int stock)
        {
            using (var conexion = Conexion.ObtenerConexion())
            using (var transaction = conexion.BeginTransaction())
            {
                try
                {
                    using (var cmd = new NpgsqlCommand(
                        "UPDATE producto SET id_talla = @talla, stock = @stock, fecha_act = NOW() " +
                        "WHERE id_producto = @id", conexion, transaction))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@talla", talla);
                        cmd.Parameters.AddWithValue("@stock", stock);

                        int result = cmd.ExecuteNonQuery();
                        transaction.Commit();
                        return result > 0;
                    }
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public bool VerificarConsistenciaCampos(string nombreProducto, out decimal? precioComun, out int? categoriaComun)
        {
            precioComun = null;
            categoriaComun = null;

            using (var conexion = Conexion.ObtenerConexion())
            {
                using (var cmd = new NpgsqlCommand(
                    @"SELECT 
                        COUNT(DISTINCT precio_unit) as precio_distinct,
                        COUNT(DISTINCT id_categoria) as categoria_distinct,
                        MAX(precio_unit) as precio,
                        MAX(id_categoria) as categoria
                    FROM producto 
                    WHERE nombre_prod ILIKE @nombre",
                    conexion))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombreProducto);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int distinctPrecios = reader.GetInt32(0);
                            int distinctCategorias = reader.GetInt32(1);

                            if (distinctPrecios == 1)
                                precioComun = reader.GetDecimal(2);

                            if (distinctCategorias == 1)
                                categoriaComun = reader.GetInt32(3);

                            return distinctPrecios <= 1 && distinctCategorias <= 1;
                        }
                    }
                }
            }
            return true;
        }

        public int ObtenerStockPorProductoYTalla(int productoId, int tallaId)
        {
            using (var conexion = Conexion.ObtenerConexion())
            {
                using (var cmd = new NpgsqlCommand(
                    "SELECT stock FROM producto WHERE id_producto = @productoId AND id_talla = @tallaId",
                    conexion))
                {
                    cmd.Parameters.AddWithValue("@productoId", productoId);
                    cmd.Parameters.AddWithValue("@tallaId", tallaId);
                    var result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
        }

        public List<int> ObtenerIdsTallasConStock(int productoId)
        {
            var idsTallas = new List<int>();

            using (var conexion = Conexion.ObtenerConexion())
            {
                using (var cmd = new NpgsqlCommand(
                    "SELECT DISTINCT id_talla FROM producto WHERE id_producto = @productoId AND stock > 0",
                    conexion))
                {
                    cmd.Parameters.AddWithValue("@productoId", productoId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            idsTallas.Add(reader.GetInt32(0));
                        }
                    }
                }
            }

            return idsTallas;
        }

        public List<Producto> ObtenerProductosConTallasYStockPorNombre(string nombreProducto)
        {
            var productos = new List<Producto>();

            using (var conexion = Conexion.ObtenerConexion())
            {
                using (var cmd = new NpgsqlCommand(
                    @"SELECT 
                  p.id_producto,
                  p.nombre_prod,
                  t.id_talla,
                  t.descripcion,
                  p.precio_unit,
                  p.stock
              FROM 
                  Producto p
              JOIN 
                  Tallas t ON p.id_talla = t.id_talla
              WHERE 
                  p.nombre_prod = @nombreProducto AND p.stock > 0",
                    conexion))
                {
                    cmd.Parameters.AddWithValue("@nombreProducto", nombreProducto);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int idProducto = reader.GetInt32(0);
                            string nombre = reader.GetString(1);
                            int idTalla = reader.GetInt32(2);
                            string descripcionTalla = reader.GetString(3);
                            decimal precio = reader.GetDecimal(4);
                            int stock = reader.GetInt32(5);

                            var talla = new Talla
                            {
                                Id_Talla = idTalla,
                                Descripcion = descripcionTalla
                            };

                            var producto = new Producto(idProducto, nombre, talla, precio, stock);
                            productos.Add(producto);
                        }
                    }
                }
            }

            return productos;
        }

    }
}