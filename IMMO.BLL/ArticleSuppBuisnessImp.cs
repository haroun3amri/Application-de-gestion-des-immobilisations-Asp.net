using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;

namespace IMMO.BLL
{
   public  class ArticleSuppBuisnessImp:IArticleSuppBuisness
    {
         private IArticleSupprimeRepo repo;
        //*************************************************************
         public ArticleSuppBuisnessImp()
         { this.repo = new ArticleSupprimeRepImp(); }
        //**************************************************************
         public void Ajouter(IMMO_ARTICLESUPPRIME a)
        {
            repo.add(a);
        }
        //***************************************************************
         public IMMO_ARTICLESUPPRIME Trouver(string CODE)
         {
             return repo.Find(CODE);
         }
        //**************************************************************
         public List<IMMO_ARTICLESUPPRIME> Afficher()
         {
             return repo.FindAll();
         }
        //****************************************************************

         public void Mettre_A_Jour(IMMO_ARTICLESUPPRIME a)
         {
              repo.Update(a);
         }
        //****************************************************************
         public void Supprimer(IMMO_ARTICLESUPPRIME a)
         {
             repo.Delete(a);
         }
       //*****************************************************************
       public  IMMO_ARTICLESUPPRIME AjoutSupprime(IMMO_ARTICLE ar)
         {
             return repo.addDel(ar);
         }
    }
}
