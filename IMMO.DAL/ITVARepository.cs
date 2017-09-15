using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMMO.DAL
{
   public  interface ITVARepository
    {
        void add(IMMO_TVA l);
        IMMO_TVA Find(int CODE);
        List<IMMO_TVA> FindAll();
        void Update(IMMO_TVA l);
        void Delete(IMMO_TVA l);
    }
}
