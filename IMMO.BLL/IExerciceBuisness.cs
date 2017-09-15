using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;

namespace IMMO.BLL
{
   public  interface IExerciceBuisness
    {
        void Ajouter(IMMO_EXERCICE a);
        IMMO_EXERCICE Trouver(int annee);
        List<IMMO_EXERCICE> Afficher();
        void Mettre_A_Jour(IMMO_EXERCICE a);
        void Supprimer(IMMO_EXERCICE a);
    }
}
