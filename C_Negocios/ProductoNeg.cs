using C_Entidades;
using C_Datos;

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
            foreach (var producto in productos)
            {
                // Verificar si la categoría tiene un ID válido
                if (producto.Categoria?.Id <= 0)
                {
                    continue;
                }

                try
                {
                    productoDatos.AgregarProducto(producto);
                }
                catch (Exception)
                {
                }
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
        public bool ActualizarProducto(int id, string nombre, int talla, decimal precio, int stock, int categoriaId, bool actualizarCamposComunes)
        {
            if (id <= 0 || string.IsNullOrWhiteSpace(nombre) || precio <= 0 || stock < 0 || categoriaId <= 0)
            {
                return false;
            }

            var productoActual = productoDatos.ObtenerProductoPorId(id);

            // Verificar si productoActual es null antes de acceder a sus propiedades
            if (productoActual == null || productoActual.Categoria == null)
            {
                return false;
            }

            bool necesitaActualizarComunes = actualizarCamposComunes &&
                                           (productoActual.Nombre != nombre ||
                                            productoActual.Precio != precio ||
                                            productoActual.Categoria.Id != categoriaId);

            return productoDatos.ActualizarProducto(id, nombre, talla, precio, stock, categoriaId, necesitaActualizarComunes);
        }

        // Método para eliminar un producto
        public bool EliminarProducto(int id)
        {
            if (id <= 0)
            {
                throw new Exception("ID de producto inválido.");
            }
            return productoDatos.EliminarProducto(id);
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
    }
}
