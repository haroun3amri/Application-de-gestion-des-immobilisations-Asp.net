using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;

namespace IMMO.BLL
{
   public  interface ITVaBuisness
    {
        void Ajouter(IMMO_TVA t);
        IMMO_TVA Trouver(int code);
        List<IMMO_TVA> Afficher();
        void Mettre_A_Jour(IMMO_TVA t);
        void Supprimer(IMMO_TVA t);
    }
}
