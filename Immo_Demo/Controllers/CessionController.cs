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
    public class CessionController : Controller
    {
        // GET: Cession
        public ActionResult Index()
        {
            return View();
        }

        //*********************************************************************
        /// <summary>
        ///Operations CRUD pour la classe IMMO_SESSION
        /// </summary>
        private ICesstionBuisness bo = new CessionBuisness();

        //*********************************************************************     
        IMMODEMOEntities ctxt = new IMMODEMOEntities();

        //************************************************************************
        public ActionResult GetAll([DataSourceRequest] DataSourceRequest request ,string ANNEE, string NUM)
        {

              IMMODEMOEntities ctxt = new IMMODEMOEntities();
            var C = ctxt.IMMO_CESSION.OrderBy(o => o.NUM).AsQueryable();
            
            if ((ANNEE != "") && (NUM != ""))
                C = C.Where(w => w.ANNEE.ToString() == ANNEE)
                    .Where(w => w.NUM.ToString() == NUM);
            if ((ANNEE != "") && (NUM == ""))
                C = C.Where(w => w.ANNEE.ToString() == ANNEE);
            if ((ANNEE == "") && (NUM != ""))
                C = C.Where(w => w.NUM.ToString() == NUM);
            if ((ANNEE == "") && (NUM == ""))
                C = bo.Afficher().AsQueryable();

            
            return Json(C.ToDataSourceResult(request, record => new
            {
                record.ANNEE,
                record.NUM,
                record.DATECESSION,
                record.RAISON,
                record.ETAT,

                record.VALTOTAL,
                record.EXERCICE



            }), JsonRequestBehavior.AllowGet);
        }
        //***********************************************************************************
        public ActionResult ChercherCess([DataSourceRequest] DataSourceRequest request, int? ANNEE, int? NUM)
        {
            IMMODEMOEntities ctxt = new IMMODEMOEntities();
            var C = ctxt.IMMO_CESSION.OrderBy(o => o.NUM).AsQueryable();
            string ANNEEs = ANNEE.ToString();
            string NUMs = NUM.ToString();
            if ((ANNEEs != "") && (NUMs != ""))
                C = C.Where(w => w.ANNEE == ANNEE)
                    .Where(w => w.NUM == NUM);
            if ((ANNEEs != "") && (NUMs == ""))
                C = C.Where(w => w.ANNEE == ANNEE);
            if ((ANNEEs == "") && (NUMs != ""))
                C = C.Where(w => w.NUM == NUM);



            var fList = C.Select((IMMO_CESSION p) => new CessionLite
            {
                NUM = p.NUM,
                RAISON = p.RAISON,

                DATECESSION = p.DATECESSION,
                EXERCICE = p.EXERCICE,
                ETAT = p.ETAT,
                VALTOTAL = p.VALTOTAL,
                ANNEE = p.ANNEE,


            });
            var fvt = fList.ToList();

            return Json(fvt.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);

        }
        //***********************************************************************************
        public JsonResult GetCession2(int? ANNEE)
        {    //initialisation de context de base de donnees
            IMMODEMOEntities ctxt = new IMMODEMOEntities();
            List<IMMO_CESSION> l = new List<IMMO_CESSION>();
            string s = ANNEE.ToString();
            if (s != "")
            {
                int ANNEEs = (int)ANNEE;
                l.Add(bo.TrouverParAnnee(ANNEEs));
            }
            else
                l = bo.Afficher();
            var List = l.AsQueryable();
            return Json(List.Select(c => new { ANNEE = c.ANNEE, NUM = c.NUM }).OrderBy(o => o.NUM).ToList(), JsonRequestBehavior.AllowGet);
        }
        //********************************************************************
        public JsonResult GetCession3()
        {    //initialisation de context de base de donnees
            IMMODEMOEntities ctxt = new IMMODEMOEntities();
            return Json(ctxt.IMMO_CESSION.Select(c => new { ANNEE = c.ANNEE, NUM = c.NUM }).OrderBy(o => o.NUM).ToList(), JsonRequestBehavior.AllowGet);
        }
        //********************************************************************
        public JsonResult GetCessionA()
        {
            IMMODEMOEntities ctxt = new IMMODEMOEntities();
            return Json(ctxt.IMMO_ARTICLE_SESSION.Select(c => new { ARTICLE = c.ARTICLE, NUM = c.NUM }).OrderBy(o => o.ARTICLE).ToList(), JsonRequestBehavior.AllowGet);
        }
       

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Add([DataSourceRequest] DataSourceRequest request, IMMO_CESSION cession)
        {
            try { 
            if (cession != null && ModelState.IsValid)
            {
                bo.Ajouter(cession);

                ctxt.SaveChanges();
            }
            return Json(new[] { cession }.ToDataSourceResult(request, ModelState));
            }
            catch { return View(); }
        }
        //**************************************************************************************

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, IMMO_CESSION cession)
        {
            try { 
            if (cession != null && ModelState.IsValid)
            {
                bo.Mettre_A_Jour(cession);

                ctxt.SaveChanges();
            }
            return Json(ModelState.ToDataSourceResult());
            }
            catch { return View(); }
        }


        //*****************************************************************
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete([DataSourceRequest] DataSourceRequest request, IMMO_CESSION cession)
        {
            try { 
           if (cession != null && ModelState.IsValid)
           {
               int annee = (int)cession.ANNEE;
               int num = (int)cession.NUM;

               bo1.SupprimerParArticle(annee,num);
               ctxt.SaveChanges();
                bo.Supprimer(cession);
                ctxt.SaveChanges();
            }
            return Json(ModelState.ToDataSourceResult());
            }
            catch { return View(); }
        }
        //******************************************************************************
        public ActionResult GetCession()
        {
            IMMODEMOEntities ctxt = new IMMODEMOEntities();
            var C = ctxt.IMMO_CESSION.OrderBy(o => o.ANNEE).AsQueryable();


           



            var fList = C.Select((IMMO_CESSION p) => new CessionLite
            {
                NUM = p.NUM,
                RAISON = p.RAISON,

                DATECESSION= p.DATECESSION,
                EXERCICE = p.EXERCICE,
                ETAT = p.ETAT,
                VALTOTAL = p.VALTOTAL,
                ANNEE = p.ANNEE,

            });
            var fvt = fList.ToList();

            return Json(fvt, JsonRequestBehavior.AllowGet);

        }

        //*******************************Debut Article Session Controler*********************
        private IArticleCessionBuisness bo1 = new ArticleCessionBuisness();

        //*********************************************************************     

        //************************************************************************
        public ActionResult GetAll2([DataSourceRequest] DataSourceRequest request)
        {

            var Cession = bo1.Afficher();
            return Json(Cession.ToDataSourceResult(request, record => new
            {
                record.ARTICLE,
                record.RAISON,
                record.VALEUR,
                record.DATESESSION,
                record.ETAT,

                record.DOTATION,
                record.ANNEE,
                record.NUM,
                record.AMORTISSEMENTPRATIQUE




            }), JsonRequestBehavior.AllowGet);
        }
        //***********************************************************************************
        public ActionResult GetAllC([DataSourceRequest] DataSourceRequest request)
        {

            var C = bo.Afficher();
            var fList = C.Select((IMMO_CESSION p) => new CessionLite
            {
                NUM = p.NUM,
                RAISON = p.RAISON,

                DATECESSION = p.DATECESSION,
                EXERCICE = p.EXERCICE,
                ETAT = p.ETAT,
                VALTOTAL = p.VALTOTAL,
                ANNEE = p.ANNEE,

            });
            var fvt = fList.ToList();

            return Json(fvt, JsonRequestBehavior.AllowGet);
        }
        //******************************************************************************


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Add2([DataSourceRequest] DataSourceRequest request, IMMO_ARTICLE_SESSION s)
        {
            try { 
            if (s != null && ModelState.IsValid)
            {
                bo1.Ajouter(s);

                ctxt.SaveChanges();
            }
            return Json(new[] {s}.ToDataSourceResult(request, ModelState));
            }
            catch { return View(); }
        }
        //**************************************************************************************
        public JsonResult GetArticlesA()
        {    //initialisation de context de base de donnees
            return Json(ctxt.IMMO_ARTICLE_SESSION.Select(c => new { ARTICLE = c.ARTICLE.ToString() }).OrderBy(o => o.ARTICLE).ToList(), JsonRequestBehavior.AllowGet);
        }

        //***********************************************************************************

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update2([DataSourceRequest] DataSourceRequest request, IMMO_ARTICLE_SESSION s)
        {
            try { 
            if (s != null && ModelState.IsValid)
            {
                bo1.Mettre_A_Jour(s);

                ctxt.SaveChanges();
            }
            return Json(ModelState.ToDataSourceResult());
            }
            catch { return View(); }
        }


        //*****************************************************************
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete2([DataSourceRequest] DataSourceRequest request, IMMO_ARTICLE_SESSION s)
        {
            try { 
            if (s != null && ModelState.IsValid)
            {
                bo1.Supprimer(s);
                ctxt.SaveChanges();
            }
            return Json(ModelState.ToDataSourceResult());
            }
            catch { return View(); }
        }
        //***********************************************************************************
        public ActionResult ChercherCession([DataSourceRequest] DataSourceRequest request, int? ANNEE, int? NUM)
        {
            IMMODEMOEntities ctxt = new IMMODEMOEntities();
            var C = ctxt.IMMO_ARTICLE_SESSION.OrderBy(o => o.NUM).AsQueryable();
            string ANNEEs = ANNEE.ToString();
            string NUMs = NUM.ToString();
            if ((ANNEEs != "") && (NUMs != ""))
                C = C.Where(w => w.ANNEE == ANNEE)
                    .Where(w => w.NUM == NUM);
            if ((ANNEEs != "") && (NUMs == ""))
                C = C.Where(w => w.ANNEE == ANNEE);
            if ((ANNEEs == "") && (NUMs != ""))
                C = C.Where(w => w.NUM == NUM);
            if ((ANNEEs == "") && (NUMs == ""))
                C = bo1.Afficher().AsQueryable();




            var fList = C.Select((IMMO_ARTICLE_SESSION p) => new ArticleSessionLite
            {
                ARTICLE = p.ARTICLE,
                NUM = p.NUM,
                RAISON = p.RAISON,

                VALEUR = p.VALEUR,
                DATESESSION = p.DATESESSION,
                ETAT = p.ETAT,
                DOTATION = p.DOTATION,
                ANNEE = p.ANNEE,
                AMORTISSEMENTPRATIQUE = p.AMORTISSEMENTPRATIQUE,

            });
            var fvt = fList.ToList();

            return Json(fvt.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);

        }

        //*****************************************************************
        //**********************************************************************************
        public ActionResult ChercherCessionArticleChart(int? ANNEE, int? NUM,string ARTICLE)
        {
            IMMODEMOEntities ctxt = new IMMODEMOEntities();
            var C = ctxt.IMMO_ARTICLE_SESSION.OrderBy(o => o.ARTICLE).AsQueryable();

            if((ANNEE != null)&&(NUM!= null)&&(ARTICLE== ""))
            C = C.Where(w => w.ANNEE == ANNEE)
                .Where(w => w.NUM == NUM);
            if ((ANNEE == null) && (NUM != null) && (ARTICLE == ""))
                C = C.Where(w => w.NUM == NUM);
            if ((ANNEE != null) && (NUM == null) && (ARTICLE == ""))
                C = C.Where(w => w.ANNEE == ANNEE);
            if ((ANNEE == null) && (NUM == null) && (ARTICLE == ""))
                C = bo1.Afficher().AsQueryable();
            if ((ANNEE != null) && (NUM != null) && (ARTICLE != ""))
                C = C.Where(w => w.ANNEE == ANNEE)
                    .Where(w => w.NUM == NUM)
                    .Where(w => w.ARTICLE == ARTICLE);
            if ((ANNEE == null) && (NUM != null) && (ARTICLE != ""))
                C = C.Where(w => w.NUM == NUM)
                    .Where(w => w.ARTICLE == ARTICLE);
            if ((ANNEE != null) && (NUM == null) && (ARTICLE != ""))
                C = C.Where(w => w.ANNEE == ANNEE)
                    .Where(w => w.ARTICLE == ARTICLE);
            if ((ANNEE == null) && (NUM == null) && (ARTICLE != ""))
                C = C.Where(w => w.ARTICLE == ARTICLE);




            var fList = C.Select((IMMO_ARTICLE_SESSION p) => new ArticleSessionLite
            {
                ARTICLE = p.ARTICLE,
                NUM = p.NUM,
                RAISON = p.RAISON,

                VALEUR = p.VALEUR,
                DATESESSION = p.DATESESSION,
                ETAT = p.ETAT,
                DOTATION = p.DOTATION,
                ANNEE = p.ANNEE,
                AMORTISSEMENTPRATIQUE = p.AMORTISSEMENTPRATIQUE,

            });
            var fvt = fList.ToList();

            return Json(fvt, JsonRequestBehavior.AllowGet);

        }
        //***********************************************
        public ActionResult ChercherCessionChart(int? ANNEE, int? NUM)
        {
            IMMODEMOEntities ctxt = new IMMODEMOEntities();
            var C = ctxt.IMMO_CESSION.OrderBy(o => o.NUM).AsQueryable();

            if ((ANNEE != null) && (NUM != null))
                C = C.Where(w => w.ANNEE == ANNEE)
                    .Where(w => w.NUM == NUM);
            if ((ANNEE == null) && (NUM != null))
                C = C.Where(w => w.NUM == NUM);
            if ((ANNEE != null) && (NUM == null))
                C = C.Where(w => w.ANNEE == ANNEE);
            if ((ANNEE == null) && (NUM == null))
                C = bo.Afficher().AsQueryable();


            var fList = C.Select((IMMO_CESSION p) => new CessionLite
            {
                NUM = p.NUM,
                RAISON = p.RAISON,

                DATECESSION = p.DATECESSION,
                EXERCICE = p.EXERCICE,
                ETAT = p.ETAT,
                VALTOTAL = p.VALTOTAL,
                ANNEE = p.ANNEE,

            });
            var fvt = fList.ToList();

            return Json(fvt, JsonRequestBehavior.AllowGet);

        }
        //**************************************************************************************
        public ActionResult ChercherCessArt([DataSourceRequest] DataSourceRequest request, int? ANNEE, int? NUM, string ARTICLE)
        {
            IMMODEMOEntities ctxt = new IMMODEMOEntities();
            var C = ctxt.IMMO_ARTICLE_SESSION.OrderBy(o => o.NUM).AsQueryable();
            string ANNEEs = ANNEE.ToString();
            string NUMs = NUM.ToString();
            if ((ANNEEs != "") && (NUMs != "") && (ARTICLE != ""))
                C = C.Where(w => w.ANNEE == ANNEE)
                    .Where(w => w.NUM == NUM)
                    .Where(w => w.ARTICLE == ARTICLE);

            if ((ANNEEs != "") && (NUMs == "") && (ARTICLE != ""))
                C = C.Where(w => w.ANNEE == ANNEE)
            .Where(w => w.ARTICLE == ARTICLE);
            if ((ANNEEs == "") && (NUMs != "") && (ARTICLE != ""))
                C = C.Where(w => w.NUM == NUM)
                .Where(w => w.ARTICLE == ARTICLE);
            if ((ANNEEs == "") && (NUMs == "") && (ARTICLE != ""))
                C = C.Where(w => w.ARTICLE == ARTICLE)
            .Where(w => w.ARTICLE == ARTICLE);
            if ((ANNEEs != "") && (NUMs != "") && (ARTICLE == ""))
                C = C.Where(w => w.ANNEE == ANNEE)
                    .Where(w => w.NUM == NUM);


            if ((ANNEEs != "") && (NUMs == "") && (ARTICLE == ""))
                C = C.Where(w => w.ANNEE == ANNEE);
            if ((ANNEEs == "") && (NUMs != "") && (ARTICLE == ""))
                C = C.Where(w => w.NUM == NUM);



            var fList = C.Select((IMMO_ARTICLE_SESSION p) => new ArticleSessionLite
            {
                ARTICLE = p.ARTICLE,
                NUM = p.NUM,
                RAISON = p.RAISON,

                VALEUR = p.VALEUR,
                DATESESSION = p.DATESESSION,
                ETAT = p.ETAT,

                DOTATION = p.DOTATION,
                ANNEE = p.ANNEE,
                AMORTISSEMENTPRATIQUE = p.AMORTISSEMENTPRATIQUE


            });
            var fvt = fList.ToList();

            return Json(fvt.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);

        }
        //****************************************************************************************
    }
}