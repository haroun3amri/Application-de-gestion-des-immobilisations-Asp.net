using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;

namespace IMMO.BLL
{
   public  interface IInvLivreBuisness
    {
        void Ajouter(IMMO_INV_LIVRE i);
        IMMO_INV_LIVRE Trouver(int ANNEE, string ARTICLE);
        List<IMMO_INV_LIVRE> Afficher();
        void Mettre_A_Jour(IMMO_INV_LIVRE i);
        void Supprimer(IMMO_INV_LIVRE i);
        void SupprimerParArticle(IMMO_ARTICLE a);
    }
}
