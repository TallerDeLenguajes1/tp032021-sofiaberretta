using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Models
{
    public class DBTemporal
    {
        private Cadeteria cadeteria;

        public DBTemporal()
        {
            Cadeteria = new Cadeteria();
        }

        public Cadeteria Cadeteria { get => cadeteria; set => cadeteria = value; }
    }
}
