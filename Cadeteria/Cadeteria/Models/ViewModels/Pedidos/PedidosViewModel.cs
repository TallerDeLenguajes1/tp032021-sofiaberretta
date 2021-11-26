using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Models.ViewModels.Pedidos
{
    public class PedidosViewModel
    {
        public int NumeroPedido { get; set; }
        public string Observaciones { get; set; }
        public Cliente Cliente { get; set; }
        public string Estado { get; set; }

        public PedidosViewModel()
        {

        }
    }
}
