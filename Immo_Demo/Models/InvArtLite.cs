using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMMO.DAL;

namespace Immo_Demo.Models
{
    public class InvArtLite
    {
        public decimal ANNEE { get; set; }
        public decimal NUM { get; set; }
        public string ARTICLE { get; set; }
        public string AFFECTATION { get; set; }
        public string EXISTE { get; set; }
        public string OPERATEUR { get; set; }
        public string EMPLACEMENT { get; set; }
        public string OBSERVATION { get; set; }
        public string AFFECTATIONTH { get; set; }
        public Nullable<decimal> VALEURCOMPTABLE { get; set; }
        public string DESIGNATION{ get; set; }
        public string LIBELLE { get; set; }
        public string RESPONSABLEACHAT { get; set; }
        public virtual IMMO_AFFECTATION IMMO_AFFECTATION { get; set; }
        public virtual IMMO_ARTICLE IMMO_ARTICLE { get; set; }
        public virtual IMMO_INVENTAIRE IMMO_INVENTAIRE { get; set; }
    }
}