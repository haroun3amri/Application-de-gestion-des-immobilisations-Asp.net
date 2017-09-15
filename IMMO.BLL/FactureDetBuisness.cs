using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;

namespace IMMO.BLL
{
    public class FactureDetBuisness:IFactureDetBuisness
    {
         private IFactureDetRepository repo;
        //*************************************************************
         public FactureDetBuisness()
         { this.repo = new FactureDetailRepImp(); }
       //**************************************************************
        public void Ajouter(IMMO_DETAILFACTURE c)
        {
            repo.add(c);  
        }
       //************************************************************
        public List<IMMO_DETAILFACTURE> Trouver(string NumFacture)
        {
            return repo.Find(NumFacture);
        }
      
       //**********************************************************

        public List<IMMO_DETAILFACTURE> Afficher()
        {
            return repo.FindAll();
        }
       //*************************************************************

        public void Mettre_A_Jour(IMMO_DETAILFACTURE c)
        {
               repo.Update(c);
        }
       //********************************************************

        public void Supprimer(IMMO_DETAILFACTURE c)
        {
            repo.Delete(c);
        }
       //******************************************************************
       public List<IMMO_DETAILFACTURE> TrouverParMere(string NUM)
        {
            return repo.FindByM(NUM);
        }
        //**************************************************************
      

    }
}
