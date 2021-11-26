using Cadeteria.Models.ViewModels.Cadete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Models.ViewModels.Pedidos
{
    public class PedidosMostrarViewModel
    {
        public List<PedidosViewModel> listaPedidos { get; set; }
        public List<CadeteViewModel> listaCadetes { get; set; }

        public PedidosMostrarViewModel()
        {

        }
    }
}
