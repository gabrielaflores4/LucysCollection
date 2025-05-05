using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Entidades
{
    public class Talla
    {
        public int Id_Talla { get; set; }  
        public string Descripcion { get; set; }  

        // Constructor por defecto
        public Talla() { }

        // Constructor con parámetros para crear un objeto Talla
        public Talla(int idTalla, string descripcion)
        {
            Id_Talla = idTalla;
            Descripcion = descripcion;
        }
    }
}
