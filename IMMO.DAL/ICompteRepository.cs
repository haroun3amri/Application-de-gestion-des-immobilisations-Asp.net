using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMMO.DAL
{
   public  interface ICompteRepository
    {
        void add(IMMO_COMPTE c);
        IMMO_COMPTE Find(string NUM);
        List<IMMO_COMPTE> FindAll();
        void Update(IMMO_COMPTE c);
        void Delete(IMMO_COMPTE c);
    }
}
