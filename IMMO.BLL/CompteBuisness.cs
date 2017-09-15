using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;
namespace IMMO.BLL
{
    public class CompteBuisness:ICompteBuisness
    {
         private ICompteRepository repo;
        //*************************************************************
         public CompteBuisness()
         { this.repo = new CompteRepImp(); }
        //**************************************************************
         public void Ajouter(IMMO_COMPTE c)
        {
            repo.add(c);
        }
        //***************************************************************
         public IMMO_COMPTE Trouver(string NUM)
         {
             return repo.Find(NUM);
         }
        //**************************************************************
         public List<IMMO_COMPTE> Afficher()
         {
             return repo.FindAll();
         }
        //****************************************************************

         public void Mettre_A_Jour(IMMO_COMPTE c)
         {
              repo.Update(c);
         }
        //****************************************************************
         public void Supprimer(IMMO_COMPTE c)
         {
             repo.Delete(c);
         }
        //***************************************************************
    }
}
