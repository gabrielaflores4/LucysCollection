using C_Datos;
using C_Entidades;

namespace C_Negocios
{
    public class VentaNeg
    {
        private VentaDatos ventaDatos = new VentaDatos();
        private ProductoNeg productoNeg;  

        public VentaNeg()
        {
            ventaDatos = new VentaDatos();
            productoNeg = new ProductoNeg(); 
        }

        public bool RegistrarVentaConDetalles(Venta venta, int idUsuario)
        {
            using (var conexion = Conexion.ObtenerConexion())
            using (var transaction = conexion.BeginTransaction())
            {
                try
                {
                    // Validación
                    if (venta.Detalles == null || !venta.Detalles.Any())
                        return false;

                    // Registrar la venta
                    int idVenta = ventaDatos.RegistrarVenta(venta, idUsuario, conexion, transaction);
                    if (idVenta <= 0) return false;

                    // Registrar detalles y actualizar stock
                    foreach (var detalle in venta.Detalles)
                    {
                        // Insertar detalle de venta
                        ventaDatos.InsertarVentaDetalle(idVenta, detalle, conexion, transaction);

                        // Actualizar stock
                        ventaDatos.ActualizarStock(detalle.ProductoId, detalle.Cantidad, conexion, transaction);
                    }

                    // Comprobar si la venta necesita comprobante
                    ventaDatos.InsertarComprobante(idVenta, conexion, transaction);

                    // Commit de la transacción
                    transaction.Commit();
                    return true; // Éxito
                }
                catch (Exception)
                {
                    transaction.Rollback(); 
                    return false;
                }
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
