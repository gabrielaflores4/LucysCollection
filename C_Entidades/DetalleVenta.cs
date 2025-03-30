using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Entidades
{
    public class DetalleVenta
    {
        public int Id { get; set; }
        public int VentaId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public Producto Producto { get; set; }
        // Constructor por defecto
        public DetalleVenta()
        {
        }

        // Constructor personalizado
        public DetalleVenta(int id, int ventaId, int productoId, int cantidad, decimal precioUnitario)
        {
            Id = id;
            VentaId = ventaId;
            ProductoId = productoId;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
        }
    }
}
