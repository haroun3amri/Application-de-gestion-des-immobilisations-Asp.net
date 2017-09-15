using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;

namespace IMMO.BLL
{
    public interface IInv_ArticleBuisness
    {
        void Ajouter(IMMO_INVETAIRE_ARTICLE i);
        IMMO_INVETAIRE_ARTICLE Trouver(int ANNEE, int NUM,string Article);
        List<IMMO_INVETAIRE_ARTICLE> Afficher();
        void Mettre_A_Jour(IMMO_INVETAIRE_ARTICLE i);
        void Supprimer(IMMO_INVETAIRE_ARTICLE i);
        void SupprimerParArticle(IMMO_ARTICLE a);
    }
}
