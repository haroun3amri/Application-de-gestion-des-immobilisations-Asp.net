using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;

namespace IMMO.BLL
{
   public class InvBuisness:IInvBuisness
    {

         private  IInventaireRepository repo;
        //*************************************************************
         public InvBuisness()
         { this.repo = new InvRepImp(); }
        //**************************************************************
         public void Ajouter(IMMO_INVENTAIRE i)
        {
            repo.add(i);
        }
        //***************************************************************
         public IMMO_INVENTAIRE Trouver(int ANNEE, int NUM)
         {
             return repo.Find(ANNEE,NUM);
         }
        //**************************************************************
         public List<IMMO_INVENTAIRE> Afficher()
         {
             return repo.FindAll();
         }
        //****************************************************************

         public void Mettre_A_Jour(IMMO_INVENTAIRE i)
         {
              repo.Update(i);
         }
        //****************************************************************
         public void Supprimer(IMMO_INVENTAIRE i)
         {
             repo.Delete(i);
         }
        //***************************************************************
          public int NbTotal(IMMO_INVENTAIRE i)
         {
             return repo.Total(i);
         }
       //*********************************************  
        public int NbExiste(IMMO_INVENTAIRE i)
          {
              return repo.Existe(i);
          }
       //*************************************************
        public int NbNonExiste(IMMO_INVENTAIRE i)
         {
             return repo.NonExiste(i);
         }
       //*******************************************
        public int NbDelace(IMMO_INVENTAIRE i)
         {
             return repo.Delace(i);
         }
       //****************************************
        public int NbNonDelace(IMMO_INVENTAIRE i)
         {
             return repo.NonDelace(i);
         }
       //*******************************************
        public int NbTotal2()
        {
            return repo.Total2();
        }
       //**************************************
        public int NbArtTotal()
        {
            return repo.ArtTotal();
        }
       //******************************
       public int NBArtBureau()
        {
            return repo.ArtBureau();

        }
    //*******************************************
       public double PtauxMutation(IMMO_INVENTAIRE i)
       {
           return repo.tauxMutation(i);
       }
       //****************************************
       public double PtauxNonMutation(IMMO_INVENTAIRE i)
      {
          return repo.tauxNonMutation(i);
      }
       //*************************************************
       public double PtauxExistance(IMMO_INVENTAIRE i)
      {
          return repo.tauxExistance(i);
      }
       //*************************************************
       public double PtauxNonExistance(IMMO_INVENTAIRE i)
       {
           return repo.tauxNonExistance(i);
       }
    }
}
