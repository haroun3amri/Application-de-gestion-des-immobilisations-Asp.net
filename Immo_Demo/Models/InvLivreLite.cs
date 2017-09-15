using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMMO.DAL;

namespace Immo_Demo.Models
{
    public class InvLivreLite
    {
        public decimal ANNEE { get; set; }
        public string ARTICLE { get; set; }
        public string AFFECTATIONTH { get; set; }
        public string AFFECTATIONPHY { get; set; }
        public string EXISTE { get; set; }
        public string EMPLACEMENT { get; set; }
        public string OBSERVATION { get; set; }
        public Nullable<System.DateTime> DATEACQUISITION { get; set; }
        public Nullable<decimal> VALEURCOMPTABLE { get; set; }
        public Nullable<System.DateTime> DATEEXPLOITATION { get; set; }
        public Nullable<decimal> TAUXAMORTISSEMENT { get; set; }
        public string JOURNALINVENTAIRE { get; set; }
        public string SERVICE { get; set; }
        public string LOCALE { get; set; }
        public string FAMILLECPT { get; set; }
        public string DESIGNATIONARTICLE { get; set; }
        public string LIBELLEAFFECTATION { get; set; }
        public Nullable<decimal> DOTATIONANTERIEURE { get; set; }
        public Nullable<decimal> DOTATIONEXERCICE { get; set; }
        public Nullable<decimal> DUREE { get; set; }
        public string AMORTI { get; set; }
        public string RESPONSABLEACHAT { get; set; }
        public Nullable<System.DateTime> DATEAMORTISSEMENT { get; set; }
    }
}