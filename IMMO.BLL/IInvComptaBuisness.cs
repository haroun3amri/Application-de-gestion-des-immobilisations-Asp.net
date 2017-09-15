using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;

namespace IMMO.BLL
{
    public interface IInvComptaBuisness
    {
        void Ajouter(IMMO_INV_COMPTABILITE i);
        IMMO_INV_COMPTABILITE Trouver(int ANNEE, DateTime DATEAMORTI,string FAMILLECPT);
        List<IMMO_INV_COMPTABILITE> Afficher();
        void Mettre_A_Jour(IMMO_INV_COMPTABILITE i);
        void Supprimer(IMMO_INV_COMPTABILITE i);
    }
}
