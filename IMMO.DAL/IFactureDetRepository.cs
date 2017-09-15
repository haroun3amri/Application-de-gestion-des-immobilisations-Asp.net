using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMMO.DAL
{
   public  interface IFactureDetRepository
    {
        void add(IMMO_DETAILFACTURE a);
        List<IMMO_DETAILFACTURE> Find(string NumFacture);
        List<IMMO_DETAILFACTURE> FindAll();
       void Update(IMMO_DETAILFACTURE a);
        void Delete(IMMO_DETAILFACTURE a);
        List<IMMO_DETAILFACTURE> FindByM(string NUM);

    }
    
}
