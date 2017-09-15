using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;

namespace IMMO.BLL
{
   public  class LocalBuisnessImp:ILocalBuisness
    {
         private ILocalRespository repo;
        //*************************************************************
         public LocalBuisnessImp()
         { this.repo = new LocalRepImp(); }
        //**************************************************************
         public void Ajouter(IMMO_LOCAL l)
        {
            repo.add(l);
        }
        //***************************************************************
         public IMMO_LOCAL Trouver(string CODE)
         {
             return repo.Find(CODE);
         }
        //**************************************************************
         public List<IMMO_LOCAL> Afficher()
         {
             return repo.FindAll();
         }
        //****************************************************************

         public void Mettre_A_Jour(IMMO_LOCAL l)
         {
              repo.Update(l);
         }
        //****************************************************************
         public void Supprimer(IMMO_LOCAL l)
         {
             repo.Delete(l);
         }
        //**********************************************************


    }
}
