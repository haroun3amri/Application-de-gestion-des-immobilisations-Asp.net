using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMMO.DAL;

namespace Immo_Demo.Models
{
    public class LocalLite
    {
        public LocalLite()
        {
            this.IMMO_ARTICLE = new HashSet<IMMO_ARTICLE>();
            this.IMMO_EMPLACEMENT = new HashSet<IMMO_EMPLACEMENT>();
        }
    
        public string CODE { get; set; }
        public string LIBELLE { get; set; }
    
        public virtual ICollection<IMMO_ARTICLE> IMMO_ARTICLE { get; set; }
        public virtual ICollection<IMMO_EMPLACEMENT> IMMO_EMPLACEMENT { get; set; }
    }
}