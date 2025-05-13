using C_Entidades;
using C_Datos;
using System.Diagnostics;
using Npgsql;

namespace C_Negocios
{
    public class ProductoNeg
    {
        private ProductoDatos productoDatos = new ProductoDatos();
        private CategoriaDatos categoriaDatos = new CategoriaDatos();
        private TallaDatos tallaDatos = new TallaDatos();


        // Método para agregar un producto
        public void AgregarProductos(List<Producto> productos)
        {
            if (productos == null || productos.Count == 0)
                throw new ArgumentException("Debe proporcionar al menos un producto");

            // Validaciones comunes
            var primerProducto = productos[0];

            if (string.IsNullOrWhiteSpace(primerProducto.Nombre))
                throw new ArgumentException("El nombre del producto es requerido");

            if (primerProducto.Precio <= 0)
                throw new ArgumentException("El precio debe ser mayor a 0");

            if (primerProducto.Categoria?.Id <= 0)
                throw new ArgumentException("Categoría inválida");

            // Verificar duplicados
            if (productoDatos.ObtenerProductos()
                .Any(p => p.Nombre.Equals(primerProducto.Nombre, StringComparison.OrdinalIgnoreCase)))
            {
                throw new InvalidOperationException($"El producto '{primerProducto.Nombre}' ya existe");
            }

            // Validar que haya al menos una talla con stock > 0
            if (!productos.Any(p => p.Stock > 0))
                throw new InvalidOperationException("Debe haber al menos una talla con stock positivo");

            try
            {
                productoDatos.AgregarProductos(productos);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar productos: " + ex.Message, ex);
            }
        }

        public List<string> ObtenerNombresProductos()
        {
            return productoDatos.ObtenerNombresProductos();
        }
        public int ObtenerCategoriaIdPorNombre(string nombre)
        {
            return categoriaDatos.ObtenerIdPorNombre(nombre);
        }

        // Método para obtener todos los productos
        public List<Producto> ObtenerProductos()
        {
            return productoDatos.ObtenerProductos();
        }

        // Método para actualizar un producto
        public bool ActualizarProducto(int id, string nombre, int talla, decimal precio,
                         int stock, int categoriaId, bool aplicarCambiosGlobales)
        {
            // Validaciones básicas
            if (precio <= 0) throw new ArgumentException("El precio debe ser mayor que cero");
            if (stock < 0) throw new ArgumentException("El stock no puede ser negativo");
            if (string.IsNullOrWhiteSpace(nombre)) throw new ArgumentException("El nombre no puede estar vacío");

            // Obtener producto original
            var productoOriginal = productoDatos.ObtenerProductoPorId(id);
            if (productoOriginal == null)
                throw new Exception("Producto no encontrado");

            // Validar antes de actualizar
            if (!nombre.Equals(productoOriginal.Nombre, StringComparison.OrdinalIgnoreCase))
            {
                var productoExistente = productoDatos.ObtenerProductoPorNombre(nombre);
                if (productoExistente != null && productoExistente.Id_Prod != id)
                {
                    throw new Exception($"Ya existe un producto con ese nombre (ID: {productoExistente.Id_Prod})");
                }
            }

            return productoDatos.ActualizarProductoCompleto(id, nombre, talla, precio, stock, categoriaId, aplicarCambiosGlobales);
        }

        public bool ActualizarCamposComunes(string nombreProducto, decimal? nuevoPrecio = null,
                                  int? nuevaCategoriaId = null, string nuevoNombre = null)
        {
            try
            {
                // Validar que al menos un campo se va a actualizar
                if (nuevoPrecio == null && nuevaCategoriaId == null && nuevoNombre == null)
                    throw new ArgumentException("Debe especificar al menos un campo a actualizar");

                // Validar nombre único si se va a cambiar
                if (nuevoNombre != null && !nuevoNombre.Equals(nombreProducto, StringComparison.OrdinalIgnoreCase))
                {
                    if (productoDatos.ExisteProductoConNombre(nuevoNombre))
                        throw new Exception("Ya existe un producto con ese nombre");
                }

                return productoDatos.ActualizarCamposComunes(nombreProducto, nuevoPrecio, nuevaCategoriaId, nuevoNombre);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al actualizar campos comunes: {ex.Message}");
                throw;
            }
        }

        public bool VerificarConsistenciaProducto(string nombreProducto)
        {
            try
            {
                decimal? precioComun;
                int? categoriaComun;
                return productoDatos.VerificarConsistenciaCampos(nombreProducto, out precioComun, out categoriaComun);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al verificar consistencia: {ex.Message}");
                throw new Exception("No se pudo verificar la consistencia del producto");
            }
        }


