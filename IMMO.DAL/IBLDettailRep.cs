using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMMO.DAL
{
    public interface IBLDettailRep
    {
        void add(IMMO_DETAILBL d);
        IMMO_DETAILBL Find(int ANNEEBL, int NUMBL, int NUM);
       List<IMMO_DETAILBL> FindByNumBl( int NUMBL);

        List<IMMO_DETAILBL> FindByAnnee(int ANNEEBL);
        List<IMMO_DETAILBL> FindByMix(int ANNEEBL, int NUMBL);

        List<IMMO_DETAILBL> FindAll();
        void Update(IMMO_DETAILBL d);
        void Delete(IMMO_DETAILBL d);
        List<IMMO_DETAILBL> FindByM(int NUM);

    }
}
