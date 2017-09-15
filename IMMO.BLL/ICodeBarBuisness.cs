using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;

namespace IMMO.BLL
{
    public interface ICodeBarBuisness
    {
        void Ajouter(CODEBAR c);
        CODEBAR Trouver(string CODE);
        List<CODEBAR> Afficher();
        void Mettre_A_Jour(CODEBAR c);
        void Supprimer(CODEBAR c);
    }
}
