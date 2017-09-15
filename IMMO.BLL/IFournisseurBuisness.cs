using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;

namespace IMMO.BLL
{
   public interface IFournisseurBuisness
    {

        void Ajouter(IMMO_FOURNISSEUR f);
        IMMO_FOURNISSEUR Trouver(string CODE);
        List<IMMO_FOURNISSEUR> Afficher();
        void Mettre_A_Jour(IMMO_FOURNISSEUR f);
        void Supprimer(IMMO_FOURNISSEUR f);
    }
}
