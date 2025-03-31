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

        public int ObtenerCategoriaIdPorNombre(string nombre)
        {
            return categoriaDatos.ObtenerIdPorNombre(nombre); // Aquí llamas a un método de la capa de datos
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
    }
}
