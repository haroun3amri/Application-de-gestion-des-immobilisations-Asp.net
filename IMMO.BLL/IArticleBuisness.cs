using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;
namespace IMMO.BLL
{
    public interface IArticleBuisness
    {
        void Ajouter(IMMO_ARTICLE p);
        IMMO_ARTICLE Trouver(string CODE);
        List<IMMO_ARTICLE> Afficher();
       void Mettre_A_Jour(IMMO_ARTICLE p);
        void Supprimer(IMMO_ARTICLE p);
    }
}
