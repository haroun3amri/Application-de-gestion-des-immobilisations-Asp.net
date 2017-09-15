using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace IMMO.DAL
{
    public class InvRepImp : IInventaireRepository
    {
        public void add(IMMO_INVENTAIRE i)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                ctxt.IMMO_INVENTAIRE.Add(i);
                ctxt.SaveChanges();

            }
        }
        //************************************************************************

        public IMMO_INVENTAIRE Find(int ANNEE, int NUM)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
               /* foreach (IMMO_INVENTAIRE i in ctxt.IMMO_INVENTAIRE)
                {
                    if ((i.ANNEE == ANNEE) && (i.NUM == NUM))
                        return i;
                }*/
                return ctxt.IMMO_INVENTAIRE.Find(ANNEE,NUM);
            }
        }
        //*********************************************************
        public List<IMMO_INVENTAIRE> FindAll()
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                return ctxt.IMMO_INVENTAIRE.ToList();

            }
        }
        //*******************************************************

      /*  public IMMO_INVENTAIRE Update(IMMO_INVENTAIRE i)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                var mod = ctxt.IMMO_INVENTAIRE.Find(i.ANNEE, i.NUM);
                if (mod != null)
                {
                    mod.ANNEE = i.ANNEE;
                    mod.NUM = i.NUM;
                    mod.DESCRIPTION = i.DESCRIPTION;
                    mod.DATECREATION = i.DATECREATION;
                    mod.ETAT = i.ETAT;
                    mod.DATEVALIDATION = i.DATEVALIDATION;
                    mod.DATECLOTURE = i.DATECLOTURE;
                    mod.AUTOMATIQUE = i.AUTOMATIQUE;
                    mod.MUTATION = i.MUTATION;


                    return i;
                }
                else return null;
            }
        }*/
        //***************************************************

        //*****************************************************************

        public void Update(IMMO_INVENTAIRE a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                ctxt.Entry(a).State = EntityState.Modified;
                ctxt.SaveChanges();
            }
        }
        //******************************************************************
        public void Delete(IMMO_INVENTAIRE a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {

                //ctxt.IMMO_ARTICLE.Remove(a);
                ctxt.Entry(a).State = EntityState.Deleted;




                ctxt.SaveChanges();
            }

        }
        //****************************************************
        public int Total(IMMO_INVENTAIRE i)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                int cpt = 0;
                foreach (IMMO_INVETAIRE_ARTICLE a in ctxt.IMMO_INVETAIRE_ARTICLE)
                {
                    if ((i.ANNEE == a.ANNEE) && (i.NUM == a.NUM))
                        cpt++;
                }
                return cpt;

            }

        }
        //**************************************************
       public int Existe(IMMO_INVENTAIRE i)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                int cpt = 0;
                foreach (IMMO_INVETAIRE_ARTICLE a in ctxt.IMMO_INVETAIRE_ARTICLE)
                {
                    if ((i.ANNEE == a.ANNEE) && (i.NUM == a.NUM) && (a.EXISTE == "y"))
                        cpt++;
                }
                return cpt;

            }
        }
        //***************************************************************
       public int NonExiste(IMMO_INVENTAIRE i)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                int cpt = 0;
                foreach (IMMO_INVETAIRE_ARTICLE a in ctxt.IMMO_INVETAIRE_ARTICLE)
                {
                    if ((i.ANNEE == a.ANNEE) && (i.NUM == a.NUM) && (a.EXISTE == "n"))
                        cpt++;
                }
                return cpt;

            }
        }
        //***************************************************************
       public int Delace(IMMO_INVENTAIRE i)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                int cpt = 0;
                foreach (IMMO_INVETAIRE_ARTICLE a in ctxt.IMMO_INVETAIRE_ARTICLE)
                {
                    if ((i.ANNEE == a.ANNEE) && (i.NUM == a.NUM) && (a.EMPLACEMENT == a.IMMO_ARTICLE.Emplacement))
                        cpt++;
                }
                return cpt;

            }
        }
        //********************************************************************
       public int NonDelace(IMMO_INVENTAIRE i)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                int cpt = 0;
                foreach (IMMO_INVETAIRE_ARTICLE a in ctxt.IMMO_INVETAIRE_ARTICLE)
                {
                    if ((i.ANNEE == a.ANNEE) && (i.NUM == a.NUM) && (a.EMPLACEMENT != a.IMMO_ARTICLE.Emplacement))
                        cpt++;
                }
                return cpt;

            }
        }
        //***********************************************************************
      public  int Total2()
       {  using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
           int cpt = 0;
           foreach (INV_PH a in ctxt.INV_PH)
           {
               cpt++;
           }
           return cpt;
       }
      }
        //**********************************************************************
    
     public bool ExisteA(string s, List<List<INV_PH>> l)
     {
         using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
         {
             bool b = false;
             foreach (List<INV_PH> i in l)
             {
                 foreach (INV_PH p in i)
                 {
                     if (s == p.CODE)
                     {
                         b = true;
                         break;


                     }

                 }

             }
             return b;
         }



     }
     //***********************************************************************
        //***********************************************************************
    public bool ExisteB(string s, List<List<INV_PH>> l)
     {
         using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
         {
             bool b = false;
           foreach (List<INV_PH> i in l)
           {
                foreach (INV_PH p in i)
                {if(s==p.BUREAU)
                {
                    b=true;
                    break;
                    
                
                }

                }
                
           }
           return b;
         }


     }
        //***********************************************************************
    public int ArtTotal()
    {
        using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
        {
            List<List<INV_PH>> n = new List<List<INV_PH>>();
            int cpt = 0;
            foreach (INV_PH a in ctxt.INV_PH)
            {
                if ((a.CODE != "") && (ExisteA(a.CODE, n) == false))
                {
                    List<INV_PH> l = new List<INV_PH>();

                    foreach (INV_PH p in ctxt.INV_PH)
                    {
                        if (a.CODE == p.CODE)
                            l.Add(p);
                    }
                    n.Add(l);
                }


            }
            foreach (List<INV_PH> i in n)
                cpt++;
            return cpt;
        }
    }
    //***************************
   
     public int ArtBureau()
      {
          using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
          {
              List<List<INV_PH>> n = new List<List<INV_PH>>();
              int cpt = 0;
              foreach (INV_PH a in ctxt.INV_PH)
              {
                  if((a.BUREAU != "")&&(ExisteB(a.BUREAU,n)==false))
                  {
                      List<INV_PH> l = new List<INV_PH>();

                      foreach( INV_PH p in ctxt.INV_PH)
                  {  
                      if (a.BUREAU == p.BUREAU)
                          l.Add(p);
                  }
                      n.Add(l);
                  }
                  
                  
              }
              foreach (List<INV_PH> i in n)
                  cpt++;
              return cpt;
          }
      }
        //*************************************************************************
     public double tauxMutation(IMMO_INVENTAIRE i)
     {
         using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
         {
             int cpt = 0;
             foreach (IMMO_INVETAIRE_ARTICLE a in ctxt.IMMO_INVETAIRE_ARTICLE)
             {
                 if ((i.ANNEE == a.ANNEE) && (i.NUM == a.NUM) && (a.EMPLACEMENT == a.IMMO_ARTICLE.Emplacement))
                     cpt++;
             }
             if (cpt != 0)
                 return ((cpt * 100 / Total(i)));
             else
                 return 0;

         }
     }
        //******************************************************************
     public double tauxNonMutation(IMMO_INVENTAIRE i)
     {
         using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
         {
             int cpt = 0;
             foreach (IMMO_INVETAIRE_ARTICLE a in ctxt.IMMO_INVETAIRE_ARTICLE)
             {
                 if ((i.ANNEE == a.ANNEE) && (i.NUM == a.NUM) && (a.EMPLACEMENT != a.IMMO_ARTICLE.Emplacement))
                     cpt++;
             }
             if (cpt != 0)
                 return ((cpt * 100 / Total(i)) );
             else
                 return 0;

         }
     }
       //***********************************************************************
     public double tauxExistance(IMMO_INVENTAIRE i)
    {
        using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
        {
            int cpt = 0;
            foreach (IMMO_INVETAIRE_ARTICLE a in ctxt.IMMO_INVETAIRE_ARTICLE)
            {
                if ((i.ANNEE == a.ANNEE) && (i.NUM == a.NUM) && (a.EXISTE == "y"))
                    cpt++;
            }
            if (cpt != 0)
                return ((cpt * 100 / Total(i)) );
            else
                return 0;

        }

    }
        //*******************************************************************
    public double tauxNonExistance(IMMO_INVENTAIRE i)
    {
        using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
        {
            int cpt = 0;
            foreach (IMMO_INVETAIRE_ARTICLE a in ctxt.IMMO_INVETAIRE_ARTICLE)
            {
                if ((i.ANNEE == a.ANNEE) && (i.NUM == a.NUM) && (a.EXISTE == "n"))
                    cpt++;
            }
            if (cpt != 0)
                return ((cpt * 100 / Total(i)));
            else
                return 0;

        }

    }
        //*************************************
    }
}