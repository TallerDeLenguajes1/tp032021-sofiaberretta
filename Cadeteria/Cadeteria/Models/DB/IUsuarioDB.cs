using Cadeteria.Models.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Models.DB
{
    public interface IUsuarioDB
    {
        void guardarUsuario(Usuario usuario);
        int getUsuarioId(string nombre, string pass);
        int getUsuarioRol(int idUsuario);
    }
}
