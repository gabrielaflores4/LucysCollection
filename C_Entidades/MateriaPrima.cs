using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Entidades
{
    public class MateriaPrima
    {
        //Atributos de las Materias Primas
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Stock { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaActMP { get; set; }
        public int ProveedorId { get; set; } // Clave foránea
        public Proveedor Proveedor { get; set; } // Objeto proveedor

        // Constructor por defecto
        public MateriaPrima()
        {
            FechaIngreso = DateTime.Now;
            FechaActMP = DateTime.Now;
        }

        // Constructor con todos los atributos
        public MateriaPrima(int id, string nombre, decimal precioUnitario, int cantidadStock, int proveedorId)
        {
            Id = id;
            Nombre = nombre;
            PrecioUnitario = precioUnitario;
            Stock = cantidadStock;
            ProveedorId = proveedorId;
            FechaIngreso = DateTime.Now;
            FechaActMP = DateTime.Now;
        }
    }
}
