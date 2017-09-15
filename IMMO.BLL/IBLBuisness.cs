using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;

namespace IMMO.BLL
{
   public  interface IBLBuisness
    {

        void Ajouter(IMMO_BL bl);
        IMMO_BL Trouver(int annee , int num);
        List<IMMO_BL> Afficher();
        void Mettre_A_Jour(IMMO_BL bl);
        void Supprimer(IMMO_BL bl);


    }
}
