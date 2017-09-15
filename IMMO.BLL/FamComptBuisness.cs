using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;

namespace IMMO.BLL
{
    public class FamComptBuisness:IFamilleComptableBuisness
    {

         private IFamComptableRep repo;
        //*************************************************************
         public FamComptBuisness()
         { this.repo = new famComptableRepImp(); }
        //**************************************************************
         public void Ajouter(IMMO_FAMILLECOMPTABLE fc)
        {
            repo.add(fc);
        }
        //***************************************************************
         public IMMO_FAMILLECOMPTABLE Trouver(string CODE)
         {
             return repo.Find(CODE);
         }
        //**************************************************************
         public List<IMMO_FAMILLECOMPTABLE> Afficher()
         {
             return repo.FindAll();
         }
        //****************************************************************

         public void Mettre_A_Jour(IMMO_FAMILLECOMPTABLE fc)
         {
              repo.Update(fc);
         }
        //****************************************************************
         public void Supprimer(IMMO_FAMILLECOMPTABLE fc)
         {
             repo.Delete(fc);
         }
        //***********************
    }
}
