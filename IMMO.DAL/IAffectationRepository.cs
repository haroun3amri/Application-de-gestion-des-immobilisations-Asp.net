using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMMO.DAL
{
   public interface IAffectationRepository
    {
        void add(IMMO_AFFECTATION a);
        IMMO_AFFECTATION Find(string CODE);
        List<IMMO_AFFECTATION> FindAll();
        void Update(IMMO_AFFECTATION a);
        void Delete(IMMO_AFFECTATION a);
    }
}
