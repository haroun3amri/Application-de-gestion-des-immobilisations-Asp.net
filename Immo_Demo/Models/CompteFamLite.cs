using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMMO.DAL;
namespace Immo_Demo.Models
{
    public class CompteFamLite
    {

        public CompteFamLite()
        {
            this.IMMO_COMPTE = new HashSet<IMMO_COMPTE>();
        }
    
        public string CODE { get; set; }
        public string LIBELLE { get; set; }
        public string CONTREPARTIE { get; set; }
        public Nullable<decimal> TAUX { get; set; }
        public string CONTREPARTIESECONDAIRE { get; set; }
        public string LIBELLEESECONDAIRE { get; set; }
    
        public virtual ICollection<IMMO_COMPTE> IMMO_COMPTE { get; set; }
    }
}