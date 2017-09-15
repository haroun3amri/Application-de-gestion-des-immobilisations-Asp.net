using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMMO.DAL
{
   public  interface ICessionRepository
   {// on va ajouter les methodes CRUD our manipuler les Factures
       void add(IMMO_CESSION c);
       IMMO_CESSION Find(int annee,int num);
       IMMO_CESSION FindByAnnee(int annee);
       IMMO_CESSION FindByNum(int Num);

       List<IMMO_CESSION> FindAll();
       void Update(IMMO_CESSION c);
       void Delete(IMMO_CESSION c);
    }
}
