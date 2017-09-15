using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;

namespace IMMO.BLL
{
   public  interface IAffec_Hist_Buisness
    {
        void Ajouter(IMMO_HIST_AFFECTATION a);
        IMMO_HIST_AFFECTATION Trouver(int annee,int num);
        IMMO_HIST_AFFECTATION TrouverParAnnee(int annee);
        IMMO_HIST_AFFECTATION TrouverParNum(int num);
        List<IMMO_HIST_AFFECTATION> Afficher();
        void Mettre_A_Jour(IMMO_HIST_AFFECTATION a);
        void Supprimer(IMMO_HIST_AFFECTATION a);
    }
}
