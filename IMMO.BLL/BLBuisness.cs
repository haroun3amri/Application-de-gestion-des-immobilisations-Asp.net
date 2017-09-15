using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;

namespace IMMO.BLL
{
    public class BLBuisness:IBLBuisness
    {

         private IBLRepository repo;
        //*************************************************************
         public BLBuisness()
        { this.repo = new BLRepositoryImp(); }
        //**************************************************************
         public void Ajouter(IMMO_BL bl)
        {
            repo.add(bl);
        }
        //***************************************************************
         public IMMO_BL Trouver(int annee,int num)
         {
             return repo.Find(annee,num);
         }
        //**************************************************************
         public List<IMMO_BL> Afficher()
         {
             return repo.FindAll();
         }
        //****************************************************************

         public void Mettre_A_Jour(IMMO_BL bl)
         {
              repo.Update(bl);
         }
        //****************************************************************
         public void Supprimer(IMMO_BL bl)
         {
             repo.Delete(bl);
         }
    }
}
