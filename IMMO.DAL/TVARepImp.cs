using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace IMMO.DAL
{
   public  class TVARepImp:ITVARepository
    {
       //*********************************************************
        public void add(IMMO_TVA l)
        {
            //instancier le context EF
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                ctxt.IMMO_TVA.Add(l);
                ctxt.SaveChanges();

            }
        }
       //********************************************************
        public IMMO_TVA Find(int CODE)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())

                return ctxt.IMMO_TVA.Find(CODE);
        }
       //***********************************************************
        public List<IMMO_TVA> FindAll()
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
                return ctxt.IMMO_TVA.ToList();
        }
       //*************************************************************
        public void Update(IMMO_TVA l)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                ctxt.Entry(l).State = EntityState.Modified;
                ctxt.SaveChanges();
            }
        }

        public void Delete(IMMO_TVA l)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {

                //ctxt.IMMO_ARTICLE.Remove(a);
                ctxt.Entry(l).State = EntityState.Deleted;




                ctxt.SaveChanges();
            }
        }
       //****************************************************************
    }

}
