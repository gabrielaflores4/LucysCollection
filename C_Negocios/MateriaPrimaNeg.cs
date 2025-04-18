using C_Datos;
using C_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Negocios
{
    public class MateriaPrimaNeg
    {
        private readonly MateriaPrimaDatos _materiaPrimaDatos = new MateriaPrimaDatos();

        public List<MateriaPrima> ObtenerMateriasPrimas()
        {
            return _materiaPrimaDatos.ObtenerMateriasPrimas();
        }

        public bool AgregarMateriaPrima(MateriaPrima materia)
        {
            ValidarMateriaPrima(materia);
            return _materiaPrimaDatos.AgregarMateriaPrima(materia);
        }

        public bool ActualizarMateriaPrima(MateriaPrima materia)
        {
            if (materia.IdMateriaPrima <= 0)
                throw new ArgumentException("ID de materia prima inválido");

            ValidarMateriaPrima(materia);
            return _materiaPrimaDatos.ActualizarMateriaPrima(materia);
        }

        public bool EliminarMateriaPrima(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID de materia prima inválido");

            return _materiaPrimaDatos.EliminarMateriaPrima(id);
        }

        private void ValidarMateriaPrima(MateriaPrima materia)
        {
            if (materia.IdProveedor <= 0)
                throw new ArgumentException("Proveedor es requerido");

            if (string.IsNullOrWhiteSpace(materia.Nombre))
                throw new ArgumentException("Nombre de la materia prima es requerido");

            if (materia.PrecioUnit <= 0)
                throw new ArgumentException("Precio unitario debe ser mayor a cero");

            if (materia.Stock < 0)
                throw new ArgumentException("Stock no puede ser negativo");
        }

        /*
        public List<Usuario> BuscarEmpleados(string texto)
        {
            return MateriaPrimaDatos.BuscarMateriaPrima(texto);
        }*/
    }
}
