using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMMO.DAL;

namespace Immo_Demo.Models
{
    public class EmplacementLite
    {

        public string CODE { get; set; }
        public string LIEU { get; set; }
        public string ETAGE { get; set; }
        public string COULOIR { get; set; }
        public string BUREAU { get; set; }
        public string LOCAL { get; set; }

        public virtual IMMO_LOCAL IMMO_LOCAL { get; set; }
    }
}