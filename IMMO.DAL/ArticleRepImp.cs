using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace IMMO.DAL
{
    public class ArticleRepImp:IArticleRepository
 {
        public void add(IMMO_ARTICLE a)
        {//instancier le context EF
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                ctxt.IMMO_ARTICLE.Add(a);
                ctxt.SaveChanges();

            }
        }
        //*******************************************************************
        public IMMO_ARTICLE Find(string CODE)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            
                return ctxt.IMMO_ARTICLE.Find(CODE);
            
        }
        //********************************************************************
        public List<IMMO_ARTICLE> FindAll()
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
                return ctxt.IMMO_ARTICLE.ToList();

        }
        //*****************************************************************
      /* public IMMO_ARTICLE Update(IMMO_ARTICLE a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                var mod = ctxt.IMMO_ARTICLE.Find(a.CODE);
                if (mod != null)
                {
                    mod.CODE = a.CODE;
                    mod.FAMILLE = a.FAMILLE.ToString();
                    mod.CENTREACHAT = a.CENTREACHAT;
                    if (a.AFFECTATION != "")
                        mod.AFFECTATION = a.AFFECTATION;
                    else
                        mod.AFFECTATION = "1211";
                    mod.DATEAFFECTATION = a.DATEAFFECTATION;
                    mod.DATEAQUISITION = a.DATEAQUISITION;
                    mod.ANNEEBL = a.ANNEEBL;
                    mod.NUMBL = a.NUMBL;
                    mod.NUMLIGBL = a.NUMLIGBL;
                    mod.NUMFACTURE = a.NUMFACTURE;
                    mod.DATEEXPLOITATION = a.DATEEXPLOITATION;
                    mod.DUREE = a.DUREE;
                    mod.TAUXAMORTISSEMENT = a.TAUXAMORTISSEMENT;
                    mod.DOTATIONANTERIEURE = a.DOTATIONANTERIEURE;
                    mod.VALEURCOMPTABLE = a.VALEURCOMPTABLE;
                    mod.DATESESSION = a.DATESESSION;
                    mod.VALEURSESSION = a.VALEURSESSION;
                    mod.RAISONSESSION = a.RAISONSESSION;
                    mod.AMORTI = a.AMORTI;
                    mod.ETAT = a.ETAT;
                    mod.DESIGNATION = a.DESIGNATION;
                    mod.ETATSESSION = a.ETATSESSION;
                    mod.COMPTE = a.COMPTE;
                    
                    mod.COMPTE = a.COMPTE;
                   
                    mod.REFERENCE = a.REFERENCE;
                    mod.CARACTERISTIQUE = a.CARACTERISTIQUE;
                    mod.ANNEE = a.ANNEE;
                    mod.SERVICE = a.SERVICE;
                    mod.LOCALE = a.LOCALE;
                    mod.Emplacement = a.Emplacement;

                    a = mod;

                    return a;
                }
                else return null;

            }
        }*/
        //*****************************************************************
       
        public void Update(IMMO_ARTICLE a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {             
                ctxt.Entry(a).State = EntityState.Modified;
                ctxt.SaveChanges();
            }
        }
        //******************************************************************
        public void Delete(IMMO_ARTICLE a)
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
