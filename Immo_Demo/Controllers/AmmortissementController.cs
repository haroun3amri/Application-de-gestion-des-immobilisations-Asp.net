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


namespace Immo_Demo.Controllers
{
    //****************************************************
    public class AmmortissementController : Controller
    {
        public JsonResult GetArticles(string CODEM, string CODEF)
        {
            IMMODEMOEntities ctxt = new IMMODEMOEntities();
          
            var Articles = ctxt.IMMO_ARTICLE.OrderBy(o => o.DESIGNATION).AsQueryable();

            if (CODEM != "")
            {
                Articles = Articles.Where(w => w.IMMO_FAMILLE.FAMILLEM == CODEM);
            }



            if (CODEF != "")
            {
                Articles = Articles.Where(w => w.IMMO_FAMILLE.CODE == CODEF);

            }

            return Json(Articles.Select(c => new { ID = c.CODE, Name = c.DESIGNATION }).OrderBy(o => o.ID).ToList(),
               JsonRequestBehavior.AllowGet);
        }
        //*********************************************************
        
        




        // GET: Ammortissement
        public ActionResult Index()
        {
            return View();
        }
        private IAmmoLinBuisness bo = new AmmoLinBuisnessImp();
        //*********************************************************************     
        IMMODEMOEntities ctxt = new IMMODEMOEntities();
        //************************************************************************
        public ActionResult GetAll([DataSourceRequest] DataSourceRequest request)
        {

            var Articles = bo.Afficher();
            return Json(Articles.ToDataSourceResult(request, record => new
            {
                record.ARTICLE,
                record.ANNEE,
                record.DATEAMORTISSEMENT,
                record.VALEUR,
                record.MONTANTCALCUL,

                record.AMORTISSEMENTP,
                record.AMORTISSEMENTNONCPT



            }), JsonRequestBehavior.AllowGet);
        }
        //***********************************************************************************

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Add([DataSourceRequest] DataSourceRequest request, IMMO_AMORTISSEMENTANNUELLE Am)
        {
            try
            {
                if (Am != null && ModelState.IsValid)
                {
                    bo.Ajouter(Am);

                    ctxt.SaveChanges();
                }
                return Json(new[] { Am }.ToDataSourceResult(request, ModelState));
            }
            catch { return View(); }
        }
        //**************************************************************************************

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, IMMO_AMORTISSEMENTANNUELLE Am)
        {
            try { 
            if (Am != null && ModelState.IsValid)
            {
                bo.Mettre_A_Jour(Am);

                ctxt.SaveChanges();
            }
            return Json(ModelState.ToDataSourceResult());
            }
            catch { return View(); }
        }


        //*****************************************************************
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete([DataSourceRequest] DataSourceRequest request, IMMO_AMORTISSEMENTANNUELLE Am)
        {
            try { 
            if (Am != null && ModelState.IsValid)
            {
                bo.Supprimer(Am);
                ctxt.SaveChanges();
            }
            return Json(ModelState.ToDataSourceResult());
            }
            catch { return View(); }
        }
        //*********************************************************
        public ActionResult GetAmmortissementsLin([DataSourceRequest] DataSourceRequest request, string ARTICLE)
        {

            if (ARTICLE != "")
            {

                var Articles = bo.TrouverParArticle(ARTICLE);
                return Json(Articles.ToDataSourceResult(request, record => new
                {
                    record.ARTICLE,
                    record.ANNEE,
                    record.DATEAMORTISSEMENT,
                    record.VALEUR,
                    record.MONTANTCALCUL,
                    record.AMORTISSEMENTP



                }), JsonRequestBehavior.AllowGet);

            }
            else return null;
        }
        //**********************************************************
        public JsonResult GetArticles2(string CODE)
        {
            IMMODEMOEntities ctxt = new IMMODEMOEntities();
            var Articles = ctxt.IMMO_AMORTISSEMENTANNUELLE.OrderBy(o => o.ANNEE).AsQueryable();

            if (CODE != null)
            {
                Articles = Articles.Where(w => w.ARTICLE== CODE);
            }


            var ArticlesList = Articles.Select((IMMO_AMORTISSEMENTANNUELLE p) => new AmmortissementLite
            {
                ARTICLE = p.ARTICLE,
                ANNEE = p.ANNEE,
                MONTANTCALCUL= p.MONTANTCALCUL,
                VALEUR=p.VALEUR

               // FAMILLE = p.FAMILLE,
               // VALEURCOMPTABLE = p.VALEURCOMPTABLE,
                //AFFECTATION = p.IMMO_AFFECTATION.LIBELLE,
                //LOCALE = p.LOCALE



            });
            var fvt = ArticlesList.ToList();

            return Json(fvt, JsonRequestBehavior.AllowGet);

        }
        //************************************************************************
        //**********************************************************
        public JsonResult GetArticlesgrid([DataSourceRequest] DataSourceRequest request,string CODE)
        {
            IMMODEMOEntities ctxt = new IMMODEMOEntities();
            var Articles = ctxt.IMMO_AMORTISSEMENTANNUELLE.OrderBy(o => o.ANNEE).AsQueryable();

            if (CODE != "")
            {
                Articles = Articles.Where(w => w.ARTICLE == CODE);
            }


            var ArticlesList = Articles.Select((IMMO_AMORTISSEMENTANNUELLE p) => new AmmortissementLite
            {
                ARTICLE = p.ARTICLE,
                ANNEE = p.ANNEE,
                MONTANTCALCUL = p.MONTANTCALCUL,
                VALEUR = p.VALEUR,
                AMORTISSEMENTNONCPT=p.AMORTISSEMENTNONCPT,
                AMORTISSEMENTP=p.AMORTISSEMENTP,
                DATEAMORTISSEMENT=p.DATEAMORTISSEMENT

                



            });
            var fvt = ArticlesList.ToList();

            return Json(fvt.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);

        }

