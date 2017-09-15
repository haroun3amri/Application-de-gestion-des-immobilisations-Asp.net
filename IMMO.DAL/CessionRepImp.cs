using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace IMMO.DAL
{
   public  class CessionRepImp:ICessionRepository
    {
       public void add(IMMO_CESSION c)
        {
            //instancier le context EF
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                ctxt.IMMO_CESSION.Add(c);
                ctxt.SaveChanges();

            }
        }
        //********************************************************

      public  IMMO_CESSION Find(int annee, int num)
       {
           using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
           {
               foreach (IMMO_CESSION c in ctxt.IMMO_CESSION)
               {
                   if ((c.ANNEE == annee) && (c.NUM == num))
                   { return c; }
                   
               }
               return null;
           }
       }
        //*********************************************************
      public IMMO_CESSION FindByAnnee(int annee)
      {
          using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
          {
              foreach (IMMO_CESSION c in ctxt.IMMO_CESSION)
              {
                  if (c.ANNEE == annee) 
                  { return c; }

              }
              return null;
          }

      }

       //**********************************************************
      public IMMO_CESSION FindByNum(int Num)
      {
          using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
          {
              foreach (IMMO_CESSION c in ctxt.IMMO_CESSION)
              {
                  if (c.NUM == Num)
                  { return c; }

              }
              return null;
          }

      }

       //***********************************************************

      public  List<IMMO_CESSION> FindAll()
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
                return ctxt.IMMO_CESSION.ToList();
        }
        //*********************************************************

     /* public  IMMO_CESSION Update(IMMO_CESSION c)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                var mod = ctxt.IMMO_CESSION.Find(c.ANNEE,c.NUM);
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

      //*****************************************************************

      public void Update(IMMO_CESSION a)
      {
          using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
          {
              ctxt.Entry(a).State = EntityState.Modified;
              ctxt.SaveChanges();
          }
      }
      //******************************************************************
      public void Delete(IMMO_CESSION a)
      {
          using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
          {

             // ctxt.IMMO_CESSION.Remove(a);
              ctxt.Entry(a).State = EntityState.Deleted;




              ctxt.SaveChanges();
          }

      }
       //****************************************************************
        


    }
}
