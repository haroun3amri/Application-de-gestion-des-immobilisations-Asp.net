using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace IMMO.DAL
{
   public class famComptableRepImp:IFamComptableRep
    {
        public void add(IMMO_FAMILLECOMPTABLE fc)
        {
            //instancier le context EF
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                ctxt.IMMO_FAMILLECOMPTABLE.Add(fc);
                ctxt.SaveChanges();

            }
        }
        //********************************************************

        public IMMO_FAMILLECOMPTABLE Find(string CODE)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
                return ctxt.IMMO_FAMILLECOMPTABLE.Find(CODE);
        }
        //*********************************************************

        public List<IMMO_FAMILLECOMPTABLE> FindAll()
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
                return ctxt.IMMO_FAMILLECOMPTABLE.ToList();
        }
        //*********************************************************

       /* public IMMO_FAMILLECOMPTABLE Update(IMMO_FAMILLECOMPTABLE a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                var mod = ctxt.IMMO_FAMILLECOMPTABLE.Find(a.CODE);
                if (mod != null)
                {
                    mod.CODE = a.CODE;
                    mod.LIBELLE = a.LIBELLE;
                    mod.CONTREPARTIE = a.CONTREPARTIE;
                    mod.TAUX = a.TAUX;
                    mod.CONTREPARTIE = a.CONTREPARTIE;
                    mod.LIBELLEESECONDAIRE = a.LIBELLEESECONDAIRE;


                    return a;
                }
                else return null;

            }
        }*/
        //***********************************************************

        //*****************************************************************

        public void Update(IMMO_FAMILLECOMPTABLE a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                ctxt.Entry(a).State = EntityState.Modified;
                ctxt.SaveChanges();
            }
        }
        //******************************************************************
        public void Delete(IMMO_FAMILLECOMPTABLE a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {

                //ctxt.IMMO_ARTICLE.Remove(a);
                ctxt.Entry(a).State = EntityState.Deleted;




                ctxt.SaveChanges();
            }

        }
       //*********************************************************
    }
}
