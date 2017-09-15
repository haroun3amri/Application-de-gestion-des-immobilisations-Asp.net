using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;

namespace IMMO.BLL
{
   public  class EmplacementBuisness:IEmplacementBuisness
    {

         private IEmplacementRepository repo;
        //*************************************************************
         public EmplacementBuisness()
         { this.repo = new EmplacementRepImp(); }
        //**************************************************************
         public void Ajouter(IMMO_EMPLACEMENT e)
        {
            repo.add(e);
        }
        //***************************************************************
         public IMMO_EMPLACEMENT Trouver(string CODE)
         {
             return repo.Find(CODE);
         }
        //**************************************************************
         public List<IMMO_EMPLACEMENT> Afficher()
         {
             return repo.FindAll();
         }
        //****************************************************************

         public void Mettre_A_Jour(IMMO_EMPLACEMENT e)
         {
              repo.Update(e);
         }
        //****************************************************************
         public void Supprimer(IMMO_EMPLACEMENT e)
         {
             repo.Delete(e);
         }
        //**********************************************************

    }
}
