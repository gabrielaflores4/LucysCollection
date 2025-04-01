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

        public bool ActualizarProveedor(Proveedor proveedor)
        {
            if (proveedor.IdProveedor <= 0)
                throw new ArgumentException("ID de proveedor inválido");

            if (string.IsNullOrWhiteSpace(proveedor.NombreProv))
                throw new ArgumentException("El nombre del proveedor es requerido");

            return _proveedorDatos.ActualizarProveedor(proveedor);
        }

        public bool EliminarProveedor(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID de proveedor inválido");

            return _proveedorDatos.EliminarProveedor(id);
        }
    }
}
