using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace IMMO.DAL
{
   public class TvaRecRepImp:ITvaRecRepository
    {
        //*********************************************************
        public void add(IMMO_TVARECUPERATION l)
        {
            //instancier le context EF
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                ctxt.IMMO_TVARECUPERATION.Add(l);
                ctxt.SaveChanges();

            }
        }
        //********************************************************
        public IMMO_TVARECUPERATION Find(int annee)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())

                return ctxt.IMMO_TVARECUPERATION.Find(annee);
        }
        //***********************************************************
        public List<IMMO_TVARECUPERATION> FindAll()
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
                return ctxt.IMMO_TVARECUPERATION.ToList();
        }
        //*************************************************************
        public void Update(IMMO_TVARECUPERATION l)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                ctxt.Entry(l).State = EntityState.Modified;
                ctxt.SaveChanges();
            }
        }
        //***********************************
        public void Delete(IMMO_TVARECUPERATION l)
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
