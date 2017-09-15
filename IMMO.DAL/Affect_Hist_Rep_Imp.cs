using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace IMMO.DAL
{
   public  class Affect_Hist_Rep_Imp:IAff_HistoRepository
    {
        public void add(IMMO_HIST_AFFECTATION a)
        {
            //instancier le context EF
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                ctxt.IMMO_HIST_AFFECTATION.Add(a);
                ctxt.SaveChanges();

            }
        }
       //******************************************************

        public IMMO_HIST_AFFECTATION Find(int annee, int num)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                foreach (IMMO_HIST_AFFECTATION h in ctxt.IMMO_HIST_AFFECTATION)
                {
                    if ((h.ANNEE == annee)&&(h.NUM==num))
                        return h;
                }
                return null;

            }
        }
        
       //******************************************************
        public IMMO_HIST_AFFECTATION FindByAnnee(int annee)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
               foreach(IMMO_HIST_AFFECTATION h in ctxt.IMMO_HIST_AFFECTATION)
               {
                   if (h.ANNEE == annee)
                       return h;
               }
               return null;

            }
        }
       //*******************************************************
        public IMMO_HIST_AFFECTATION FindByNum(int num)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                foreach (IMMO_HIST_AFFECTATION h in ctxt.IMMO_HIST_AFFECTATION)
                {
                    if (h.NUM == num)
                        return h;
                }
                return null;

            }
        }
       //*************************************************

        public List<IMMO_HIST_AFFECTATION> FindAll()
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                return ctxt.IMMO_HIST_AFFECTATION.ToList();

            }
        }
       //*********************************************************
       /* public IMMO_HIST_AFFECTATION Update(IMMO_HIST_AFFECTATION a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                var mod = ctxt.IMMO_HIST_AFFECTATION.Find(a.ANNEE,a.NUM);
                if (mod != null)
                {
                    mod.ANNEE = a.ANNEE;
                    mod.NUM = a.NUM;
                    mod.DATEAFFECTATION = a.DATEAFFECTATION;
                    mod.ANCIENNEAFFECTATION = a.ANCIENNEAFFECTATION;
                    mod.NOUVELLEAFFECTATION = a.NOUVELLEAFFECTATION;
                    mod.ETAT = a.ETAT;
                    mod.OBSERVATION = a.OBSERVATION;



                    return a;
                }
                else return null;

            }
        }*/
        //*****************************************************************

        public void Update(IMMO_HIST_AFFECTATION a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                ctxt.Entry(a).State = EntityState.Modified;
                ctxt.SaveChanges();
            }
        }
        //******************************************************************
        public void Delete(IMMO_HIST_AFFECTATION a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {

                //ctxt.IMMO_ARTICLE.Remove(a);
                ctxt.Entry(a).State = EntityState.Deleted;




                ctxt.SaveChanges();
            }

        }
       //***************************************************************
    }
}
