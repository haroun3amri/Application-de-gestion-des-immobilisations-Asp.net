using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMMO.DAL
{
     public interface IStatRepository
    {
         int CountArticle();
         int CountFamilleM();
         int CountFamilleF();
         int CessionTotal();
         int CessionParAnnee();


    }
}
