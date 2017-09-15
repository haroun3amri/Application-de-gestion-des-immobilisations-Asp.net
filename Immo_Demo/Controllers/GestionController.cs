using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IMMO.DAL;
using IMMO.BLL;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.Resources;
using Kendo.Mvc.Infrastructure;
using System.Data.Entity;
using Immo_Demo.Models;
using System.Security.Cryptography;

namespace Immo_Demo.Controllers
{
    public class GestionController : Controller
    {
        // GET: Gestion
        public ActionResult Index()
        {
            return View();
        }

        //*********************************************************************
        private IArticleBuisness bo = new ArticleBuisnessImp();
        private IArticleSuppBuisness bo1 = new ArticleSuppBuisnessImp();
        private IAmmoLinBuisness bo2= new AmmoLinBuisnessImp();
        private IAmmoLinBuisness bo3 = new AmmoLinBuisnessImp();
        private IAff_Hist_Art_Buisness bo4 = new Affect_Hist_Art_Buisness();
        private IArticleCessionBuisness bo5 = new ArticleCessionBuisness();
        private IInv_ArticleBuisness bo6 = new Inv_ArticleBuisness();
        private IInvLivreBuisness bo7 = new InvLivreBuisness();
        private ICodeBarBuisness bo8 = new CodeBarBuisness();





        //*********************************************************************     
        IMMODEMOEntities ctxt = new IMMODEMOEntities();

        //************************************************************************
        public ActionResult GetAll([DataSourceRequest] DataSourceRequest request)
        {

            var Articles = bo.Afficher();
            return Json(Articles.ToDataSourceResult(request, record => new 
            {
                record.CODE,
                record.DESIGNATION,
                record.AFFECTATION,
                record.DUREE,
                record.ETAT,
                record.VALEURCOMPTABLE,
                record.VALEURSESSION,
                record.NUMFACTURE,
                record.REFERENCE,
                record.DATEAFFECTATION,
                record.TAUXAMORTISSEMENT,
                record.SERVICE,
                record.Emplacement,
                record.DATEEXPLOITATION,
                record.DATEAQUISITION,
                record.RAISONSESSION,
                record.DOTATIONANTERIEURE,
                record.FAMILLE,
                record.ANNEEBL,
                record.NUMBL,
                record.NUMLIGBL,
                record.ETATSESSION,
                record.COMPTE,
                record.CARACTERISTIQUE,
                record.ANNEE,
                record.LOCALE,
                record.DATESESSION,
                record.AMORTI,
                record.CENTREACHAT



            }),JsonRequestBehavior.AllowGet);
        }
        //***********************************************************************************
        public ActionResult GetAll2([DataSourceRequest] DataSourceRequest request)
        {

            var Articles = bo.Afficher();
            return Json(Articles.ToDataSourceResult(request, record => new
            {
                record.CODE,
               record.DESIGNATION,
               record.VALEURCOMPTABLE



            }), JsonRequestBehavior.AllowGet);
        }
        //***********************************************************************************
        //***********************************************************************************
        public JsonResult GetArticles()
        {    //initialisation de context de base de donnees
            IMMODEMOEntities ctxt = new IMMODEMOEntities();
            return Json(ctxt.IMMO_ARTICLE.Select(c => new { ID = c.CODE.ToString(), NAME = c.DESIGNATION.ToString() }).OrderBy(o => o.ID).ToList(), JsonRequestBehavior.AllowGet);
        }
        //***********************************************************************************
        public ActionResult ChercherArticle([DataSourceRequest] DataSourceRequest request, string CODE)
        {
            IMMODEMOEntities ctxt = new IMMODEMOEntities();
            var C = ctxt.IMMO_ARTICLE.OrderBy(o => o.DESIGNATION).AsQueryable();

            if (CODE != "")
                C = C.Where(w => w.CODE == CODE);
            else
                C = bo.Afficher().AsQueryable();



            var fList = C.Select((IMMO_ARTICLE a) => new ArticleLite
            {
              CODE = a.CODE,
                    FAMILLE = a.FAMILLE,
                   CENTREACHAT = a.CENTREACHAT,
                    
                        
                   DATEAFFECTATION = a.DATEAFFECTATION,
                    DATEAQUISITION = a.DATEAQUISITION,
                   ANNEEBL = a.ANNEEBL,
                   NUMBL = a.NUMBL,
                   NUMLIGBL = a.NUMLIGBL,
                   NUMFACTURE = a.NUMFACTURE,
                   DATEEXPLOITATION = a.DATEEXPLOITATION,
                 DUREE = a.DUREE,
                  TAUXAMORTISSEMENT = a.TAUXAMORTISSEMENT,
            DOTATIONANTERIEURE = a.DOTATIONANTERIEURE,
                   VALEURCOMPTABLE = a.VALEURCOMPTABLE,
                   DATESESSION = a.DATESESSION,
                    VALEURSESSION = a.VALEURSESSION,
                   RAISONSESSION = a.RAISONSESSION,
                   AMORTI = a.AMORTI,
                    ETAT = a.ETAT,
                    DESIGNATION = a.DESIGNATION,
                    ETATSESSION = a.ETATSESSION,
                    COMPTE = a.COMPTE,
                    
                   
                    REFERENCE = a.REFERENCE,
                    CARACTERISTIQUE = a.CARACTERISTIQUE,
                   ANNEE = a.ANNEE,
                    SERVICE = a.SERVICE,
                    LOCALE = a.LOCALE,
                    Emplacement = a.Emplacement,



            });
            var fvt = fList.ToList();

            return Json(fvt.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);

        }

