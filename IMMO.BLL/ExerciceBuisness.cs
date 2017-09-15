using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;

namespace IMMO.BLL
{
    public class ExerciceBuisness:IExerciceBuisness
    {
         private IExerciceRep repo;
        //*************************************************************
         public ExerciceBuisness()
         { this.repo = new ExerciceRepImp(); }
        //**************************************************************
         public void Ajouter(IMMO_EXERCICE c)
        {
            repo.add(c);
        }
        //***************************************************************
         public IMMO_EXERCICE Trouver(int annee)
         {
             return repo.Find(annee);
         }
        //**************************************************************
         public List<IMMO_EXERCICE> Afficher()
         {
             return repo.FindAll();
         }
        //****************************************************************

         public void Mettre_A_Jour(IMMO_EXERCICE c)
         {
              repo.Update(c);
         }
        //****************************************************************
         public void Supprimer(IMMO_EXERCICE c)
         {
             repo.Delete(c);
         }
        //***************************************************************
    }
}
