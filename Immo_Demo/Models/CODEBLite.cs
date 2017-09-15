using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMMO.DAL;

namespace Immo_Demo.Models

{
    public class CODEBLite
    {

        public string CODECLAIR { get; set; }
        public string CODEBAR1 { get; set; }
        public string LIBELLE { get; set; }
        public string AFFECTLOCAL { get; set; }
        public string CODE { get; set; }

        public virtual IMMO_ARTICLE IMMO_ARTICLE { get; set; }
    }
}