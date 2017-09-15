using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace IMMO.DAL
{
   public class FournisseurRepImp:IFournisseurRepository
    {
        public void add(IMMO_FOURNISSEUR f)
        {
            //instancier le context EF
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                ctxt.IMMO_FOURNISSEUR.Add(f);
                ctxt.SaveChanges();

            }
        }
        //************************************************************
        public IMMO_FOURNISSEUR Find(string CODE)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
                return ctxt.IMMO_FOURNISSEUR.Find(CODE);
        }
        //************************************************************

        public List<IMMO_FOURNISSEUR> FindAll()
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
                return ctxt.IMMO_FOURNISSEUR.ToList();
        }
        //**************************************************************

      /*  public IMMO_FOURNISSEUR Update(IMMO_FOURNISSEUR f)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                var mod = ctxt.IMMO_FOURNISSEUR.Find(f.CODE);
                if (mod != null)
                {
                    mod.CODE = f.CODE;
                    mod.NOM = f.NOM;
                    mod.RESPONSABLE = f.RESPONSABLE;
                    mod.MATFISCAL = f.MATFISCAL;
                    mod.TEL = f.MATFISCAL;
                    mod.FAX = f.FAX;
                    mod.CONTACT = f.CONTACT;
                    return mod;
                }
                else return null;

            }
        }*/
       //*****************************************************************
        public void Update(IMMO_FOURNISSEUR f)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                ctxt.Entry(f).State = EntityState.Modified;
                ctxt.SaveChanges();
            }
        }
        //*************************************************************


        public void Delete(IMMO_FOURNISSEUR a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {

                //ctxt.IMMO_ARTICLE.Remove(a);
                ctxt.Entry(a).State = EntityState.Deleted;




                ctxt.SaveChanges();
            }

        }
    }
}
