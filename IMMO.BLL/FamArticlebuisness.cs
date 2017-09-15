using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;

namespace IMMO.BLL
{
   public class FamArticlebuisness:IFamArtBuisness
    {
         private IFamArticleRepo repo;
        //*************************************************************
         public FamArticlebuisness()
         { this.repo = new FAmArticleRepImp(); }
        //**************************************************************
         public void Ajouter(IMMO_FAMILLE a)
        {
            repo.add(a);
        }
        //***************************************************************
         public IMMO_FAMILLE Trouver(string CODE)
         {
             return repo.Find(CODE);
         }
        //**************************************************************
        public List<IMMO_FAMILLE> TrouverParMere(string CODE)
         {
             return repo.FindByM(CODE);
         }
       //************************************************************
         public List<IMMO_FAMILLE> Afficher()
         {
             return repo.FindAll();
         }
        //****************************************************************

         public void Mettre_A_Jour(IMMO_FAMILLE a)
         {
          repo.Update(a);
         }
        //****************************************************************
         public void Supprimer(IMMO_FAMILLE a)
         {
             repo.Delete(a);
         }
    }
}
