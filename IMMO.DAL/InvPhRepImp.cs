using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace IMMO.DAL
{
   public class InvPhRepImp:IInvPhRepository
    {

        public void add(INV_PH a)
        {//instancier le context EF
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                ctxt.INV_PH.Add(a);
                ctxt.SaveChanges();

            }
        }
        //*******************************************************************
        public INV_PH Find(string CODE)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())

                return ctxt.INV_PH.Find(CODE);

        }
        //********************************************************************
        public List<INV_PH> FindAll()
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
                return ctxt.INV_PH.ToList();

        }


        public void Update(INV_PH a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                ctxt.Entry(a).State = EntityState.Modified;
                ctxt.SaveChanges();
            }
        }
        //******************************************************************
        public void Delete(INV_PH a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {

              
                ctxt.Entry(a).State = EntityState.Deleted;




                ctxt.SaveChanges();
            }

        }

    }
}
