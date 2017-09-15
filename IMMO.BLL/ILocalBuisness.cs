using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;

namespace IMMO.BLL
{
    public interface ILocalBuisness
    {
        void Ajouter(IMMO_LOCAL l);
        IMMO_LOCAL Trouver(string CODE);
        List<IMMO_LOCAL> Afficher();
        void Mettre_A_Jour(IMMO_LOCAL l);
        void Supprimer(IMMO_LOCAL l);
    }
}
