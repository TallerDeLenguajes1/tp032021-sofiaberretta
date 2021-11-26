using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Models.Clases
{
    public class Usuario
    {
        private string nombre;
        private string password;

        public Usuario(string nombre, string password)
        {
            Nombre = nombre;
            Password = password;
        }

        public Usuario()
        {

        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Password { get => password; set => password = value; }
    }
}
