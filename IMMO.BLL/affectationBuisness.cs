using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;

namespace IMMO.BLL
{
   public  class affectationBuisness:IAffectationBuiness1
    {   private IAffectationRepository repo;
        //*************************************************************
    public affectationBuisness()
    { this.repo = new AffectationRepImp(); }
        //**************************************************************
        public void Ajouter(IMMO_AFFECTATION a)
        {
            repo.add(a);
        }
       //***************************************************************
        public IMMO_AFFECTATION Trouver(string CODE)
        {
            return repo.Find(CODE);
        }
       //***************************************************
        public List<IMMO_AFFECTATION> Afficher()
        {
            return repo.FindAll();

        }
       //*********************************************************
        public void Mettre_A_Jour(IMMO_AFFECTATION a)
        {
             repo.Update(a);
        }
       //******************************************
        public void Supprimer(IMMO_AFFECTATION a)
        {
            repo.Delete(a);
        }
    }
}
