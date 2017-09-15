using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMMO.DAL;
using IMMO.BLL;

namespace Immo_Demo.Models
{
    public class CessionLite
    {  public CessionLite()
        {
            this.IMMO_ARTICLE_SESSION = new HashSet<IMMO_ARTICLE_SESSION>();
        }
    
        public decimal ANNEE { get; set; }
        public decimal NUM { get; set; }
        public System.DateTime DATECESSION { get; set; }
        public string RAISON { get; set; }
        public string ETAT { get; set; }
        public Nullable<decimal> VALTOTAL { get; set; }
        public decimal EXERCICE { get; set; }
    
        public virtual ICollection<IMMO_ARTICLE_SESSION> IMMO_ARTICLE_SESSION { get; set; }

    }
}