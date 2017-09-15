using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;

namespace IMMO.BLL
{
    public class InvLivreBuisness:IInvLivreBuisness
    {
        private IInvLivreRepository repo;
        //*************************************************************
         public InvLivreBuisness()
        { this.repo = new InvLivreRepImp(); }
        //**************************************************************
         public void Ajouter(IMMO_INV_LIVRE i)
        {
            repo.add(i);
        }
        //***************************************************************
         public IMMO_INV_LIVRE Trouver(int ANNEE, string ARTICLE)
         {
             return repo.Find(ANNEE,ARTICLE);
         }
        //**************************************************************
         public List<IMMO_INV_LIVRE> Afficher()
         {
             return repo.FindAll();
         }
        //****************************************************************

         public void Mettre_A_Jour(IMMO_INV_LIVRE i)
         {
             repo.Update(i);
         }
        //****************************************************************
         public void Supprimer(IMMO_INV_LIVRE i)
         {
             repo.Delete(i);
         }
        //******************
         public void SupprimerParArticle(IMMO_ARTICLE a)
         {
             repo.deleteByArticle(a);
         }
    }
}
