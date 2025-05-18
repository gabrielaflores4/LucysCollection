using C_Datos;
using C_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Negocios
{
    public class ProveedorNeg
    {
        private readonly ProveedorDatos _proveedorDatos = new ProveedorDatos();

        public List<Proveedor> ObtenerProveedores()
        {
            return _proveedorDatos.ObtenerProveedores();
        }

        public bool AgregarProveedor(Proveedor proveedor)
        {
            if (string.IsNullOrWhiteSpace(proveedor.NombreProv))
                throw new ArgumentException("El nombre del proveedor es requerido");

            if (string.IsNullOrWhiteSpace(proveedor.Telefono))
                throw new ArgumentException("El teléfono es requerido");

            return _proveedorDatos.AgregarProveedor(proveedor);
        }

        public bool ActualizarProveedor(int id, string nombre, string telefono, string correo, string direccion)
        {
            try
            {
                var proveedor = new Proveedor
                {
                    IdProveedor = id,
                    NombreProv = nombre,
                    Telefono = telefono,
                    Correo = correo,
                    Direccion = direccion
                };
                return _proveedorDatos.ActualizarProveedor(proveedor);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EliminarProveedor(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID de proveedor inválido");

            return _proveedorDatos.EliminarProveedor(id);
        }
        public int ObtenerProveedorIdPorNombre(string nombreProveedor)
        {
            try
            {
                var proveedorDatos = new ProveedorDatos();
                object resultado = proveedorDatos.ObtenerProveedorIdPorNombre(nombreProveedor);
                if (resultado == null)
                {
                    return 0; 
                }
                return Convert.ToInt32(resultado); 
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener ID del proveedor '{nombreProveedor}': {ex.Message}", ex);
            }
        }
    }
}
