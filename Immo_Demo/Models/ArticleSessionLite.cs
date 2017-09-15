using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMMO.DAL;

namespace Immo_Demo.Models
{
    public class ArticleSessionLite
    {
        public string ARTICLE { get; set; }
        public string RAISON { get; set; }
        public decimal VALEUR { get; set; }
        public System.DateTime DATESESSION { get; set; }
        public string ETAT { get; set; }
        public Nullable<decimal> DOTATION { get; set; }
        public decimal ANNEE { get; set; }
        public decimal NUM { get; set; }
        public Nullable<decimal> AMORTISSEMENTPRATIQUE { get; set; }

        public virtual IMMO_ARTICLE IMMO_ARTICLE { get; set; }
        public virtual IMMO_CESSION IMMO_CESSION { get; set; }
    }
}