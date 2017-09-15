using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace IMMO.DAL
{
   public class ArticleSupprimeRepImp:IArticleSupprimeRepo
    {

        public void add(IMMO_ARTICLESUPPRIME a)
        {//instancier le context EF
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                ctxt.IMMO_ARTICLESUPPRIME.Add(a);
                ctxt.SaveChanges();

            }
        }
        //*******************************************************************
        public IMMO_ARTICLESUPPRIME Find(string CODE)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
                return ctxt.IMMO_ARTICLESUPPRIME.Find(CODE);

        }
        //********************************************************************
        public List<IMMO_ARTICLESUPPRIME> FindAll()
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
                return ctxt.IMMO_ARTICLESUPPRIME.ToList();

        }
        //*****************************************************************
      /*  public IMMO_ARTICLESUPPRIME Update(IMMO_ARTICLESUPPRIME a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                var mod = ctxt.IMMO_ARTICLESUPPRIME.Find(a.CODE);
                if (mod != null)
                {
                    mod.CODE = a.CODE;
                    mod.FAMILLE = a.FAMILLE;
                    mod.CENTREACHAT = a.CENTREACHAT;
                    mod.AFFECTATION = a.AFFECTATION;
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
                    mod.REFERENCE = a.REFERENCE;
                    mod.CARACTERISTIQUE = a.CARACTERISTIQUE;
                    mod.ANNEE = a.ANNEE;
                    mod.SERVICE = a.SERVICE;
                    mod.LOCALE = a.LOCALE;
                    mod.EMPLACEMENT = a.EMPLACEMENT;
                    mod.DATESUPP = a.DATESUPP;
                    mod.OPERATEUR = a.OPERATEUR;
                    return a;
                }
                else return null;

            }
        }*/
        //******************************************************************
        //*****************************************************************

        public void Update(IMMO_ARTICLESUPPRIME a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                ctxt.Entry(a).State = EntityState.Modified;
                ctxt.SaveChanges();
            }
        }
        //******************************************************************
        public void Delete(IMMO_ARTICLESUPPRIME a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {

                //ctxt.IMMO_ARTICLE.Remove(a);
                ctxt.Entry(a).State = EntityState.Deleted;




                ctxt.SaveChanges();
            }

        }
       //*************************************************************************
       public IMMO_ARTICLESUPPRIME addDel(IMMO_ARTICLE ar)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                IMMO_ARTICLESUPPRIME mod = new IMMO_ARTICLESUPPRIME();
                var a = ctxt.IMMO_ARTICLE.Find(ar.CODE);
                if (a != null)
                {
                    mod.CODE = a.CODE;
                    mod.FAMILLE = a.FAMILLE;
                    mod.CENTREACHAT = a.CENTREACHAT;
                    mod.AFFECTATION = a.AFFECTATION;
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
                    mod.REFERENCE = a.REFERENCE;
                    mod.CARACTERISTIQUE = a.CARACTERISTIQUE;
                    mod.ANNEE = a.ANNEE;
                    mod.SERVICE = a.SERVICE;
                    mod.LOCALE = a.LOCALE;
                    mod.EMPLACEMENT = a.Emplacement;

                    mod.DATESUPP = DateTime.Today;
                    mod.OPERATEUR = Environment.UserName;
                    return mod;
                }
                else return null;

            }

        }
       //**************************************************************************

    }
}
