using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;

namespace IMMO.BLL
{
    public class ArticleCessionBuisness:IArticleCessionBuisness
    {
         private IArticleCessionRepository repo;
        //*************************************************************
         public ArticleCessionBuisness()
         { this.repo = new ArticleCessionRepImp(); }
       //**************************************************************
       public void Ajouter(IMMO_ARTICLE_SESSION s)
        {
            repo.add(s);  
        }
       //************************************************************
       public IMMO_ARTICLE_SESSION Trouver(string article, int annee, int num)
        {
            return repo.Find(article,annee, num);
        }
        //*********************************************************************
       public IMMO_ARTICLE_SESSION TrouverParArticle(string article)
        {
            return repo.FindbyArticle(article);
        }


        //*****************************************************************
       public IMMO_ARTICLE_SESSION TrouverParAnnee(int annee)
        {
            return repo.FindbyAnnee(annee);
        }
       //****************************************************************
       public IMMO_ARTICLE_SESSION TrouverParNum(int num)
        {
            return repo.FindbyNum(num);
        }
        //****************************************************************
       public IMMO_ARTICLE_SESSION TrouverParCession(int annee, int num)
        {
            return repo.FindbyCession(annee,num);
        }
        //**********************************************************

        public List<IMMO_ARTICLE_SESSION> Afficher()
        {
            return repo.FindAll();
        }
       //*************************************************************

        public void Mettre_A_Jour(IMMO_ARTICLE_SESSION s)
        {
             repo.Update(s);
        }
       //********************************************************

        public void Supprimer(IMMO_ARTICLE_SESSION s)
        {
            repo.Delete(s);
        }
       //******************************************************************
        public void SupprimerParArticle(int annee, int num)
        {
            repo.deleteByArticle(annee,num);
        }
        //******************************************************************
        public void SupprimerParArticle2(IMMO_ARTICLE a)
        {
            repo.deleteByArticle2(a);
        }
    }
}
