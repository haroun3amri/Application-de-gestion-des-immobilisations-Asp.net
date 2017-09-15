using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMMO.DAL
{
   public interface IFamComptableRep
    {
       void add(IMMO_FAMILLECOMPTABLE fcpt);
        IMMO_FAMILLECOMPTABLE Find(string CODE);
        List<IMMO_FAMILLECOMPTABLE> FindAll();
        void Update(IMMO_FAMILLECOMPTABLE fcpt);
        void Delete(IMMO_FAMILLECOMPTABLE fcpt);
    }
}
