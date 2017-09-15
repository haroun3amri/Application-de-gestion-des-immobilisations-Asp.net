using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace IMMO.DAL
{
  public  class FamMereArticleRepImp:IFamMereArticleRep
    {

        public void add(IMMO_FAMILLEM a)
        {//instancier le context EF
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                ctxt.IMMO_FAMILLEM.Add(a);
                ctxt.SaveChanges();

            }
        }
        //*******************************************************************
        public IMMO_FAMILLEM Find(string CODE)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
                return ctxt.IMMO_FAMILLEM.Find(CODE);

        }
        //********************************************************************
        public List<IMMO_FAMILLEM> FindAll()
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
                return ctxt.IMMO_FAMILLEM.ToList();

        }
        //*****************************************************************

        //*****************************************************************

        public void Update(IMMO_FAMILLEM a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                ctxt.Entry(a).State = EntityState.Modified;
                ctxt.SaveChanges();
            }
        }
        //******************************************************************
        public void Delete(IMMO_FAMILLEM a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {

                //ctxt.IMMO_ARTICLE.Remove(a);
                ctxt.Entry(a).State = EntityState.Deleted;




                ctxt.SaveChanges();
            }

        }
    }
}
