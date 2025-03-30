using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Entidades
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaAct { get; set; }
        public Categoria Categoria { get; set; }
        public int Talla { get; set; }

        // Constructor por defecto
        public Producto()
        {
            FechaIngreso = DateTime.Now;
            FechaAct = DateTime.Now;
        }

    }
}
