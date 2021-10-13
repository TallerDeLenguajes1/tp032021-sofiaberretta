using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Models
{
    public class Pedidos
    {
        private int numeroPedido;
        private string observaciones;
        private Cliente cliente;
        private string estado;

        public Pedidos(int numPedido, string obs, string idCliente, string nombreCliente, string direcCliente, string telCliente, string estado)
        {
            numeroPedido = numPedido;
            observaciones = obs;
            cliente = new Cliente(idCliente, nombreCliente, direcCliente, telCliente);
            this.estado = estado;
        }

        public Pedidos()
        {

        }

        public int NumeroPedido { get => numeroPedido; set => numeroPedido = value; }
        public string Observaciones { get => observaciones; set => observaciones = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public string Estado { get => estado; set => estado = value; }
    }
}
