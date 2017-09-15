using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMMO.DAL;

namespace Immo_Demo.Models
{
    public class CompteLite
    {
        public CompteLite()
        {
            this.IMMO_ARTICLE = new HashSet<IMMO_ARTICLE>();
            this.IMMO_FAMILLE = new HashSet<IMMO_FAMILLE>();
        }
    
        public string NUM { get; set; }
        public string INTITULE { get; set; }
        public Nullable<decimal> TAUX { get; set; }
        public Nullable<decimal> DUREE { get; set; }
        public string FAMILLECPT { get; set; }
        public string LINEAIRE { get; set; }
    
        public virtual ICollection<IMMO_ARTICLE> IMMO_ARTICLE { get; set; }
        public virtual ICollection<IMMO_FAMILLE> IMMO_FAMILLE { get; set; }
        public virtual IMMO_FAMILLECOMPTABLE IMMO_FAMILLECOMPTABLE { get; set; }
    }
}