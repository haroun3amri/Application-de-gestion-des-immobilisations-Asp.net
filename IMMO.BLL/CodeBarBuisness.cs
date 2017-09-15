using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;

namespace IMMO.BLL
{
   public  class CodeBarBuisness:ICodeBarBuisness
    {

         private  ICodeABarRepository repo;
        //*************************************************************
         public CodeBarBuisness()
         { this.repo = new CodeABarRepImp(); }
        //**************************************************************
         public void Ajouter(CODEBAR c)
        {
            repo.add(c);
        }
        //***************************************************************
         public CODEBAR Trouver(string CODE)
         {
             return repo.Find(CODE);
         }
        //**************************************************************
         public List<CODEBAR> Afficher()
         {
             return repo.FindAll();
         }
        //****************************************************************

         public void Mettre_A_Jour(CODEBAR c)
         {
              repo.Update(c);
         }
        //****************************************************************
         public void Supprimer(CODEBAR c)
         {
             repo.Delete(c);
         }
        //***************************************************************
    }
}
