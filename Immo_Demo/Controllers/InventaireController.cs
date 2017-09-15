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
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.IO;
using Excel;
using System.Xml;
using System.Configuration;
using System.Data.SqlClient;
using System.Net;

using System.Web.UI;
using System.Web.UI.WebControls;


using System.Web.Script.Serialization;


namespace Immo_Demo.Controllers
{
    public class InventaireController : Controller
    {     //*****************************DEclaration des Couche Buisness A employee****************************************
        private IInvBuisness bo1 = new InvBuisness();
        private IInv_ArticleBuisness bo2 = new Inv_ArticleBuisness();
        private IInvLivreBuisness bo3 = new InvLivreBuisness();
        private IInvComptaBuisness bo4 = new InvComptaBuisness();
        private IInvPhBuisnessRep bo5 = new InvPhBuisness();

        //******************************************************
        //*********************************************************************     
        IMMODEMOEntities ctxt = new IMMODEMOEntities();
        //////////////////////////Debut Conroleur Inventaire///////////////////
        //************************************************************************
        public ActionResult GetAllInv([DataSourceRequest] DataSourceRequest request)
        {

            var Aff = bo1.Afficher();
            return Json(Aff.ToDataSourceResult(request, record => new
            {
                record.ANNEE,
                record.NUM,
                record.DESCRIPTION,
                record.DATECREATION,
                record.ETAT,
                record.DATEVALIDATION,
                record.DATECLOTURE,
                record.AUTOMATIQUE,
                record.MUTATION,




            }), JsonRequestBehavior.AllowGet);
        }

        //***********************************************************************************


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddInv([DataSourceRequest] DataSourceRequest request,IMMO_INVENTAIRE inv)
        {
            try { 
            if (inv != null && ModelState.IsValid)
            {
                bo1.Ajouter(inv);

                ctxt.SaveChanges();
            }
            return Json(new[] { inv }.ToDataSourceResult(request, ModelState));
            }
            catch { return View(); }
        }
        //**************************************************************************************

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdateInv([DataSourceRequest] DataSourceRequest request, IMMO_INVENTAIRE inv)
        {
            try { 
            if (inv != null && ModelState.IsValid)
            {
                bo1.Mettre_A_Jour(inv);

                ctxt.SaveChanges();
            }
            return Json(ModelState.ToDataSourceResult());
            }
            catch { return View(); }
        }


