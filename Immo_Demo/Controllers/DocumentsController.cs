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
    public class DocumentsController : Controller
    {


        //################### Controleur des Fournisseur ##################################
        //*********************************************************************
        private IFournisseurBuisness bo = new FournisseurBuisness();

        //*********************************************************************     
        IMMODEMOEntities ctxt = new IMMODEMOEntities();

        //************************************************************************
        public ActionResult GetAllfour([DataSourceRequest] DataSourceRequest request)
        {

            var Articles = bo.Afficher();
            return Json(Articles.ToDataSourceResult(request, record => new
            {
                record.CODE,
                record.NOM,
                record.RESPONSABLE,
                record.MATFISCAL,
                record.ADRESSE,

                record.TEL,
                record.FAX,
                record.CONTACT




            }));
        }
        //***********************************************************************************

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Addfour([DataSourceRequest] DataSourceRequest request, IMMO_FOURNISSEUR fournisseur)
        {
            try { 
            if (fournisseur != null && ModelState.IsValid)
            {
                bo.Ajouter(fournisseur);

                ctxt.SaveChanges();
            }
            return Json(new[] { fournisseur }.ToDataSourceResult(request, ModelState));
            }
            catch { return View(); }
        }
        //**************************************************************************************

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Updatefour([DataSourceRequest] DataSourceRequest request, IMMO_FOURNISSEUR fournisseur)
        {
            try { 
            if (fournisseur != null && ModelState.IsValid)
            {
                bo.Mettre_A_Jour(fournisseur);

                ctxt.SaveChanges();
            }
            return Json(ModelState.ToDataSourceResult());
            }
            catch { return View(); }
        }


        //*****************************************************************
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Deletefour([DataSourceRequest] DataSourceRequest request, IMMO_FOURNISSEUR fournisseur)
        {
            try { 
            if (fournisseur != null && ModelState.IsValid)
            {
                bo.Supprimer(fournisseur);
                ctxt.SaveChanges();
            }
            return Json(ModelState.ToDataSourceResult());
            }
            catch { return View(); }
        }
        //*********************************************************************************************************
        //################### Controleur des Factures ##################################


        private IFactureBuisness bo1 = new FactureBuisness();

        //*********************************************************************     
        

        //************************************************************************
        public ActionResult GetAllfac([DataSourceRequest] DataSourceRequest request)
        {

            var Articles = bo1.Afficher();
            return Json(Articles.ToDataSourceResult(request, record => new
            {
                record.NUM,
                record.REFERENCE,
                record.FOURNISSEUR,
                record.OBSERVATION,
                record.MONTANTTTC,

                record.MONTANTHT,
                record.CHARGERATTACHEIMMO,
                record.CHARGENONRATTACHEIMMO,
                record.ETAT,
                record.TVARECPERATION,
                record.DATEFACTURE,
                





            }));
        }
        //************************************************************************************
        //*****************************************************************
        public JsonResult GetFacture()
        {    //initialisation de context de base de donnees

            IMMODEMOEntities ctxt = new IMMODEMOEntities();
            return Json(ctxt.IMMO_DETAILFACTURE.Select(c => new { ID = c.NUMFACTURE, Name = c.NUMBL }).OrderBy(o => o.ID).ToList(), JsonRequestBehavior.AllowGet);
        }
        //***********************************************************************************

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Addfac([DataSourceRequest] DataSourceRequest request, IMMO_FACTURE facture)
        {
           // try { 
            if (facture != null && ModelState.IsValid)
            {
                bo1.Ajouter(facture);

                ctxt.SaveChanges();
            }
            return Json(new[] { facture }.ToDataSourceResult(request, ModelState));
//}
            //catch { return View(); }
        }
        //**************************************************************************************

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Updatefac([DataSourceRequest] DataSourceRequest request, IMMO_FACTURE facture)
        {
            try { 
            if (facture != null && ModelState.IsValid)
            {
                bo1.Mettre_A_Jour(facture);

                ctxt.SaveChanges();
            }
            return Json(ModelState.ToDataSourceResult());
            }
            catch { return View(); }
        }


        //*****************************************************************
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Deletefac([DataSourceRequest] DataSourceRequest request, IMMO_FACTURE facture)
        {
            try { 
            if (facture != null && ModelState.IsValid)
            {
                bo1.Supprimer(facture);
                ctxt.SaveChanges();
            }
            return Json(ModelState.ToDataSourceResult());
            }
            catch { return View(); }
        }
        //*********************************************************************************************************
        //################### Controleur des Details Factures ##################################


        private IFactureDetBuisness bod = new FactureDetBuisness();

        //*********************************************************************     


        //************************************************************************
        public ActionResult GetAllfacDet([DataSourceRequest] DataSourceRequest request)
        {

            var Articles = bod.Afficher();
            return Json(Articles.ToDataSourceResult(request, record => new
            {
                record.NUMFACTURE,
                record.ANNEEBL,
                record.NUMBL,
                record.NUMLIGNEBL,
                record.MONTANTHT,

                record.TVA,
                record.MONTANTTTC,
                record.QTE,
                record.VALEURCOMPTABLE,
                record.PRIXUNITAIREHT,





            }));
        }
        //************************************************************************************
        public ActionResult ChercherfacDet(string NUMFACTURE, [DataSourceRequest] DataSourceRequest request)
        {

           
                
                var Articles = bod.Afficher();
                if (NUMFACTURE != "")
                    Articles = bod.TrouverParMere(NUMFACTURE);
                
                
               


                return Json(Articles.ToDataSourceResult(request, record => new
                {
                    record.NUMFACTURE,
                    record.ANNEEBL,
                    record.NUMBL,
                    record.NUMLIGNEBL,
                    record.MONTANTHT,

                    record.TVA,
                    record.MONTANTTTC,
                    record.QTE,
                    record.VALEURCOMPTABLE,
                    record.PRIXUNITAIREHT,





                }), JsonRequestBehavior.AllowGet);
            }
            
        
        //*****************************************************************
        //************************************************************************************
        public ActionResult ChercherfacDet2( [DataSourceRequest] DataSourceRequest request)
        {



            var Articles = bod.Afficher();
           



            return Json(Articles.ToDataSourceResult(request, record => new
            {
                record.NUMFACTURE,
                record.ANNEEBL,
                record.NUMBL,
                record.NUMLIGNEBL,
                record.MONTANTHT,

                record.TVA,
                record.MONTANTTTC,
                record.QTE,
                record.VALEURCOMPTABLE,
                record.PRIXUNITAIREHT,





            }), JsonRequestBehavior.AllowGet);
        }


        //*****************************************************************
        public JsonResult GetFactureDet()
        {    //initialisation de context de base de donnees

            IMMODEMOEntities ctxt = new IMMODEMOEntities();
            return Json(ctxt.IMMO_DETAILFACTURE.Select(c => new { ID = c.NUMFACTURE, Name = c.NUMBL }).OrderBy(o => o.ID).ToList(), JsonRequestBehavior.AllowGet);
        }
        //***********************************************************************************

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddfacDet([DataSourceRequest] DataSourceRequest request, IMMO_DETAILFACTURE facture)
        {
           // try { 

            if (facture != null && ModelState.IsValid)
            {
                bod.Ajouter(facture);

                ctxt.SaveChanges();
            }
            return Json(new[] { facture }.ToDataSourceResult(request, ModelState));
           // }
           // catch { return View(); }
        }
        //**************************************************************************************

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdatefacDet([DataSourceRequest] DataSourceRequest request, IMMO_DETAILFACTURE facture)
        {
            try { 
            if (facture != null && ModelState.IsValid)
            {
                bod.Mettre_A_Jour(facture);

                ctxt.SaveChanges();
            }
            return Json(ModelState.ToDataSourceResult());
            }
            catch { return View(); } 
        }


        //*****************************************************************
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeletefacDet([DataSourceRequest] DataSourceRequest request, IMMO_DETAILFACTURE facture)
        {
            try { 
            if (facture != null && ModelState.IsValid)
            {
                bod.Supprimer(facture);
                ctxt.SaveChanges();
            }
            return Json(ModelState.ToDataSourceResult());
            }
            catch { return View(); }
        }
        //*********************************************************************

        //*********************************************************************************************
        //################### Controleur des BL ##################################
        private IBLBuisness bo2 = new BLBuisness();
        private IBlDetailBuisness bo2d = new BlDetailBuisness();

        //*********************************************************************     


        //************************************************************************
        public ActionResult GetAllbl([DataSourceRequest] DataSourceRequest request)
        {

            var BLs = bo2.Afficher();
            return Json(BLs.ToDataSourceResult(request, record => new
            {
                record.ANNEE,
                record.NUM,
                record.REFCOMMANDE,
                record.DATECOMMANDE,
                record.CENTREACHAT,

                record.FOURNISSEUR,
                record.DATELIVRAISON,
                record.OBSERVATION,
                record.ETAT,
                record.REFERENCE,
                record.EXERCICE





            }));
        }
        //***********************************************************************************

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Addbl([DataSourceRequest] DataSourceRequest request, IMMO_BL bl)
        {
            try { 

            if (bl != null && ModelState.IsValid)
            {
                bo2.Ajouter(bl);

                ctxt.SaveChanges();
            }
            return Json(new[] { bl }.ToDataSourceResult(request, ModelState));
            }
            catch { return View(); }
        }
        //**************************************************************************************

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Updatebl([DataSourceRequest] DataSourceRequest request, IMMO_BL bl)
        {
            try { 
            if (bl != null && ModelState.IsValid)
            {
                bo2.Mettre_A_Jour(bl);

                ctxt.SaveChanges();
            }
            return Json(ModelState.ToDataSourceResult());
            }
            catch { return View(); }
        }


        //*****************************************************************
        public JsonResult GetAnnBl()
        {    //initialisation de context de base de donnees

            IMMODEMOEntities ctxt = new IMMODEMOEntities();
            return Json(ctxt.IMMO_DETAILBL.Select(c => new { ID = c.ANNEEBL, Name = c.NUMBL }).OrderBy(o => o.ID).ToList(), JsonRequestBehavior.AllowGet);
        }
        //**************************************************************************************
        public JsonResult GetNumBl(int? ANNEEBL)
        {    //initialisation de context de base de donnees

            IMMODEMOEntities ctxt = new IMMODEMOEntities();
            var C = ctxt.IMMO_DETAILBL.OrderBy(o => o.NUMBL).AsQueryable();

            if (ANNEEBL != null)
                C = C.Where(w => w.ANNEEBL == ANNEEBL);
            else
                C = bo2d.Afficher().AsQueryable();
            var l = C.ToList();
            return Json(l.Select(c => new { ID = c.NUMBL, Name = c.NUMBL }).OrderBy(o => o.ID).ToList(), JsonRequestBehavior.AllowGet);
        }
        //**************************************************************************************
        public JsonResult GetNumBlLig( int? ANNEEBL,int? NUMBL)
        {    //initialisation de context de base de donnees

            IMMODEMOEntities ctxt = new IMMODEMOEntities();
            var C = ctxt.IMMO_DETAILBL.OrderBy(o => o.NUMBL).AsQueryable();

            if ((ANNEEBL != null)&&(NUMBL != null))
                C = C.Where(w => w.ANNEEBL == ANNEEBL)
                    .Where(w => w.NUMBL == NUMBL);
            else
                C = bo2d.Afficher().AsQueryable();
            var l = C.ToList();
            return Json(l.Select(c => new { ID = c.NUM, Name = c.NUMBL }).OrderBy(o => o.ID).ToList(), JsonRequestBehavior.AllowGet);
        }
        //**************************************************************************************
        //**************************************************************************************
        public JsonResult GetNumBl2()
        {    //initialisation de context de base de donnees

            IMMODEMOEntities ctxt = new IMMODEMOEntities();
            return Json(ctxt.IMMO_DETAILBL.Select(c => new { ID = c.NUMBL, Name = c.NUM }).OrderBy(o => o.ID).ToList(), JsonRequestBehavior.AllowGet);
        }
        //**************************************************************************************
        public JsonResult GetNumBlLig2()
        {       //initialisation de context de base de donnees

            IMMODEMOEntities ctxt = new IMMODEMOEntities();
            return Json(ctxt.IMMO_DETAILBL.Select(c => new { ID = c.NUM, Name = c.NUM }).OrderBy(o => o.ID).ToList(), JsonRequestBehavior.AllowGet);
        }
        //**************************************************************************************
        //******************************************************************
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Deletebl([DataSourceRequest] DataSourceRequest request, IMMO_BL bl)
        {
            try { 
            if (bl != null && ModelState.IsValid)
            {
                bo2.Supprimer(bl);
                ctxt.SaveChanges();
            }
            return Json(ModelState.ToDataSourceResult());
            }
            catch { return View(); }
        }

        //*********************************************************************************************
        //################### Controleur des Detail BL ##################################
        private IBlDetailBuisness bo7 = new BlDetailBuisness();
        public ActionResult ChercherblDet(int? NUMBL, [DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                var Articles = bo7.Afficher();
                int n = (int)NUMBL;
                if (NUMBL == null)
                    Articles = bo7.TrouverParMere(n);
                if(NUMBL != null)
                {
                    Articles = bo7.TrouverParNumBl(n);
                }
                
                return Json(Articles.ToDataSourceResult(request, record => new
                {
                    record.ANNEEBL,
                    record.NUMBL,
                    record.NUM,
                    record.FAMILLE,
                    record.QTE,

                    record.QTEFACTURE,
                    record.PRIXUNITAIRE,
                    record.OBSERVATION,
                    record.AFFECTATION,
                    record.SERVICE,
                    record.LOCALE





                }), JsonRequestBehavior.AllowGet);
            }
            catch { return View(); }
        }
        //****************************************************************
        public ActionResult ChercherblDet2( [DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                var Articles = bo7.Afficher();
                
                return Json(Articles.ToDataSourceResult(request, record => new
                {
                    record.ANNEEBL,
                    record.NUMBL,
                    record.NUM,
                    record.FAMILLE,
                    record.QTE,

                    record.QTEFACTURE,
                    record.PRIXUNITAIRE,
                    record.OBSERVATION,
                    record.AFFECTATION,
                    record.SERVICE,
                    record.LOCALE





                }), JsonRequestBehavior.AllowGet);
            }
            catch { return View(); }
        }
        //*****************************************************************
        public JsonResult GetblDet()
        {    //initialisation de context de base de donnees

            IMMODEMOEntities ctxt = new IMMODEMOEntities();
            return Json(ctxt.IMMO_DETAILBL.Select(c => new { ID = c.NUM, Name = c.NUMBL }).OrderBy(o => o.ID).ToList(), JsonRequestBehavior.AllowGet);
        }
        //***********************************************************************************

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddblDet([DataSourceRequest] DataSourceRequest request, IMMO_DETAILBL bl)
        {
            //try { 

            if (bl != null && ModelState.IsValid)
            {
                bo7.Ajouter(bl);

                ctxt.SaveChanges();
            }
            return Json(new[] { bl }.ToDataSourceResult(request, ModelState));
          //  }
           // catch { return View(); }
        }
        //**************************************************************************************

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdateblDet([DataSourceRequest] DataSourceRequest request, IMMO_DETAILBL bl)
        {
            try { 
            if (bl != null && ModelState.IsValid)
            {
                bo7.Mettre_A_Jour(bl);

                ctxt.SaveChanges();
            }
            return Json(ModelState.ToDataSourceResult());
            }
            catch { return View(); }
        }


        //*****************************************************************
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeleteblDet([DataSourceRequest] DataSourceRequest request, IMMO_DETAILBL bl)
        {
            try { 
            if (bl != null && ModelState.IsValid)
            {
                bo7.Supprimer(bl);
                ctxt.SaveChanges();
            }
            return Json(ModelState.ToDataSourceResult());
            }
            catch { return View(); }
        }
        //*********************************************************************



        // GET: Documents
        public ActionResult Index()
        {
            return View();
        }
    }
}