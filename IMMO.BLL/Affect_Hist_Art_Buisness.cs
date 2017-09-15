using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;

namespace IMMO.BLL
{
   public class Affect_Hist_Art_Buisness:IAff_Hist_Art_Buisness
   {
       private IAff_Hist_Art_Repository repo;
        //*************************************************************
           public Affect_Hist_Art_Buisness()
       { this.repo = new Affec_Hist_Art_Rep_Imp(); }
        //**************************************************************
        public void Ajouter(IMMO_HIST_AFFECTATION_ARTICLE a)
        {
            repo.add(a);
        }
       //**************************************************
        public IMMO_HIST_AFFECTATION_ARTICLE Trouver(int annee, int num, string article)
        {
            return repo.Find(annee, num, article);
        }
       //**************************************************

        public IMMO_HIST_AFFECTATION_ARTICLE TrouverParAnnee(int annee)
        {
            return repo.FindByAnnee(annee);
        }
       //*****************************************************
        public IMMO_HIST_AFFECTATION_ARTICLE TrouverParNum(int num)
        {
            return repo.FindByNum(num);
        }
       //********************************************************

        public IMMO_HIST_AFFECTATION_ARTICLE TrouverParArticle(string article)
        {
            return repo.FindByArticle(article);
        }
       //***********************************************************
        public List<IMMO_HIST_AFFECTATION_ARTICLE> Afficher()
        {
            return repo.FindAll();
        }
       //**********************************************************

        public void Mettre_A_Jour(IMMO_HIST_AFFECTATION_ARTICLE a)
        {
             repo.Update(a);
        }
       //*****************************************************
        public void Supprimer(IMMO_HIST_AFFECTATION_ARTICLE a)
        {
            repo.Delete(a);
        }
       //************************************************************
        public void SupprimerParArticle(IMMO_ARTICLE a)
        {
            repo.deleteByArticle(a);
        }
    }
}
