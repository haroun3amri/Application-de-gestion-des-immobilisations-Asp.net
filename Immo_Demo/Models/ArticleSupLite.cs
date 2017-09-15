using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMMO.DAL;

namespace Immo_Demo.Models
{
    public class ArticleSupLite
    {
        public string CODE { get; set; }
        public string FAMILLE { get; set; }
        public string CENTREACHAT { get; set; }
        public string AFFECTATION { get; set; }
        public Nullable<System.DateTime> DATEAFFECTATION { get; set; }
        public Nullable<System.DateTime> DATEAQUISITION { get; set; }
        public Nullable<decimal> ANNEEBL { get; set; }
        public Nullable<decimal> NUMBL { get; set; }
        public Nullable<decimal> NUMLIGBL { get; set; }
        public string NUMFACTURE { get; set; }
        public Nullable<System.DateTime> DATEEXPLOITATION { get; set; }
        public Nullable<decimal> DUREE { get; set; }
        public Nullable<decimal> TAUXAMORTISSEMENT { get; set; }
        public Nullable<decimal> DOTATIONANTERIEURE { get; set; }
        public Nullable<decimal> VALEURCOMPTABLE { get; set; }
        public Nullable<System.DateTime> DATESESSION { get; set; }
        public Nullable<decimal> VALEURSESSION { get; set; }
        public string RAISONSESSION { get; set; }
        public string AMORTI { get; set; }
        public string ETAT { get; set; }
        public string DESIGNATION { get; set; }
        public string ETATSESSION { get; set; }
        public string COMPTE { get; set; }
        public string REFERENCE { get; set; }
        public string CARACTERISTIQUE { get; set; }
        public Nullable<decimal> ANNEE { get; set; }
        public string SERVICE { get; set; }
        public string LOCALE { get; set; }
        public string EMPLACEMENT { get; set; }
        public System.DateTime DATESUPP { get; set; }
        public string OPERATEUR { get; set; }

        public virtual IMMO_FAMILLE IMMO_FAMILLE { get; set; }
    }
}