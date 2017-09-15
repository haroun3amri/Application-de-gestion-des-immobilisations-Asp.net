using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMMO.DAL
{
   public  interface IInvPhRepository
    {
        void add(INV_PH i);
        INV_PH Find(string CODE);
        List<INV_PH> FindAll();
        void Update(INV_PH i);
        void Delete(INV_PH i);
    }
}