        // Método para eliminar un producto
        public bool EliminarProducto(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID de producto inválido.");
            }

            try
            {
                // Verificar si el producto existe antes de intentar eliminarlo
                var producto = productoDatos.ObtenerProductoPorId(id);
                if (producto == null)
                {
                    throw new KeyNotFoundException($"No se encontró el producto con ID: {id}");
                }

                return productoDatos.EliminarProducto(id);
            }
            catch (PostgresException ex) when (ex.SqlState == "23503")
            {
                throw new InvalidOperationException(
                    "No se puede eliminar el producto porque tiene ventas registradas. " + "Considere desactivarlo en lugar de eliminarlo.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar producto: {ex.Message}", ex);
            }
        }

        public bool EliminarProductoForzado(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID de producto inválido.");
            }

            try
            {
                return productoDatos.EliminarProductoForzado(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar producto (forzado): {ex.Message}", ex);
            }
        }

        public int EliminarProductosPorNombre(string nombreProducto)
        {
            if (string.IsNullOrWhiteSpace(nombreProducto))
            {
                throw new ArgumentException("El nombre del producto no puede estar vacío");
            }

            try
            {
                // Eliminación directa en una sola operación
                return productoDatos.EliminarProductosPorNombre(nombreProducto);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar productos por nombre: {ex.Message}", ex);
            }
        }

        public List<int> ObtenerTallasDisponibles()
        {
            return productoDatos.ObtenerTallasDisponibles();
        }

        public List<Talla> ObtenerTallasPorProducto(int idProducto)
        {
            return productoDatos.ObtenerTallasPorProducto(idProducto);
        }

        public bool ActualizarStock(int productoId, int cantidadModificada)
        {
            try
            {
                // Validación básica
                if (productoId <= 0)
                {
                    throw new ArgumentException("ID de producto inválido");
                }

                if (cantidadModificada < 0)
                {
                    var producto = productoDatos.ObtenerProductos()
                                    .FirstOrDefault(p => p.Id_Prod == productoId);

                    if (producto != null && Math.Abs(cantidadModificada) > producto.Stock)
                    {
                        throw new InvalidOperationException(
                            $"No hay suficiente stock. Stock actual: {producto.Stock}, intentando quitar: {Math.Abs(cantidadModificada)}");
                    }
                }

                return productoDatos.ActualizarStock(productoId, cantidadModificada);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar stock: {ex.Message}", ex);
            }
        }

        public bool ExisteProductoConMismaTalla(string nombre, int talla, int excluirId = 0)
        {
            return productoDatos.ObtenerProductos()
                .Any(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase)
                       && p.Talla.Id_Talla == talla
                       && p.Id_Prod != excluirId);
        }

        public Producto? ObtenerProductoPorId(int id)
        {
            if (id <= 0) return null;
            return productoDatos.ObtenerProductoPorId(id);
        }

        public List<Producto> ObtenerProductosConStock()
        {
            return productoDatos.ObtenerProductos().Where(p => p.Stock > 0).ToList();
        }

        public List<Talla> ObtenerTodasLasTallas()
        {
            return tallaDatos.ObtenerTodasLasTallas();
        }

        public List<Producto> ObtenerProductosConTallasPorNombre(string nombreProducto)
        {
            if (string.IsNullOrWhiteSpace(nombreProducto))
            {
                throw new ArgumentException("El nombre del producto no puede estar vacío");
            }

            try
            {
                return productoDatos.ObtenerProductosConTallasPorNombre(nombreProducto);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener productos por nombre: {ex.Message}", ex);
            }
        }

        public bool ActualizarTallaYStock(int id, int nuevaTalla, int nuevoStock)
        {
            if (id <= 0 || nuevoStock < 0) return false;

            var producto = productoDatos.ObtenerProductoPorId(id);
            if (producto == null) return false;

            // Validar duplicados de talla para el mismo nombre
            if (nuevaTalla != producto.Talla?.Id_Talla &&
                productoDatos.ExisteProductoConMismaTalla(producto.Nombre, nuevaTalla, id))
            {
                throw new Exception("Ya existe un producto con este nombre y talla");
            }

            return productoDatos.ActualizarTallaYStock(id, nuevaTalla, nuevoStock);
        }

        public int ObtenerStockPorProductoYTalla(int productoId, int tallaId)
        {
            return productoDatos.ObtenerStockPorProductoYTalla(productoId, tallaId);
        }
    }
}
