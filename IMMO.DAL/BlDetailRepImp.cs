using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace IMMO.DAL
{
   public  class BlDetailRepImp:IBLDettailRep
    {

        public void add(IMMO_DETAILBL b)
        {
            //instancier le context EF
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                ctxt.IMMO_DETAILBL.Add(b);
                ctxt.SaveChanges();

            }
        }
        //********************************************************

        public IMMO_DETAILBL Find(int ANNEEBL, int NUMBL, int NUM)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                foreach (IMMO_DETAILBL c in ctxt.IMMO_DETAILBL)
                {
                    if ((c.ANNEEBL == ANNEEBL) && (c.NUMBL == NUMBL) && (c.NUM == NUM))
                    { return c; }

                }
                return null;
            }
        }
        //*********************************************************
        public List<IMMO_DETAILBL> FindByNumBl(int NUMBL)
        {

            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                List<IMMO_DETAILBL> l = new List<IMMO_DETAILBL>();
                foreach (IMMO_DETAILBL c in ctxt.IMMO_DETAILBL)
                {
                    if ((c.NUMBL == NUMBL) )
                    {  l.Add(c); }

                }
                if (l.Count() != 0)
                    return l;
                else
                    return null;

            }

        }

       //*************************************************************
       public  List<IMMO_DETAILBL> FindByAnnee(int ANNEEBL)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                List<IMMO_DETAILBL> l = new List<IMMO_DETAILBL>();
                foreach (IMMO_DETAILBL c in ctxt.IMMO_DETAILBL)
                {
                    if (c.ANNEEBL == ANNEEBL)
                    { l.Add(c); }

                }
                return l;
            }

        }

        //**********************************************************
      public  List<IMMO_DETAILBL> FindByMix(int ANNEEBL, int NUMBL)
       {
           using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
           {
               List<IMMO_DETAILBL> l = new List<IMMO_DETAILBL>();
               foreach (IMMO_DETAILBL c in ctxt.IMMO_DETAILBL)
               {
                   if ((c.ANNEEBL == ANNEEBL) &&(c.NUMBL==NUMBL))
                   { l.Add(c); }

               }
               return l;
           }

       }

        //***********************************************************

       public List<IMMO_DETAILBL> FindAll()
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
                return ctxt.IMMO_DETAILBL.ToList();
        }
        //*********************************************************

      /*  public IMMO_CESSION Update(IMMO_CESSION c)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                var mod = ctxt.IMMO_CESSION.Find(c.ANNEE, c.NUM);
                if (mod != null)
                {
                    mod.ANNEE = c.ANNEE;
                    mod.NUM = c.NUM;
                    mod.DATECESSION = c.DATECESSION;
                    mod.RAISON = c.RAISON;
                    mod.ETAT = c.ETAT;
                    mod.VALTOTAL = c.VALTOTAL;
                    mod.EXERCICE = c.EXERCICE;


                    return c;
                }
                else return null;

            }
        }*/
       //************************************************************
       public  void Update(IMMO_DETAILBL d)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {             
                ctxt.Entry(d).State = EntityState.Modified;
                ctxt.SaveChanges();
            }
        }
        //***********************************************************


       public void Delete(IMMO_DETAILBL a)
       {
           using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
           {

               //ctxt.IMMO_ARTICLE.Remove(a);
               ctxt.Entry(a).State = EntityState.Deleted;




               ctxt.SaveChanges();
           }

       }
       //********************************************************
       public List<IMMO_DETAILBL> FindByM(int NUM)
       {
           using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
           {
               List<IMMO_DETAILBL> l = new List<IMMO_DETAILBL>();
               foreach (IMMO_DETAILBL f in ctxt.IMMO_DETAILBL)
               {
                   if ((f.NUM == NUM))
                       l.Add(f);
               }
               if (l.Count != 0)
                   return l;
               else
               { 
                    Random rnd = new Random();
           
                                IMMO_DETAILBL m = new IMMO_DETAILBL();
                   m.NUM = (rnd.Next(1000000, 9999999));
                   m.ANNEEBL = 2000;
                   m.NUMBL = NUM;
                   m.FAMILLE = "vide";
                   m.QTE = 0;
                   m.QTEFACTURE = 0;
                   m.PRIXUNITAIRE = 0;
                   m.QTE = 0;
                   m.AFFECTATION = "vide";
                   m.SERVICE = "vide";
                   m.LOCALE = "vide";
                   l.Add(m);
                   return l;


               }

           }
              }
       //*************************

    }
}
