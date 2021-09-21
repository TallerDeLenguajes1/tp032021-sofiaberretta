using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Models
{
    public class Cadeteria
    {
        private string nombre;
        public List<Cadete> Cadetes;
        public List<Pedidos> Pedidos;

        public Cadeteria()
        {
            Cadetes = new List<Cadete>();
            Pedidos = new List<Pedidos>();
        }
    }
}
