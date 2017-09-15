using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;

namespace IMMO.BLL
{
   public  interface IInvBuisness
    {
        void Ajouter(IMMO_INVENTAIRE i);
        IMMO_INVENTAIRE Trouver(int ANNEE,int NUM);
        List<IMMO_INVENTAIRE> Afficher();
       void Mettre_A_Jour(IMMO_INVENTAIRE i);
        void Supprimer(IMMO_INVENTAIRE i);
        int NbTotal(IMMO_INVENTAIRE i);
        int NbExiste (IMMO_INVENTAIRE i);
        int NbNonExiste (IMMO_INVENTAIRE i);
        int NbDelace(IMMO_INVENTAIRE i);
        int NbNonDelace(IMMO_INVENTAIRE i);
       //les methodes buisness de l inventaire physique
        int NbTotal2();
        int NbArtTotal();
        int NBArtBureau();
        double PtauxMutation(IMMO_INVENTAIRE i);
        double PtauxNonMutation(IMMO_INVENTAIRE i);
        double PtauxExistance(IMMO_INVENTAIRE i);
        double PtauxNonExistance(IMMO_INVENTAIRE i);
       
    }
}
