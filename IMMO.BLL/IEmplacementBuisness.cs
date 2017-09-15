using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;

namespace IMMO.BLL
{
    public interface IEmplacementBuisness
    {
        void Ajouter(IMMO_EMPLACEMENT e);
        IMMO_EMPLACEMENT Trouver(string CODE);
        List<IMMO_EMPLACEMENT> Afficher();
        void Mettre_A_Jour(IMMO_EMPLACEMENT e);
        void Supprimer(IMMO_EMPLACEMENT e);

    }
}
