using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cadeteria.Models;

namespace Cadeteria.Controllers
{
    public class PedidoController : Controller
    {
        static int numPedido = 100;
        private readonly ILogger<PedidoController> _logger;
        static Models.Cadeteria cadeteria = new Models.Cadeteria();
        public PedidoController(ILogger<PedidoController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MostrarPedidos()
        {
            return View();
        }

        public IActionResult crearPedido(string obs, string estado, string nombreC, string idC, string direcC, string telC)
        {
            Pedidos nuevoPedido = new Pedidos(numPedido, obs, idC, nombreC, direcC, telC, estado);
            numPedido++;
            cadeteria.ListaPedidos.Add(nuevoPedido);
            return View("MostrarPedidos", cadeteria.ListaPedidos);
        }
    }
}
