using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace IMMO.DAL
{
   public class CompteRepImp:ICompteRepository
    {
        public void add(IMMO_COMPTE c)
        {
            //instancier le context EF
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                ctxt.IMMO_COMPTE.Add(c);
                ctxt.SaveChanges();

            }
        }
        //********************************************************

        public IMMO_COMPTE Find(string NUM)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
                return ctxt.IMMO_COMPTE.Find(NUM);
        }
        //*********************************************************

        public List<IMMO_COMPTE> FindAll()
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
                return ctxt.IMMO_COMPTE.ToList();
        }
        //*********************************************************

        /*public IMMO_COMPTE Update(IMMO_COMPTE a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                var mod = ctxt.IMMO_COMPTE.Find(a.NUM);
                if (mod != null)
                {
                    mod.NUM = a.NUM;
                    mod.INTITULE = a.INTITULE;
                    mod.TAUX = a.TAUX;
                    mod.DUREE = a.DUREE;
                    mod.FAMILLECPT = a.FAMILLECPT;
                    mod.LINEAIRE = a.LINEAIRE;
                    

                    return a;
                }
                else return null;

            }
        }*/
        //***********************************************************


        public void Update(IMMO_COMPTE a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                ctxt.Entry(a).State = EntityState.Modified;
                ctxt.SaveChanges();
            }
        }
        //******************************************************************
        public void Delete(IMMO_COMPTE a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {

                //ctxt.IMMO_ARTICLE.Remove(a);
                ctxt.Entry(a).State = EntityState.Deleted;




                ctxt.SaveChanges();
            }

        }
       //*************************************************************
    }
}
