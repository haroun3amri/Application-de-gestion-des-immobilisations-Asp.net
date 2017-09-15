using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;

namespace IMMO.BLL
{
   public  interface IAff_Hist_Art_Buisness
    {
        void Ajouter(IMMO_HIST_AFFECTATION_ARTICLE a);
        IMMO_HIST_AFFECTATION_ARTICLE Trouver(int annee, int num,string article);
        IMMO_HIST_AFFECTATION_ARTICLE TrouverParAnnee(int annee);
        IMMO_HIST_AFFECTATION_ARTICLE TrouverParNum(int num);
        IMMO_HIST_AFFECTATION_ARTICLE TrouverParArticle(string article);

        List<IMMO_HIST_AFFECTATION_ARTICLE> Afficher();
        void Mettre_A_Jour(IMMO_HIST_AFFECTATION_ARTICLE a);
        void Supprimer(IMMO_HIST_AFFECTATION_ARTICLE a);
        void SupprimerParArticle(IMMO_ARTICLE a);

    }
}
