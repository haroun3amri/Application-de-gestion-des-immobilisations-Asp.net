using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;

namespace IMMO.BLL
{
   public  interface IFamArtBuisness
    {
        void Ajouter(IMMO_FAMILLE p);
        IMMO_FAMILLE Trouver(string CODE);
        List<IMMO_FAMILLE> TrouverParMere(string CODE);
        List<IMMO_FAMILLE> Afficher();
        void Mettre_A_Jour(IMMO_FAMILLE p);
        void Supprimer(IMMO_FAMILLE p);
    }
}
