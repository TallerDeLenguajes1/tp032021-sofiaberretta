using System.Collections.Generic;

namespace Cadeteria.Models
{
    public interface IPedidoDB
    {
        void borrarPedido(Pedidos pedidoABorrar);
        List<Pedidos> getAllPedidos();
        Pedidos getPedidoById(int id);
        void guardarPedido(Pedidos pedidoAGuardar);
        void modificarPedido(Pedidos pedidoAModificar);
    }
}