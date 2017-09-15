using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMMO.DAL;

namespace Immo_Demo.Models
{
    public class AffHistoLite
    {
        public AffHistoLite()
        {
            this.IMMO_HIST_AFFECTATION_ARTICLE = new HashSet<IMMO_HIST_AFFECTATION_ARTICLE>();
        }
    
        public decimal ANNEE { get; set; }
        public decimal NUM { get; set; }
        public System.DateTime DATEAFFECTATION { get; set; }
        public string ANCIENNEAFFECTATION { get; set; }
        public string NOUVELLEAFFECTATION { get; set; }
        public string ETAT { get; set; }
        public string OBSERVATION { get; set; }
    
        public virtual ICollection<IMMO_HIST_AFFECTATION_ARTICLE> IMMO_HIST_AFFECTATION_ARTICLE { get; set; }
    }
}