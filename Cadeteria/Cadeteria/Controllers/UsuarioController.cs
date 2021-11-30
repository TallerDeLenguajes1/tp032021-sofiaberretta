using AutoMapper;
using Cadeteria.Models;
using Cadeteria.Models.Clases;
using Cadeteria.Models.DB;
using Cadeteria.Models.ViewModels.Usuario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly IUsuarioDB repoUsuario;
        private readonly IMapper mapper;

        public UsuarioController(ILogger<UsuarioController> logger, IUsuarioDB repoUsuario, IMapper mapper)
        {
            _logger = logger;
            this.repoUsuario = repoUsuario;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            return View(new UsuarioIndexViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult logIn(UsuarioIndexViewModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Usuario logInUsuario = mapper.Map<Usuario>(usuario);
                    int usuarioID = repoUsuario.getUsuarioId(logInUsuario.Nombre, logInUsuario.Contrasenia);
                    int usuarioRol = repoUsuario.getUsuarioRol(usuarioID);

                    if (usuarioID != 0)
                    {
                        HttpContext.Session.SetInt32("ID", usuarioID);
                        HttpContext.Session.SetInt32("Rol", usuarioRol);

                        return RedirectToAction("Index", "Home");
                        
                    }
                    else
                    {
                        return RedirectToAction(nameof(Error));
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

            return RedirectToAction("Index", "Usuario");
        }

        public ActionResult CrearUsuario()
        {
            return View(new UsuarioAltaViewModel());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult guardarUsuario(UsuarioAltaViewModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Usuario nuevoUsuario = mapper.Map<Usuario>(usuario);
                    repoUsuario.guardarUsuario(nuevoUsuario);

                    return RedirectToAction("Index", "Usuario");
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

            return RedirectToAction(nameof(CrearUsuario));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
