using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace IMMO.DAL
{
   public class IInv_Article_RepImp:IInv_Article_Repository
    {
        public void add(IMMO_INVETAIRE_ARTICLE i)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                ctxt.IMMO_INVETAIRE_ARTICLE.Add(i);
                ctxt.SaveChanges();

            }
        }
        //************************************************************************

        public IMMO_INVETAIRE_ARTICLE Find(int ANNEE, int NUM,string ARTICLE)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                foreach (IMMO_INVETAIRE_ARTICLE i in ctxt.IMMO_INVETAIRE_ARTICLE)
                {
                    if ((i.ANNEE == ANNEE) && (i.NUM == NUM) &&(i.ARTICLE==ARTICLE))
                        return i;
                }
                return null;
            }
        }
        //*********************************************************
        public List<IMMO_INVETAIRE_ARTICLE> FindAll()
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                return ctxt.IMMO_INVETAIRE_ARTICLE.ToList();

            }
        }
        //*******************************************************

       /* public IMMO_INVETAIRE_ARTICLE Update(IMMO_INVETAIRE_ARTICLE i)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                var mod = ctxt.IMMO_INVETAIRE_ARTICLE.Find(i.ANNEE, i.NUM,i.ARTICLE);
                if (mod != null)
                {
                    mod.ANNEE = i.ANNEE;
                    mod.NUM = i.NUM;
                    mod.ARTICLE = i.ARTICLE;
                    mod.AFFECTATION = i.AFFECTATION;
                    mod.EXISTE = i.EXISTE;
                    mod.OPERATEUR = i.OPERATEUR;
                    mod.EMPLACEMENT = i.EMPLACEMENT;
                    mod.OPERATEUR = i.OPERATEUR;
                    mod.AFFECTATIONTH = i.AFFECTATIONTH;


                    return i;
                }
                else return null;
            }
        }*/
        //***************************************************

        public void Update(IMMO_INVETAIRE_ARTICLE a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                ctxt.Entry(a).State = EntityState.Modified;
                ctxt.SaveChanges();
            }
        }
        //******************************************************************
        public void Delete(IMMO_INVETAIRE_ARTICLE a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {

                //ctxt.IMMO_ARTICLE.Remove(a);
                ctxt.Entry(a).State = EntityState.Deleted;




                ctxt.SaveChanges();
            }

        }
        //*********************************************************
        public void deleteByArticle(IMMO_ARTICLE a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                foreach (IMMO_INVETAIRE_ARTICLE am in ctxt.IMMO_INVETAIRE_ARTICLE.ToList())
                {
                    if (am.ARTICLE == a.CODE)
                    {
                        ctxt.IMMO_INVETAIRE_ARTICLE.Remove(am);
                        ctxt.SaveChanges();
                    }

                }


            }

        }
    }
}
