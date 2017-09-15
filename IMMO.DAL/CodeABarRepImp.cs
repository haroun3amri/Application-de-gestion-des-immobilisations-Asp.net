using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace IMMO.DAL
{
    public class CodeABarRepImp:ICodeABarRepository
    {
        public void add(CODEBAR c)
        {
            //instancier le context EF
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                ctxt.CODEBARs.Add(c);
                ctxt.SaveChanges();

            }
        }
        //********************************************************

        public CODEBAR Find(string CODE)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
                return ctxt.CODEBARs.Find(CODE);
        }
        //*********************************************************

        public List<CODEBAR> FindAll()
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
                return ctxt.CODEBARs.ToList();
        }
        //*********************************************************

       /* public CODEBAR Update(CODEBAR a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                var mod = ctxt.CODEBARs.Find(a.CODE);
                if (mod != null)
                {
                    mod.CODECLAIR = a.CODECLAIR;
                    mod.CODEBAR1 = a.CODEBAR1;
                    mod.LIBELLE = a.LIBELLE;
                    mod.AFFECTLOCAL = a.AFFECTLOCAL;
                    mod.CODE = a.CODE;


                    return a;
                }
                else return null;

            }
        }*/
        //***********************************************************

        //*****************************************************************

        public void Update(CODEBAR a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                ctxt.Entry(a).State = EntityState.Modified;
                ctxt.SaveChanges();
            }
        }
        //******************************************************************
        public void Delete(CODEBAR a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {

                //ctxt.IMMO_ARTICLE.Remove(a);
                ctxt.Entry(a).State = EntityState.Deleted;




                ctxt.SaveChanges();
            }

        }
        //********************************************************
    }
}
