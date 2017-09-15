using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;

namespace IMMO.BLL
{
   public  class CessionBuisness:ICesstionBuisness
    {
        private ICessionRepository repo;
        //*************************************************************
        public CessionBuisness()
         { this.repo = new CessionRepImp(); }
       //**************************************************************
        public void Ajouter(IMMO_CESSION c)
        {
            repo.add(c);  
        }
       //************************************************************
        public IMMO_CESSION Trouver(int annee, int num)
        {
            return repo.Find(annee, num);
        }
       //*****************************************************************
        public IMMO_CESSION TrouverParAnnee(int annee)
        {
            return repo.FindByAnnee(annee);
        }
       //****************************************************************
        public IMMO_CESSION TrouverParNum(int Num)
        {
            return repo.FindByNum(Num);
        }
       //**********************************************************

        public List<IMMO_CESSION> Afficher()
        {
            return repo.FindAll();
        }
       //*************************************************************

        public void Mettre_A_Jour(IMMO_CESSION c)
        {
            repo.Update(c);
        }
       //********************************************************

        public void Supprimer(IMMO_CESSION c)
        {
            repo.Delete(c);
        }
       //******************************************************************
    }
}
