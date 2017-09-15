using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace IMMO.DAL
{
   public  class ArticleCessionRepImp:IArticleCessionRepository
    {

       public  void add(IMMO_ARTICLE_SESSION s)
        {
            //instancier le context EF
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                ctxt.IMMO_ARTICLE_SESSION.Add(s);
                ctxt.SaveChanges();

            }
        }
        //********************************************************

       public  IMMO_ARTICLE_SESSION Find(string article, int annee, int num)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities() )
            {
                foreach (IMMO_ARTICLE_SESSION s in ctxt.IMMO_ARTICLE_SESSION)
                {
                    if ((s.ANNEE == annee) && (s.NUM == num) &&(s.ARTICLE==article))
                    { return s; }

                }
                return null;
            }
        }
        //*********************************************************
       public IMMO_ARTICLE_SESSION FindbyArticle(string article)
       {
           using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
           {
               foreach (IMMO_ARTICLE_SESSION s in ctxt.IMMO_ARTICLE_SESSION)
               {
                   if (s.ARTICLE == article)
                   { return s; }

               }
               return null;
           }

       }

       //**********************************************************

       public IMMO_ARTICLE_SESSION FindbyAnnee(int annee)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                foreach (IMMO_ARTICLE_SESSION s in ctxt.IMMO_ARTICLE_SESSION)
                {
                    if (s.ANNEE == annee)
                    { return s; }

                }
                return null;
            }

        }

     
       //***********************************************************
       public IMMO_ARTICLE_SESSION FindbyNum(int num)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                foreach (IMMO_ARTICLE_SESSION s in ctxt.IMMO_ARTICLE_SESSION)
                {
                    if (s.NUM == num)
                    { return s; }

                }
                return null;
            }

        }
       //*****************************************************************
       public IMMO_ARTICLE_SESSION FindbyCession(int annee, int num)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                foreach (IMMO_ARTICLE_SESSION s in ctxt.IMMO_ARTICLE_SESSION)
                {
                    if ((s.ANNEE == annee) && (s.NUM == num) )
                    { return s; }

                }
                return null;
            }
        }


        //***********************************************************

       public List<IMMO_ARTICLE_SESSION> FindAll()
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
                return ctxt.IMMO_ARTICLE_SESSION.ToList();
        }
        //*********************************************************

      /* public IMMO_ARTICLE_SESSION Update(IMMO_ARTICLE_SESSION s)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                var mod = ctxt.IMMO_ARTICLE_SESSION.Find(s.ANNEE, s.NUM,s.ARTICLE);
                if (mod != null)
                {
                    mod.ARTICLE = s.ARTICLE;
                    mod.RAISON = s.RAISON;
                    mod.VALEUR = s.VALEUR;
                    mod.DATESESSION = s.DATESESSION;
                    mod.ETAT = s.ETAT;
                    mod.DOTATION = s.DOTATION;
                    mod.ANNEE = s.ANNEE;
                    mod.NUM = s.NUM;
                    mod.AMORTISSEMENTPRATIQUE = s.AMORTISSEMENTPRATIQUE;


                    return s;
                }
                else return null;

            }
        }*/
       //************************************************************
       public void Update(IMMO_ARTICLE_SESSION a)
       {
           using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
           {
               ctxt.Entry(a).State = EntityState.Modified;
               ctxt.SaveChanges();
           }
       }
        //***********************************************************

       public void Delete(IMMO_ARTICLE_SESSION s)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                ctxt.Entry(s).State = EntityState.Deleted;
                ctxt.SaveChanges();
            }
        }
       //****************************
       public void deleteByArticle(int annee,int num)
       {
           using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
           {
               foreach (IMMO_ARTICLE_SESSION am in ctxt.IMMO_ARTICLE_SESSION.ToList())
               {
                   if (   (am.ANNEE==annee)&&(am.NUM==annee)  )
                   {
                       ctxt.IMMO_ARTICLE_SESSION.Remove(am);
                       ctxt.SaveChanges();
                   }

               }


           }

       }
       //***********************************
      public void deleteByArticle2(IMMO_ARTICLE a)
       {
           using (IMMODEMOEntities ctxt = new IMMODEMOEntities())

           foreach (IMMO_ARTICLE_SESSION am in ctxt.IMMO_ARTICLE_SESSION.ToList())
           {
               if (a.CODE==am.ARTICLE)
               {
                   ctxt.IMMO_ARTICLE_SESSION.Remove(am);
                   ctxt.SaveChanges();
               }

           }
       }

    }
}
