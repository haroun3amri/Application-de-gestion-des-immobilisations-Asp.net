using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace IMMO.DAL
{
   public  class FactureRepImp:IFactureRepository
    {
        public void add(IMMO_FACTURE f)
        {
            //instancier le context EF
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                ctxt.IMMO_FACTURE.Add(f);
                ctxt.SaveChanges();

            }
        }
       //********************************************************

        public IMMO_FACTURE Find(string NUM)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
                return ctxt.IMMO_FACTURE.Find(NUM);
        }
       //*********************************************************

        public List<IMMO_FACTURE> FindAll()
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
                return ctxt.IMMO_FACTURE.ToList();
        }
       //*********************************************************

       /* public IMMO_FACTURE Update(IMMO_FACTURE a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                var mod = ctxt.IMMO_FACTURE.Find(a.NUM);
                if (mod != null)
                {
                    mod.NUM = a.NUM;
                    mod.REFERENCE= a.REFERENCE;
                    mod.FOURNISSEUR = a.FOURNISSEUR;
                    mod.OBSERVATION = a.OBSERVATION;
                    mod.MONTANTTTC = a.MONTANTTTC;
                    mod.MONTANTHT = a.MONTANTHT;
                    mod.CHARGENONRATTACHEIMMO = a.CHARGENONRATTACHEIMMO;
                    mod.CHARGERATTACHEIMMO = a.CHARGERATTACHEIMMO;
                    mod.ETAT = a.ETAT;
                    mod.TVARECPERATION = a.TVARECPERATION;
                    mod.DATEFACTURE= a.DATEFACTURE;

                    return a;
                }
                else return null;

            }
        }*/
       //***********************************************************

        //*****************************************************************

        public void Update(IMMO_FACTURE a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                ctxt.Entry(a).State = EntityState.Modified;
                ctxt.SaveChanges();
            }
        }
        //******************************************************************
        public void Delete(IMMO_FACTURE a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {

                //ctxt.IMMO_ARTICLE.Remove(a);
                ctxt.Entry(a).State = EntityState.Deleted;




                ctxt.SaveChanges();
            }

        }
       //*********************************************************************
    }
}
