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
                // Verificar primero si el ID existe
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
                throw new Exception("Error al obtener cliente por ID: " + ex.Message);
            }
        }
        public (bool success, string message) EliminarCliente(int idCliente)
        {
            try
            {
                // Validar que el cliente exista
                var cliente = ObtenerClientePorId(idCliente);
                if (cliente == null)
                    return (false, "Cliente no encontrado");

                // Validar ventas asociadas
                if (clienteDatos.TieneVentasAsociadas(idCliente))
                    return (false, "El cliente tiene ventas asociadas y no puede ser eliminado");

                // Ejecutar eliminación
                bool resultado = clienteDatos.EliminarCliente(idCliente);
                return resultado
                    ? (true, "Cliente eliminado correctamente")
                    : (false, "No se pudo completar la eliminación");
            }
            catch (Exception ex)
            {
                return (false, $"Error al eliminar cliente: {ex.Message}");
            }
        }

        public (bool success, string message) ActualizarCliente(Cliente cliente)
        {
            try
            {
                // Validaciones básicas
                if (cliente == null)
                    return (false, "El cliente no puede ser nulo");

                if (string.IsNullOrWhiteSpace(cliente.Nombre))
                    return (false, "El nombre es requerido");

                if (string.IsNullOrWhiteSpace(cliente.Apellido))
                    return (false, "El apellido es requerido");

                // La fecha de registro no se valida porque no es editable
                bool resultado = clienteDatos.ActualizarCliente(cliente);

                return resultado
                    ? (true, "Cliente actualizado correctamente")
                    : (false, "No se pudo actualizar el cliente");
            }
            catch (Exception ex)
            {
                return (false, $"Error al actualizar cliente: {ex.Message}");
            }
        }

    }
}
