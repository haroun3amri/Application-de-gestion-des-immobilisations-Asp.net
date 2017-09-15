using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;

namespace IMMO.BLL
{
    public interface IFamilleComptableBuisness
    {
        void Ajouter(IMMO_FAMILLECOMPTABLE fc);
        IMMO_FAMILLECOMPTABLE Trouver(string CODE);
        List<IMMO_FAMILLECOMPTABLE> Afficher();
        void Mettre_A_Jour(IMMO_FAMILLECOMPTABLE fc);
        void Supprimer(IMMO_FAMILLECOMPTABLE fc);
    }
}
