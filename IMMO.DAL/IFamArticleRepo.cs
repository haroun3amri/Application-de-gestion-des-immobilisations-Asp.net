using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMMO.DAL
{
    public interface IFamArticleRepo
    {
        void add(IMMO_FAMILLE a);
        IMMO_FAMILLE Find(string CODE);
        List<IMMO_FAMILLE> FindByM(string CODE);
        List<IMMO_FAMILLE> FindAll();
        void Update(IMMO_FAMILLE a);
        void Delete(IMMO_FAMILLE a);
    }
}
