using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;

namespace IMMO.BLL
{
   public  class AmmoLinBuisnessImp:IAmmoLinBuisness
    {
        private IAmmoLRepository repo;
        //*************************************************************
        public AmmoLinBuisnessImp ()
        { this.repo = new AmmoLImp(); }
        //**************************************************************
         public void Ajouter(IMMO_AMORTISSEMENTANNUELLE a)
        {
            repo.add(a);
        }
        //***************************************************************
         public void AjouterList( List<IMMO_AMORTISSEMENTANNUELLE> a)
         {
             repo.addList(a);
         }
       //****************************************************************
         public List<IMMO_AMORTISSEMENTANNUELLE> TrouverParArticle(string Article)
         {
             return repo.FindByArticle(Article);
         }
        //**************************************************************
         public IMMO_AMORTISSEMENTANNUELLE Trouver(string Article, int Annee)
         {
             return repo.Find(Article, Annee);
         }

       //*************************************************************
         public bool VerifExistance(IMMO_AMORTISSEMENTANNUELLE p, List<IMMO_AMORTISSEMENTANNUELLE> l)
         {
             return repo.verif(p,l);
         }
       //************************************************************
         public List<IMMO_AMORTISSEMENTANNUELLE> Afficher()
         {
             return repo.FindAll();
         }
        //****************************************************************

         public void Mettre_A_Jour(IMMO_AMORTISSEMENTANNUELLE a)
         {
             repo.Update(a);
         }
        //****************************************************************
         public void Supprimer(IMMO_AMORTISSEMENTANNUELLE a)
         {
             repo.delete(a);
         }
       
       //*****************************************************************
        public  void SupprimerParArticle(IMMO_ARTICLE a)
         {
             repo.deleteByArticle(a);
         }

       //*****************************************************************
         public IMMO_AMORTISSEMENTANNUELLE InitialiserAmmLPour1Article(string CODE)
         {
            return repo.remplir1LigneAmmAnnuelle(CODE);
         }
       //*******************************************************
         public List<IMMO_AMORTISSEMENTANNUELLE> RemplirAmmLpour1Article(string CODE)
        {
             return repo.remplirAmmorLinParArticle(CODE);
        }
       //**************************************************************
        public  IMMO_AMORTISSEMENTANNUELLE InitialiserAmmLDegPour1Article(string CODE)
         {
             return repo.remplir1LigneAmmAnnuelleDeg(CODE);

         }
       //*****************************************************************
        public List<IMMO_AMORTISSEMENTANNUELLE> RemplirAmmDegpour1Article(string CODE)
        {
            return repo.remplirAmmorDegParArticle(CODE);
        }
    }
}
