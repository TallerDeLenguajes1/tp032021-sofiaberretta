using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Models.ViewModels.Usuario
{
    public class UsuarioAltaViewModel
    {
        [Required(ErrorMessage = "Por favor ingrese un nombre de usuario")]
        [StringLength(15)]
        [Display(Name = "Nombre de Usuario")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Ingrese una direccion de correo valida")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Ingrese una contraseña")]
        [StringLength(15, ErrorMessage = "La {0} debe tener al menos {2} y como máximo {1} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Contrasenia { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Password", ErrorMessage = "La contraseña no coincide con la confirmación.")]
        public string ConfirmarContrasenia { get; set; }

        public UsuarioAltaViewModel()
        {

        }
    }
}
