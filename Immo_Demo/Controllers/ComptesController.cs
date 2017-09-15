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
    public class ComptesController : Controller
    {
        //################### Controleur des comptes ##################################
        //*********************************************************************
        private ICompteBuisness bo = new CompteBuisness();
        private IFamilleComptableBuisness bo2=new FamComptBuisness();

        //*********************************************************************     
        IMMODEMOEntities ctxt = new IMMODEMOEntities();

        //************************************************************************
        public ActionResult GetAllcpt([DataSourceRequest] DataSourceRequest request)
        {

            var Articles = bo.Afficher();
            return Json(Articles.ToDataSourceResult(request, record => new
            {
                record.NUM,
                record.INTITULE,
                record.TAUX,
                record.DUREE,
                record.FAMILLECPT,
                record.LINEAIRE,
               




            }));
        }
        //***********************************************************************************

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Addcpt([DataSourceRequest] DataSourceRequest request, IMMO_COMPTE c)
        {
            try { 

            if (c!= null && ModelState.IsValid)
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
        public ActionResult Updatecpt([DataSourceRequest] DataSourceRequest request, IMMO_COMPTE c)
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
        public ActionResult Deletecpt([DataSourceRequest] DataSourceRequest request, IMMO_COMPTE c)
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
        //################### Controleur des Familles Comptables ##################################


        private IFamilleComptableBuisness bo1 = new FamComptBuisness();

        //*********************************************************************     
        public JsonResult Getfamillecomptables()
        {    //initialisation de context de base de donnees
            IMMODEMOEntities ctxt = new IMMODEMOEntities();
            return Json(ctxt.IMMO_FAMILLECOMPTABLE.Select(c => new { ID = c.CODE, Name = c.LIBELLE }).OrderBy(o => o.ID).ToList(), JsonRequestBehavior.AllowGet);
        }
        //**********************************************************************
        public JsonResult GetCpt()
        {    //initialisation de context de base de donnees
            IMMODEMOEntities ctxt = new IMMODEMOEntities();
            return Json(ctxt.IMMO_COMPTE.Select(c => new { ID = c.NUM.ToString(), Name = c.INTITULE }).OrderBy(o => o.ID).ToList(), JsonRequestBehavior.AllowGet);
        }

        //***********************************************************************
        public JsonResult test(string CODE)
        {    //initialisation de context de base de donnees
            IMMODEMOEntities ctxt = new IMMODEMOEntities();
            var tmp = ctxt.IMMO_FAMILLECOMPTABLE.Find(CODE);
            List<IMMO_FAMILLECOMPTABLE> a = new List<IMMO_FAMILLECOMPTABLE>();
            a.Add(tmp);
            return Json(a.Select(c => new { CODE = c.CODE, Libelle = c.LIBELLE, ContrPartie = c.CONTREPARTIESECONDAIRE, Taux = c.TAUX, ConrepartieSeconsaire = c.CONTREPARTIESECONDAIRE, LibelleSeconsaire = c.LIBELLEESECONDAIRE }).OrderBy(o => o.CODE).ToList(), JsonRequestBehavior.AllowGet);

        }

        //************************************************************************
        public ActionResult chercherCpt2([DataSourceRequest] DataSourceRequest request, string NUM)
        {
            var l = new List<IMMO_COMPTE>();  
             l = bo.Afficher();
             if (NUM != "")
             {
                 l.Clear();
                 var t = bo.Trouver(NUM);
                 l.Add(t);

             }
               
          
            return Json(l.ToDataSourceResult(request,record => new
            {
                record.NUM,
                record.INTITULE,
                record.TAUX,
                record.DUREE,
                record.FAMILLECPT,

                record.LINEAIRE,






            }), JsonRequestBehavior.AllowGet);
        }
        //***********************************************************************************
        public ActionResult ChercherFamilleCpt([DataSourceRequest] DataSourceRequest request, string CODE)
        
        {
            var l = new List<IMMO_FAMILLECOMPTABLE>();
            l = bo2.Afficher();
            if (CODE != "")
            {
                l.Clear();
                var t = bo2.Trouver(CODE);
                l.Add(t);

            }


            return Json(l.ToDataSourceResult(request, record => new
            {
                record.CODE,
                record.LIBELLE,
                record.CONTREPARTIE,
                record.TAUX,
                record.CONTREPARTIESECONDAIRE,

                record.LIBELLEESECONDAIRE,






            }), JsonRequestBehavior.AllowGet);
        }
        //********************
        public ActionResult GetAllfcpt([DataSourceRequest] DataSourceRequest request)
        {

            var Articles = bo2.Afficher();
            return Json(Articles.ToDataSourceResult(request, record => new
            {
                record.CODE,
                record.LIBELLE,
                record.CONTREPARTIE,
                record.TAUX,
                record.CONTREPARTIESECONDAIRE,

                record.LIBELLEESECONDAIRE,






            }));
        }
        //***********************************************************************************
        public ActionResult ChercherCpt(string CODE)
        {
            IMMODEMOEntities ctxt = new IMMODEMOEntities();
            var f = ctxt.IMMO_COMPTE.OrderBy(o => o.INTITULE).AsQueryable();

            if (CODE != "")
            {
                f = f.Where(w => w.FAMILLECPT== CODE);
            }


            var fList = f.Select((IMMO_COMPTE p) => new CompteLite
            {
                NUM = p.NUM,
                INTITULE = p.INTITULE,
                TAUX = p.TAUX,

                DUREE = p.DUREE,
                FAMILLECPT = p.FAMILLECPT,
                LINEAIRE = p.LINEAIRE,




            });
            var fvt = fList.ToList();

            return Json(fvt, JsonRequestBehavior.AllowGet);

        }
        //***********************************************************************************
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Addfcpt([DataSourceRequest] DataSourceRequest request, IMMO_FAMILLECOMPTABLE f)
        {
            //try { 

            if (f != null && ModelState.IsValid)
            {
                bo1.Ajouter(f);

                ctxt.SaveChanges();
            }
            return Json(new[] { f }.ToDataSourceResult(request, ModelState));
           // }
           // catch { return View(); }
        }
        //**************************************************************************************

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Updatefcpt([DataSourceRequest] DataSourceRequest request, IMMO_FAMILLECOMPTABLE f)
        {
            try { 
            if (f != null && ModelState.IsValid)
            {
                bo1.Mettre_A_Jour(f);

                ctxt.SaveChanges();
            }
            return Json(ModelState.ToDataSourceResult());
            }
            catch { return View(); }
        }


        //*****************************************************************
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Deletefcpt([DataSourceRequest] DataSourceRequest request, IMMO_FAMILLECOMPTABLE f)
        {
            try { 
            if (f != null && ModelState.IsValid)
            {
                bo1.Supprimer(f);
                ctxt.SaveChanges();
            }
            return Json(ModelState.ToDataSourceResult());
            }
           catch { return View(); }
        }
        //****************************************************************************
        // GET: Comptes
        public ActionResult Index()
        {
            return View();
        }
    }
}