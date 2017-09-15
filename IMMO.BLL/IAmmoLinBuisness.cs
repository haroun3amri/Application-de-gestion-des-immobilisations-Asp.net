using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;

namespace IMMO.BLL
{
   public interface IAmmoLinBuisness
    {
        void Ajouter(IMMO_AMORTISSEMENTANNUELLE p);
        void AjouterList(List<IMMO_AMORTISSEMENTANNUELLE> a);
       List<IMMO_AMORTISSEMENTANNUELLE> TrouverParArticle(string Article);
       IMMO_AMORTISSEMENTANNUELLE Trouver(string Article,int Annee);
       bool VerifExistance(IMMO_AMORTISSEMENTANNUELLE p, List<IMMO_AMORTISSEMENTANNUELLE> l);


       List<IMMO_AMORTISSEMENTANNUELLE> Afficher();
       void Mettre_A_Jour(IMMO_AMORTISSEMENTANNUELLE p);
       void Supprimer(IMMO_AMORTISSEMENTANNUELLE p);
       void SupprimerParArticle(IMMO_ARTICLE a);
      IMMO_AMORTISSEMENTANNUELLE InitialiserAmmLPour1Article(string CODE);
      List<IMMO_AMORTISSEMENTANNUELLE> RemplirAmmLpour1Article(string CODE);
      IMMO_AMORTISSEMENTANNUELLE InitialiserAmmLDegPour1Article(string CODE);
      List<IMMO_AMORTISSEMENTANNUELLE> RemplirAmmDegpour1Article(string CODE);

    }
}
