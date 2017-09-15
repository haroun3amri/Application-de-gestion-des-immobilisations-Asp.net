using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;

namespace IMMO.BLL
{
   public  class Affect_Hist_Buisness:IAffec_Hist_Buisness
    {
        private IAff_HistoRepository repo;
        //*************************************************************
        public Affect_Hist_Buisness()
        { this.repo = new Affect_Hist_Rep_Imp(); }
        //**************************************************************
        public void Ajouter(IMMO_HIST_AFFECTATION a)
        {
            repo.add(a);
        }
       //*****************************************************************

        public IMMO_HIST_AFFECTATION Trouver(int annee, int num)
        {
            return repo.Find(annee, num);
        }
       //******************************************************************

        public IMMO_HIST_AFFECTATION TrouverParAnnee(int annee)
        {
            return repo.FindByAnnee(annee);
        }
       //***************************************************
        public IMMO_HIST_AFFECTATION TrouverParNum(int num)
        {
            return repo.FindByNum(num);
        }
       //********************************************************

        public List<IMMO_HIST_AFFECTATION> Afficher()
        {
            return repo.FindAll(); 
        }
       //**********************************************************
        public void Mettre_A_Jour(IMMO_HIST_AFFECTATION a)
        {
             repo.Update(a);
        }
       //***********************************************************
        public void Supprimer(IMMO_HIST_AFFECTATION a)
        {
            repo.Delete(a);
        }
       //****************************************************************
    }
}
