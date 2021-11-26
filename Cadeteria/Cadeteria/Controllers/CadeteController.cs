using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cadeteria.Models;
using AutoMapper;
using Cadeteria.Models.ViewModels.Cadete;
using Microsoft.AspNetCore.Http;

namespace Cadeteria.Controllers
{
    public class CadeteController : Controller
    {
        private readonly ILogger<CadeteController> _logger;
        private readonly ICadeteDB repoCadete;
        private readonly IMapper mapper;

        public CadeteController(ILogger<CadeteController> logger, ICadeteDB repoCadete, IMapper mapper)
        {
            _logger = logger;
            this.repoCadete = repoCadete;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("ID") != null)
            {
                return View(new CadeteAltaViewModel());
            }
            else
            {
                return RedirectToAction("Index", "Usuario");
            }
        }

        public IActionResult MostrarCadetes()
        {
            List<Cadete> listaCadetes = repoCadete.getAllCadetes();
            var listaCadetesVM = mapper.Map<List<CadeteViewModel>>(listaCadetes);

            CadeteMostrarViewModel mostrarCadetesVM = new()
            {
                listaCadetes = listaCadetesVM
            };

            return View(mostrarCadetesVM);
        }

        [HttpPost]
        public IActionResult crearCadete(CadeteAltaViewModel cadete)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Cadete nuevoCadete = mapper.Map<Cadete>(cadete);
                    repoCadete.guardarCadete(nuevoCadete);

                    return RedirectToAction(nameof(MostrarCadetes));
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

            return View("Index");
        }

        public IActionResult eliminarCadete(int id) 
        {
            Cadete cadeteAEliminar = repoCadete.getCadeteById(id);

            if (cadeteAEliminar != null)
            {
                repoCadete.borrarCadete(cadeteAEliminar);
            }

            return RedirectToAction(nameof(MostrarCadetes));
        }

        [HttpGet]
        public IActionResult modificarCadete(int id)
        {
            if (HttpContext.Session.GetInt32("ID") != null)
            {
                Cadete cadeteAModificar = repoCadete.getCadeteById(id);


                if (cadeteAModificar != null)
                {
                    var cadeteVM = mapper.Map<CadeteModificarViewModel>(cadeteAModificar);
                    return View("ModificarCadete", cadeteVM);
                }
                else
                {
                    return RedirectToAction(nameof(MostrarCadetes));
                }
            }
            else
            {
                return RedirectToAction("Index", "Usuario");
            }
        }

        [HttpPost]
        public IActionResult cambiarDatosCadete(CadeteModificarViewModel cadete)
        {
            if (ModelState.IsValid) // ERROR: da falso
            {
                Cadete cadeteAModificar = mapper.Map<Cadete>(cadete);
                repoCadete.modificarCadete(cadeteAModificar);
            }

            return RedirectToAction(nameof(MostrarCadetes));
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
