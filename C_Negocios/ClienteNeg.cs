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

        public Cliente ObtenerClientePorId(int clienteId)
        {
            try
            {
                // Verificar primero si el ID existe (opcional, puedes omitir este paso si prefieres)
                var idsExistentes = clienteDatos.ObtenerIdsClientes();
                if (!idsExistentes.Contains(clienteId))
                {
                    throw new Exception($"No existe un cliente con el ID {clienteId}");
                }

                // Obtener el cliente completo
                var cliente = clienteDatos.ObtenerClientePorId(clienteId);

                if (cliente == null)
                {
                    throw new Exception($"Error al obtener datos del cliente con ID {clienteId}");
                }

                return cliente;
            }
            catch (Exception ex)
            {
                // Puedes loggear el error aquí si tienes un sistema de logging
                throw new Exception("Error al obtener cliente por ID: " + ex.Message);
            }
        }

    }
}
