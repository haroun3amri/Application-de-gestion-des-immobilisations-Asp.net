using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMMO.DAL
{
   public interface ITvaRecRepository
    {
        void add(IMMO_TVARECUPERATION l);
        IMMO_TVARECUPERATION Find(int annee);
        List<IMMO_TVARECUPERATION> FindAll();
        void Update(IMMO_TVARECUPERATION l);
        void Delete(IMMO_TVARECUPERATION l);
    }
}
