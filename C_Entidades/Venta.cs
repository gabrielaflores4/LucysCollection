using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Entidades
{
    public class Venta
    {
        //Atributos de Venta
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public List<DetalleVenta> Detalles { get; set; } = new List<DetalleVenta>();


        // Constructor por defecto
        public Venta()
        {
            Fecha = DateTime.Now;
            Detalles = new List<DetalleVenta>();
        }

        // Constructor con todos los parámetros
        public Venta(int clienteId, DateTime fecha, decimal total)
        {
            ClienteId = clienteId;
            Fecha = fecha;
            Total = total;

            // Inicializa la lista de detalles
            Detalles = new List<DetalleVenta>();
        }
    }
}
