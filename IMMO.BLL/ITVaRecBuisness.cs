using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;

namespace IMMO.BLL
{
    public interface ITVaRecBuisness
    {
        void Ajouter(IMMO_TVARECUPERATION t);
        IMMO_TVARECUPERATION Trouver(int annee);
        List<IMMO_TVARECUPERATION> Afficher();
        void Mettre_A_Jour(IMMO_TVARECUPERATION t);
        void Supprimer(IMMO_TVARECUPERATION t);
    }
}