        //*****************************************************************
        public ActionResult RemplirCompteur([DataSourceRequest] DataSourceRequest request, int? ANNEE, int? NUM)
        {
            IMMODEMOEntities ctxt = new IMMODEMOEntities();
            var C = ctxt.IMMO_INVENTAIRE.OrderBy(o => o.NUM).AsQueryable();
            string ANNEEs = ANNEE.ToString();
            string NUMs = NUM.ToString();
            if ((ANNEEs != "") && (NUMs != ""))
            
                C = C.Where(w => w.ANNEE == ANNEE)
                     .Where(w => w.NUM == NUM);
            if ((ANNEEs != "") && (NUMs == ""))
                C = C.Where(w => w.ANNEE == ANNEE);
            if ((ANNEEs == "") && (NUMs != ""))
                C = C.Where(w => w.NUM == NUM);

                var t = C.ToList();
            IMMO_INVENTAIRE i = new IMMO_INVENTAIRE();
            if(t.Count !=0)
                 i = t[0];
            
            
                
                ComptageManuelle cpt = new ComptageManuelle();
                cpt.NbTotal = bo1.NbTotal(i);
                cpt.NbExiste = bo1.NbExiste(i);
                cpt.NbNonExiste = bo1.NbNonExiste(i);
                cpt.NbDelace = bo1.NbDelace(i);
                cpt.NbNonDelace = bo1.NbNonDelace(i);
                List<ComptageManuelle> li = new List<ComptageManuelle>();
                li.Add(cpt);
                return Json(li.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            

        }
        //*****************************************************************
        public ActionResult RemplirCompteur2(int? ANNEE, int? NUM)
        {
            IMMODEMOEntities ctxt = new IMMODEMOEntities();
            var C = ctxt.IMMO_INVENTAIRE.OrderBy(o => o.NUM).AsQueryable();
            string ANNEEs = ANNEE.ToString();
            string NUMs = NUM.ToString();
            if ((ANNEEs != "") && (NUMs != ""))

                C = C.Where(w => w.ANNEE == ANNEE)
                     .Where(w => w.NUM == NUM);
            if ((ANNEEs != "") && (NUMs == ""))
                C = C.Where(w => w.ANNEE == ANNEE);
            if ((ANNEEs == "") && (NUMs != ""))
                C = C.Where(w => w.NUM == NUM);

            var t = C.ToList();
            IMMO_INVENTAIRE i = new IMMO_INVENTAIRE();
            if (t.Count != 0)
                i = t[0];



            ComptageManuelle cpt = new ComptageManuelle();
            cpt.NbTotal = bo1.NbTotal(i);
            cpt.NbExiste = bo1.NbExiste(i);
            cpt.NbNonExiste = bo1.NbNonExiste(i);
            cpt.NbDelace = bo1.NbDelace(i);
            cpt.NbNonDelace = bo1.NbNonDelace(i);
            List<ComptageManuelle> li = new List<ComptageManuelle>();
            li.Add(cpt);
            return Json(li, JsonRequestBehavior.AllowGet);


        }
        //****************************************************************
        //*****************************************************************
        public ActionResult RemplirCompteur22(int? ANNEE, int? NUM)
        {
            IMMODEMOEntities ctxt = new IMMODEMOEntities();
            var C = ctxt.IMMO_INVENTAIRE.OrderBy(o => o.NUM).AsQueryable();
            string ANNEEs = ANNEE.ToString();
            string NUMs = NUM.ToString();
            if ((ANNEEs != "") && (NUMs != ""))

                C = C.Where(w => w.ANNEE == ANNEE)
                     .Where(w => w.NUM == NUM);
            if ((ANNEEs != "") && (NUMs == ""))
                C = C.Where(w => w.ANNEE == ANNEE);
            if ((ANNEEs == "") && (NUMs != ""))
                C = C.Where(w => w.NUM == NUM);

            var t = C.ToList();
            IMMO_INVENTAIRE i = new IMMO_INVENTAIRE();
            if (t.Count != 0)
                i = t[0];

            





            PieModel cpt = new PieModel();
           
            
           cpt.valtotal = bo1.NbTotal(i);

        cpt.existance = bo1.PtauxExistance(i);
            cpt.nonexistance = bo1.PtauxNonExistance(i);
            cpt.mutation = bo1.PtauxMutation(i);
            cpt.nonMutation = bo1.PtauxNonMutation(i);
           
            List<PieModel> li = new List<PieModel>();
            li.Add(cpt);
            return Json(li, JsonRequestBehavior.AllowGet);


        }
        //****************************************************************
        public ActionResult RemplirCompteur3()
        {
            IMMODEMOEntities ctxt = new IMMODEMOEntities();
            var C = ctxt.INV_PH.OrderBy(o => o.CODE).AsQueryable();
           

            var t = C.ToList();




            ComtageAutomatique cpt = new ComtageAutomatique();
            cpt.Total = bo1.NbTotal2();
            cpt.NbTotalArticle = bo1.NbArtTotal();
            cpt.NbTotalBureau = bo1.NBArtBureau();

            List<ComtageAutomatique> li = new List<ComtageAutomatique>();
            li.Add(cpt);
            return Json(li, JsonRequestBehavior.AllowGet);


        }
        //****************************************************************
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeleteInv([DataSourceRequest] DataSourceRequest request, IMMO_INVENTAIRE inv)
        {
            try { 
            if (inv != null && ModelState.IsValid)
            {
                bo1.Supprimer(inv);
                ctxt.SaveChanges();
            }
            return Json(ModelState.ToDataSourceResult());
            }
            catch { return View(); }
        }
        //***********************************************************************
        //////////////////////////Debut Conroleur Affectation_Hisorique///////////////////
        //************************************************************************
        public ActionResult GetAllInv_Art([DataSourceRequest] DataSourceRequest request)
        {

            var Aff = bo2.Afficher();
            return Json(Aff.ToDataSourceResult(request, record => new
            {
                record.ANNEE,
                record.NUM,
                record.ARTICLE,
                record.AFFECTATION,
                record.EXISTE,
                record.OPERATEUR,
                record.EMPLACEMENT,
                record.OBSERVATION,
                record.AFFECTATIONTH,






            }), JsonRequestBehavior.AllowGet);
        }
        //***********************************************************************************
        public JsonResult GetArticlesN()
        {    //initialisation de context de base de donnees
            return Json(ctxt.IMMO_INVENTAIRE.Select(c => new { ANNEE = c.ANNEE.ToString() }).OrderBy(o => o.ANNEE).ToList(), JsonRequestBehavior.AllowGet);
        }
        //***********************************************************************************
        public JsonResult GetArticlesH()
        {    //initialisation de context de base de donnees
            return Json(ctxt.IMMO_INVENTAIRE.Select(c => new { NUM = c.NUM.ToString() }).OrderBy(o => o.NUM).ToList(), JsonRequestBehavior.AllowGet);
        }

        //***********************************************************************************
        public JsonResult GetArticlesA()
        {    //initialisation de context de base de donnees
            return Json(ctxt.IMMO_INVETAIRE_ARTICLE.Select(c => new { ARTICLE = c.ARTICLE.ToString() }).OrderBy(o => o.ARTICLE).ToList(), JsonRequestBehavior.AllowGet);
        }
        //**************************************************************************************

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddInv_Art([DataSourceRequest] DataSourceRequest request, IMMO_INVETAIRE_ARTICLE inv)
        {
            try { 
            if (inv != null && ModelState.IsValid)
            {
                bo2.Ajouter(inv);

                ctxt.SaveChanges();
            }
            return Json(new[] { inv }.ToDataSourceResult(request, ModelState));
            }
            catch { return View(); }
        }
        //**************************************************************************************

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdateInv_Art([DataSourceRequest] DataSourceRequest request, IMMO_INVETAIRE_ARTICLE inv)
        {
            try { 
            if (inv != null && ModelState.IsValid)
            {
                bo2.Mettre_A_Jour(inv);

                ctxt.SaveChanges();
            }
            return Json(ModelState.ToDataSourceResult());
            }
            catch { return View(); }
        }
        //*****************************************************************
        public ActionResult ChercherInv([DataSourceRequest] DataSourceRequest request, int? ANNEE, int? NUM)
        {
            IMMODEMOEntities ctxt = new IMMODEMOEntities();
            var C = ctxt.IMMO_INVENTAIRE.OrderBy(o => o.NUM).AsQueryable();
            string ANNEEs = ANNEE.ToString();
            string NUMs = NUM.ToString();
            if ((ANNEEs != "") && (NUMs != ""))
                C = C.Where(w => w.ANNEE == ANNEE)
                    .Where(w => w.NUM == NUM);
            if ((ANNEEs != "") && (NUMs == ""))
                C = C.Where(w => w.ANNEE == ANNEE);
            if ((ANNEEs == "") && (NUMs != ""))
                C = C.Where(w => w.NUM == NUM);



            var fList = C.Select((IMMO_INVENTAIRE p) => new InvLite
            {    DESCRIPTION=p.DESCRIPTION,
                 DATECREATION=p.DATECREATION,
                DATEVALIDATION=p.DATEVALIDATION,
                DATECLOTURE=p.DATECLOTURE,
                AUTOMATIQUE=p.AUTOMATIQUE,
                MUTATION=p.MUTATION,
                NUM = p.NUM,

                ETAT = p.ETAT,

                ANNEE = p.ANNEE,


            });
            var fvt = fList.ToList();

            return Json(fvt.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);

        }

        //*****************************************************************
        public ActionResult ChercherInvArt([DataSourceRequest] DataSourceRequest request, int? ANNEE, int? NUM, string ARTICLE)
        {
            IMMODEMOEntities ctxt = new IMMODEMOEntities();
            var C = ctxt.IMMO_INVETAIRE_ARTICLE.OrderBy(o => o.NUM).AsQueryable();
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



            var fList = C.Select((IMMO_INVETAIRE_ARTICLE p) => new InvArtLite 
            {
                ARTICLE = p.ARTICLE,
                AFFECTATION=p.AFFECTATION,
                NUM = p.NUM,
                EXISTE=p.EXISTE,
                OPERATEUR=p.OPERATEUR,
                EMPLACEMENT=p.EMPLACEMENT,
                AFFECTATIONTH=p.AFFECTATIONTH,
                
                OBSERVATION = p.OBSERVATION,

                ANNEE = p.ANNEE,
                DESIGNATION=p.IMMO_ARTICLE.DESIGNATION,
                VALEURCOMPTABLE=p.IMMO_ARTICLE.VALEURCOMPTABLE,
                RESPONSABLEACHAT=p.IMMO_AFFECTATION.RESPONSABLEACHAT,
                LIBELLE=p.IMMO_AFFECTATION.LIBELLE,



            });
            var fvt = fList.ToList();

            return Json(fvt.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);

        }

        //*****************************************************************
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeleteInv_Art([DataSourceRequest] DataSourceRequest request, IMMO_INVETAIRE_ARTICLE inv)
        {
            try { 
            if (inv != null && ModelState.IsValid)
            {
                bo2.Supprimer(inv);
                ctxt.SaveChanges();
            }
            return Json(ModelState.ToDataSourceResult());
            }
            catch { return View(); }
        }
        //******************************************************************************************
        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Importexcel(int lineDebut,int lineFin)
        {
            /*
            if (Request.Files.Count != 0)
            {
                if (Request.Files["FileUpload1"].ContentLength > 0)
                {
                    string extension = System.IO.Path.GetExtension(Request.Files["FileUpload1"].FileName);
                    string path1 = string.Format("{0}/{1}", Server.MapPath("~/Content/UploadedFolder"), Request.Files["FileUpload1"].FileName);
                    if (System.IO.File.Exists(path1))
                        System.IO.File.Delete(path1);

                    Request.Files["FileUpload1"].SaveAs(path1);
                    string sqlConnectionString = @"Data Source=(localdb)\Projects;Initial Catalog=IMMODEMO;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";


                    string WordConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path1 + ";Extended Properties=Word 12.0;Persist Security Info=False";
                    OleDbConnection WordConnection = new OleDbConnection(WordConnectionString);
                    OleDbCommand cmd = new OleDbCommand("Select [CODE],[BUREAU] from [Sheet1$]", WordConnection);

                    WordConnection.Open();
                    OleDbDataReader dReader;
                    dReader = cmd.ExecuteReader();

                    SqlBulkCopy sqlBulk = new SqlBulkCopy(sqlConnectionString);
                    sqlBulk.DestinationTableName = "INV_PH";
                    sqlBulk.WriteToServer(dReader);
                    WordConnection.Close();
                }
            }
            */
            if (Request.Files.Count != 0)
            {
                if (Request.Files["FileUpload1"].ContentLength > 0)
                {
                    DataTable dt = new DataTable();
                    string line = null;
                    int i = lineDebut;
                    string extension = System.IO.Path.GetExtension(Request.Files["FileUpload1"].FileName);
                    string path1 = string.Format("{0}/{1}", Server.MapPath("~/Content/UploadedFolder"), Request.Files["FileUpload1"].FileName);
                    if (System.IO.File.Exists(path1))
                        System.IO.File.Delete(path1);

                    Request.Files["FileUpload1"].SaveAs(path1);
                    using (StreamReader sr = System.IO.File.OpenText(path1))
                    {  //Initililser le reader dans a la position de debut de lecture
                        for (int j = 0; j < lineDebut; ++j)
                        {
                            line = sr.ReadLine();
                        }
                        //     Fin positionnement au debut
                        while ((line = sr.ReadLine()) != null)
                        {    
                            string[] data = line.Split(',');
                            if (data.Length > 0)
                            {
                                if (i < lineFin)
                                {
                                    foreach (var item in data)
                                    {
                                        dt.Columns.Add(new DataColumn());
                                    }
                                    i++;
                                }
                                else
                                    break;
                                DataRow row = dt.NewRow();
                                row.ItemArray = data;
                                dt.Rows.Add(row);
                            }
                        }
                        string cn = @"Data Source=(localdb)\Projects;Initial Catalog=IMMODEMO;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";
                        
                           // cn.Open();
                            using (SqlBulkCopy copy = new SqlBulkCopy(cn))
                            {
                                copy.ColumnMappings.Add(0, 0);
                                copy.ColumnMappings.Add(1, 1);

                                copy.DestinationTableName = "INV_PH";
                                copy.WriteToServer(dt);
                            }
                        
                    }
                }
            }
            return RedirectToAction("Index");
            }

        //***********************************************************************************
        //////////////////////////Debut Conroleur Inventaire_Livre///////////////////
        //************************************************************************
        public ActionResult GetAllInvLiv([DataSourceRequest] DataSourceRequest request)
        {

            var Aff = bo3.Afficher();
            return Json(Aff.ToDataSourceResult(request, record => new
            {
                record.ANNEE,
                record.ARTICLE,
                record.AFFECTATIONTH,
                record.AFFECTATIONPHY,
                record.EXISTE,
                record.EMPLACEMENT,
                record.OBSERVATION,
                record.DATEACQUISITION,
                record.VALEURCOMPTABLE,
                 record.DATEEXPLOITATION,
                record.TAUXAMORTISSEMENT,
                record.JOURNALINVENTAIRE,
                record.SERVICE,
                record.LOCALE,
                record.FAMILLECPT,
                record.DESIGNATIONARTICLE,
                record.LIBELLEAFFECTATION,
                record.DOTATIONANTERIEURE,
                 record.DOTATIONEXERCICE,
                record.DUREE,
                record.AMORTI,
                record.RESPONSABLEACHAT,
                record.DATEAMORTISSEMENT,
                





            }), JsonRequestBehavior.AllowGet);
        }

        //*****************************************************************
        public ActionResult ChercherInvLiv([DataSourceRequest] DataSourceRequest request, int? ANNEE, string ARTICLE)
        {
            IMMODEMOEntities ctxt = new IMMODEMOEntities();
            var C = ctxt.IMMO_INV_LIVRE.OrderBy(o => o.ANNEE).AsQueryable();
            string ANNEEs = ANNEE.ToString();
            if ((ANNEEs != "") && (ARTICLE != ""))
                C = C.Where(w => w.ANNEE == ANNEE)
                    .Where(w => w.ARTICLE == ARTICLE);
            if ((ANNEEs != "") && (ARTICLE == ""))
                C = C.Where(w => w.ANNEE == ANNEE);
            if ((ANNEEs == "") && (ARTICLE != ""))
                C = C.Where(w => w.ARTICLE == ARTICLE);



            var fList = C.Select((IMMO_INV_LIVRE i) => new InvLivreLite
            {
                ANNEE = i.ANNEE,
                    ARTICLE = i.ARTICLE,
                    AFFECTATIONTH = i.AFFECTATIONTH,
                    AFFECTATIONPHY= i.AFFECTATIONPHY,
                     EXISTE = i.EXISTE,
                     EMPLACEMENT = i.EMPLACEMENT,
                      OBSERVATION = i.OBSERVATION,
                      DATEACQUISITION = i.DATEACQUISITION,
                       VALEURCOMPTABLE = i.VALEURCOMPTABLE,
                      DATEEXPLOITATION = i.DATEEXPLOITATION,
                     TAUXAMORTISSEMENT = i.TAUXAMORTISSEMENT,
                    JOURNALINVENTAIRE = i.JOURNALINVENTAIRE,
                    SERVICE = i.SERVICE,
                    LOCALE = i.LOCALE,
                  FAMILLECPT = i.FAMILLECPT,
                  DESIGNATIONARTICLE = i.DESIGNATIONARTICLE,
                  LIBELLEAFFECTATION = i.LIBELLEAFFECTATION,
                 DOTATIONANTERIEURE = i.DOTATIONANTERIEURE,
                    DOTATIONEXERCICE = i.DOTATIONEXERCICE,
                   DUREE = i.DUREE,
                 AMORTI= i.AMORTI,
                  RESPONSABLEACHAT = i.RESPONSABLEACHAT,
                    DATEAMORTISSEMENT = i.DATEAMORTISSEMENT,


            });
            var fvt = fList.ToList();

            return Json(fvt.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);

        }

        //*****************************************************************
        public JsonResult GetArticlesN2()
        {    //initialisation de context de base de donnees
            return Json(ctxt.IMMO_INV_LIVRE.Select(c => new { ANNEE = c.ANNEE.ToString(),ARTICLE=c.ARTICLE.ToString() }).OrderBy(o => o.ANNEE).ToList(), JsonRequestBehavior.AllowGet);
        }
        //***********************************************************************************
        public JsonResult GetArticlesH2()
        {    //initialisation de context de base de donnees
            return Json(ctxt.IMMO_INV_LIVRE.Select(c => new { ARTICLE = c.ARTICLE.ToString(), ANNEE=c.ANNEE.ToString() }).OrderBy(o => o.ARTICLE).ToList(), JsonRequestBehavior.AllowGet);
        }

        //***********************************************************************************


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddInvLiv([DataSourceRequest] DataSourceRequest request, IMMO_INV_LIVRE inv)
        {
            try { 
            if (inv != null && ModelState.IsValid)
            {
                bo3.Ajouter(inv);

                ctxt.SaveChanges();
            }
            return Json(new[] { inv }.ToDataSourceResult(request, ModelState));
            }
            catch { return View(); }
        }
        //**************************************************************************************

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdateInvLiv([DataSourceRequest] DataSourceRequest request, IMMO_INV_LIVRE inv)
        {
            try { 
            if (inv != null && ModelState.IsValid)
            {
                bo3.Mettre_A_Jour(inv);

                ctxt.SaveChanges();
            }
            return Json(ModelState.ToDataSourceResult());
            }
            catch { return View(); }
        }


        //*****************************************************************
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeleteInvLiv([DataSourceRequest] DataSourceRequest request, IMMO_INV_LIVRE inv)
        {
            try { 
            if (inv != null && ModelState.IsValid)
            {
                bo3.Supprimer(inv);
                ctxt.SaveChanges();
            }
            return Json(ModelState.ToDataSourceResult());
            }
            catch { return View(); }
        }
        //***********************************************************************
        //////////////////////////Debut Conroleur Inventaire_Comptabilite///////////////////
        //************************************************************************
        public ActionResult GetAllInvCompt([DataSourceRequest] DataSourceRequest request)
        {

            var Aff = bo4.Afficher();
            return Json(Aff.ToDataSourceResult(request, record => new
            {
                record.ANNEE,
                record.DATEAMORTISSEMENT,
                record.FAMILLECPT,
                record.CONTREPARTIE,
                record.DEBIT,
                record.CREDIT,
                record.LIBELLE,
               






            }), JsonRequestBehavior.AllowGet);
        }

        //***********************************************************************************


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddInvCompt([DataSourceRequest] DataSourceRequest request, IMMO_INV_COMPTABILITE inv)
        {
            try { 
            if (inv != null && ModelState.IsValid)
            {
                bo4.Ajouter(inv);

                ctxt.SaveChanges();
            }
            return Json(new[] { inv }.ToDataSourceResult(request, ModelState));
            }
            catch { return View(); }
        }
        //**************************************************************************************

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdateInvCompt([DataSourceRequest] DataSourceRequest request, IMMO_INV_COMPTABILITE inv)
        {
            try { 
            if (inv != null && ModelState.IsValid)
            {
                bo4.Mettre_A_Jour(inv);

                ctxt.SaveChanges();
            }
            return Json(ModelState.ToDataSourceResult());
            }
            catch { return View(); }
        }


        //*****************************************************************
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeleteInvCompt([DataSourceRequest] DataSourceRequest request, IMMO_INV_COMPTABILITE inv)
        {
            try { 
            if (inv != null && ModelState.IsValid)
            {
                bo4.Supprimer(inv);
                ctxt.SaveChanges();
            }
            return Json(ModelState.ToDataSourceResult());
            }
            catch { return View(); }
        }
        //***********************************************************************
        //////////////////////////Debut Conroleur Inventaire Physique///////////////////
        //************************************************************************
        public ActionResult GetAllInvPh([DataSourceRequest] DataSourceRequest request)
        {

            var Aff = bo5.Afficher();
            return Json(Aff.ToDataSourceResult(request, record => new
            {
                record.CODE,
                record.BUREAU,
               



            }), JsonRequestBehavior.AllowGet);
        }

        //*****************************************************************
      
        
       

        //***********************************************************************************


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddInvPh([DataSourceRequest] DataSourceRequest request, INV_PH inv)
        {
            try { 
            if (inv != null && ModelState.IsValid)
            {
                bo5.Ajouter(inv);

                ctxt.SaveChanges();
            }
            return Json(new[] { inv }.ToDataSourceResult(request, ModelState));
            }
            catch { return View(); }
        }
        //**************************************************************************************

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdateInvPh([DataSourceRequest] DataSourceRequest request, INV_PH inv)
        {
            try { 
            if (inv != null && ModelState.IsValid)
            {
                bo5.Mettre_A_Jour(inv);

                ctxt.SaveChanges();
            }
            return Json(ModelState.ToDataSourceResult());
            }
            catch { return View(); }
        }

        //*******************************************************************
        public ActionResult DeleteAllInvPh([DataSourceRequest] DataSourceRequest request)
        {
           
          /* foreach(INV_PH i in ctxt.INV_PH)
            {
                bo5.Supprimer(i);
            }
            var Aff = bo5.Afficher();
            return Json(Aff.ToDataSourceResult(request, record => new
            {
                record.CODE,
                record.BUREAU,




            }), JsonRequestBehavior.AllowGet);
                */
            try
            {

                foreach (INV_PH i in ctxt.INV_PH)
                {
                    DeleteInvPh2(i);
                    ctxt.SaveChanges();

                }
               return Json(ModelState.ToDataSourceResult(),JsonRequestBehavior.AllowGet);
               //RedirectToAction(View());
                    
            }
            catch { return Index(); }
        }
        //*****************************************************************
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeleteInvPh([DataSourceRequest] DataSourceRequest request, INV_PH inv)
        {
            try
            {
                if (inv != null && ModelState.IsValid)
                {
                    bo5.Supprimer(inv);
                    ctxt.SaveChanges();
                }
                return Json(ModelState.ToDataSourceResult());
            }
            catch { return View(); }
        }
        //*****************************
        public ActionResult DeleteInvPh2(INV_PH inv)
        {
            try
            {
                if (inv != null && ModelState.IsValid)
                {
                    bo5.Supprimer(inv);
                    return View();
                }
                else
                    return View();
                ctxt.SaveChanges();
            }
            catch { return View(); }
        }
        //*********************************************************************
        // GET: Inventaire
        public ActionResult Index()
        {
            return View();
        }
    }
}
