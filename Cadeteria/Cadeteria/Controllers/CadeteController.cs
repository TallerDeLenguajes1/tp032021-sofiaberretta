using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cadeteria.Models;

namespace Cadeteria.Controllers
{
    public class CadeteController : Controller
    {
        private readonly ILogger<CadeteController> _logger;
        private readonly ICadeteDB repoCadete;

        public CadeteController(ILogger<CadeteController> logger, ICadeteDB repoCadete)
        {
            _logger = logger;
            this.repoCadete = repoCadete;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MostrarCadetes()
        {
            return View(repoCadete.getAllCadetes());
        }

        public IActionResult crearCadete(string nombre, string direc, string tel)
        {
            try
            {
                Cadete nuevoCadete = new Cadete(nombre, direc, tel);
                repoCadete.guardarCadete(nuevoCadete);

                return View("MostrarCadetes", repoCadete.getAllCadetes());

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

            return View("Index");
        }

        public IActionResult eliminarCadete(int id) 
        {
            Cadete cadeteAEliminar = repoCadete.getCadeteById(id);

            if (cadeteAEliminar != null)
            {
                repoCadete.borrarCadete(cadeteAEliminar);
            }

            return View("MostrarCadetes", repoCadete.getAllCadetes());
        }

        public IActionResult modificarCadete(int id)
        {
            Cadete cadeteAModificar = repoCadete.getCadeteById(id);

            if(cadeteAModificar != null)
            {
                return View("ModificarCadete", cadeteAModificar);
            }
            else
            {
                return View("MostrarCadetes", repoCadete.getAllCadetes());
            }
        }

        public IActionResult cambiarDatosCadete(int id, string nombre, string direc, string tel)
        {
            Cadete cadeteAModificar = new Cadete(id, nombre, direc, tel);
            repoCadete.modificarCadete(cadeteAModificar);

            return View("MostrarCadetes", repoCadete.getAllCadetes());
        }

        /*public IActionResult listarPedidos(int id)
        {
            Cadete cadeteAListar = null;
            for (int i = 0; i < _DB.Cadeteria.ListaCadetes.Count(); i++)
            {
                if (_DB.Cadeteria.ListaCadetes[i].Id == id)
                {
                    cadeteAListar = _DB.Cadeteria.ListaCadetes[i];
                    break;
                }
            }

            if (cadeteAListar != null)
            {
                return View("ListarPedidos", cadeteAListar);
            }
            else
            {
                return Redirect("MostrarCadetes");
            }
        }*/

        /*public IActionResult pagarCadete(int id)
        {
            Cadete cadeteAPagar = null;
            for (int i = 0; i < _DB.Cadeteria.ListaCadetes.Count(); i++)
            {
                if (_DB.Cadeteria.ListaCadetes[i].Id == id)
                {
                    cadeteAPagar = _DB.Cadeteria.ListaCadetes[i];
                    break;
                }
            }

            if (cadeteAPagar != null)
            {
                string info = "Se le pago al Cadete " + cadeteAPagar.Id + " un monto total de " + cadeteAPagar.Pago();
                _logger.LogInformation(info);

                for (int i = 0; i < cadeteAPagar.ListadoPedidos.Count(); i++)
                {
                    if(cadeteAPagar.ListadoPedidos[i].Estado == "Entregado")
                    {
                        cadeteAPagar.ListadoPedidos[i].Estado = "Pagado";
                        cadeteAPagar.CantPedidosPagados++;
                    }
                }

                _DB.GuardarCadete(_DB.Cadeteria.ListaCadetes);

                return View("PagoExitoso", cadeteAPagar);
            }
            else
            {
                return Redirect("ListarPedidos");
            }
        }*/

    }

}
