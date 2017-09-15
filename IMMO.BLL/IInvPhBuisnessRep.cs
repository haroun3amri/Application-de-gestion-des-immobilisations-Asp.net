using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;

namespace IMMO.BLL
{
  public interface IInvPhBuisnessRep
    {
        void Ajouter(INV_PH i);
        INV_PH Trouver(string CODE);
        List<INV_PH> Afficher();
        void Mettre_A_Jour(INV_PH i);
        void Supprimer(INV_PH i);
    }
}
