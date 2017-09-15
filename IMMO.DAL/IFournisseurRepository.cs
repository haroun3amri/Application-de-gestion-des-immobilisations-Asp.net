using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMMO.DAL
{
   public interface IFournisseurRepository
    {
        void add(IMMO_FOURNISSEUR f);
        IMMO_FOURNISSEUR Find(string CODE);
        List<IMMO_FOURNISSEUR> FindAll();
        void Update(IMMO_FOURNISSEUR f);
        void Delete(IMMO_FOURNISSEUR f);
    }
}
