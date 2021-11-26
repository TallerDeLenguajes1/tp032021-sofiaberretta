using Cadeteria.Models.ViewModels.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Models.ViewModels.Cadete
{
    public class CadeteViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public List<PedidosViewModel> ListadoPedidos { get; set; }
        public int CantPedidosPagados { get; set; }

        public CadeteViewModel()
        {

        }
    }
}
