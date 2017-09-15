using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;

namespace IMMO.BLL
{
   public interface IServiceBuisness
    {
        void Ajouter(IMMO_SERVICE t);
        IMMO_SERVICE Trouver(string code);
        List<IMMO_SERVICE> Afficher();
        void Mettre_A_Jour(IMMO_SERVICE t);
        void Supprimer(IMMO_SERVICE t);
    }
}
