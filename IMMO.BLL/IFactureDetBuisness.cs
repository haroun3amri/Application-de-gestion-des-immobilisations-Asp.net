using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;

namespace IMMO.BLL
{
   public  interface IFactureDetBuisness
    {
        void Ajouter(IMMO_DETAILFACTURE df);
        List<IMMO_DETAILFACTURE> Trouver(string NumFacture);
        List<IMMO_DETAILFACTURE> Afficher();
        void Mettre_A_Jour(IMMO_DETAILFACTURE df);
        void Supprimer(IMMO_DETAILFACTURE df);
        List<IMMO_DETAILFACTURE> TrouverParMere(string NUM);
    }
}
