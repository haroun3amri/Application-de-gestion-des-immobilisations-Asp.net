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
    public class LocalController : Controller
    {
        /// <summary>
        /// Debut de Local Controller Associe A la table IMMO_Local
        /// </summary>
        private ILocalBuisness bo = new LocalBuisnessImp();
        private IArticleBuisness tmp = new ArticleBuisnessImp();


        //*********************************************************************     
        IMMODEMOEntities ctxt = new IMMODEMOEntities();

        //************************************************************************
        public ActionResult GetAllLoc([DataSourceRequest] DataSourceRequest request, string CODE)
        {
            List<IMMO_LOCAL> Local = new List<IMMO_LOCAL>();

            if (CODE != "")
            {
                try
                {
                IMMO_ARTICLE ar = tmp.Trouver(CODE);
                
                    string l = ar.LOCALE;
                    Local.Add(bo.Trouver(l));
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine(e);
                }
                
                  
            }
               
            
            else
                Local = bo.Afficher();



            try
            {
                return Json(Local.ToDataSourceResult(request, record => new
                {
                    record.CODE,
                    record.LIBELLE,
                }), JsonRequestBehavior.AllowGet);
            }
            catch (System.NullReferenceException e) { }
            return null;
        }
        //***********************************************************************************
        public JsonResult GetLoca()
        {    //initialisation de context de base de donnees

            IMMODEMOEntities ctxt = new IMMODEMOEntities();
            return Json(ctxt.IMMO_LOCAL.Select(c => new { ID = c.CODE, Name = c.LIBELLE }).OrderBy(o => o.ID).ToList(), JsonRequestBehavior.AllowGet);
        }
        //**************************************

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddLoc([DataSourceRequest] DataSourceRequest request, IMMO_LOCAL l)
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
        public ActionResult Updatecpt([DataSourceRequest] DataSourceRequest request, IMMO_LOCAL l)
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
        public ActionResult DeleteLoc([DataSourceRequest] DataSourceRequest request, IMMO_LOCAL l)
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
        //*********************************************************************************************************
        /// <summary>
        /// Debut de Emplacement Controller Associe A la table IMMO_Emplacement
        /// </summary>
        private IEmplacementBuisness bo1 = new EmplacementBuisness();


        //************************************************************************
        public ActionResult GetAllEmp([DataSourceRequest] DataSourceRequest request,string CODE)
        {
            List<IMMO_EMPLACEMENT> emp = new List<IMMO_EMPLACEMENT>();

            if (CODE != "")
            {
                IMMO_ARTICLE ar = tmp.Trouver(CODE);
                try
                {
                    string l = ar.Emplacement;
                    emp.Add(bo1.Trouver(l));
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine(e);
                }


            }


            else
                emp = bo1.Afficher();



            try
            {
                return Json(emp.ToDataSourceResult(request, record => new
                {
                    record.CODE,
                    record.LIEU,
                    record.ETAGE,
                    record.COULOIR,
                    record.BUREAU,
                    record.LOCAL,

                }), JsonRequestBehavior.AllowGet);
            }
            catch (System.NullReferenceException e) { }
            return null;
        }
        //***********************************************************************************
        public JsonResult GetEmp()
        {    //initialisation de context de base de donnees

            IMMODEMOEntities ctxt = new IMMODEMOEntities();
            return Json(ctxt.IMMO_EMPLACEMENT.Select(c => new { ID = c.CODE.ToString(), Name = c.CODE }).OrderBy(o => o.ID).ToList(), JsonRequestBehavior.AllowGet);
        }
        //********************************************************************************
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddEmp([DataSourceRequest] DataSourceRequest request, IMMO_EMPLACEMENT e)
        {
            try { 
            if (e != null && ModelState.IsValid)
            {
                bo1.Ajouter(e);

                ctxt.SaveChanges();
            }
            return Json(new[] { e }.ToDataSourceResult(request, ModelState));
            }
            catch { return View(); }
        }
        //**************************************************************************************

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdateEmp([DataSourceRequest] DataSourceRequest request, IMMO_EMPLACEMENT e)
        {
            try { 
            if (e != null && ModelState.IsValid)
            {
                bo1.Mettre_A_Jour(e);

                ctxt.SaveChanges();
            }
            return Json(ModelState.ToDataSourceResult());
            }
            catch { return View(); }
        }


        //*****************************************************************
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeleteEmp([DataSourceRequest] DataSourceRequest request, IMMO_EMPLACEMENT e)
        {
            try { 
            if (e != null && ModelState.IsValid)
            {
                bo1.Supprimer(e);
                ctxt.SaveChanges();
            }
            return Json(ModelState.ToDataSourceResult());
            }
            catch { return View(); }
        }
        //*********************************************************************************************************
        // GET: Local
        public ActionResult Index()
        {
            return View();
        }
    }
}