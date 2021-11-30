using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Models.Clases
{
    public class Usuario
    {
        int idUsuario;
        string nombre;
        string contrasenia;
        string email;
        string rol;
        public Usuario()
        {

        }


        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Contrasenia { get => contrasenia; set => contrasenia = value; }
        public string Email { get => email; set => email = value; }
        public string Rol { get => rol; set => rol = value; }
    }
}
