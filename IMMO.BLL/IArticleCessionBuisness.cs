using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;

namespace IMMO.BLL
{
    public interface IArticleCessionBuisness
    {
        void Ajouter(IMMO_ARTICLE_SESSION s);
        IMMO_ARTICLE_SESSION Trouver(string article, int annee, int num);
        IMMO_ARTICLE_SESSION TrouverParArticle(string article);
        IMMO_ARTICLE_SESSION TrouverParAnnee(int annee);
        IMMO_ARTICLE_SESSION TrouverParNum(int num);
        IMMO_ARTICLE_SESSION TrouverParCession(int annee, int num);
        List<IMMO_ARTICLE_SESSION> Afficher();
        void Mettre_A_Jour(IMMO_ARTICLE_SESSION s);
        void Supprimer(IMMO_ARTICLE_SESSION s);
        void SupprimerParArticle(int annee,int num);
        void SupprimerParArticle2(IMMO_ARTICLE a);

    }
}
