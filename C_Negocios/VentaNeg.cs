using C_Datos;
using C_Entidades;
using Microsoft.Extensions.Logging;
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
        private ProductoNeg productoNeg;  

        public VentaNeg()
        {
            ventaDatos = new VentaDatos();
            productoNeg = new ProductoNeg(); 
        }

        public void RegistrarVentaConDetalles(Venta venta, int idUsuario)
        {
            using (var conexion = Conexion.ObtenerConexion())
            using (var transaction = conexion.BeginTransaction())
            {
                try
                {
                    if (venta.Detalles == null || !venta.Detalles.Any())
                        throw new Exception("La venta debe contener al menos un detalle.");

                    int idVentaRegistrada = ventaDatos.RegistrarVenta(venta, idUsuario, conexion, transaction);
                    venta.Id = idVentaRegistrada;

                    foreach (var detalle in venta.Detalles)
                    {
                        ventaDatos.ActualizarStock(detalle.ProductoId, detalle.Cantidad, conexion, transaction);
                    }

                    ventaDatos.InsertarComprobante(venta.Id, conexion, transaction);

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception($"Error al registrar la venta con detalles: {ex.Message}");
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
