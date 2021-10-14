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
        private readonly DBTemporal _DB;
        public PedidoController(ILogger<PedidoController> logger, DBTemporal DB)
        {
            _logger = logger;
            _DB = DB;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MostrarPedidos()
        {
            return View(_DB.Cadeteria);
        }

        public IActionResult crearPedido(string obs, string estado, string nombreC, string idC, string direcC, string telC)
        {
            try
            {
                int ultimoNum = 100;
                if (_DB.Cadeteria.ListaPedidos.Count() > 0)
                {
                    ultimoNum = _DB.Cadeteria.ListaPedidos.Max(x => x.NumeroPedido);
                }
                ultimoNum++;
                Pedidos nuevoPedido = new Pedidos(ultimoNum, obs, idC, nombreC, direcC, telC, estado);
                _DB.Cadeteria.ListaPedidos.Add(nuevoPedido);
                _DB.GuardarPedido(_DB.Cadeteria.ListaPedidos);
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
            
            return View("MostrarPedidos", _DB.Cadeteria);
        }

        public IActionResult AsignarCadete(int idPedido, int idCadete)
        {
            QuitarPedidoDeCadete(idPedido);

            if (idCadete != 0)
            {
                Cadete cadete = _DB.Cadeteria.ListaCadetes.Where(a => a.Id == idCadete).First();
                Pedidos pedido = _DB.Cadeteria.ListaPedidos.Where(b => b.NumeroPedido == idPedido).First();
                cadete.ListadoPedidos.Add(pedido);

                string info = "Se asigno el cadete " + idCadete + " al pedido " + idPedido;
                _logger.LogInformation(info);
            }

            return View("MostrarPedidos", _DB.Cadeteria);
        }

        private void QuitarPedidoDeCadete(int idPedido)
        {
            Pedidos pedido = _DB.Cadeteria.ListaPedidos.Find(x => x.NumeroPedido == idPedido);
            _DB.Cadeteria.ListaCadetes.ForEach(cadete => cadete.ListadoPedidos.Remove(pedido));

        }

        public IActionResult eliminarPedido(int NumeroPedido)
        {
            for (int i = 0; i < _DB.Cadeteria.ListaPedidos.Count(); i++)
            {
                if (_DB.Cadeteria.ListaPedidos[i].NumeroPedido == NumeroPedido)
                {
                    _DB.Cadeteria.ListaPedidos.Remove(_DB.Cadeteria.ListaPedidos[i]);
                    _DB.BorrarPedido(NumeroPedido);
                    break;
                }
            }

            return View("MostrarPedidos", _DB.Cadeteria);
        }

        public IActionResult modificarPedido(int NumeroPedido)
        {
            Pedidos pedidoAModificar = null;
            for (int i = 0; i < _DB.Cadeteria.ListaPedidos.Count(); i++)
            {
                if (_DB.Cadeteria.ListaPedidos[i].NumeroPedido == NumeroPedido)
                {
                    pedidoAModificar = _DB.Cadeteria.ListaPedidos[i];
                    break;
                }
            }

            if (pedidoAModificar != null)
            {
                return View("ModificarPedido", pedidoAModificar);
            }
            else
            {
                return View("MostrarPedidos", _DB.Cadeteria);
            }
        }

        public IActionResult cambiarDatosPedido(int numPedido, string obs, string estado, string nombreC, string idC, string direcC, string telC)
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
                    pedidoAModificar.Cliente.Id = idC;
                    pedidoAModificar.Cliente.Direccion = direcC;
                    pedidoAModificar.Cliente.Telefono = telC;

                    _DB.ModificarPedido(pedidoAModificar);
                    return View("MostrarPedidos", _DB.Cadeteria);//No se modifica en la vista
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
            
            return View("MostrarPedidos", _DB.Cadeteria);
            
        }
    }
}