        //*************************************************************************
        public ActionResult GetAmmortissement(string ARTICLE)
        {
            
            var AMS = ctxt.IMMO_AMORTISSEMENTANNUELLE.OrderBy(o => o.ANNEE).AsQueryable();


            if (ARTICLE == "")
            {

                AMS = AMS.Where(w => (w.IMMO_ARTICLE.CODE == ARTICLE));


            }

           
            var AMSList = AMS.Select( p => new AmmortissementLite
            {
                ARTICLE = p.ARTICLE,
                ANNEE= p.ANNEE,
                DATEAMORTISSEMENT = p.DATEAMORTISSEMENT,
                VALEUR = p.VALEUR,
                MONTANTCALCUL = p.MONTANTCALCUL,
               AMORTISSEMENTP = p.AMORTISSEMENTP,
                AMORTISSEMENTNONCPT = p.AMORTISSEMENTNONCPT


            });
            return Json(AMSList.ToList(),JsonRequestBehavior.AllowGet);


        }
        //*************************************************************************
        public ActionResult test(string CODE)
        {

            IMMO_AMORTISSEMENTANNUELLE l = bo.InitialiserAmmLPour1Article(CODE);
            List<IMMO_AMORTISSEMENTANNUELLE> AMS1 = new List<IMMO_AMORTISSEMENTANNUELLE>();
            AMS1.Add(l);
             var AMS = AMS1.AsQueryable();

            var AMSList = AMS.Select(p => new AmmortissementLite
            {
                ARTICLE = p.ARTICLE,
                ANNEE = p.ANNEE,
                DATEAMORTISSEMENT = p.DATEAMORTISSEMENT,
                VALEUR = p.VALEUR,
                MONTANTCALCUL = p.MONTANTCALCUL,
                AMORTISSEMENTP = p.AMORTISSEMENTP,
                AMORTISSEMENTNONCPT = p.AMORTISSEMENTNONCPT


            });
            return Json(AMSList.ToList(), JsonRequestBehavior.AllowGet);


        }
        //**********************************************************************
        public ActionResult testd(string CODE)
        {

            IMMO_AMORTISSEMENTANNUELLE l = bo.InitialiserAmmLDegPour1Article(CODE);
            List<IMMO_AMORTISSEMENTANNUELLE> AMS1 = new List<IMMO_AMORTISSEMENTANNUELLE>();
            AMS1.Add(l);
            var AMS = AMS1.AsQueryable();

            var AMSList = AMS.Select(p => new AmmortissementLite
            {
                ARTICLE = p.ARTICLE,
                ANNEE = p.ANNEE,
                DATEAMORTISSEMENT = p.DATEAMORTISSEMENT,
                VALEUR = p.VALEUR,
                MONTANTCALCUL = p.MONTANTCALCUL,
                AMORTISSEMENTP = p.AMORTISSEMENTP,
                AMORTISSEMENTNONCPT = p.AMORTISSEMENTNONCPT


            });
            return Json(AMSList.ToList(), JsonRequestBehavior.AllowGet);


        }
        //***********************************************************************
        public ActionResult testd2(string CODE)
        {

            List<IMMO_AMORTISSEMENTANNUELLE> AMS1 = bo.RemplirAmmDegpour1Article(CODE);

            var AMS = AMS1.AsQueryable();

            var AMSList = AMS.Select(p => new AmmortissementLite
            {
                ARTICLE = p.ARTICLE,
                ANNEE = p.ANNEE,
                DATEAMORTISSEMENT = p.DATEAMORTISSEMENT,
                VALEUR = p.VALEUR,
                MONTANTCALCUL = p.MONTANTCALCUL,
                AMORTISSEMENTP = p.AMORTISSEMENTP,
                AMORTISSEMENTNONCPT = p.AMORTISSEMENTNONCPT


            });
            return Json(AMSList.ToList(), JsonRequestBehavior.AllowGet);


        }
        //***************************************
        public ActionResult test2(string CODE)
        {

            List<IMMO_AMORTISSEMENTANNUELLE> AMS1 = bo.RemplirAmmLpour1Article(CODE);
           
            var AMS = AMS1.AsQueryable();

            var AMSList = AMS.Select(p => new AmmortissementLite
            {
                ARTICLE = p.ARTICLE,
                ANNEE = p.ANNEE,
                DATEAMORTISSEMENT = p.DATEAMORTISSEMENT,
                VALEUR = p.VALEUR,
                MONTANTCALCUL = p.MONTANTCALCUL,
                AMORTISSEMENTP = p.AMORTISSEMENTP,
                AMORTISSEMENTNONCPT = p.AMORTISSEMENTNONCPT


            });
            return Json(AMSList.ToList(), JsonRequestBehavior.AllowGet);


        }
        //***********************************************************************
    }
}