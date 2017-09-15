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
    public class HistoriqueController : Controller
    {
        //*****************************DEclaration des Couche Buisness A employer****************************************
        private IAffectationBuiness1 bo1 = new affectationBuisness();
        private IAffec_Hist_Buisness bo2 = new Affect_Hist_Buisness();
        private IAff_Hist_Art_Buisness bo3 = new Affect_Hist_Art_Buisness();




        //*********************************************************************     
        IMMODEMOEntities ctxt = new IMMODEMOEntities();
        //////////////////////////Debut Conroleur Affectation///////////////////
        //************************************************************************
        public ActionResult GetAllAff([DataSourceRequest] DataSourceRequest request)
        {

            var Aff = bo1.Afficher();
            return Json(Aff.ToDataSourceResult(request, record => new
            {
                record.CODE,
                record.LIBELLE,
                record.RESPONSABLEACHAT,
               



            }), JsonRequestBehavior.AllowGet);
        }
       
        //***********************************************************************************
       

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Add([DataSourceRequest] DataSourceRequest request, IMMO_AFFECTATION Aff)
        {
            try { 
            if (Aff != null && ModelState.IsValid)
            {
                bo1.Ajouter(Aff);

                ctxt.SaveChanges();
            }
            return Json(new[] { Aff }.ToDataSourceResult(request, ModelState));
            }
            catch { return View(); }
        }
        //**************************************************************************************

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, IMMO_AFFECTATION Aff)
        {
            try { 
            if (Aff != null && ModelState.IsValid)
            {
                bo1.Mettre_A_Jour(Aff);

                ctxt.SaveChanges();
            }
            return Json(ModelState.ToDataSourceResult());
            }
            catch { return View(); }
        }


        //*****************************************************************
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete([DataSourceRequest] DataSourceRequest request, IMMO_AFFECTATION Aff)
        {
            try { 
            if (Aff != null && ModelState.IsValid)
            {
                bo1.Supprimer(Aff);
                ctxt.SaveChanges();
            }
            return Json(ModelState.ToDataSourceResult());
            }
            catch { return View(); }
        }
        //***********************************************************************
        //////////////////////////Debut Conroleur Affectation_Hisorique///////////////////
        //************************************************************************
        public ActionResult GetAll_His([DataSourceRequest] DataSourceRequest request)
        {

            var Aff = bo2.Afficher();
            return Json(Aff.ToDataSourceResult(request, record => new
            {
                record.ANNEE,
                record.NUM,
                record.DATEAFFECTATION,
                record.ANCIENNEAFFECTATION,
                record.NOUVELLEAFFECTATION,
                record.ETAT,
                record.OBSERVATION,






            }), JsonRequestBehavior.AllowGet);
        }
        //***********************************************************************************
        public JsonResult GetArticlesN()
        {    //initialisation de context de base de donnees
            return Json(ctxt.IMMO_HIST_AFFECTATION.Select(c => new {ANNEE = c.ANNEE.ToString() }).OrderBy(o => o.ANNEE).ToList(), JsonRequestBehavior.AllowGet);
        }
        //***********************************************************************************
        public JsonResult GetArticlesH()
        {    //initialisation de context de base de donnees
            return Json(ctxt.IMMO_HIST_AFFECTATION.Select(c => new { NUM = c.NUM.ToString() }).OrderBy(o => o.NUM).ToList(), JsonRequestBehavior.AllowGet);
        }

        //***********************************************************************************

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Add_His([DataSourceRequest] DataSourceRequest request, IMMO_HIST_AFFECTATION Aff)
        {
            try { 
            if (Aff != null && ModelState.IsValid)
            {
                bo2.Ajouter(Aff);

                ctxt.SaveChanges();
            }
            return Json(new[] { Aff }.ToDataSourceResult(request, ModelState));
            }
            catch { return View(); }
        }
        //**************************************************************************************

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update_His([DataSourceRequest] DataSourceRequest request, IMMO_HIST_AFFECTATION Aff)
        {
            try { 
            if (Aff != null && ModelState.IsValid)
            {
                bo2.Mettre_A_Jour(Aff);

                ctxt.SaveChanges();
            }
            return Json(ModelState.ToDataSourceResult());
            }
            catch { return View(); }
        }
        //*****************************************************************
        public ActionResult ChercherHisto([DataSourceRequest] DataSourceRequest request, int? ANNEE, int? NUM)
        {
            IMMODEMOEntities ctxt = new IMMODEMOEntities();
            var C = ctxt.IMMO_HIST_AFFECTATION.OrderBy(o => o.NUM).AsQueryable();
            string ANNEEs = ANNEE.ToString();
            string NUMs = NUM.ToString();
            if((ANNEEs != "") &&(NUMs != ""))
                C = C.Where(w => w.ANNEE == ANNEE)
                    .Where(w => w.NUM == NUM);
            if ((ANNEEs != "") && (NUMs == ""))
                C = C.Where(w => w.ANNEE == ANNEE);
            if ((ANNEEs == "") && (NUMs != ""))
                C = C.Where(w => w.NUM == NUM);
            


            var fList = C.Select((IMMO_HIST_AFFECTATION p) => new AffHistoLite
            {
                DATEAFFECTATION = p.DATEAFFECTATION,
                NUM = p.NUM,
                ANCIENNEAFFECTATION = p.ANCIENNEAFFECTATION,

                NOUVELLEAFFECTATION = p.NOUVELLEAFFECTATION,
                OBSERVATION= p.OBSERVATION,
                ETAT = p.ETAT,
               
                ANNEE = p.ANNEE,
                

            });
            var fvt = fList.ToList();

            return Json(fvt.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);

        }

        //*****************************************************************
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete_His([DataSourceRequest] DataSourceRequest request, IMMO_HIST_AFFECTATION Aff)
        {
            try { 
            if (Aff != null && ModelState.IsValid)
            {
                bo2.Supprimer(Aff);
                ctxt.SaveChanges();
            }
            return Json(ModelState.ToDataSourceResult());
            }
            catch { return View(); }
        }
        //***********************************************************************
        //////////////////////////Debut Conroleur Affectation_Hisorique_Article///////////////////
        //************************************************************************
        public ActionResult GetAll_His_Art([DataSourceRequest] DataSourceRequest request)
        {

            var Aff = bo3.Afficher();
            return Json(Aff.ToDataSourceResult(request, record => new
            {
                record.ANNEE,
                record.NUM,
                record.ARTICLE,
                record.DATEAFFECTATION,

                record.ANCIENNEAFFECTATION,
                record.NOUVELLEAFFECTATION,
                record.ETAT,
                record.OBSERVATION,






            }), JsonRequestBehavior.AllowGet);
        }

        //***********************************************************************************
        public JsonResult GetArticlesA()
        {    //initialisation de context de base de donnees
            return Json(ctxt.IMMO_HIST_AFFECTATION_ARTICLE.Select(c => new { ARTICLE = c.ARTICLE.ToString() }).OrderBy(o => o.ARTICLE).ToList(), JsonRequestBehavior.AllowGet);
        }

        //***********************************************************************************
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Add_His_Art([DataSourceRequest] DataSourceRequest request, IMMO_HIST_AFFECTATION_ARTICLE Aff)
        {
            try { 
            if (Aff != null && ModelState.IsValid)
            {
                bo3.Ajouter(Aff);

                ctxt.SaveChanges();
            }
            return Json(new[] { Aff }.ToDataSourceResult(request, ModelState));
            }
            catch { return View(); }
        }
        //**************************************************************************************

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update_His_Art([DataSourceRequest] DataSourceRequest request, IMMO_HIST_AFFECTATION_ARTICLE Aff)
        {
            try { 
            if (Aff != null && ModelState.IsValid)
            {
                bo3.Mettre_A_Jour(Aff);

                ctxt.SaveChanges();
            }
            return Json(ModelState.ToDataSourceResult());
            }
            catch { return View(); }
        }


        //*****************************************************************
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete_His_Art([DataSourceRequest] DataSourceRequest request, IMMO_HIST_AFFECTATION_ARTICLE Aff)
        {
            try { 
            if (Aff != null && ModelState.IsValid)
            {
                bo3.Supprimer(Aff);
                ctxt.SaveChanges();
            }
            return Json(ModelState.ToDataSourceResult());
            }
            catch { return View(); }
        }
        //***********************************************************************
        public ActionResult ChercherAffHisArt([DataSourceRequest] DataSourceRequest request, int? ANNEE, int? NUM ,string ARTICLE)
        {
            IMMODEMOEntities ctxt = new IMMODEMOEntities();
            var C = ctxt.IMMO_HIST_AFFECTATION_ARTICLE.OrderBy(o => o.NUM).AsQueryable();
            string ANNEEs = ANNEE.ToString();
            string NUMs = NUM.ToString();
            if ((ANNEEs != "") && (NUMs != "") &&(ARTICLE !=""))
                C = C.Where(w => w.ANNEE == ANNEE)
                    .Where(w => w.NUM == NUM)
                    .Where(w => w.ARTICLE==ARTICLE);

            if ((ANNEEs != "") && (NUMs == "") && (ARTICLE != ""))
                C = C.Where(w => w.ANNEE == ANNEE)
            .Where(w => w.ARTICLE==ARTICLE);
            if ((ANNEEs == "") && (NUMs != "") && (ARTICLE != ""))
                C = C.Where(w => w.NUM == NUM)
                .Where(w => w.ARTICLE==ARTICLE);
            if ((ANNEEs == "") && (NUMs == "") && (ARTICLE != ""))
                C = C.Where(w => w.ARTICLE == ARTICLE)
            .Where(w => w.ARTICLE==ARTICLE);
            if ((ANNEEs != "") && (NUMs != "") && (ARTICLE == ""))
                C = C.Where(w => w.ANNEE == ANNEE)
                    .Where(w => w.NUM == NUM);
                    

            if ((ANNEEs != "") && (NUMs == "") && (ARTICLE == ""))
                C = C.Where(w => w.ANNEE == ANNEE);
            if ((ANNEEs == "") && (NUMs != "") && (ARTICLE == ""))
                C = C.Where(w => w.NUM == NUM);
           


            var fList = C.Select((IMMO_HIST_AFFECTATION_ARTICLE p) => new Aff_Hist_Art_Lite
            {   ARTICLE=p.ARTICLE,
                DATEAFFECTATION = p.DATEAFFECTATION,
                NUM = p.NUM,
                ANCIENNEAFFECTATION = p.ANCIENNEAFFECTATION,

                NOUVELLEAFFECTATION = p.NOUVELLEAFFECTATION,
                OBSERVATION = p.OBSERVATION,
                ETAT = p.ETAT,

                ANNEE = p.ANNEE,


            });
            var fvt = fList.ToList();

            return Json(fvt.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);

        }

        //*****************************************************************
        //***********************************************************************************
        public JsonResult GetAffect()
        {    //initialisation de context de base de donnees

            IMMODEMOEntities ctxt = new IMMODEMOEntities();
            return Json(ctxt.IMMO_AFFECTATION.Select(c => new { ID = c.CODE, Name = c.LIBELLE}).OrderBy(o => o.ID).ToList(), JsonRequestBehavior.AllowGet);
        }
        //**************************************************************************************
        //*********************************************************************
        // GET: Historique
        public ActionResult Index()
        {
            return View();
        }
    }
}