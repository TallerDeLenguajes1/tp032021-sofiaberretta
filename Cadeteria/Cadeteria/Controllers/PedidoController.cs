using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cadeteria.Models;
using AutoMapper;
using Cadeteria.Models.ViewModels.Pedidos;
using Cadeteria.Models.ViewModels.Cadete;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;

namespace Cadeteria.Controllers
{
    public class PedidoController : Controller
    {
        private readonly ILogger<PedidoController> _logger;
        private readonly IPedidoDB repoPedido;
        private readonly IClienteDB repoCliente;
        private readonly ICadeteDB repoCadete;
        private readonly IMapper mapper;
        public PedidoController(ILogger<PedidoController> logger, IPedidoDB repoPedido, IClienteDB repoCliente, ICadeteDB repoCadete, IMapper mapper)
        {
            _logger = logger;
            this.repoPedido = repoPedido;
            this.repoCliente = repoCliente;
            this.repoCadete = repoCadete;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("ID") != null)
            {
                if (HttpContext.Session.GetInt32("Rol") == 1)
                {
                    PedidosAltaViewModel pedidos = new PedidosAltaViewModel();

                    pedidos.Estados = new List<string>()
                    {
                        "Pendiente",
                        "Entregado"
                    };

                    return View(pedidos);
                }
                else
                {
                    return RedirectToAction(nameof(MostrarPedidos));
                }
            }
            else
            {
                return RedirectToAction("Index", "Usuario");
            }
            
        }

        public IActionResult MostrarPedidos()
        {
            if (HttpContext.Session.GetInt32("ID") != null)
            {
                List<Cadete> cadetes = repoCadete.getAllCadetes();
                var cadetesVM = mapper.Map<List<CadeteViewModel>>(cadetes);

                List<Pedidos> pedidos = repoPedido.getAllPedidos();
                var pedidosVM = mapper.Map<List<PedidosViewModel>>(pedidos);

                var pedidoMostrarVM = new PedidosMostrarViewModel();
                pedidoMostrarVM.listaCadetes = cadetesVM;
                pedidoMostrarVM.listaPedidos = pedidosVM;

                return View(pedidoMostrarVM);
            }
            else
            {
                return RedirectToAction("Index", "Usuario");
            }
        }

        public IActionResult crearPedido(PedidosAltaViewModel pedido)
        {
            try
            {
                if (HttpContext.Session.GetInt32("ID") != null)
                {
                    if (HttpContext.Session.GetInt32("Rol") == 1)
                    {
                        if (ModelState.IsValid)
                        {
                            Pedidos nuevoPedido = mapper.Map<Pedidos>(pedido);

                            repoCliente.guardarCliente(nuevoPedido.Cliente);

                            nuevoPedido.Cliente.Id = repoCliente.getLastIDCliente();

                            repoPedido.guardarPedido(nuevoPedido);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var mensaje = "Mensaje de error: " + ex.Message;

                if (ex.InnerException != null)
                {
                    mensaje = mensaje + " Excepcion interna: " + ex.InnerException.Message;
                }

                mensaje = mensaje + " Sucedio en: " + ex.StackTrace;

                _logger.LogError(mensaje);
            }

            return RedirectToAction(nameof(MostrarPedidos));
        }

        public IActionResult eliminarPedido(int NumeroPedido)
        {
            if (HttpContext.Session.GetInt32("ID") != null)
            {
                if (HttpContext.Session.GetInt32("Rol") == 1)
                {
                    Pedidos pedidoAEliminar = repoPedido.getPedidoById(NumeroPedido);

                    if (pedidoAEliminar != null)
                    {
                        repoPedido.borrarPedido(pedidoAEliminar);
                    }

                    return RedirectToAction(nameof(MostrarPedidos));
                }
                else
                {
                    return RedirectToAction(nameof(Error));
                }
            }
            else
            {
                return RedirectToAction("Index", "Usuario");
            }
        }

        [HttpGet]
        public IActionResult modificarPedido(int NumeroPedido)
        {
            if (HttpContext.Session.GetInt32("ID") != null)
            {
                if (HttpContext.Session.GetInt32("Rol") == 1 || HttpContext.Session.GetInt32("Rol") == 2)
                {
                    Pedidos pedidoAModificar = repoPedido.getPedidoById(NumeroPedido);

                    if (pedidoAModificar != null)
                    {
                        var pedidoVM = mapper.Map<PedidosModificarViewModel>(pedidoAModificar);
                        return View("ModificarPedido", pedidoVM);
                    }
                    else
                    {
                        return RedirectToAction(nameof(MostrarPedidos));
                    }
                }
                else
                {
                    return RedirectToAction(nameof(MostrarPedidos));
                }
            }
            else
            {
                return RedirectToAction("Index", "Usuario");
            }
        }

        [HttpPost]
        public IActionResult cambiarDatosPedido(PedidosModificarViewModel pedido)
        {
            try
            {
                if (HttpContext.Session.GetInt32("ID") != null)
                {
                    if (HttpContext.Session.GetInt32("Rol") == 1 || HttpContext.Session.GetInt32("Rol") == 2)
                    {
                        if (ModelState.IsValid)
                        {
                            Pedidos pedidoAModificar = mapper.Map<Pedidos>(pedido);
                            repoPedido.modificarPedido(pedidoAModificar);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var mensaje = "Mensaje de error: " + ex.Message;

                if (ex.InnerException != null)
                {
                    mensaje = mensaje + " Excepcion interna: " + ex.InnerException.Message;
                }

                mensaje = mensaje + " Sucedio en: " + ex.StackTrace;

                _logger.LogError(mensaje);
            }

            return RedirectToAction(nameof(MostrarPedidos));

        }

        /*public IActionResult AsignarCadete(int idPedido, int idCadete)
        {
            QuitarPedidoDeCadete(idPedido);

            if (idCadete != 0)
            {
                Cadete cadete = _DB.Cadeteria.ListaCadetes.Where(a => a.Id == idCadete).First();
                Pedidos pedido = _DB.Cadeteria.ListaPedidos.Where(b => b.NumeroPedido == idPedido).First();
                cadete.ListadoPedidos.Add(pedido);

                _DB.GuardarCadete(_DB.Cadeteria.ListaCadetes);

                string info = "Se asigno el cadete " + idCadete + " al pedido " + idPedido;
                _logger.LogInformation(info);
            }

            return View("MostrarPedidos", _DB.Cadeteria);
        }*/

        /*private void QuitarPedidoDeCadete(int idPedido)
        {
            Pedidos pedidoSeleccionado = _DB.Cadeteria.ListaPedidos.Find(x => x.NumeroPedido == idPedido);
            foreach (var cadete in _DB.Cadeteria.ListaCadetes)
            {
                foreach (var pedido in cadete.ListadoPedidos)
                {
                    if (pedido.NumeroPedido == pedidoSeleccionado.NumeroPedido)
                    {
                        cadete.ListadoPedidos.Remove(pedido);
                        break;
                    }
                }
            }
            
            _DB.GuardarCadete(_DB.Cadeteria.ListaCadetes);
        }*/

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
