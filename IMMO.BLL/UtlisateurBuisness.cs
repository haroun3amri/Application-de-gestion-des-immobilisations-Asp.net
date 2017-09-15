using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;
namespace IMMO.BLL
{
    public class UtlisateurBuisness:IUtilsateurBuisness
    {

         private IUtilsateurRepository repo;
        //*************************************************************
         public UtlisateurBuisness()
         { this.repo = new UtlisateurRepImp(); }
        //**************************************************************
         public void Ajouter(Login1 l)
        {
            repo.add(l);
        }
        //***************************************************************
         public Login1 Trouver(int username)
         {
             return repo.Find(username);
         }
        //**************************************************************
         public List<Login1> Afficher()
         {
             return repo.FindAll();
         }
        //****************************************************************

         public void Mettre_A_Jour(Login1 l)
         {
              repo.Update(l);
         }
        //****************************************************************
         public void Supprimer(Login1 l)
         {
             repo.Delete(l);
         }
    }
}
