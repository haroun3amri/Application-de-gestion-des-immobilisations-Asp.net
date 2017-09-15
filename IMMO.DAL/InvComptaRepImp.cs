using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace IMMO.DAL
{
    public class InvComptaRepImp:IIncComptaRepository
    {
        public void add(IMMO_INV_COMPTABILITE i)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                ctxt.IMMO_INV_COMPTABILITE.Add(i);
                ctxt.SaveChanges();

            }
        }
        //************************************************************************

        public IMMO_INV_COMPTABILITE Find(int ANNEE, DateTime DATEAMORTI ,string FAMILLECPT)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                foreach (IMMO_INV_COMPTABILITE i in ctxt.IMMO_INV_COMPTABILITE)
                {
                    if ((i.ANNEE == ANNEE) && (i.DATEAMORTISSEMENT == DATEAMORTI) && (i.FAMILLECPT == FAMILLECPT))
                        return i;
                }
                return null;
            }
        }
        //*********************************************************
        public List<IMMO_INV_COMPTABILITE> FindAll()
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                return ctxt.IMMO_INV_COMPTABILITE.ToList();

            }
        }
        //*******************************************************

      /*  public IMMO_INV_COMPTABILITE Update(IMMO_INV_COMPTABILITE i)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                var mod = ctxt.IMMO_INV_COMPTABILITE.Find(i.ANNEE, i.DATEAMORTISSEMENT,i.FAMILLECPT);
                if (mod != null)
                {
                    mod.ANNEE = i.ANNEE;
                    mod.DATEAMORTISSEMENT = i.DATEAMORTISSEMENT;
                    mod.FAMILLECPT = i.FAMILLECPT;
                    mod.CONTREPARTIE = i.CONTREPARTIE;
                    mod.DEBIT = i.DEBIT;
                    mod.CREDIT = i.CREDIT;
                    mod.LIBELLE = i.LIBELLE;
                   

                    return i;
                }
                else return null;
            }
        }*/
        //***************************************************

        //*****************************************************************

        public void Update(IMMO_INV_COMPTABILITE a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                ctxt.Entry(a).State = EntityState.Modified;
                ctxt.SaveChanges();
            }
        }
        //******************************************************************
        public void Delete(IMMO_INV_COMPTABILITE a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {

                //ctxt.IMMO_ARTICLE.Remove(a);
                ctxt.Entry(a).State = EntityState.Deleted;




                ctxt.SaveChanges();
            }

        }
        //****************************************************************
    }
}
