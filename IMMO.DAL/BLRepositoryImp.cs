using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace IMMO.DAL
{
   public  class BLRepositoryImp:IBLRepository
    {
        public void add(IMMO_BL bl)
        {//instancier le context EF
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                ctxt.IMMO_BL.Add(bl);
                ctxt.SaveChanges();

            }
        }
        //*******************************************************************
        public IMMO_BL Find(int annee,int num)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {        foreach (IMMO_BL b  in ctxt.IMMO_BL) 
            {
                if ((b.ANNEE == annee) && (b.NUM == num))
                { return b; }
            }
             return null;


            }
        }
        //********************************************************************
        public List<IMMO_BL> FindAll()
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
                return ctxt.IMMO_BL.ToList();

        }
        //*****************************************************************
       /* public IMMO_BL Update(IMMO_BL a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                var mod = ctxt.IMMO_BL.Find(a.ANNEE,a.NUM);
                if (mod != null)
                {
                    mod.ANNEE = a.ANNEE;
                    mod.NUM = a.NUM;
                    mod.REFCOMMANDE = a.REFCOMMANDE;
                    mod.DATECOMMANDE = a.DATECOMMANDE;
                    mod.CENTREACHAT = a.FOURNISSEUR;
                    mod.FOURNISSEUR = a.FOURNISSEUR;
                    mod.DATELIVRAISON = a.DATELIVRAISON;
                    mod.OBSERVATION = a.OBSERVATION;
                    mod.ETAT = a.ETAT;
                    mod.REFERENCE = a.REFERENCE;
                    mod.EXERCICE= a.EXERCICE;
                   
                    return a;
                }
                else return null;

            }
        }*/
        
        //*****************************************************************

        public void Update(IMMO_BL a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                ctxt.Entry(a).State = EntityState.Modified;
                ctxt.SaveChanges();
            }
        }
        //******************************************************************
        public void Delete(IMMO_BL a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {

                //ctxt.IMMO_ARTICLE.Remove(a);
                ctxt.Entry(a).State = EntityState.Deleted;




                ctxt.SaveChanges();
            }

        }
       //**********************************************************************




    }
}
