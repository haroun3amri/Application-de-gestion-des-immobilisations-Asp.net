using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace IMMO.DAL
{
   public  class SerciceRepImp:IServiceRepository
    {
        //*********************************************************
        public void add(IMMO_SERVICE l)
        {
            //instancier le context EF
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                ctxt.IMMO_SERVICE.Add(l);
                ctxt.SaveChanges();

            }
        }
        //********************************************************
        public IMMO_SERVICE Find(string code)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())

                return ctxt.IMMO_SERVICE.Find(code);
        }
        //***********************************************************
        public List<IMMO_SERVICE> FindAll()
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
                return ctxt.IMMO_SERVICE.ToList();
        }
        //*************************************************************
        public void Update(IMMO_SERVICE l)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                ctxt.Entry(l).State = EntityState.Modified;
                ctxt.SaveChanges();
            }
        }
        //***********************************
        public void Delete(IMMO_SERVICE l)
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
