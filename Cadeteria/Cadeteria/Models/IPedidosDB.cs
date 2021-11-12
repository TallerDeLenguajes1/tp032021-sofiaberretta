using System.Collections.Generic;

namespace Cadeteria.Models
{
    public interface IPedidosDB
    {
        Cadeteria Cadeteria { get; set; }

        void BorrarPedido(int numPedido);
        List<Pedidos> GetListPedidos();
        void GuardarPedido(List<Pedidos> pedidos);
        void ModificarPedido(Pedidos pedido);
    }
}