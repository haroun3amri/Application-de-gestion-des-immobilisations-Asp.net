using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;
namespace IMMO.BLL
{
   public interface IFactureBuisness
    {

        void Ajouter(IMMO_FACTURE f);
        IMMO_FACTURE Trouver(string NUM);
        List<IMMO_FACTURE> Afficher();
        void Mettre_A_Jour(IMMO_FACTURE f);
        void Supprimer(IMMO_FACTURE f);
    }
}
