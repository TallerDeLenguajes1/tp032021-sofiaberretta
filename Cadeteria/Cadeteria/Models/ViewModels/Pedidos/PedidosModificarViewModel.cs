using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Models.ViewModels.Pedidos
{
    public class PedidosModificarViewModel
    {
        public int NumeroPedido { get; set; }

        [Required(ErrorMessage = "Ingrese las observaciones")]
        [StringLength(800)]
        public string Observaciones { get; set; }

        [Required(ErrorMessage = "Ingrese un nombre")]
        [StringLength(200)]
        [Display(Name = "Nombre del Cliente")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Ingrese una direccion")]
        [StringLength(200)]
        [Display(Name = "Direccion del Cliente")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Ingrese un telefono")]
        [RegularExpression(pattern: "^[0-9]{10}$",
            ErrorMessage = "Ingrese un num de telefono valido",
            MatchTimeoutInMilliseconds = 350)]
        [Display(Name = "Telefono del Cliente")]
        public string Telefono { get; set; }

        [Display(Name = "Estado pedido")]
        public string Estado { get; set; }

        public PedidosModificarViewModel()
        {

        }
    }
}
