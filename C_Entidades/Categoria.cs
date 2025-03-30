using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Entidades
{
    public class Categoria
    {
        //Atributos para Categorias
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Producto> Producto { get; set; } = new List<Producto>();

        //Constructor por defecto
        public Categoria()
        {
        }

        // Constructor con todos los atributos.
        public Categoria(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public Categoria(string nombre)
        {
            Nombre = nombre;
        }
    }
}
