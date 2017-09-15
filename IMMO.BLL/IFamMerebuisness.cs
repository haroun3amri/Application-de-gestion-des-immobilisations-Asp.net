using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;

namespace IMMO.BLL
{
  public  interface IFamMerebuisness
    {
        void Ajouter(IMMO_FAMILLEM p);
        IMMO_FAMILLEM Trouver(string CODE);
        List<IMMO_FAMILLEM> Afficher();
        void Mettre_A_Jour(IMMO_FAMILLEM p);
        void Supprimer(IMMO_FAMILLEM p);
    }
}
