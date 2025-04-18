using C_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_Datos;


namespace C_Negocios
{
    public class ProductoNeg
    {
        private ProductoDatos productoDatos = new ProductoDatos();
        private CategoriaDatos categoriaDatos = new CategoriaDatos();

        // Método para agregar un producto
        public void AgregarProductos(List<Producto> productos)
        {
            foreach (var producto in productos)
            {
                // Verificar si la categoría tiene un ID válido (ya asignado desde el formulario)
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
        public bool ActualizarProducto(int id, string nombre, int talla, decimal precio, int cantidadStock, int categoriaId)
        {
            // Validación de los datos
            if (id <= 0 || string.IsNullOrWhiteSpace(nombre) || precio <= 0 || cantidadStock < 0 || categoriaId <= 0)
            {
                return false; // Datos inválidos
            }
            return productoDatos.ActualizarProducto(id, nombre, talla, precio, cantidadStock, categoriaId);
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

        public List<int> ObtenerTallasPorProducto(int idProducto)
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

                // Verificar que no estamos intentando quitar más stock del disponible
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
                // Podrías loggear el error aquí
                throw new Exception($"Error al actualizar stock: {ex.Message}", ex);
            }
        }

        public List<Producto> ObtenerProductosConStock()
        {
            return productoDatos.ObtenerProductos().Where(p => p.Stock > 0).ToList();
        }


    }
}
