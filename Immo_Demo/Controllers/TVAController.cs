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
namespace Immo_Demo.Controllers
{
    public class TVAController : Controller
    {
        //////////////////////////////////////Debut CRUD Controller pour TVA////////
        private ITVaBuisness bo = new TvaBuisness();
        private ITVaRecBuisness bo1 = new TvaRecBuisness();


        //*********************************************************************     
        IMMODEMOEntities ctxt = new IMMODEMOEntities();

        //************************************************************************
        public ActionResult GetAll([DataSourceRequest] DataSourceRequest request)
        {

            var Aff = bo.Afficher();
            return Json(Aff.ToDataSourceResult(request, record => new
            {
                record.CODE,
                record.VALEUR
                





            }), JsonRequestBehavior.AllowGet);
        }
        //***********************************************************************************

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Add([DataSourceRequest] DataSourceRequest request, IMMO_TVA l)
        {
            try { 
            if (l != null && ModelState.IsValid)
            {
                bo.Ajouter(l);

                ctxt.SaveChanges();
            }
            return Json(new[] { l }.ToDataSourceResult(request, ModelState));
            }
            catch { return View(); }
        }
        //**************************************************************************************

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, IMMO_TVA l)
        {
            try { 
            if (l != null && ModelState.IsValid)
            {
                bo.Mettre_A_Jour(l);

                ctxt.SaveChanges();
            }
            return Json(ModelState.ToDataSourceResult());
            }
            catch { return View(); }
        }


        //*****************************************************************
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete([DataSourceRequest] DataSourceRequest request, IMMO_TVA l)
        {
            try { 
            if (l != null && ModelState.IsValid)
            {
                bo.Supprimer(l);
                ctxt.SaveChanges();
            }
            return Json(ModelState.ToDataSourceResult());
            }
            catch { return View(); }
        }
        //********************************************************
        //////////////////////////////////////Debut CRUD Controller pour TVA Recuperation ////////
       



        //************************************************************************
        public ActionResult GetAll2([DataSourceRequest] DataSourceRequest request)
        {

            var Aff = bo1.Afficher();
            return Json(Aff.ToDataSourceResult(request, record => new
            {
                record.ANNEE,
                record.TAUX






            }), JsonRequestBehavior.AllowGet);
        }
        //***********************************************************************************

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Add2([DataSourceRequest] DataSourceRequest request, IMMO_TVARECUPERATION l)
        {
            try { 
            if (l != null && ModelState.IsValid)
            {
                bo1.Ajouter(l);

                ctxt.SaveChanges();
            }
            return Json(new[] { l }.ToDataSourceResult(request, ModelState));
            }
            catch { return View(); }
        }
        //**************************************************************************************

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update2([DataSourceRequest] DataSourceRequest request, IMMO_TVARECUPERATION l)
        {
            try { 
            if (l != null && ModelState.IsValid)
            {
                bo1.Mettre_A_Jour(l);

                ctxt.SaveChanges();
            }
            return Json(ModelState.ToDataSourceResult());
            }
            catch { return View(); }
        }


        //*****************************************************************
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete2([DataSourceRequest] DataSourceRequest request, IMMO_TVARECUPERATION l)
        {
            try { 
            if (l != null && ModelState.IsValid)
            {
                bo1.Supprimer(l);
                ctxt.SaveChanges();
            }
            return Json(ModelState.ToDataSourceResult());
            }
            catch { return View(); }
        }
        //********************************************************
        // GET: TVA
        public ActionResult Index()
        {
            return View();
        }
    }
}