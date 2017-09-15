using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace IMMO.DAL
{
    public class EmplacementRepImp:IEmplacementRepository
    {
        public void add(IMMO_EMPLACEMENT e)
        {
            //instancier le context EF
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                ctxt.IMMO_EMPLACEMENT.Add(e);
                ctxt.SaveChanges();

            }
        }
        //********************************************************

       
        //**********************************************************
        public IMMO_EMPLACEMENT Find(string  CODE)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
                return ctxt.IMMO_EMPLACEMENT.Find(CODE);

        }

        //***********************************************************

        public List<IMMO_EMPLACEMENT> FindAll()
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
                return ctxt.IMMO_EMPLACEMENT.ToList();
        }
        //*********************************************************

       /* public IMMO_EMPLACEMENT Update(IMMO_EMPLACEMENT e)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                var mod = ctxt.IMMO_EMPLACEMENT.Find(e.CODE);
                if (mod != null)
                {
                    mod.CODE = e.CODE;
                    mod.LIEU= e.LIEU;
                   mod.ETAGE = e.ETAGE;
                    mod.COULOIR = e.COULOIR;
                    mod.BUREAU = e.BUREAU;
                    mod.LOCAL = e.LOCAL;
                  


                    return e;
                }
                else return null;

            }
        }*/
        //***********************************************************


        public void Update(IMMO_EMPLACEMENT a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                ctxt.Entry(a).State = EntityState.Modified;
                ctxt.SaveChanges();
            }
        }
        //******************************************************************
        public void Delete(IMMO_EMPLACEMENT a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {

                //ctxt.IMMO_ARTICLE.Remove(a);
                ctxt.Entry(a).State = EntityState.Deleted;




                ctxt.SaveChanges();
            }

        }
        //***************************************************
    }
}
