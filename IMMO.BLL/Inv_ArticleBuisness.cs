using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;

namespace IMMO.BLL
{
    public class Inv_ArticleBuisness:IInv_ArticleBuisness
    {
          private IInv_Article_Repository repo;
        //*************************************************************
          public Inv_ArticleBuisness()
          { this.repo = new IInv_Article_RepImp(); }
        //**************************************************************
         public void Ajouter(IMMO_INVETAIRE_ARTICLE i)
        {
            repo.add(i);
        }
        //***************************************************************
         public IMMO_INVETAIRE_ARTICLE Trouver(int ANNEE, int NUM,string ARTICLE)
         {
             return repo.Find(ANNEE,NUM,ARTICLE);
         }
        //**************************************************************
         public List<IMMO_INVETAIRE_ARTICLE> Afficher()
         {
             return repo.FindAll();
         }
        //****************************************************************

         public void Mettre_A_Jour(IMMO_INVETAIRE_ARTICLE i)
         {
              repo.Update(i);
         }
        //****************************************************************
         public void Supprimer(IMMO_INVETAIRE_ARTICLE i)
         {
             repo.Delete(i);
         }
        //***************************************************************
         public void SupprimerParArticle(IMMO_ARTICLE a)
         {
             repo.deleteByArticle(a);
         }
    }
}
