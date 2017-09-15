using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMMO.DAL
{
   public  interface IAmmoLRepository
    {//declartion des methodes CRUD des amortissemnts Lineaires
       void add(IMMO_AMORTISSEMENTANNUELLE a);
       void addList(List<IMMO_AMORTISSEMENTANNUELLE> l);
       IMMO_AMORTISSEMENTANNUELLE Find(string Article,int ANNEE);
       bool verif(IMMO_AMORTISSEMENTANNUELLE a, List<IMMO_AMORTISSEMENTANNUELLE> l);
       List<IMMO_AMORTISSEMENTANNUELLE> FindByArticle(string Article);
       List<IMMO_AMORTISSEMENTANNUELLE> FindAll();
       void Update(IMMO_AMORTISSEMENTANNUELLE a);
       void delete(IMMO_AMORTISSEMENTANNUELLE a);
       void deleteByArticle(IMMO_ARTICLE a);
       //declaratio  de methode de calcule automatique des amortissemnt Lineaire
       IMMO_AMORTISSEMENTANNUELLE remplir1LigneAmmAnnuelle(string CODE);
       List<IMMO_AMORTISSEMENTANNUELLE> remplirAmmorLinParArticle(string CODE);

       IMMO_AMORTISSEMENTANNUELLE remplir1LigneAmmAnnuelleDeg(string CODE);
       List<IMMO_AMORTISSEMENTANNUELLE> remplirAmmorDegParArticle(string CODE);

    }
}
