using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_Datos;
using C_Entidades;

namespace C_Negocios
{
    public class ClienteNeg

    {
        private ClienteDatos clienteDatos;

        public ClienteNeg()
        {
            clienteDatos = new ClienteDatos();

            if (clienteDatos == null)
            {
                throw new Exception("Error al inicializar ClienteDatos.");
            }
        }
        public int CrearCliente(string nombre, string apellido, string correo, string telefono, DateTime fechaRegistro)
        {
            // Llamar a la clase de datos para crear el cliente
            return clienteDatos.CrearCliente(nombre, apellido, correo, telefono, fechaRegistro);
        }

        public List<string> ObtenerNombresClientes()
        {
            return clienteDatos.ObtenerNombresClientes();
        }

        public List<int> ObtenerIdsClientes()
        {
            try
            {
                return clienteDatos.ObtenerIdsClientes();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener IDs de clientes: " + ex.Message);
            }
        }

        public List<Cliente> ObtenerClientes()
        {
            ClienteDatos datos = new ClienteDatos();
            return datos.ObtenerClientes();
        }
    }
}
