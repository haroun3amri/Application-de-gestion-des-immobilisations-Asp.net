using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace IMMO.DAL
{
  public  class FactureDetailRepImp:IFactureDetRepository
    {
        public void add(IMMO_DETAILFACTURE a)
        {
            //instancier le context EF
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                ctxt.IMMO_DETAILFACTURE.Add(a);
                ctxt.SaveChanges();

            }
        }
        //********************************************************

        public List<IMMO_DETAILFACTURE> Find(string NumFacture)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                List<IMMO_DETAILFACTURE> l = new List<IMMO_DETAILFACTURE>();
                foreach (IMMO_DETAILFACTURE c in ctxt.IMMO_DETAILFACTURE)
                {
                    if (c.NUMFACTURE == NumFacture)
                        l.Add(c);

                }
                if (l.Count() != 0)
                    return l;
                else
                    return null;
            }
        }
        //*******************************************************

        public List<IMMO_DETAILFACTURE> FindAll()
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
                return ctxt.IMMO_DETAILFACTURE.ToList();
        }
        //*********************************************************

        public void Update(IMMO_DETAILFACTURE d)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                ctxt.Entry(d).State = EntityState.Modified;
                ctxt.SaveChanges();
            }
        }
        //***********************************************************


        public void Delete(IMMO_DETAILFACTURE a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {

                //ctxt.IMMO_ARTICLE.Remove(a);
                ctxt.Entry(a).State = EntityState.Deleted;




                ctxt.SaveChanges();
            }

        }
      //*******************************************************
        public List<IMMO_DETAILFACTURE> FindByM(string NUM)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                List<IMMO_DETAILFACTURE> l = new List<IMMO_DETAILFACTURE>();
                foreach (IMMO_DETAILFACTURE f in ctxt.IMMO_DETAILFACTURE)
                {
                    if (f.NUMFACTURE == NUM)
                        l.Add(f);
                }
                if (l.Count != 0)
                    return l;
                else
                {
                    IMMO_DETAILFACTURE m = new IMMO_DETAILFACTURE();
                    m.NUMFACTURE = NUM;
                    m.ANNEEBL = 2000;
                    m.NUMBL = 5090;
                    m.NUMLIGNEBL = 50901;
                    m.MONTANTHT = 0;
                    m.TVA = 0;
                    m.MONTANTTTC = 0;
                    m.QTE = 0;
                    m.VALEURCOMPTABLE = 0;
                    m.PRIXUNITAIREHT = 0;
                    l.Add(m);
                    return l;


                }

            }


        }

    }
}
