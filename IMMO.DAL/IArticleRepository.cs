using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMMO.DAL
{
    public interface IArticleRepository
    {
        //declaration des methodes CRUD pour les article
        void add(IMMO_ARTICLE a);
        IMMO_ARTICLE Find(string CODE);
        List<IMMO_ARTICLE> FindAll();
        void Update(IMMO_ARTICLE a);
        void Delete(IMMO_ARTICLE a);
        


    }
}
