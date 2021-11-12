using System.Collections.Generic;

namespace Cadeteria.Models
{
    public interface ICadeteDB
    {
        void borrarCadete(Cadete cadeteABorrar);
        List<Cadete> getAllCadetes();
        Cadete getCadeteById(int id);
        void guardarCadete(Cadete cadeteAGuardar);
        void modificarCadete(Cadete cadeteAModificar);
    }
}