        //*****************************************************************
        public ActionResult GetAllA([DataSourceRequest] DataSourceRequest request,string CODE)
        {
            List<IMMO_ARTICLE> Articles = new List<IMMO_ARTICLE>();

            
            if (bo.Trouver(CODE) != null)
            {
                Articles.Clear();
                IMMO_ARTICLE Article = bo.Trouver(CODE);

                Articles.Add(Article);
            }
            if (bo.Trouver(CODE) == null)
                Articles = bo.Afficher();

            return Json(Articles.ToDataSourceResult(request, record => new
            {
                record.CODE,
                record.DESIGNATION,
                record.AFFECTATION,
                record.DUREE,
                record.ETAT,
                record.VALEURCOMPTABLE,
                record.VALEURSESSION,
                record.NUMFACTURE,
                record.REFERENCE,
                record.DATEAFFECTATION,
                record.TAUXAMORTISSEMENT,
                record.SERVICE,
                record.Emplacement,
                record.DATEEXPLOITATION,
                record.DATEAQUISITION,
                record.RAISONSESSION,
                record.DOTATIONANTERIEURE,
                record.FAMILLE,
                record.ANNEEBL,
                record.NUMBL,
                record.NUMLIGBL,
                record.ETATSESSION,
                record.COMPTE,
                record.CARACTERISTIQUE,
                record.ANNEE,
                record.LOCALE,
                record.DATESESSION,
                record.AMORTI,
                record.CENTREACHAT
                



            }), JsonRequestBehavior.AllowGet);
        }
        //***********************************************************************************

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Add([DataSourceRequest] DataSourceRequest request, IMMO_ARTICLE Article)
        {
            try { 
            
                bo.Ajouter(Article);
              CODEBAR co = new CODEBAR();
            Random rnd = new Random();
           
            co.CODECLAIR = (rnd.Next(100000000, 999999999)).ToString();
            string t1 = (rnd.Next(100000, 999999)).ToString();
            string t2 = (rnd.Next(100000, 999999)).ToString();
            co.CODEBAR1 = t1 + t2;
            co.CODE = Article.CODE;
            co.AFFECTLOCAL = Article.AFFECTATION;
            co.LIBELLE = Article.DESIGNATION;
            bo8.Ajouter(co);

                
            //Ajouter une valeur aleatoire du code a barre

               


            //***************Prototype*******************************
                //***************Chargement automatique des ammortissements*******************************

                if (Article.AMORTI.ToString() == "L")
                {
                    List<IMMO_AMORTISSEMENTANNUELLE> l = bo2.RemplirAmmLpour1Article(Article.CODE);
                    foreach (IMMO_AMORTISSEMENTANNUELLE a in l)
                    {
                        if (bo2.TrouverParArticle(Article.CODE) == null)
                        // bo2.AjouterList(l);
                        {
                            foreach (IMMO_AMORTISSEMENTANNUELLE a1 in l)
                            {
                                ctxt.IMMO_AMORTISSEMENTANNUELLE.Add(a1);
                            }
                        }
                        else
                        {
                            foreach (IMMO_AMORTISSEMENTANNUELLE b in ctxt.IMMO_AMORTISSEMENTANNUELLE)
                            {
                                if (bo2.VerifExistance(b, l) == false)
                                {
                                    if ((bo2 != null) && (b.ARTICLE == a.ARTICLE))
                                        // bo2.Supprimer(b);
                                        ctxt.IMMO_AMORTISSEMENTANNUELLE.Remove(b);

                                    else
                                        return RedirectToAction("Index");
                                }


                                if ((b.ARTICLE == a.ARTICLE) && (b.ANNEE == a.ANNEE))
                                    bo2.Mettre_A_Jour(a);
                            }
                        }
                    }
                }
                if (Article.AMORTI.ToString() == "D")
                {
                    List<IMMO_AMORTISSEMENTANNUELLE> l = bo2.RemplirAmmDegpour1Article(Article.CODE);
                    
                    foreach (IMMO_AMORTISSEMENTANNUELLE a in l)
                    {
                        if (bo2.TrouverParArticle(Article.CODE) == null)
                        // bo2.AjouterList(l);
                        {
                            foreach (IMMO_AMORTISSEMENTANNUELLE a1 in l)
                            {
                                ctxt.IMMO_AMORTISSEMENTANNUELLE.Add(a1);
                            }
                        }
                        else
                            foreach (IMMO_AMORTISSEMENTANNUELLE b in ctxt.IMMO_AMORTISSEMENTANNUELLE)
                            {
                                if (bo2.VerifExistance(b, l) == false)
                                {
                                    if ((bo2 != null) && (b.ARTICLE == a.ARTICLE))
                                        // bo2.Supprimer(b);
                                        ctxt.IMMO_AMORTISSEMENTANNUELLE.Remove(b);

                                    else
                                        return RedirectToAction("Index");
                                }


                                if ((b.ARTICLE == a.ARTICLE) && (b.ANNEE == a.ANNEE))
                                    bo2.Mettre_A_Jour(a);

                            }
                    
                }
                }
                //******************************************************
                ctxt.SaveChanges();

            return Json(new[] { Article }.ToDataSourceResult(request, ModelState));
            }
            catch { return View(); }
        }
        //**************************************************************************************
        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, IMMO_ARTICLE Article)
        {
            try { 
            if (Article != null && ModelState.IsValid)
            {
                bo.Mettre_A_Jour(Article);
               // ctxt.SaveChanges();


                //***************Chargement automatique des ammortissements*******************************
                
                    if (Article.AMORTI.ToString() == "L")
                    {
                        List<IMMO_AMORTISSEMENTANNUELLE> l = bo2.RemplirAmmLpour1Article(Article.CODE);
                        foreach (IMMO_AMORTISSEMENTANNUELLE a in l)
                        {
                            if (bo2.TrouverParArticle(Article.CODE) == null)
                                // bo2.AjouterList(l);
                            {
                                foreach (IMMO_AMORTISSEMENTANNUELLE a1 in l)
                                {
                                    ctxt.IMMO_AMORTISSEMENTANNUELLE.Add(a1);
                                }
                            }
                            else
                            {
                                foreach (IMMO_AMORTISSEMENTANNUELLE b in ctxt.IMMO_AMORTISSEMENTANNUELLE)
                                {
                                    if  (bo2.VerifExistance(b, l) == false)   
                                    {
                                        if ((bo2 != null) &&(b.ARTICLE==a.ARTICLE ))
                                            // bo2.Supprimer(b);
                                            
                                            ctxt.IMMO_AMORTISSEMENTANNUELLE.Remove(b);

                                        else
                                            return RedirectToAction("Index");
                                    }
                                   

                                    if ((b.ARTICLE == a.ARTICLE) && (b.ANNEE == a.ANNEE))
                                        bo2.Mettre_A_Jour(a);
                                }
                            }
                        }
                    }
                    if (Article.AMORTI.ToString() == "D")
                    {
                        List<IMMO_AMORTISSEMENTANNUELLE> l = bo2.RemplirAmmDegpour1Article(Article.CODE);
                        foreach (IMMO_AMORTISSEMENTANNUELLE a in l)
                        {
                            if (bo2.TrouverParArticle(Article.CODE) == null)
                               // bo2.AjouterList(l);
                            {
                                foreach (IMMO_AMORTISSEMENTANNUELLE a1 in l)
                                {
                                    ctxt.IMMO_AMORTISSEMENTANNUELLE.Add(a1);
                                }
                            }
                            else
                                foreach (IMMO_AMORTISSEMENTANNUELLE b in ctxt.IMMO_AMORTISSEMENTANNUELLE)
                                {
                                    if (bo2.VerifExistance(b, l) == false)
                                    {
                                        if ((bo2 != null)&&(b.ARTICLE==a.ARTICLE ))
                                            // bo2.Supprimer(b);
                                            ctxt.IMMO_AMORTISSEMENTANNUELLE.Remove(b);

                                        else
                                            return RedirectToAction("Index");
                                    }


                                    if ((b.ARTICLE == a.ARTICLE) && (b.ANNEE == a.ANNEE))
                                        bo2.Mettre_A_Jour(a);

                                }
                        }
                    }
                    //******************************************************
                    ctxt.SaveChanges();

                    return RedirectToAction("Index");


                
            }
                return Json(ModelState.ToDataSourceResult());

            }
            catch { return View(); }
        }


