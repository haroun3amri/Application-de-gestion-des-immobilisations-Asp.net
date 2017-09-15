using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;

namespace IMMO.BLL
{
   public  class FamMereArticleBuisness:IFamMerebuisness
    {
        private IFamMereArticleRep repo;
        //*************************************************************
        public FamMereArticleBuisness()
        { this.repo = new FamMereArticleRepImp(); }
        //**************************************************************
         public void Ajouter(IMMO_FAMILLEM a)
        {
            repo.add(a);
        }
        //***************************************************************
         public IMMO_FAMILLEM Trouver(string CODE)
         {
             return repo.Find(CODE);
         }
        //**************************************************************
         public List<IMMO_FAMILLEM> Afficher()
         {
             return repo.FindAll();
         }
        //****************************************************************

         public void Mettre_A_Jour(IMMO_FAMILLEM a)
         {
          repo.Update(a);
         }
        //****************************************************************
         public void Supprimer(IMMO_FAMILLEM a)
         {
             repo.Delete(a);
         }
    }
}
