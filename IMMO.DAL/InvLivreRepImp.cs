using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace IMMO.DAL
{
   public  class InvLivreRepImp:IInvLivreRepository
    {

        public void add(IMMO_INV_LIVRE i)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                ctxt.IMMO_INV_LIVRE.Add(i);
                ctxt.SaveChanges();

            }
        }
        //************************************************************************

        public IMMO_INV_LIVRE Find(int ANNEE, string ARTICLE)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                foreach (IMMO_INV_LIVRE i in ctxt.IMMO_INV_LIVRE)
                {
                    if ((i.ANNEE == ANNEE) && (i.ARTICLE== ARTICLE))
                        return i;
                }
                return null;
            }
        }
        //*********************************************************
        public List<IMMO_INV_LIVRE> FindAll()
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                return ctxt.IMMO_INV_LIVRE.ToList();

            }
        }
        //*******************************************************

        /*public IMMO_INV_LIVRE Update(IMMO_INV_LIVRE i)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                var mod = ctxt.IMMO_INV_LIVRE.Find(i.ANNEE, i.ARTICLE);
                if (mod != null)
                {
                    mod.ANNEE = i.ANNEE;
                    mod.ARTICLE = i.ARTICLE;
                    mod.AFFECTATIONTH = i.AFFECTATIONTH;
                    mod.AFFECTATIONPHY= i.AFFECTATIONPHY;
                    mod.EXISTE = i.EXISTE;
                    mod.EMPLACEMENT = i.EMPLACEMENT;
                    mod.OBSERVATION = i.OBSERVATION;
                    mod.DATEACQUISITION = i.DATEACQUISITION;
                    mod.VALEURCOMPTABLE = i.VALEURCOMPTABLE;
                    mod.DATEACQUISITION = i.DATEACQUISITION;
                    mod.VALEURCOMPTABLE = i.VALEURCOMPTABLE;
                    mod.DATEEXPLOITATION = i.DATEEXPLOITATION;
                    mod.TAUXAMORTISSEMENT = i.TAUXAMORTISSEMENT;
                    mod.JOURNALINVENTAIRE = i.JOURNALINVENTAIRE;
                    mod.SERVICE = i.SERVICE;
                    mod.LOCALE = i.LOCALE;
                    mod.FAMILLECPT = i.FAMILLECPT;
                    mod.DESIGNATIONARTICLE = i.DESIGNATIONARTICLE;
                    mod.LIBELLEAFFECTATION = i.LIBELLEAFFECTATION;
                    mod.DOTATIONANTERIEURE = i.DOTATIONANTERIEURE;
                    mod.DOTATIONEXERCICE = i.DOTATIONEXERCICE;
                    mod.DUREE = i.DUREE;
                    mod.AMORTI= i.AMORTI;
                    mod.RESPONSABLEACHAT = i.RESPONSABLEACHAT;
                    mod.DATEAMORTISSEMENT = i.DATEAMORTISSEMENT;



                    return i;
                }
                else return null;
            }
        }*/

        //*****************************************************************

        public void Update(IMMO_INV_LIVRE a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                ctxt.Entry(a).State = EntityState.Modified;
                ctxt.SaveChanges();
            }
        }
        //******************************************************************
        public void Delete(IMMO_INV_LIVRE a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {

                //ctxt.IMMO_ARTICLE.Remove(a);
                ctxt.Entry(a).State = EntityState.Deleted;




                ctxt.SaveChanges();
            }

        }
       //*********************************************************************
        public void deleteByArticle(IMMO_ARTICLE a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                foreach (IMMO_INV_LIVRE am in ctxt.IMMO_INV_LIVRE.ToList())
                {
                    if (am.ARTICLE == a.CODE)
                    {
                        ctxt.IMMO_INV_LIVRE.Remove(am);
                        ctxt.SaveChanges();
                    }

                }


            }

        }
    }
}
