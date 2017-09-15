using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;

namespace IMMO.BLL
{
    public class FournisseurBuisness:IFournisseurBuisness
    {


         private IFournisseurRepository repo;
        //*************************************************************
         public FournisseurBuisness()
        { this.repo = new FournisseurRepImp(); }
        //**************************************************************
         public void Ajouter(IMMO_FOURNISSEUR f)
        {
            repo.add(f);
        }
        //***************************************************************
         public IMMO_FOURNISSEUR Trouver(string CODE)
         {
             return repo.Find(CODE);
         }
        //**************************************************************
         public List<IMMO_FOURNISSEUR> Afficher()
         {
             return repo.FindAll();
         }
        //****************************************************************

         public void Mettre_A_Jour(IMMO_FOURNISSEUR f)
         {
             repo.Update(f);
         }
        //****************************************************************
         public void Supprimer(IMMO_FOURNISSEUR f)
         {
             repo.Delete(f);
         }
        //***************************************************************
    }
}
