using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;

namespace IMMO.BLL
{
    public class InvPhBuisness : IInvPhBuisnessRep
    {
         private IInvPhRepository repo;
        //*************************************************************
         public InvPhBuisness()
         { this.repo = new InvPhRepImp(); }
        //**************************************************************
         public void Ajouter(INV_PH i)
        {
            repo.add(i);
        }
        //***************************************************************
         public INV_PH Trouver(string CODE)
         {
             return repo.Find(CODE);
         }
        //**************************************************************
         public List<INV_PH> Afficher()
         {
             return repo.FindAll();
         }
        //****************************************************************

         public void Mettre_A_Jour(INV_PH i)
         {
             repo.Update(i);
         }
        //****************************************************************
         public void Supprimer(INV_PH i)
         {
             repo.Delete(i);
         }
    }
}
