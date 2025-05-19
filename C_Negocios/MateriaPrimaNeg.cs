using C_Datos;
using C_Entidades;

namespace C_Negocios
{
    public class MateriaPrimaNeg
    {
        private readonly MateriaPrimaDatos _materiaPrimaDatos = new MateriaPrimaDatos();

        public List<MateriaPrima> ObtenerMateriasPrimas()
        {
            return _materiaPrimaDatos.ObtenerMateriasPrimas();
        }

        public bool AgregarMateriasPrimas(List<MateriaPrima> materias)
        {
            // Validaciones de negocio
            foreach (var materia in materias)
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

            // Delegar a la capa de datos
            return _materiaPrimaDatos.AgregarMateriasPrimas(materias);
        }

        public bool ActualizarMateriaPrima(int id, string nombre, decimal precioUnit, int stock, int proveedorId)
        {
            try
            {
                var materia = new MateriaPrima
                {
                    IdMateriaPrima = id,
                    Nombre = nombre,
                    PrecioUnit = precioUnit,
                    Stock = stock,
                    IdProveedor = proveedorId 
                };

                Console.WriteLine($"Actualizando: ID={id}, Nombre={nombre}, ProveedorID={proveedorId}");
                return _materiaPrimaDatos.ActualizarMateriaPrima(materia);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en negocio: {ex.Message}");
                return false;
            }
        }
        
        public bool EliminarMP(int idMateriaPrima)
        {
            // Solo validación básica del ID
            if (idMateriaPrima <= 0)
                throw new ArgumentException("ID de materia prima inválido");

            return _materiaPrimaDatos.EliminarMP(idMateriaPrima);
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
    }
}
