using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace IMMO.DAL
{
   public  class Affec_Hist_Art_Rep_Imp:IAff_Hist_Art_Repository
    {
        public void add(IMMO_HIST_AFFECTATION_ARTICLE a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                ctxt.IMMO_HIST_AFFECTATION_ARTICLE.Add(a);
                ctxt.SaveChanges();

            }
        }
       //********************************************************

        public IMMO_HIST_AFFECTATION_ARTICLE Find(int annee, int num, string article)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                foreach (IMMO_HIST_AFFECTATION_ARTICLE h in ctxt.IMMO_HIST_AFFECTATION_ARTICLE)
                {
                    if ((h.ANNEE == annee) && (h.NUM == num) && (h.ARTICLE == article))
                        return h;
                }
                return null;

            }
        }
       //***********************************************************

        public IMMO_HIST_AFFECTATION_ARTICLE FindByAnnee(int annee)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                foreach (IMMO_HIST_AFFECTATION_ARTICLE h in ctxt.IMMO_HIST_AFFECTATION_ARTICLE)
                {
                    if (h.ANNEE == annee) 
                        return h;
                }
                return null;

            }
        }
       //***************************************************

        public IMMO_HIST_AFFECTATION_ARTICLE FindByNum(int num)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                foreach (IMMO_HIST_AFFECTATION_ARTICLE h in ctxt.IMMO_HIST_AFFECTATION_ARTICLE)
                {
                    if ( h.NUM == num)
                        return h;
                }
                return null;

            }
        }
       //*******************************************************************
        public IMMO_HIST_AFFECTATION_ARTICLE FindByArticle(string article)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                foreach (IMMO_HIST_AFFECTATION_ARTICLE h in ctxt.IMMO_HIST_AFFECTATION_ARTICLE)
                {
                    if  (h.ARTICLE == article)
                        return h;
                }
                return null;

            }
        }
       //**********************************************************
        public List<IMMO_HIST_AFFECTATION_ARTICLE> FindAll()
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                return ctxt.IMMO_HIST_AFFECTATION_ARTICLE.ToList();

            }
        }
       //*******************************************************************

      /*  public IMMO_HIST_AFFECTATION_ARTICLE Update(IMMO_HIST_AFFECTATION_ARTICLE a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                var mod = ctxt.IMMO_HIST_AFFECTATION_ARTICLE.Find(a.ANNEE, a.NUM, a.ARTICLE);
                if (mod != null)
                {
                    mod.ANNEE = a.ANNEE;
                    mod.NUM = a.NUM;
                    mod.DATEAFFECTATION = a.DATEAFFECTATION;
                    mod.ANCIENNEAFFECTATION = a.ANCIENNEAFFECTATION;
                    mod.NOUVELLEAFFECTATION = a.NOUVELLEAFFECTATION;
                    mod.ETAT = a.ETAT;
                    mod.OBSERVATION = a.OBSERVATION;
                    mod.ARTICLE = a.ARTICLE;



                    return a;
                }
                else return null;

            }
        }*/
       //****************************************************
        //*****************************************************************

        public void Update(IMMO_HIST_AFFECTATION_ARTICLE a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                ctxt.Entry(a).State = EntityState.Modified;
                ctxt.SaveChanges();
            }
        }
        //******************************************************************
        public void Delete(IMMO_HIST_AFFECTATION_ARTICLE a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {

                //ctxt.IMMO_ARTICLE.Remove(a);
                ctxt.Entry(a).State = EntityState.Deleted;




                ctxt.SaveChanges();
            }

        }
       //***********************************************************
        public void deleteByArticle(IMMO_ARTICLE a)

         {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                foreach (IMMO_HIST_AFFECTATION_ARTICLE am in ctxt.IMMO_HIST_AFFECTATION_ARTICLE.ToList())
                {
                    if (am.ARTICLE == a.CODE)
                    {
                        ctxt.IMMO_HIST_AFFECTATION_ARTICLE.Remove(am);
                        ctxt.SaveChanges();
                    }

                }

               
            }
           
        }
    }
}
