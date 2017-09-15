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
using WebMatrix.WebData;
using WebMatrix.Data;
using System.Web.Security;


namespace Immo_Demo.Controllers
{
    public class UtilsateursController : Controller
    {
        private IUtilsateurBuisness bo = new UtlisateurBuisness();
        private IRoleBuisness bo2 = new RoleBuisness();





        //*********************************************************************     
        SimpleMembershipEntities ctxt = new SimpleMembershipEntities();
        //////////////////////////Debut Conroleur Affectation///////////////////
        //************************************************************************
        public ActionResult GetAll([DataSourceRequest] DataSourceRequest request)
        {

            var Aff = bo.Afficher();
            return Json(Aff.ToDataSourceResult(request, record => new
            {
                record.Password,



            }), JsonRequestBehavior.AllowGet);
        }
        //***********************************************************************************
        public ActionResult test([DataSourceRequest] DataSourceRequest request)
        {
            
            var Articles = ctxt.Login1.OrderBy(o => o.Username).AsQueryable();

           



            var ArticlesList = Articles.Select(p => new Immo_Demo.Models.Login
            {
                Username = p.Password.ToString(),
                



            });
            var fvt = ArticlesList.ToList();

            return Json(fvt.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        //***********************************************************************
        public ActionResult ChercherUser([DataSourceRequest] DataSourceRequest request, int? RoleId)
        {
            //var C = ctxt.Login1.OrderBy(o => o.Password).AsQueryable();
            List<Login1> C = new List<Login1>();
             C = bo.Afficher();

            if (RoleId != null)
            {
                C.Clear();
                int RoleId1 = (int)RoleId;
                webpages_Roles r = bo2.Trouver(RoleId1);

                string RoleName = r.RoleName;
                var L = Roles.GetUsersInRole(RoleName).ToList();
                foreach (Login1 l in ctxt.Login1)
                {
                    string tmp = l.Password;
                    if (L.Contains(tmp) == true)
                    {
                        C.Add(l);
                    }
                }
            }


               


            var ArticlesList = C.Select(p => new Immo_Demo.Models.Login
            {
                Username = p.Password.ToString(),




            });
            var fvt = ArticlesList.ToList();







            return Json(fvt.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);

        }
        //**********************************************************************************
        //***********************************************************************************


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Add([DataSourceRequest] DataSourceRequest request, Login1 l)
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
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, Login1 l)
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
        public ActionResult Delete([DataSourceRequest] DataSourceRequest request, Login1 l)
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
        //***********************************************************************
        [Authorize(Roles = "Administrateur")]
        // GET: Utilsateurs
        public ActionResult Index()
        {
            return View();
        }
    }
}