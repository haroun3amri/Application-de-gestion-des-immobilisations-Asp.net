using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;

namespace IMMO.BLL
{
   public interface IAffectationBuiness1
    {
        void Ajouter(IMMO_AFFECTATION a);
        IMMO_AFFECTATION Trouver(string CODE);
        List<IMMO_AFFECTATION> Afficher();
        void Mettre_A_Jour(IMMO_AFFECTATION a);
        void Supprimer(IMMO_AFFECTATION a);
    }
}
