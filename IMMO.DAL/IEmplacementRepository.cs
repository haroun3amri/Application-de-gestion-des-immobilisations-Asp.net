using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMMO.DAL
{
    public interface IEmplacementRepository
    {

        void add(IMMO_EMPLACEMENT e);
        IMMO_EMPLACEMENT Find(string CODE);
        List<IMMO_EMPLACEMENT> FindAll();
        void Update(IMMO_EMPLACEMENT e);
        void Delete(IMMO_EMPLACEMENT e);
    }
}
