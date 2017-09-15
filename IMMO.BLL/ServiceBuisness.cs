using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;

namespace IMMO.BLL
{
  public   class ServiceBuisness:IServiceBuisness
    {
       private IServiceRepository repo;
        //*************************************************************
       public ServiceBuisness()
       { this.repo = new SerciceRepImp(); }
        //**************************************************************
         public void Ajouter(IMMO_SERVICE a)
        {
            repo.add(a);
        }
        //***************************************************************
         public IMMO_SERVICE Trouver(string code)
         {
             return repo.Find(code);
         }
        //**************************************************************
         public List<IMMO_SERVICE> Afficher()
         {
             return repo.FindAll();
         }
        //****************************************************************

         public void Mettre_A_Jour(IMMO_SERVICE a)
         {
          repo.Update(a);
         }
        //****************************************************************
         public void Supprimer(IMMO_SERVICE a)
         {
             repo.Delete(a);
         }
    }
}
