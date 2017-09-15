using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMMO.DAL
{
   public  interface IBLRepository
    {
        void add(IMMO_BL bl);
        IMMO_BL Find(int annee,int num);
        List<IMMO_BL> FindAll();
        void Update(IMMO_BL bl);
        void Delete(IMMO_BL bl);
    }
}
