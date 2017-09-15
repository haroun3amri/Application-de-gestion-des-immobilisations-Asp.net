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
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Immo_Demo.Controllers
{

    public class XmlResult:ActionResult
    {

        private object objectToSerialize;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlResult"/> class.
        /// </summary>
        /// <param name="objectToSerialize">The object to serialize to XML.</param>
        public XmlResult(object objectToSerialize)
        {
            this.objectToSerialize = objectToSerialize;
        }

        /// <summary>
        /// Gets the object to be serialized to XML.
        /// </summary>
        public object ObjectToSerialize
        {
            get { return this.objectToSerialize; }
        }

        /// <summary>
        /// Serialises the object that was passed into the constructor to XML and writes the corresponding XML to the result stream.
        /// </summary>
        /// <param name="context">The controller context for the current request.</param>
        public override void ExecuteResult(ControllerContext context)
        {
            if (this.objectToSerialize != null)
            {
                context.HttpContext.Response.Clear();
                XmlRootAttribute root = new XmlRootAttribute("InventaireCpt");

                var xs = new System.Xml.Serialization.XmlSerializer(this.objectToSerialize.GetType(), root);
                context.HttpContext.Response.ContentType = "text/xml";

                xs.Serialize(context.HttpContext.Response.Output, this.objectToSerialize);
            }
        }
    }
    public class XMLController : Controller
    {
        private IInvComptaBuisness bo = new InvComptaBuisness();


        //***************************
        //////////////////////////Debut Conroleur Inventaire_Comptabilite///////////////////
        //************************************************************************
        public ActionResult GetAllInvCompt([DataSourceRequest] DataSourceRequest request)
        {

            var Aff = bo.Afficher();
           /* return Json(Aff.ToDataSourceResult(request, record => new
            {
                record.ANNEE,
                record.DATEAMORTISSEMENT,
                record.FAMILLECPT,
                record.CONTREPARTIE,
                record.DEBIT,
                record.CREDIT,
                record.LIBELLE,







            }), JsonRequestBehavior.AllowGet);*/
            return new XmlResult(Aff);
        }

        //***********************************************************************************
        // GET: XML
        public ActionResult Index()
        {
            return View();
        }
    }
}