using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMMO.DAL
{
  public   interface IAff_HistoRepository
    {
        void add(IMMO_HIST_AFFECTATION a);
        IMMO_HIST_AFFECTATION Find(int annee, int num);
        IMMO_HIST_AFFECTATION FindByAnnee(int annee);
        IMMO_HIST_AFFECTATION FindByNum(int num);

        List<IMMO_HIST_AFFECTATION> FindAll();
        void Update(IMMO_HIST_AFFECTATION a);
        void Delete(IMMO_HIST_AFFECTATION a);
    }
}
