using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMMO.DAL
{
   public  interface IExerciceRep
    {
        void add(IMMO_EXERCICE a);
        IMMO_EXERCICE Find(int annee);
        List<IMMO_EXERCICE> FindAll();
        void Update(IMMO_EXERCICE a);
        void Delete(IMMO_EXERCICE a);
    }
}
