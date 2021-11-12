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
        private readonly ILogger<PedidoController> _logger;
        private readonly IPedidoDB repoPedido;
        private readonly IClienteDB repoCliente;
        public PedidoController(ILogger<PedidoController> logger, IPedidoDB repoPedido, IClienteDB repoCliente)
        {
            _logger = logger;
            this.repoPedido = repoPedido;
            this.repoCliente = repoCliente;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MostrarPedidos()
        {
            return View(repoPedido.getAllPedidos());
        }

        public IActionResult crearPedido(string obs, string estado, string nombreC, string direcC, string telC)
        {
            try
            {
                Cliente nuevoCliente = new Cliente(nombreC, direcC, telC);
                repoCliente.guardarCliente(nuevoCliente);

                nuevoCliente.Id = repoCliente.getLastIDCliente();

                Pedidos nuevoPedido = new Pedidos(obs, estado);
                nuevoPedido.Cliente = nuevoCliente;

                repoPedido.guardarPedido(nuevoPedido);
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
            
            return View("MostrarPedidos", repoPedido.getAllPedidos());
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

        public IActionResult eliminarPedido(int NumeroPedido)
        {
            Pedidos pedidoAEliminar = repoPedido.getPedidoById(NumeroPedido);

            if (pedidoAEliminar != null)
            {
                repoPedido.borrarPedido(pedidoAEliminar);
            }

            return View("MostrarPedidos", repoPedido.getAllPedidos());
        }

        public IActionResult modificarPedido(int NumeroPedido)
        {
            Pedidos pedidoAModificar = repoPedido.getPedidoById(NumeroPedido);

            if (pedidoAModificar != null)
            {
                return View("ModificarPedido", pedidoAModificar);
            }
            else
            {
                return View("MostrarPedidos", repoPedido.getAllPedidos());
            }
        }

        public IActionResult cambiarDatosPedido(int numPedido, string obs, string estado, string nombreC, string direcC, string telC)
        {
            try
            {
                if (numPedido > 0)
                {
                    Pedidos pedidoAModificar = new Pedidos();
                    pedidoAModificar.NumeroPedido = numPedido;
                    pedidoAModificar.Observaciones = obs;
                    pedidoAModificar.Estado = estado;
                    pedidoAModificar.Cliente.Nombre = nombreC;
                    pedidoAModificar.Cliente.Direccion = direcC;
                    pedidoAModificar.Cliente.Telefono = telC;

                    repoPedido.modificarPedido(pedidoAModificar);
                    return View("MostrarPedidos", repoPedido.getAllPedidos());
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
            
            return View("MostrarPedidos", repoPedido.getAllPedidos());
            
        }
    }
}
