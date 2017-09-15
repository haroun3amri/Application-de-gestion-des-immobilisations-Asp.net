using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMMO.DAL
{
    public interface IInventaireRepository
    {
        void add(IMMO_INVENTAIRE i);
        IMMO_INVENTAIRE Find(int ANNEE,int NUM);
        List<IMMO_INVENTAIRE> FindAll();
        void Update(IMMO_INVENTAIRE i);
        void Delete(IMMO_INVENTAIRE i);
        //operation sur l invenrtaire manuel
        int Total(IMMO_INVENTAIRE i);
        int Existe(IMMO_INVENTAIRE i);
        int NonExiste(IMMO_INVENTAIRE i);
        int Delace(IMMO_INVENTAIRE i);
        int NonDelace(IMMO_INVENTAIRE i);
        //operation de comptage sur les inventaire physique 
        int Total2();
        bool ExisteA(string s, List<List<INV_PH>> l);
         bool ExisteB(string s , List<List<INV_PH>> l);
         
        int ArtTotal();
        int ArtBureau();
        //operation de statestique Pie pour compatge manuelle
        double tauxMutation(IMMO_INVENTAIRE i);
        double tauxNonMutation(IMMO_INVENTAIRE i);
        double tauxExistance(IMMO_INVENTAIRE i);
        double tauxNonExistance(IMMO_INVENTAIRE i);

       
    }
}
