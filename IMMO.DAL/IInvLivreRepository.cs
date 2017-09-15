using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMMO.DAL
{
   public  interface IInvLivreRepository
    {
        void add(IMMO_INV_LIVRE i);
        IMMO_INV_LIVRE Find(int ANNEE, string ARTICLE);
        List<IMMO_INV_LIVRE> FindAll();
        void Update(IMMO_INV_LIVRE i);
        void Delete(IMMO_INV_LIVRE i);
        void deleteByArticle(IMMO_ARTICLE a);
    }
}
