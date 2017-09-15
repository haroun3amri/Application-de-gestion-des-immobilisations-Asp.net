using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;

namespace IMMO.BLL
{
   public class TvaRecBuisness:ITVaRecBuisness
    {
        private ITvaRecRepository repo;
        //*************************************************************
        public TvaRecBuisness()
        { this.repo = new TvaRecRepImp(); }
        //**************************************************************
         public void Ajouter(IMMO_TVARECUPERATION a)
        {
            repo.add(a);
        }
        //***************************************************************
         public IMMO_TVARECUPERATION Trouver(int annee)
         {
             return repo.Find(annee);
         }
        //**************************************************************
         public List<IMMO_TVARECUPERATION> Afficher()
         {
             return repo.FindAll();
         }
        //****************************************************************

         public void Mettre_A_Jour(IMMO_TVARECUPERATION a)
         {
          repo.Update(a);
         }
        //****************************************************************
         public void Supprimer(IMMO_TVARECUPERATION a)
         {
             repo.Delete(a);
         }
    }
}
