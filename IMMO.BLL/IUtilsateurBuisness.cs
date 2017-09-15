using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;
using IMMO.BLL;
namespace IMMO.BLL
{
   public interface IUtilsateurBuisness
    {
        void Ajouter(Login1 l);
        Login1 Trouver(int username);
        List<Login1> Afficher();
      void Mettre_A_Jour(Login1 l);
        void Supprimer(Login1 l);
    }
}
