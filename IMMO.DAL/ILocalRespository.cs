using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMMO.DAL
{
    public interface ILocalRespository
    {

        void add(IMMO_LOCAL l);
        IMMO_LOCAL Find(string CODE);
        List<IMMO_LOCAL> FindAll();
        void Update(IMMO_LOCAL l);
        void Delete(IMMO_LOCAL l);
    }
}
