using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace IMMO.DAL
{
   public class ExerciceRepImp:IExerciceRep
    {
        public void add(IMMO_EXERCICE a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                ctxt.IMMO_EXERCICE.Add(a);
                ctxt.SaveChanges();
            }
        }
		//***********************************************
        public IMMO_EXERCICE Find(int annee)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
                return ctxt.IMMO_EXERCICE.Find(annee);
        }
		//*********************************************************
        public List<IMMO_EXERCICE> FindAll()
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
                return ctxt.IMMO_EXERCICE.ToList();
        }
		//********************************************************
        public void Update(IMMO_EXERCICE a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                ctxt.Entry(a).State = EntityState.Modified;
                ctxt.SaveChanges();
            }
        }
		//*************************************************
        public void Delete(IMMO_EXERCICE a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                ctxt.Entry(a).State = EntityState.Deleted;
                ctxt.SaveChanges();
            }
        }
    }
}
