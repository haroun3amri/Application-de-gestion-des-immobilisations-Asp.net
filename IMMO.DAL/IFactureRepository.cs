using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMMO.DAL
{
   public interface IFactureRepository
    {
       // on va ajouter les methodes CRUD our manipuler les Factures
        void add(IMMO_FACTURE a);
        IMMO_FACTURE Find(string NUM);
        List<IMMO_FACTURE> FindAll();
        void Update(IMMO_FACTURE a);
        void Delete(IMMO_FACTURE a);
    }
}
