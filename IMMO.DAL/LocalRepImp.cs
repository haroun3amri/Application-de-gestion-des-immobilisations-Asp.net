using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace IMMO.DAL
{
    public class LocalRepImp:ILocalRespository
    {

        public void add(IMMO_LOCAL l)
        {
            //instancier le context EF
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                ctxt.IMMO_LOCAL.Add(l);
                ctxt.SaveChanges();

            }
        }
        //********************************************************

        public IMMO_LOCAL Find(string CODE)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            if(CODE != "")
                return ctxt.IMMO_LOCAL.Find(CODE);
            else
            {
                IMMO_LOCAL l = new IMMO_LOCAL();
                l.CODE = "vide";
                l.LIBELLE = "vide";
                return l;
            }
        }
        //*********************************************************

        public List<IMMO_LOCAL> FindAll()
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
                return ctxt.IMMO_LOCAL.ToList();
        }
        //*********************************************************

       /* public IMMO_LOCAL Update(IMMO_LOCAL l)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                var mod = ctxt.IMMO_LOCAL.Find(l.CODE);
                if (mod != null)
                {
                    mod.CODE = l.CODE;
                    mod.LIBELLE =l.LIBELLE;
                    


                    return l;
                }
                else return null;

            }
        }*/
        //***********************************************************

        //*****************************************************************

        public void Update(IMMO_LOCAL a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                ctxt.Entry(a).State = EntityState.Modified;
                ctxt.SaveChanges();
            }
        }
        //******************************************************************
        public void Delete(IMMO_LOCAL a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {

                //ctxt.IMMO_ARTICLE.Remove(a);
                ctxt.Entry(a).State = EntityState.Deleted;




                ctxt.SaveChanges();
            }

        }
        //***********************************************************

    }
}
