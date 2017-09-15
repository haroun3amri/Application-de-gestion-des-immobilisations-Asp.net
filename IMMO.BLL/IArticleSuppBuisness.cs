using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;

namespace IMMO.BLL
{
   public interface IArticleSuppBuisness
    {
        void Ajouter(IMMO_ARTICLESUPPRIME a);
        IMMO_ARTICLESUPPRIME Trouver(string CODE);
        List<IMMO_ARTICLESUPPRIME> Afficher();
        void Mettre_A_Jour(IMMO_ARTICLESUPPRIME a);
        void Supprimer(IMMO_ARTICLESUPPRIME a);
        IMMO_ARTICLESUPPRIME AjoutSupprime(IMMO_ARTICLE ar);

    }
}
