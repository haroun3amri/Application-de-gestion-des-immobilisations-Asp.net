using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;

namespace IMMO.BLL
{
   public interface ICompteBuisness
   {
       void Ajouter(IMMO_COMPTE c);
       IMMO_COMPTE Trouver(string NUM);
       List<IMMO_COMPTE> Afficher();
       void Mettre_A_Jour(IMMO_COMPTE c);
       void Supprimer(IMMO_COMPTE c);
    }
}
