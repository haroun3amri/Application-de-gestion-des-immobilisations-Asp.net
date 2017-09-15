using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMMO.DAL;

namespace Immo_Demo.Models
{
    public class Aff_Hist_Art_Lite
    {
        public decimal ANNEE { get; set; }
        public decimal NUM { get; set; }
        public string ARTICLE { get; set; }
        public string ANCIENNEAFFECTATION { get; set; }
        public string NOUVELLEAFFECTATION { get; set; }
        public System.DateTime DATEAFFECTATION { get; set; }
        public string ETAT { get; set; }
        public string OBSERVATION { get; set; }

        public virtual IMMO_AFFECTATION IMMO_AFFECTATION { get; set; }
        public virtual IMMO_AFFECTATION IMMO_AFFECTATION1 { get; set; }
        public virtual IMMO_ARTICLE IMMO_ARTICLE { get; set; }
        public virtual IMMO_HIST_AFFECTATION IMMO_HIST_AFFECTATION { get; set; }
    }
}