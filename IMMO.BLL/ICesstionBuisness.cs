using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;

namespace IMMO.BLL
{
  public  interface ICesstionBuisness
  {
      void Ajouter(IMMO_CESSION c);
      IMMO_CESSION Trouver(int annee, int num);
      IMMO_CESSION TrouverParAnnee(int annee);
      IMMO_CESSION TrouverParNum(int Num);
      List<IMMO_CESSION> Afficher();
      void Mettre_A_Jour(IMMO_CESSION c);
      void Supprimer(IMMO_CESSION c);

    }
}
