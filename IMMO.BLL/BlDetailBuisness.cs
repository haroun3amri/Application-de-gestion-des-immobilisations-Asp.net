using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;

namespace IMMO.BLL
{
   public class BlDetailBuisness:IBlDetailBuisness
    {

        private IBLDettailRep repo;
        //*************************************************************
        public BlDetailBuisness()
         { this.repo = new BlDetailRepImp(); }
       //**************************************************************
        public void Ajouter(IMMO_DETAILBL c)
        {
            repo.add(c);  
        }
       //************************************************************
        public IMMO_DETAILBL Trouver(int ANNEEBL, int NUMBL, int NUM)
        {
            return repo.Find(ANNEEBL,NUMBL,NUM);
        }
       //*****************************************************************
        public List<IMMO_DETAILBL> TrouverParNumBl(int NUMBL)
        {
            return repo.FindByNumBl(NUMBL);
        }
       //****************************************************************
        public List<IMMO_DETAILBL> TrouverParAnnee(int ANNEEBL)
        {
            return repo.FindByAnnee(ANNEEBL);
        }
       //****************************************************************
        public List<IMMO_DETAILBL> TrouverParNumEtAnnee(int ANNEEBL, int NUMBL)
        {
            return repo.FindByMix(ANNEEBL,NUMBL);
        }
       //**********************************************************

        public List<IMMO_DETAILBL> Afficher()
        {
            return repo.FindAll();
        }
       //*************************************************************

        public void Mettre_A_Jour(IMMO_DETAILBL c)
        {
               repo.Update(c);
        }
       //********************************************************

        public void Supprimer(IMMO_DETAILBL c)
        {
            repo.Delete(c);
        }
       //******************************************************************
        public List<IMMO_DETAILBL> TrouverParMere(int NUM)
        {
            return repo.FindByM(NUM);
        }
    }
}
