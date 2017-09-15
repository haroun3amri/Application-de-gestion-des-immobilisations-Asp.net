using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;

namespace IMMO.BLL
{
    public class FactureBuisness:IFactureBuisness
    {

         private IFactureRepository repo;
        //*************************************************************
         public FactureBuisness()
        { this.repo = new FactureRepImp(); }
        //**************************************************************
         public void Ajouter(IMMO_FACTURE f)
        {
            repo.add(f);
        }
        //***************************************************************
         public IMMO_FACTURE Trouver(string NUM)
         {
             return repo.Find(NUM);
         }
        //**************************************************************
         public List<IMMO_FACTURE> Afficher()
         {
             return repo.FindAll();
         }
        //****************************************************************

         public void Mettre_A_Jour(IMMO_FACTURE f)
         {
              repo.Update(f);
         }
        //****************************************************************
         public void Supprimer(IMMO_FACTURE f)
         {
             repo.Delete(f);
         }
    }
}
