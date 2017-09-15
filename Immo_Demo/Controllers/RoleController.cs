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
    public class RoleController : Controller
    {
        private IRoleBuisness bo = new RoleBuisness();




        //*********************************************************************     
        SimpleMembershipEntities ctxt = new SimpleMembershipEntities();
        //////////////////////////Debut Conroleur Affectation///////////////////
        //************************************************************************
        public ActionResult GetAll([DataSourceRequest] DataSourceRequest request)
        {

            var Aff = bo.Afficher();
            return Json(Aff.ToDataSourceResult(request, record => new
            {
                record.Login1,
                record.RoleId,
                record.RoleName





            }), JsonRequestBehavior.AllowGet);
        }
        //***********************************************************************************
        public ActionResult test([DataSourceRequest] DataSourceRequest request)
        {

            var Articles = ctxt.webpages_Roles.OrderBy(o => o.RoleId).AsQueryable();





            var ArticlesList = Articles.Select(p => new Immo_Demo.Models.RoleLite
            {
                RoleId = p.RoleId,
                RoleName=p.RoleName,




            });
            var fvt = ArticlesList.ToList();

            return Json(fvt.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        //***********************************************************************
        //***********************************************************************************


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Add([DataSourceRequest] DataSourceRequest request, webpages_Roles r)
        {
            try { 
            if (r != null && ModelState.IsValid)
            {
                bo.Ajouter(r);

                ctxt.SaveChanges();
            }
            return Json(new[] { r }.ToDataSourceResult(request, ModelState));
            }
            catch { return View(); }
        }
        //**************************************************************************************

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, webpages_Roles r)
        {
            try { 
            if (r != null && ModelState.IsValid)
            {
                bo.Mettre_A_Jour(r);

                ctxt.SaveChanges();
            }
            return Json(ModelState.ToDataSourceResult());
            }
            catch { return View(); }
        }


        //*****************************************************************
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete([DataSourceRequest] DataSourceRequest request, webpages_Roles r)
        {
            try { 
            if (r != null && ModelState.IsValid)
            {
                bo.Supprimer(r);
                ctxt.SaveChanges();
            }
            return Json(ModelState.ToDataSourceResult());
            }
            catch { return View(); }
        }
        //***********************************************************************
        [Authorize(Roles = "Administrateur")]
        
        // GET: Role
        public ActionResult Index()
        {
            return View();
        }
    }
}