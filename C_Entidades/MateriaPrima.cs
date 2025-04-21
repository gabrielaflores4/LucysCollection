using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Entidades
{
    public class MateriaPrima
    {
        // Propiedades
        public int IdMateriaPrima { get; set; }
        public int IdProveedor { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioUnit { get; set; }
        public int Stock { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaAct { get; set; }
        public Proveedor Proveedor { get; set; }

        public MateriaPrima() { }

        public MateriaPrima(int idMateriaPrima, int idProveedor, string nombre,decimal precioUnit, int stock, DateTime fechaIngreso, DateTime fechaAct, Proveedor proveedor)
        {
            IdMateriaPrima = idMateriaPrima;
            IdProveedor = idProveedor;
            Nombre = nombre;
            PrecioUnit = precioUnit;
            Stock = stock;
            FechaIngreso = fechaIngreso;
            FechaAct = fechaAct;
            Proveedor = proveedor;
        }

        public MateriaPrima(int idProveedor, string nombre, decimal precioUnit, int stock)
        {
            IdProveedor = idProveedor;
            Nombre = nombre;
            PrecioUnit = precioUnit;
            Stock = stock;
            FechaIngreso = DateTime.Now;
            FechaAct = DateTime.Now; 
        }

    }
}
