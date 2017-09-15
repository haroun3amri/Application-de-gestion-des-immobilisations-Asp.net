using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMMO.DAL
{
   public interface IServiceRepository
    {
        void add(IMMO_SERVICE l);
        IMMO_SERVICE Find(string CODE);
        List<IMMO_SERVICE> FindAll();
        void Update(IMMO_SERVICE l);
        void Delete(IMMO_SERVICE l);
    }
}
