using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;

namespace IMMO.BLL
{
   public interface IBlDetailBuisness
    {
       void Ajouter(IMMO_DETAILBL c);
       IMMO_DETAILBL Trouver(int ANNEEBL, int NUMBL, int NUM);
       List<IMMO_DETAILBL> TrouverParNumBl(int NUMBL);

       List<IMMO_DETAILBL> TrouverParAnnee(int ANNEEBL);
       List<IMMO_DETAILBL> TrouverParNumEtAnnee(int ANNEEBL, int NUMBL);
        List<IMMO_DETAILBL> Afficher();
        void Mettre_A_Jour(IMMO_DETAILBL c);
        void Supprimer(IMMO_DETAILBL c);
        List<IMMO_DETAILBL> TrouverParMere(int NUM);

    }
}
