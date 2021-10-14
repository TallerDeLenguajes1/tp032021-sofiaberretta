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
        private readonly DBTemporal _DB;
        public CadeteController(ILogger<CadeteController> logger, DBTemporal DB)
        {
            _logger = logger;
            _DB = DB;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MostrarCadetes()
        {
            return View(_DB.Cadeteria.ListaCadetes);
        }

        public IActionResult crearCadete(string nombre, string direc, string tel)
        {
            try
            {
                int ultimoId = 0;
                if (_DB.Cadeteria.ListaCadetes.Count() > 0)
                {
                    ultimoId = _DB.Cadeteria.ListaCadetes.Max(x => x.Id);
                }
                ultimoId++;
                Cadete nuevoCadete = new Cadete(ultimoId, nombre, direc, tel);
                _DB.Cadeteria.ListaCadetes.Add(nuevoCadete);
                _DB.GuardarCadete(_DB.Cadeteria.ListaCadetes);

                return View("MostrarCadetes", _DB.Cadeteria.ListaCadetes);

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
            for(int i=0; i < _DB.Cadeteria.ListaCadetes.Count(); i++)
            {
                if(_DB.Cadeteria.ListaCadetes[i].Id == id)
                {
                    _DB.Cadeteria.ListaCadetes.Remove(_DB.Cadeteria.ListaCadetes[i]);
                    _DB.BorrarCadete(id);
                    break;
                }
            }

            return View("MostrarCadetes", _DB.Cadeteria.ListaCadetes);
        }

        public IActionResult modificarCadete(int id)
        {
            Cadete cadeteAModificar = null;
            for (int i = 0; i < _DB.Cadeteria.ListaCadetes.Count(); i++)
            {
                if (_DB.Cadeteria.ListaCadetes[i].Id == id)
                {
                    cadeteAModificar = _DB.Cadeteria.ListaCadetes[i];
                    break;
                }
            }

            if(cadeteAModificar != null)
            {
                return View("ModificarCadete", cadeteAModificar);
            }
            else
            {
                return Redirect("MostrarCadetes");
            }
        }

        public IActionResult cambiarDatosCadete(int id, string nombre, string direc, string tel)
        {
            try
            {
                if (id > 0)
                {
                    Cadete cadeteAModificar = new Cadete();
                    cadeteAModificar.Nombre = nombre;
                    cadeteAModificar.Direccion = direc;
                    cadeteAModificar.Telefono = tel;
                    _DB.ModificarCadete(cadeteAModificar);

                    return View("MostrarCadetes", _DB.Cadeteria.ListaCadetes);
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

            return View("MostrarCadetes", _DB.Cadeteria.ListaCadetes);
        }

        public IActionResult listarPedidos(int id)
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
        }

        public IActionResult pagarCadete(int id)
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
                for (int i = 0; i < cadeteAPagar.ListadoPedidos.Count(); i++)
                {
                    if(cadeteAPagar.ListadoPedidos[i].Estado == "Entregado")
                    {
                        cadeteAPagar.ListadoPedidos.Remove(cadeteAPagar.ListadoPedidos[i]);
                        cadeteAPagar.CantPedidosPagados++;
                    }
                }
                return View("PagoExitoso", cadeteAPagar);
            }
            else
            {
                return Redirect("ListarPedidos");
            }
        }

        public IActionResult PagoExitoso(int id)
        {
            return View();
        }

    }

}
