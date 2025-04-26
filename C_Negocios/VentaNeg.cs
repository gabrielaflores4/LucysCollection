using C_Datos;
using C_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Negocios
{
    public class VentaNeg
    {
        private VentaDatos ventaDatos = new VentaDatos();
        private ProductoNeg productoNeg;  // Nueva instancia de la capa de productos

        public VentaNeg()
        {
            ventaDatos = new VentaDatos();
            productoNeg = new ProductoNeg();  // Inicialización de ProductoNeg
        }

        public void RegistrarVenta(int idCliente, List<DetalleVenta> detalles)
        {
            if (!Sesion.EstaLogueado() || Sesion.UsuarioActivo == null)
                throw new Exception("Usuario no autenticado");

            if (detalles == null || !detalles.Any())
                throw new Exception("La venta no contiene productos");

            // Crear objeto Venta (sin total, ya que no se almacena según tu estructura)
            Venta venta = new Venta(idCliente, DateTime.Now, 0) // El 0 es placeholder, no se usa
            {
                Detalles = detalles
            };

            try
            {
                int numComprobante = ventaDatos.InsertarComprobante(idCliente);


                // 3. Registrar los detalles de la venta
                foreach (var detalle in detalles)
                {
                    ventaDatos.InsertarVentaDetalle(numComprobante, detalle);
                }


                // Actualizar stocks
                foreach (var detalle in detalles)
                {
                    productoNeg.ActualizarStock(detalle.ProductoId, -detalle.Cantidad);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al registrar venta: {ex.Message}");
            }
        }

        public decimal CalcularTotalVenta(List<DetalleVenta> detalles)
        {
            decimal total = 0;
            foreach (var detalle in detalles)
            {
                total += detalle.Cantidad * detalle.PrecioUnitario;
            }
            return total;
        }

        public List<Producto> ObtenerProductos()
        {
            return productoNeg.ObtenerProductosConStock();
        }

        public int ObtenerNumeroTicket()
        {
            int ultimoTicket = ventaDatos.ObtenerUltimoTicket();
            return ultimoTicket + 1;
        }
    }
}
