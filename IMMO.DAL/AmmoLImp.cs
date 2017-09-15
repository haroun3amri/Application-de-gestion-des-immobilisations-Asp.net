using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace IMMO.DAL
{
     public class AmmoLImp:IAmmoLRepository
    {
        public void add(IMMO_AMORTISSEMENTANNUELLE a)
        {//instancier le context EF
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                ctxt.IMMO_AMORTISSEMENTANNUELLE.Add(a);
                ctxt.SaveChanges();

            }
        }
         //********************************************************************
       public  void addList(List<IMMO_AMORTISSEMENTANNUELLE> l)
        {
             using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
             {
                 foreach( IMMO_AMORTISSEMENTANNUELLE a in l)
                 {
                     ctxt.IMMO_AMORTISSEMENTANNUELLE.Add(a);
                 }
             }
        }
        //*******************************************************************
        public List<IMMO_AMORTISSEMENTANNUELLE> FindByArticle(string Article)
        {
         using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
         {
             List<IMMO_AMORTISSEMENTANNUELLE> L1= new List<IMMO_AMORTISSEMENTANNUELLE>();
             foreach(IMMO_AMORTISSEMENTANNUELLE a in ctxt.IMMO_AMORTISSEMENTANNUELLE)
             {
                 if (a.ARTICLE == Article)
                     L1.Add(a);
             }
             if (L1.Count() != 0)
                 return L1;
             else return null;

            
         }

        }
         //*******************************************************************
       public IMMO_AMORTISSEMENTANNUELLE Find(string Article, int ANNEE)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                List<IMMO_AMORTISSEMENTANNUELLE> L = new List<IMMO_AMORTISSEMENTANNUELLE>();

                foreach (IMMO_AMORTISSEMENTANNUELLE a in ctxt.IMMO_AMORTISSEMENTANNUELLE)
                {
                    if ((a.ARTICLE == Article) && (a.ANNEE == ANNEE))
                        return a;
                }
                return null;
            }
        }
        //********************************************************************
      public  bool verif(IMMO_AMORTISSEMENTANNUELLE a, List<IMMO_AMORTISSEMENTANNUELLE> l)
       {
           using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
           {

               foreach (IMMO_AMORTISSEMENTANNUELLE b in l)
               {
                   if ((a.ARTICLE == b.ARTICLE) && (a.ANNEE == b.ANNEE))
                       return true;
               }
               return false;
           }
       }
         //*******************************************************************
        public List<IMMO_AMORTISSEMENTANNUELLE> FindAll()
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
                return ctxt.IMMO_AMORTISSEMENTANNUELLE.ToList();

        }
        //*****************************************************************
       /* public IMMO_AMORTISSEMENTANNUELLE Update(IMMO_AMORTISSEMENTANNUELLE a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                var mod = ctxt.IMMO_AMORTISSEMENTANNUELLE.Find(a.ARTICLE);
                if (mod != null)
                {
                    mod.ARTICLE = a.ARTICLE;
                    mod.ANNEE = a.ANNEE;
                    mod.AMORTISSEMENTNONCPT = a.AMORTISSEMENTNONCPT;
                    mod.AMORTISSEMENTP = a.AMORTISSEMENTP;
                    mod.DATEAMORTISSEMENT = a.DATEAMORTISSEMENT;
                    mod.VALEUR = a.VALEUR;
                    mod.MONTANTCALCUL = a.MONTANTCALCUL;
                    return mod;
                }
                else return null;

            }
        }*/
         //*****************************************************************
        public void Update(IMMO_AMORTISSEMENTANNUELLE a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                ctxt.Entry(a).State = EntityState.Modified;
                ctxt.SaveChanges();
            }
        }


       
        //******************************************************************
        public void delete(IMMO_AMORTISSEMENTANNUELLE a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {

               // ctxt.IMMO_AMORTISSEMENTANNUELLE.Remove(a);
                ctxt.Entry(a).State = EntityState.Deleted;




                ctxt.SaveChanges();
            }

        }
        
         //******************************************************************
        public void deleteByArticle(IMMO_ARTICLE a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                foreach (IMMO_AMORTISSEMENTANNUELLE am in ctxt.IMMO_AMORTISSEMENTANNUELLE.ToList())
                {
                    if (am.ARTICLE == a.CODE)
                    {
                        ctxt.IMMO_AMORTISSEMENTANNUELLE.Remove(am);
                        ctxt.SaveChanges();
                    }

                }

               
            }
           
        }

         //******************************************************************
        public IMMO_AMORTISSEMENTANNUELLE remplir1LigneAmmAnnuelle(string CODE)
        {    //instancier le context EF
             using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {   IMMO_ARTICLE a= ctxt.IMMO_ARTICLE.Find(CODE);
                IMMO_AMORTISSEMENTANNUELLE mod = new IMMO_AMORTISSEMENTANNUELLE() ;
                 mod.ARTICLE = CODE;
                 
                 if (a.DATEEXPLOITATION != null)
                 {
                     mod.ANNEE = a.DATEEXPLOITATION.Value.Year;

                     mod.DATEAMORTISSEMENT = (DateTime)a.DATEEXPLOITATION;
                 }
                
                

                if ((mod.DATEAMORTISSEMENT.Month != 12) && (mod.DATEAMORTISSEMENT.Day != 31))
                {   //on nrgligeara le nombre des jours de decembre et on suppose que chaque mois se combose de 30 jours 
                    decimal jour = (12-mod.DATEAMORTISSEMENT.Month ) * 30;
                  
                    if((a.VALEURCOMPTABLE!=null) && (a.DUREE!=null))
                        mod.VALEUR = (decimal)((a.VALEURCOMPTABLE) * ((100/a.DUREE) / 100) * jour) / 360;
                   

                }
                else
                    if ((a.VALEURCOMPTABLE != null) && (a.DUREE!= null))

                        mod.VALEUR = (decimal)((a.VALEURCOMPTABLE) * (100 / a.DUREE) / 100);
                   
                if(a.VALEURCOMPTABLE!=null)
                    mod.MONTANTCALCUL = (decimal)a.VALEURCOMPTABLE - mod.VALEUR;
                    mod.AMORTISSEMENTP = mod.VALEUR;
                    mod.AMORTISSEMENTNONCPT = mod.VALEUR; ;
                
               // ctxt.IMMO_AMORTISSEMENTANNUELLE.Add(mod);

                return mod;
             }
          }
     
        //********************************************************************
        public List<IMMO_AMORTISSEMENTANNUELLE> remplirAmmorLinParArticle(string CODE)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                IMMO_ARTICLE a = ctxt.IMMO_ARTICLE.Find(CODE);
                List<IMMO_AMORTISSEMENTANNUELLE> list = new List<IMMO_AMORTISSEMENTANNUELLE>();
                list.Add(remplir1LigneAmmAnnuelle(CODE));
                IMMO_AMORTISSEMENTANNUELLE mod = new IMMO_AMORTISSEMENTANNUELLE();
                if (a.DATEEXPLOITATION != null)
                {
                    mod = remplir1LigneAmmAnnuelle(CODE);


                    for (var i = mod.ANNEE+1; i < DateTime.Now.Year;i++ )
                    {
                        IMMO_AMORTISSEMENTANNUELLE mod2 = new IMMO_AMORTISSEMENTANNUELLE();

                        mod2.ARTICLE = mod.ARTICLE;
                        mod2.ANNEE = i;
                        mod2.DATEAMORTISSEMENT = mod.DATEAMORTISSEMENT;
                        mod2.DATEAMORTISSEMENT.AddYears(mod2.DATEAMORTISSEMENT.Year + 1);

                        if ((a.VALEURCOMPTABLE != null) && (a.DUREE != null))

                            mod2.VALEUR = mod.VALEUR + (decimal)(a.VALEURCOMPTABLE) * ((decimal)((100 /  a.DUREE)) / 100);

                        if (a.VALEURCOMPTABLE != null)
                            mod2.MONTANTCALCUL =(decimal)(ctxt.IMMO_ARTICLE.Find(CODE).VALEURCOMPTABLE) - mod2.VALEUR;
                        if ((a.VALEURCOMPTABLE != null) && (a.DUREE != null))

                            mod2.AMORTISSEMENTP = (decimal)(a.VALEURCOMPTABLE) * ((decimal)((100 / a.DUREE)) / 100);

                        if (mod2.MONTANTCALCUL < 0)
                            break;
                        mod.AMORTISSEMENTNONCPT = mod2.VALEUR;
                        list.Add(mod2);
                        mod = mod2;



                    }
                    return list;

                }
                 return null;


            }
        }


       
         //*******************************************************************
       public  IMMO_AMORTISSEMENTANNUELLE remplir1LigneAmmAnnuelleDeg(string CODE)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                IMMO_ARTICLE a = ctxt.IMMO_ARTICLE.Find(CODE);
                IMMO_AMORTISSEMENTANNUELLE mod = new IMMO_AMORTISSEMENTANNUELLE();
                mod.ARTICLE = CODE;

                if (a.DATEEXPLOITATION != null)
                {
                    mod.ANNEE = a.DATEEXPLOITATION.Value.Year;

                    mod.DATEAMORTISSEMENT = (DateTime)a.DATEEXPLOITATION;
                }
                //intialisation du plan comptable
                //Application du plan comptable francais
               decimal tauxT = 0;
                if((a.DUREE >=3)&&(a.DUREE<=4))
                    tauxT = 1.25m;
                if ((a.DUREE >= 5) && (a.DUREE <= 6))
                    tauxT = 1.75m;
                if ( a.DUREE >= 6)
                    tauxT = 2.25m;

               



                if ((mod.DATEAMORTISSEMENT.Month != 12) && (mod.DATEAMORTISSEMENT.Day != 31))
                {   //on nrgligeara le nombre des jours de decembre et on suppose que chaque mois se combose de 30 jours 
                    decimal jour = (12-mod.DATEAMORTISSEMENT.Month) * 30;


                    if ((a.VALEURCOMPTABLE != null) && (a.DUREE != null))
                    {
                        
                        
                            var taux = tauxT * (1 / a.DUREE) * 100;
                        
                        mod.VALEUR = (decimal)((a.VALEURCOMPTABLE) * ((taux) / 100) * jour) / 360;
                    }

                }
                else
                    if ((a.VALEURCOMPTABLE != null) && (a.DUREE != null))
                    {
                        var taux = tauxT * (1 / a.DUREE) * 100;


                        mod.VALEUR = -(decimal)((a.VALEURCOMPTABLE) * (taux) / 100);
                    }

                if (a.VALEURCOMPTABLE != null)
                    mod.MONTANTCALCUL = (decimal)a.VALEURCOMPTABLE - mod.VALEUR;
                mod.AMORTISSEMENTP = mod.VALEUR;
                mod.AMORTISSEMENTNONCPT = mod.VALEUR;

                // ctxt.IMMO_AMORTISSEMENTANNUELLE.Add(mod);

                return mod;
            }
        }

         //*******************************************************************
       public List<IMMO_AMORTISSEMENTANNUELLE> remplirAmmorDegParArticle(string CODE)
       {
           using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
           {
               IMMO_ARTICLE a = ctxt.IMMO_ARTICLE.Find(CODE);
               List<IMMO_AMORTISSEMENTANNUELLE> list = new List<IMMO_AMORTISSEMENTANNUELLE>();
               list.Add(remplir1LigneAmmAnnuelleDeg(CODE));
               IMMO_AMORTISSEMENTANNUELLE mod = new IMMO_AMORTISSEMENTANNUELLE();
               if (a.DATEEXPLOITATION != null)
               {
                   mod = remplir1LigneAmmAnnuelle(CODE);
                   //intialisation du plan comptable
                   //Application du plan comptable francais
                   decimal tauxT = 0;
                   if ((a.DUREE >= 3) && (a.DUREE <= 4))
                       tauxT = 1.25m;
                   if ((a.DUREE >= 5) && (a.DUREE <= 6))
                       tauxT = 1.75m;
                   if (a.DUREE >= 6)
                       tauxT = 2.25m;


                   for (var i = mod.ANNEE + 1; i < DateTime.Now.Year; i++)
                   {
                       IMMO_AMORTISSEMENTANNUELLE mod2 = new IMMO_AMORTISSEMENTANNUELLE();
                       if (mod.AMORTISSEMENTP != 0)
                       {



                           mod2.ARTICLE = mod.ARTICLE;
                           mod2.ANNEE = i;
                           mod2.DATEAMORTISSEMENT = mod.DATEAMORTISSEMENT;
                           mod2.DATEAMORTISSEMENT.AddYears(mod2.DATEAMORTISSEMENT.Year + 1);
                           decimal taux = 0m;
                           //***********************************
                           if ((a.DUREE != 0) && ((a.DATEEXPLOITATION.Value.Year + a.DUREE) - i != 0))
                           {
                               if ((tauxT * (1 / a.DUREE) * 100) > (1 / ((a.DATEEXPLOITATION.Value.Year + a.DUREE) - mod2.ANNEE)))
                                   taux = (decimal)(tauxT * (1 / a.DUREE) * 100);
                               else
                                   taux = (decimal)(1 / ((a.DATEEXPLOITATION.Value.Year + a.DUREE) - i));
                           }
                           //***********************************

                           // if ((a.VALEURCOMPTABLE != null) && (a.DUREE != null))

                           mod2.VALEUR = mod.VALEUR + (decimal)(mod.MONTANTCALCUL) * ((decimal)(taux) / 100);

                           // if (a.VALEURCOMPTABLE != null)
                           // mod2.MONTANTCALCUL = (decimal)(ctxt.IMMO_ARTICLE.Find(CODE).VALEURCOMPTABLE) - mod2.VALEUR;
                           if (a.VALEURCOMPTABLE != null)
                               mod2.MONTANTCALCUL = (decimal)a.VALEURCOMPTABLE - mod2.VALEUR;
                           //  if ((a.VALEURCOMPTABLE != null) && (a.DUREE != null))
                           if (mod2.MONTANTCALCUL == 0)
                               break;

                           mod2.AMORTISSEMENTP = (decimal)(mod.MONTANTCALCUL) * ((decimal)(taux) / 100);


                           mod.AMORTISSEMENTNONCPT = mod2.VALEUR;

                           list.Add(mod2);
                           mod = mod2;
                       }
                       else
                       {

                           list.RemoveAt(list.Count-1);
                            break;
                       }


                   }
                   return list;

               }
               return null;
           }

       }

        //*********************************************************************

        //*********************************************************************
         
    }
}
