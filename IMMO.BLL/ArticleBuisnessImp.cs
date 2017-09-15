using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;
namespace IMMO.BLL
{
    public class ArticleBuisnessImp: IArticleBuisness
    {
        private IArticleRepository repo;
        //*************************************************************
        public ArticleBuisnessImp()
        { this.repo = new ArticleRepImp(); }
        //**************************************************************
         public void Ajouter(IMMO_ARTICLE a)
        {
            repo.add(a);
        }
        //***************************************************************
         public IMMO_ARTICLE Trouver(string CODE)
         {
             return repo.Find(CODE);
         }
        //**************************************************************
         public List<IMMO_ARTICLE> Afficher()
         {
             return repo.FindAll();
         }
        //****************************************************************

         public void Mettre_A_Jour(IMMO_ARTICLE a)
         {
          repo.Update(a);
         }
        //****************************************************************
         public void Supprimer(IMMO_ARTICLE a)
         {
             repo.Delete(a);
         }
    }
}
