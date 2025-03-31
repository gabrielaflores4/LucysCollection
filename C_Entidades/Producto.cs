using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Entidades
{
    public class Producto
    {
        public int Id_Prod { get; set; }
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
        // Constructor con todos los atributos
        public Producto(int id, string nombre, int talla, decimal precio, int cantidadStock)
        {
            Id_Prod = id;
            Nombre = nombre;
            Talla = talla;
            Precio = precio;
            Stock = cantidadStock;
            FechaIngreso = DateTime.Now;
            FechaAct = DateTime.Now;
        }

        // Constructor para visualización de datos
        public Producto(int id, string nombre, int talla, decimal precio, int cantidadStock, string categoria)
        {
            Id_Prod = id;
            Nombre = nombre;
            Talla = talla;
            Precio = precio;
            Stock = cantidadStock;
            Categoria = new Categoria() { Nombre = categoria };
        }
        public Producto(string nombre, int talla, decimal precio, int stock, int categoriaId)
        {
            Nombre = nombre;
            Talla = talla;
            Precio = precio;
            Stock = stock;
            Categoria = new Categoria() { Id = categoriaId }; // Usamos el ID de la categoría
            FechaIngreso = DateTime.Now;  // Asignado automáticamente
            FechaAct = DateTime.Now;      // Asignado automáticamente
        }
    }
}
