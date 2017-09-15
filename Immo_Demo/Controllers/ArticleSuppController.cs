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
    public class ArticleSuppController : Controller
    {
        // GET: ArticleSupp
        public ActionResult Index()
        {
            return View();
        }
        //*********************************************************************
        private IArticleSuppBuisness bo = new ArticleSuppBuisnessImp();

        //*********************************************************************     
        IMMODEMOEntities ctxt = new IMMODEMOEntities();

        //************************************************************************
        public JsonResult GetArticles([DataSourceRequest] DataSourceRequest request, string CODEM, string CODEF, string CODE)
        {
            IMMODEMOEntities ctxt = new IMMODEMOEntities();
            var Articles = ctxt.IMMO_ARTICLESUPPRIME.OrderBy(o => o.DESIGNATION).AsQueryable();

            if (CODEM != "")
            {
                Articles = Articles.Where(w => w.IMMO_FAMILLE.IMMO_FAMILLEM.CODE == CODEM);
            }




                if (CODEF != "")
                {
                    Articles = Articles.Where(w => w.IMMO_FAMILLE.CODE == CODEF);

                }

                if (CODE != "")
                {
                    Articles = Articles.Where(w => w.CODE == CODE);
                }



                var ArticlesList = Articles.Select(a => new ArticleSupLite
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
                    AFFECTATION = a.AFFECTATION,

                    REFERENCE = a.REFERENCE,
                    CARACTERISTIQUE = a.CARACTERISTIQUE,
                    ANNEE = a.ANNEE,
                    SERVICE = a.SERVICE,
                    LOCALE = a.LOCALE,
                   DATESUPP=a.DATESUPP,
                   OPERATEUR=a.OPERATEUR



                });
                var fvt = ArticlesList.ToList();

                return Json(fvt.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);

            }
        
        //***********************************************************************************
       
        public JsonResult GetArticlesN()
        {    //initialisation de context de base de donnees
            IMMODEMOEntities ctxt = new IMMODEMOEntities();
            return Json(ctxt.IMMO_ARTICLESUPPRIME.Select(c => new { ID = c.CODE.ToString(), Name = c.DESIGNATION.ToString() }).OrderBy(o => o.ID).ToList(), JsonRequestBehavior.AllowGet);
        }
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
                record.CENTREACHAT,
                record.DATESUPP,
                record.OPERATEUR



            }), JsonRequestBehavior.AllowGet);
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

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Add([DataSourceRequest] DataSourceRequest request, IMMO_ARTICLESUPPRIME Article)
        {
            try { 
            if (Article != null && ModelState.IsValid)
            {
                bo.Ajouter(Article);

                ctxt.SaveChanges();
            }
            return Json(new[] { Article }.ToDataSourceResult(request, ModelState));
            }
            catch { return View(); }
        }
        //**************************************************************************************

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, IMMO_ARTICLESUPPRIME Article)
        {
            try { 
            if (Article != null && ModelState.IsValid)
            {
                bo.Mettre_A_Jour(Article);

                ctxt.SaveChanges();
            }
            return Json(ModelState.ToDataSourceResult());
            }
            catch { return View(); }
        }


        //*****************************************************************
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete([DataSourceRequest] DataSourceRequest request, IMMO_ARTICLESUPPRIME Article)
        {
            try { 
            if (Article != null && ModelState.IsValid)
            {
                bo.Supprimer(Article);
                ctxt.SaveChanges();
            }
            return Json(ModelState.ToDataSourceResult());
            }
            catch { return View(); }
        }
        //***********************************************************************
    }
}