using AutoMapper;
using Cadeteria.Models;
using Cadeteria.Models.ViewModels.Cadete;
using Cadeteria.Models.ViewModels.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria
{
    public class PerfilDeMapeo : Profile
    {
        public PerfilDeMapeo()
        {
            //Map de cadete
            CreateMap<Cadete, CadeteViewModel>().ReverseMap();
            CreateMap<Cadete, CadeteAltaViewModel>().ReverseMap();
            CreateMap<Cadete, CadeteModificarViewModel>().ReverseMap();
            CreateMap<Cadete, CadeteMostrarViewModel>().ReverseMap();

            //Map de pedido
            CreateMap<Pedidos, PedidosViewModel>().ReverseMap();
            CreateMap<Pedidos, PedidosAltaViewModel>().ReverseMap();
            CreateMap<Pedidos, PedidosModificarViewModel>().ReverseMap();
            CreateMap<Pedidos, PedidosMostrarViewModel>().ReverseMap();

            //Map de cliente
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
        }
    }
}
