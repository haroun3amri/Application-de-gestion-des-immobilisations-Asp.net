using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMMO.DAL
{
   public  interface IArticleSupprimeRepo
   {//declaration des methodes CRUD pour les article
       void add(IMMO_ARTICLESUPPRIME a);
       IMMO_ARTICLESUPPRIME Find(string CODE);
       List<IMMO_ARTICLESUPPRIME> FindAll();
       void Update(IMMO_ARTICLESUPPRIME a);
       void Delete(IMMO_ARTICLESUPPRIME a);
       IMMO_ARTICLESUPPRIME addDel(IMMO_ARTICLE ar);
    }
}
