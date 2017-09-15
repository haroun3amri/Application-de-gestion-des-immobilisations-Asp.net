using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMMO.DAL
{
   public  interface IInv_Article_Repository
    {
        void add(IMMO_INVETAIRE_ARTICLE i);
        IMMO_INVETAIRE_ARTICLE Find(int ANNEE,int NUM,string ARTICLE);
        List<IMMO_INVETAIRE_ARTICLE> FindAll();
        void Update(IMMO_INVETAIRE_ARTICLE i);
        void Delete(IMMO_INVETAIRE_ARTICLE i);
        void deleteByArticle(IMMO_ARTICLE a);
    }
}
