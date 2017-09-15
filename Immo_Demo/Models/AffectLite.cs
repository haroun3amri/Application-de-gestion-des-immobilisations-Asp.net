using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMMO.DAL;

namespace Immo_Demo.Models
{
    public class AffectLite
    {
        public AffectLite()
        {
            this.IMMO_BL = new HashSet<IMMO_BL>();
            this.IMMO_HIST_AFFECTATION_ARTICLE = new HashSet<IMMO_HIST_AFFECTATION_ARTICLE>();
            this.IMMO_HIST_AFFECTATION_ARTICLE1 = new HashSet<IMMO_HIST_AFFECTATION_ARTICLE>();
            this.IMMO_ARTICLE = new HashSet<IMMO_ARTICLE>();
            this.IMMO_INVETAIRE_ARTICLE = new HashSet<IMMO_INVETAIRE_ARTICLE>();
        }
    
        public string CODE { get; set; }
        public string LIBELLE { get; set; }
        public string RESPONSABLEACHAT { get; set; }
    
        public virtual ICollection<IMMO_BL> IMMO_BL { get; set; }
        public virtual ICollection<IMMO_HIST_AFFECTATION_ARTICLE> IMMO_HIST_AFFECTATION_ARTICLE { get; set; }
        public virtual ICollection<IMMO_HIST_AFFECTATION_ARTICLE> IMMO_HIST_AFFECTATION_ARTICLE1 { get; set; }
        public virtual ICollection<IMMO_ARTICLE> IMMO_ARTICLE { get; set; }
        public virtual ICollection<IMMO_INVETAIRE_ARTICLE> IMMO_INVETAIRE_ARTICLE { get; set; }
    }
}