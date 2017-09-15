using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;

namespace IMMO.BLL
{
   public  class InvComptaBuisness:IInvComptaBuisness
    {
       private IIncComptaRepository repo;
        //*************************************************************
         public InvComptaBuisness()
        { this.repo = new InvComptaRepImp(); }
        //**************************************************************
         public void Ajouter(IMMO_INV_COMPTABILITE i)
        {
            repo.add(i);
        }
        //***************************************************************
         public IMMO_INV_COMPTABILITE Trouver(int ANNEE, DateTime DATEAMORTI, string FAMILLECPT)
         {
             return repo.Find(ANNEE,DATEAMORTI,FAMILLECPT);
         }
        //**************************************************************
         public List<IMMO_INV_COMPTABILITE> Afficher()
         {
             return repo.FindAll();
         }
        //****************************************************************

         public void Mettre_A_Jour(IMMO_INV_COMPTABILITE i)
         {
              repo.Update(i);
         }
        //****************************************************************
         public void Supprimer(IMMO_INV_COMPTABILITE i)
         {
             repo.Delete(i);
         }
    }
}
