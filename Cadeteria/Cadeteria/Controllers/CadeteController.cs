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
        static int id = 0;
        private readonly ILogger<CadeteController> _logger;
        public CadeteController(ILogger<CadeteController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MostrarCadetes()
        {
            return View();
        }

        public IActionResult crearCadete(string nombre, string direc, string tel)
        { 
            Cadete nuevoCadete = new Cadete(id, nombre, direc, tel);
            id++;
            //falta anadir el cadete a la lista de cadetes
            return View("MostrarCadetes");
        }
    }
}