        //*****************************************************************
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete([DataSourceRequest] DataSourceRequest request, IMMO_ARTICLE Article)
        {
            try { 
                if (Article != null)
                {
                var tmp = bo1.AjoutSupprime(Article);
                bo1.Ajouter(tmp);
                if (Article != null && ModelState.IsValid)
                {
                    bo3.SupprimerParArticle(Article);
                    bo4.SupprimerParArticle(Article);
                    bo5.SupprimerParArticle2(Article);
                    bo6.SupprimerParArticle(Article);
                    bo7.SupprimerParArticle(Article);
                   
                    bo.Supprimer(Article);
                }

                else
                    return RedirectToAction("Index");
              
            }
            return Json(ModelState.ToDataSourceResult());
            }
            catch { return View(); }
        }
        //***********************************************************************
         public ActionResult GetCode(string CODE)
        {
            IMMODEMOEntities ctxt = new IMMODEMOEntities();
            List<CODEBAR> c = new List<CODEBAR>();
            var l = bo8.Afficher();
            CODEBAR co = new CODEBAR();
            co.CODECLAIR = "CT";
            co.CODEBAR1 = "123456789102";
            co.LIBELLE = "test";
            co.CODE = "AA";
            
             foreach(CODEBAR cd in ctxt.CODEBARs)
             {
                 if (CODE == cd.CODE)
                     c.Add(cd);
             }
             if (c.Count() == 0)
                 c.Add(co);
             var List = c.AsQueryable();

            return Json(List.Select(d => new { ID = d.CODEBAR1.ToString() }).OrderBy(o => o.ID).ToList(), JsonRequestBehavior.AllowGet);
        }
        //*****************************************


    }
}