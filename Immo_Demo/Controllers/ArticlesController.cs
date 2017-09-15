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
    public class ArticlesController : Controller
    {
        IMMODEMOEntities ctxt = new IMMODEMOEntities();

        private IFamArtBuisness bo1 = new FamArticlebuisness();
        private IFamMerebuisness bo2 = new FamMereArticleBuisness();

        //***************************************Controlleur CRUD Famille***************
        public ActionResult GetAllF(string FAMILLEM, [DataSourceRequest] DataSourceRequest request)
        {
            var Articles = bo1.Afficher();
            if (FAMILLEM != "")

                Articles = bo1.TrouverParMere(FAMILLEM);
           
            
            return Json(Articles.ToDataSourceResult(request, record => new
            {
                record.CODE,
                record.LIBELLE,
                record.COMPTE,
                record.FAMILLEM,
              
            }), JsonRequestBehavior.AllowGet);
        }
        //***********************************************************************************

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddF([DataSourceRequest] DataSourceRequest request,IMMO_FAMILLE f)
        {
            try { 
            if (f != null && ModelState.IsValid)
            {
                bo1.Ajouter(f);

                ctxt.SaveChanges();
            }
            return Json(new[] { f }.ToDataSourceResult(request, ModelState));
            }
            catch { return View(); }
        }
        //**************************************************************************************

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdateF([DataSourceRequest] DataSourceRequest request, IMMO_FAMILLE f)
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
        public ActionResult DeleteF([DataSourceRequest] DataSourceRequest request, IMMO_FAMILLE f)
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
        //*********************************************************
        //***************************************Controlleur CRUD Famille Mere***************
        public ActionResult GetAllFm([DataSourceRequest] DataSourceRequest request)
        {

            var Articles = bo2.Afficher();
            return Json(Articles.ToDataSourceResult(request, record => new
            {
                record.CODE,
                record.LIBELLE,
              

            }), JsonRequestBehavior.AllowGet);
        }
        //***********************************************************************************

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddFm([DataSourceRequest] DataSourceRequest request, IMMO_FAMILLEM f)
        {
            try
            {
                if (f != null && ModelState.IsValid)
                {
                    bo2.Ajouter(f);

                    ctxt.SaveChanges();
                }
                return Json(new[] { f }.ToDataSourceResult(request, ModelState));
            }
            catch { return View(); }
        }
        //**************************************************************************************

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdateFm([DataSourceRequest] DataSourceRequest request, IMMO_FAMILLEM f)
        {
            try { 
            if (f != null && ModelState.IsValid)
            {
                bo2.Mettre_A_Jour(f);

                ctxt.SaveChanges();
            }
            return Json(ModelState.ToDataSourceResult());
            }
            catch { return View(); }
        }


        //*****************************************************************
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeleteFm([DataSourceRequest] DataSourceRequest request, IMMO_FAMILLEM f)
        {
            try { 
            if (f != null && ModelState.IsValid)
            {
                bo2.Supprimer(f);
                ctxt.SaveChanges();
            }
            return Json(ModelState.ToDataSourceResult());
            }
            catch { return View(); }
        }
        //*********************************************************
        public JsonResult GetFamilleMere()
        {    //initialisation de context de base de donnees
            IMMODEMOEntities ctxt = new IMMODEMOEntities();
            return Json(ctxt.IMMO_FAMILLEM.Select(c => new { ID = c.CODE, Name= c.LIBELLE }).OrderBy(o => o.ID).ToList(), JsonRequestBehavior.AllowGet);
        }
        //********************************************************************
        public JsonResult GetFamille()
        {    //initialisation de context de base de donnees
            IMMODEMOEntities ctxt = new IMMODEMOEntities();
            return Json(ctxt.IMMO_FAMILLE.Select(c => new { ID = c.CODE, Name = c.LIBELLE }).OrderBy(o => o.ID).ToList(), JsonRequestBehavior.AllowGet);
        }
        //********************************************************************
        public JsonResult GetArticlesN()
        {    //initialisation de context de base de donnees
            IMMODEMOEntities ctxt = new IMMODEMOEntities();
            return Json(ctxt.IMMO_ARTICLE.Select(c => new { ID = c.CODE.ToString(), NAME = c.DESIGNATION.ToString(),Amorti=c.AMORTI.ToString() }).OrderBy(o => o.ID).ToList(), JsonRequestBehavior.AllowGet);
        }
        //********************************************************************
        public JsonResult GetSousFamille(string CODE)
        {
            IMMODEMOEntities ctxt = new IMMODEMOEntities();
            var sousFamille = ctxt.IMMO_FAMILLE.OrderBy(o => o.CODE).AsQueryable();
           
              
               sousFamille = sousFamille.Where(w => w.FAMILLEM == CODE);

            
            return Json(sousFamille.Select(c => new { ID = c.CODE, Name = c.LIBELLE }).OrderBy(o => o.ID).ToList(),
                JsonRequestBehavior.AllowGet);
        }
        //**************************************
       //***************************************************************************************
        public JsonResult GetArticles([DataSourceRequest] DataSourceRequest request, string CODEM, string CODEF,string CODE)
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

            if(CODE !="")
            {
                Articles = Articles.Where(w => w.CODE == CODE);
            }
            
            

            var ArticlesList = Articles.Select(p => new ArticleLite
            {
                CODE = p.CODE,
                DESIGNATION = p.DESIGNATION,
                DATEAQUISITION = p.DATEAQUISITION,
                FAMILLE=p.FAMILLE,
                VALEURCOMPTABLE=p.VALEURCOMPTABLE,
                AFFECTATION = p.IMMO_AFFECTATION.LIBELLE,
                LOCALE = p.LOCALE,
                TAUXAMORTISSEMENT=p.TAUXAMORTISSEMENT,
                AMORTI=p.AMORTI,
                DATEEXPLOITATION=p.DATEEXPLOITATION
               


            });
            var fvt = ArticlesList.ToList();
            
            return Json(fvt.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            
        }
        //***********************************************************************************
        public JsonResult GetArticles2( string CODEM, string CODEF)
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



            var ArticlesList = Articles.Select( (IMMO_ARTICLE p) => new ArticleLite
            {
                CODE = p.CODE,
                DESIGNATION = p.DESIGNATION,
                DATEAQUISITION = p.DATEAQUISITION,
                ANNEEBL=p.ANNEEBL,
                DUREE=p.DUREE,
               
                FAMILLE = p.FAMILLE,
                VALEURCOMPTABLE = p.VALEURCOMPTABLE,
                AFFECTATION = p.IMMO_AFFECTATION.LIBELLE,
                LOCALE = p.LOCALE,
                 AMORTI=p.AMORTI,
                DATEEXPLOITATION=p.DATEEXPLOITATION



            });
            var fvt = ArticlesList.ToList();

            return Json(fvt, JsonRequestBehavior.AllowGet);

        }
        //***********************************************************************
        //***********************************************************************************
        public JsonResult GetArticles6(string CODE)
        {
            IMMODEMOEntities ctxt = new IMMODEMOEntities();
            var Articles = ctxt.IMMO_ARTICLE.OrderBy(o => o.DESIGNATION).AsQueryable();

            if (CODE != "")
            {
                Articles = Articles.Where(w => w.CODE == CODE);
            }



           



            var ArticlesList = Articles.Select((IMMO_ARTICLE p) => new ArticleLite
            {
                CODE = p.CODE,
                DESIGNATION = p.DESIGNATION,
                DATEAQUISITION = p.DATEAQUISITION,
                ANNEEBL = p.ANNEEBL,
                DUREE = p.DUREE,
                TAUXAMORTISSEMENT=p.TAUXAMORTISSEMENT,

                FAMILLE = p.FAMILLE,
                VALEURCOMPTABLE = p.VALEURCOMPTABLE,
                AFFECTATION = p.IMMO_AFFECTATION.LIBELLE,
                LOCALE = p.LOCALE,
                AMORTI = p.AMORTI,
                DATEEXPLOITATION = p.DATEEXPLOITATION



            });
            var fvt = ArticlesList.ToList();

            return Json(fvt, JsonRequestBehavior.AllowGet);

        }
        //***********************************************************************
        //***********************************************************************************
        public JsonResult GetArticles2S(string CODEM, string CODEF,string CODE)
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

            if (CODE != "")
            {
                Articles = Articles.Where(w => w.CODE == CODE);

            }


            var ArticlesList = Articles.Select((IMMO_ARTICLE p) => new ArticleLite
            {
                CODE = p.CODE,
                DESIGNATION = p.DESIGNATION,
                DATEAQUISITION = p.DATEAQUISITION,
                ANNEEBL = p.ANNEEBL,
                DUREE = p.DUREE,
                VALEURSESSION=p.VALEURSESSION,

                FAMILLE = p.FAMILLE,
                VALEURCOMPTABLE = p.VALEURCOMPTABLE,
                AFFECTATION = p.IMMO_AFFECTATION.LIBELLE,
                LOCALE = p.LOCALE,
                TAUXAMORTISSEMENT=p.TAUXAMORTISSEMENT,
                AMORTI = p.AMORTI,
                DATEEXPLOITATION = p.DATEEXPLOITATION



            });
            var fvt = ArticlesList.ToList();

            return Json(fvt, JsonRequestBehavior.AllowGet);

        }
        //***********************************************************************
        public ActionResult GetArticle3([DataSourceRequest] DataSourceRequest request, string CODEM, string CODEF)
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

            



            var ArticlesList = Articles.Select(a => new ArticleLite
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
                AFFECTATION=a.AFFECTATION,
                
                REFERENCE = a.REFERENCE,
                CARACTERISTIQUE = a.CARACTERISTIQUE,
                ANNEE = a.ANNEE,
                SERVICE = a.SERVICE,
                LOCALE = a.LOCALE,
                Emplacement = a.Emplacement,


            });
            var fvt = ArticlesList.ToList();

            return Json(fvt.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        //***********************************************************************
        public JsonResult GetArticlesN2([DataSourceRequest] DataSourceRequest request, string CODEM, string CODEF)
        {    //initialisation de context de base de donnees
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





            var ArticlesList = Articles.Select(p => new ArticleLite
            {
                CODE = p.CODE,
                DESIGNATION = p.DESIGNATION,
                DATEAQUISITION = p.DATEAQUISITION,
                FAMILLE = p.FAMILLE,
                VALEURCOMPTABLE = p.VALEURCOMPTABLE,
                AFFECTATION = p.IMMO_AFFECTATION.LIBELLE,
                LOCALE = p.LOCALE,
                TAUXAMORTISSEMENT=p.TAUXAMORTISSEMENT,
                 AMORTI=p.AMORTI,
                DATEEXPLOITATION=p.DATEEXPLOITATION



            });
            var fvt = ArticlesList;
            return Json(fvt.Select(c => new { ID = c.CODE.ToString(), NAME = c.DESIGNATION.ToString() }).OrderBy(o => o.ID).ToList(), JsonRequestBehavior.AllowGet);
        }
        //********************************************************************
        //************************************************************************
        [HttpPost]
        public ActionResult Pdf_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }
        //*************************************************************************
        //**************************Debut Controleur des Exercices*********************
        private IExerciceBuisness boe = new ExerciceBuisness();

        public ActionResult GetAlle([DataSourceRequest] DataSourceRequest request)
        {
            var Articles = boe.Afficher();
            



            return Json(Articles.ToDataSourceResult(request, record => new
            {
                record.ANNEE,
                record.DATEFERMETURE,
                record.DATEOUVERTURE,
                record.ETAT,

            }), JsonRequestBehavior.AllowGet);
        }
        //***********************************************************************************
        public JsonResult GetExercice()
        {
            IMMODEMOEntities ctxt = new IMMODEMOEntities();
            return Json(ctxt.IMMO_EXERCICE.Select(c => new { ID = c.ANNEE, Name = c.ANNEE.ToString() }).OrderBy(o => o.ID).ToList(), JsonRequestBehavior.AllowGet);
        }
        //***************************************************************************************

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Adde([DataSourceRequest] DataSourceRequest request, IMMO_EXERCICE f)
        {
            try { 
            if (f != null && ModelState.IsValid)
            {
                boe.Ajouter(f);

                ctxt.SaveChanges();
            }
            return Json(new[] { f }.ToDataSourceResult(request, ModelState));
            }
            catch { return View(); }
        }
        //**************************************************************************************

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Updatee([DataSourceRequest] DataSourceRequest request, IMMO_EXERCICE f)
        {
            try { 
            if (f != null && ModelState.IsValid)
            {
                boe.Mettre_A_Jour(f);

                ctxt.SaveChanges();
            }
            return Json(ModelState.ToDataSourceResult());
            }
            catch { return View(); }
        }


        //*****************************************************************
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Deletee([DataSourceRequest] DataSourceRequest request, IMMO_EXERCICE f)
        {
            try { 
            if (f != null && ModelState.IsValid)
            {
                boe.Supprimer(f);
                ctxt.SaveChanges();
            }
            return Json(ModelState.ToDataSourceResult());
            }
            catch { return View(); }
        }
        //*********************************************************
        //**************************Debut Controleur des Services*********************
        private IServiceBuisness bos = new ServiceBuisness();

        public ActionResult GetAlls([DataSourceRequest] DataSourceRequest request)
        {
            var Articles = bos.Afficher();




            return Json(Articles.ToDataSourceResult(request, record => new
            {
                record.CODE,
                record.LIBELLE,
               

            }), JsonRequestBehavior.AllowGet);
        }

        //***********************************************************************************
        public JsonResult GetService()
        {    

            IMMODEMOEntities ctxt = new IMMODEMOEntities();
            return Json(ctxt.IMMO_SERVICE.Select(c => new { ID = c.CODE.ToString(), Name = c.LIBELLE}).OrderBy(o => o.ID).ToList(), JsonRequestBehavior.AllowGet);
        }
        //***************************************************************************************
        //***********************************************************************************

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Adds([DataSourceRequest] DataSourceRequest request, IMMO_SERVICE f)
        {
            try { 
            if (f != null && ModelState.IsValid)
            {
                bos.Ajouter(f);

                ctxt.SaveChanges();
            }
            return Json(new[] { f }.ToDataSourceResult(request, ModelState));
            }
            catch { return View(); }
        }
        //**************************************************************************************

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Updates([DataSourceRequest] DataSourceRequest request, IMMO_SERVICE f)
        {
            try { 
            if (f != null && ModelState.IsValid)
            {
                bos.Mettre_A_Jour(f);

                ctxt.SaveChanges();
            }
            return Json(ModelState.ToDataSourceResult());
            }
            catch { return View(); }
        }


        //*****************************************************************
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Deletes([DataSourceRequest] DataSourceRequest request, IMMO_SERVICE f)
        {
            try { 
            if (f != null && ModelState.IsValid)
            {
                bos.Supprimer(f);
                ctxt.SaveChanges();
            }
            return Json(ModelState.ToDataSourceResult());
            }
            catch { return View(); }
        }
        //*******************************************************



        // GET: Articles
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Famille()
        {
            return View();
        }
        public ActionResult Affectation()
        {
            return View();
        }
        public ActionResult Exercices()
        {
            return View();
        }
        public ActionResult Services()
        {
            return View();
        }
    }
}