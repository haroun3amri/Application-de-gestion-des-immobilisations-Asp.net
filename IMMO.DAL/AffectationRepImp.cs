using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace IMMO.DAL
{
   public class AffectationRepImp:IAffectationRepository
    {
        public void add(IMMO_AFFECTATION a)
        {
            //instancier le context EF
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                ctxt.IMMO_AFFECTATION.Add(a);
                ctxt.SaveChanges();

            }
        }
       //**************************************************

        public IMMO_AFFECTATION Find(string CODE)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                return ctxt.IMMO_AFFECTATION.Find(CODE);

            }
        }
       //**************************************************

        public List<IMMO_AFFECTATION> FindAll()
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                return ctxt.IMMO_AFFECTATION.ToList();

            }
        }
       //*********************************************************

      /*  public IMMO_AFFECTATION Update(IMMO_AFFECTATION a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                var mod = ctxt.IMMO_AFFECTATION.Find(a.CODE);
                if (mod != null)
                {
                    mod.CODE= a.CODE;
                    mod.LIBELLE = a.LIBELLE;
                    mod.RESPONSABLEACHAT= a.RESPONSABLEACHAT;
                   

                    return a;
                }
                else return null;

            }
        }*/

        //*****************************************************************

        public void Update(IMMO_AFFECTATION a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                ctxt.Entry(a).State = EntityState.Modified;
                ctxt.SaveChanges();
            }
        }
        //******************************************************************
        public void Delete(IMMO_AFFECTATION a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {

                //ctxt.IMMO_ARTICLE.Remove(a);
                ctxt.Entry(a).State = EntityState.Deleted;




                ctxt.SaveChanges();
            }

        }
       //***************************************************************
    }
}
