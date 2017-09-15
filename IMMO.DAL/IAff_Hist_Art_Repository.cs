using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMMO.DAL
{
  public   interface IAff_Hist_Art_Repository
    {
        void add(IMMO_HIST_AFFECTATION_ARTICLE a);
        IMMO_HIST_AFFECTATION_ARTICLE Find(int annee, int num, string article);
        IMMO_HIST_AFFECTATION_ARTICLE FindByAnnee(int annee);
        IMMO_HIST_AFFECTATION_ARTICLE FindByNum(int num);
        IMMO_HIST_AFFECTATION_ARTICLE FindByArticle(string article);


        List<IMMO_HIST_AFFECTATION_ARTICLE> FindAll();
        void Update(IMMO_HIST_AFFECTATION_ARTICLE a);
        void Delete(IMMO_HIST_AFFECTATION_ARTICLE a);
        void deleteByArticle(IMMO_ARTICLE a);
    }
}
