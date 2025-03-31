using C_Datos;
using C_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Negocios
{
   public class CategoriaNeg
    {
        private CategoriaDatos categoriaDatos = new CategoriaDatos();

        // Método para obtener todas las categorías
        public List<Categoria> ObtenerCategorias()
        {
            return categoriaDatos.ObtenerCategorias();
        }

        public int ObtenerCategoriaIdPorNombre(string nombre)
        {
            return categoriaDatos.ObtenerIdPorNombre(nombre);
        }

    }
}
