using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMMO.DAL
{
    public interface IArticleCessionRepository
    {// on va ajouter les methodes CRUD our manipuler les Factures
        void add(IMMO_ARTICLE_SESSION s);
        IMMO_ARTICLE_SESSION Find(string article, int annee, int num);
        IMMO_ARTICLE_SESSION FindbyArticle(string article);
        IMMO_ARTICLE_SESSION FindbyAnnee(int annee);
        IMMO_ARTICLE_SESSION FindbyNum(int num);
        IMMO_ARTICLE_SESSION FindbyCession(int annee,int num);

        List<IMMO_ARTICLE_SESSION> FindAll();
       void Update(IMMO_ARTICLE_SESSION s);
        void Delete(IMMO_ARTICLE_SESSION s);
        void deleteByArticle(int annee, int num);

        void deleteByArticle2(IMMO_ARTICLE a);
    }
}
