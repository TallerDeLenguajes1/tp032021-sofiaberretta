using System.Collections.Generic;

namespace Cadeteria.Models
{
    public interface ICadetesDB
    {
        Cadeteria Cadeteria { get; set; }

        void BorrarCadete(int id);
        List<Cadete> GetListCadetes();
        void GuardarCadete(List<Cadete> cadetes);
        void ModificarCadete(Cadete cadete);
    }
}