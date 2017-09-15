using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMMO.DAL
{
   public  interface IIncComptaRepository
    {
        void add(IMMO_INV_COMPTABILITE i);
        IMMO_INV_COMPTABILITE Find(int ANNEE, DateTime DATEAMORT,string FAMILLECPT);
        List<IMMO_INV_COMPTABILITE> FindAll();
        void Update(IMMO_INV_COMPTABILITE i);
        void Delete(IMMO_INV_COMPTABILITE i);
    }
}
