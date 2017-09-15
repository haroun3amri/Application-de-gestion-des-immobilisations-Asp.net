using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMMO.DAL;

namespace Immo_Demo.Models
{
    public class InvLite
    {
        public InvLite()
        {
            this.IMMO_INVETAIRE_ARTICLE = new HashSet<IMMO_INVETAIRE_ARTICLE>();
        }
    
        public decimal ANNEE { get; set; }
        public decimal NUM { get; set; }
        public string DESCRIPTION { get; set; }
        public System.DateTime DATECREATION { get; set; }
        public string ETAT { get; set; }
        public Nullable<System.DateTime> DATEVALIDATION { get; set; }
        public Nullable<System.DateTime> DATECLOTURE { get; set; }
        public string AUTOMATIQUE { get; set; }
        public string MUTATION { get; set; }
    
        public virtual ICollection<IMMO_INVETAIRE_ARTICLE> IMMO_INVETAIRE_ARTICLE { get; set; }
    }
}