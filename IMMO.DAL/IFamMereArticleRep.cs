using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMMO.DAL
{
   public interface IFamMereArticleRep
    {
        void add(IMMO_FAMILLEM a);
        IMMO_FAMILLEM Find(string CODE);
        List<IMMO_FAMILLEM> FindAll();
        void Update(IMMO_FAMILLEM a);
        void Delete(IMMO_FAMILLEM a);
    }
}
