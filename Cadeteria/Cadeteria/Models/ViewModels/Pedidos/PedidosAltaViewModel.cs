using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Models.ViewModels.Pedidos
{
    public class PedidosAltaViewModel
    {
        [Required(ErrorMessage = "Ingrese las observaciones")]
        [StringLength(800)]
        public string Observaciones { get; set; }

        [Required]
        public ClienteViewModel Cliente { get; set; }

        [Display(Name = "Estado del Pedido")]
        public string Estado { get; set; }

        public List<string> Estados { get; set; }

        public PedidosAltaViewModel()
        {

        }
    }
}
