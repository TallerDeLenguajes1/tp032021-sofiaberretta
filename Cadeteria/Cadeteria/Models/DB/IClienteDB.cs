using System.Collections.Generic;

namespace Cadeteria.Models
{
    public interface IClienteDB
    {
        void borrarCliente(Cliente clienteABorrar);
        List<Cliente> getAllClientes();
        int getLastIDCliente();
        void guardarCliente(Cliente clienteAGuardar);
        void modificarCliente(Cliente clienteAModificar);
    }
}