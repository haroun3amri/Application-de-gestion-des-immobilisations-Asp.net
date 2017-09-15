using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace IMMO.DAL
{
   public class FAmArticleRepImp:IFamArticleRepo
    {
        public void add(IMMO_FAMILLE a)
        {//instancier le context EF
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                ctxt.IMMO_FAMILLE.Add(a);
                ctxt.SaveChanges();

            }
        }
        //*******************************************************************
        public IMMO_FAMILLE Find(string CODE)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
                return ctxt.IMMO_FAMILLE.Find(CODE);

        }
        //********************************************************************
       public List<IMMO_FAMILLE> FindByM(string CODE)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                List<IMMO_FAMILLE> l = new List<IMMO_FAMILLE>();
                foreach(IMMO_FAMILLE f in ctxt.IMMO_FAMILLE)
                {
                    if (f.FAMILLEM == CODE)
                        l.Add(f);
                }
                if (l.Count != 0)
                    return l;
                else
                {
                    IMMO_FAMILLE m = new IMMO_FAMILLE();
                    m.CODE = "vide";
                    m.LIBELLE = "vide";
                    m.COMPTE = "vide";
                    m.FAMILLEM = "vide";
                    l.Add(m);
                    return l;

 
                }

            }


        }
       //***********************************************************************
        public List<IMMO_FAMILLE> FindAll()
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
                return ctxt.IMMO_FAMILLE.ToList();

        }
        //*****************************************************************
       
        //*****************************************************************

        public void Update(IMMO_FAMILLE a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                ctxt.Entry(a).State = EntityState.Modified;
                ctxt.SaveChanges();
            }
        }
        //******************************************************************
        public void Delete(IMMO_FAMILLE a)
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
