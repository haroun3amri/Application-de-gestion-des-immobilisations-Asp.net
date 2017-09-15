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
    public class CodeBarController : Controller
    {
       

        //################### Importation des methodes CRUD ##################################
        //*********************************************************************
        private ICodeBarBuisness bo = new CodeBarBuisness();

        //*********************************************************************     
        IMMODEMOEntities ctxt = new IMMODEMOEntities();

        //************************************************************************
        public ActionResult GetAll([DataSourceRequest] DataSourceRequest request)
        {

            var Articles = bo.Afficher();
            return Json(Articles.ToDataSourceResult(request, record => new
            {
                record.CODECLAIR,
                record.CODEBAR1,
                record.LIBELLE,
                record.AFFECTLOCAL,
                record.CODE,





            }));
        }
        //***********************************************************************************
        public JsonResult GetArticlesN()
        {    //initialisation de context de base de donnees
            IMMODEMOEntities ctxt = new IMMODEMOEntities();
            return Json(ctxt.CODEBARs.Select(c => new { ID = c.CODE.ToString(), CODEB = c.CODEBAR1.ToString(), LIBELLE=c.LIBELLE.ToString() }).OrderBy(o => o.ID).ToList(), JsonRequestBehavior.AllowGet);
        }
        //***********************************************************************************

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Addcpt([DataSourceRequest] DataSourceRequest request, CODEBAR c)
        {
            try
            {

                if (c != null && ModelState.IsValid)
                {
                    bo.Ajouter(c);

                    ctxt.SaveChanges();
                }
                return Json(new[] { c }.ToDataSourceResult(request, ModelState));
            } 
            catch { return View(); }
        }
        //**************************************************************************************

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Updatecpt([DataSourceRequest] DataSourceRequest request, CODEBAR c)
        {
            try { 
            if (c != null && ModelState.IsValid)
            {
                bo.Mettre_A_Jour(c);

                ctxt.SaveChanges();
            }
            return Json(ModelState.ToDataSourceResult());
            }
            catch { return View(); }
        }


        //*****************************************************************
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Deletecpt([DataSourceRequest] DataSourceRequest request, CODEBAR c)
        {
            try { 
            if (c != null && ModelState.IsValid)
            {
                bo.Supprimer(c);
                ctxt.SaveChanges();
            }
            return Json(ModelState.ToDataSourceResult());
            }
            catch { return View(); }
        }
        //*********************************************************************************************************
        public ActionResult ChercherCODEB([DataSourceRequest] DataSourceRequest request, string CODEBAR)
        {
            IMMODEMOEntities ctxt = new IMMODEMOEntities();
            var C = ctxt.CODEBARs.OrderBy(o => o.CODE).AsQueryable();

            if (CODEBAR != "")
            {
                C = C.Where(w => w.CODEBAR1 == CODEBAR);
            }
            else
                C = bo.Afficher().AsQueryable();
                



            var fList = C.Select((CODEBAR p) => new CODEBLite
            {
                CODECLAIR = p.CODECLAIR,
                CODEBAR1= p.CODEBAR1,
                LIBELLE = p.LIBELLE,

                AFFECTLOCAL = p.AFFECTLOCAL,
               CODE = p.CODE,
              

            });
            var fvt = fList.ToList();

            return Json(fvt.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);

        }
        //**********************************************************************************
        [HttpPost]
        public ActionResult Pdf_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }
        //*********************************************************************************************************
        // GET: CodeBar
        public ActionResult Index()
        {
            return View();
        }
    }


}