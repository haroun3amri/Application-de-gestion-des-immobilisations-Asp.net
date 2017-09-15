using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;

namespace IMMO.BLL
{
   public class TvaBuisness:ITVaBuisness
    {
       private ITVARepository repo;
        //*************************************************************
       public TvaBuisness()
       { this.repo = new TVARepImp(); }
        //**************************************************************
         public void Ajouter(IMMO_TVA a)
        {
            repo.add(a);
        }
        //***************************************************************
         public IMMO_TVA Trouver(int CODE)
         {
             return repo.Find(CODE);
         }
        //**************************************************************
         public List<IMMO_TVA> Afficher()
         {
             return repo.FindAll();
         }
        //****************************************************************

         public void Mettre_A_Jour(IMMO_TVA a)
         {
          repo.Update(a);
         }
        //****************************************************************
         public void Supprimer(IMMO_TVA a)
         {
             repo.Delete(a);
         }
    }
}
