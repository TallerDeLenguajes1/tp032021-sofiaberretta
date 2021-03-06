using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Models.ViewModels.Cadete
{
    public class CadeteAltaViewModel
    {
        [Required(ErrorMessage = "Ingrese un nombre")]
        [StringLength(200)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Ingrese una direccion")]
        [StringLength(200)]
        [Display(Name = "Direccion")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Ingrese un telefono")]
        [RegularExpression(pattern: "^[0-9]{10}$",
            ErrorMessage = "Ingrese un num de telefono valido",
            MatchTimeoutInMilliseconds = 350)]
        [Display(Name = "Num de Telefono")]
        public string Telefono { get; set; }

        public CadeteAltaViewModel()
        {

        }
    }
}
