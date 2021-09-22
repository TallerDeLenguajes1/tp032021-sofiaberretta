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
        static int id = 1;
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
            Cadete nuevoCadete = new Cadete(id, nombre, direc, tel);
            id++;
            _DB.Cadeteria.ListaCadetes.Add(nuevoCadete);
            return View("MostrarCadetes", _DB.Cadeteria.ListaCadetes);
        }
    }
}
