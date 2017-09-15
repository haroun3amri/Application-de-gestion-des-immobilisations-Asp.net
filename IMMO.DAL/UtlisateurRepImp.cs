using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace IMMO.DAL
{
    public class UtlisateurRepImp:IUtilsateurRepository
    {
        public void add(Login1 l)
        {
            //instancier le context EF
            using (SimpleMembershipEntities ctxt = new SimpleMembershipEntities())
            {
                ctxt.Login1.Add(l);
                ctxt.SaveChanges();

            }
        }
        //********************************************************

        public Login1 Find(int username)
        {
            using (SimpleMembershipEntities ctxt = new SimpleMembershipEntities())
                return ctxt.Login1.Find(username);
        }
        //*********************************************************

        public List<Login1> FindAll()
        {
            using (SimpleMembershipEntities ctxt = new SimpleMembershipEntities())
                return ctxt.Login1.ToList();
        }
        //*********************************************************

       /* public Login1 Update(Login1 l)
        {
            using (SimpleMembershipEntities ctxt = new SimpleMembershipEntities())
            {
                var mod = ctxt.Login1.Find(l.Username);
                if (mod != null)
                {
                    mod.Username = l.Username;
                   


                    return l;
                }
                else return null;

            }
        }*/
        //***********************************************************

        //*****************************************************************

        public void Update(Login1 a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                ctxt.Entry(a).State = EntityState.Modified;
                ctxt.SaveChanges();
            }
        }
        //******************************************************************
        public void Delete(Login1 a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {

                //ctxt.IMMO_ARTICLE.Remove(a);
                ctxt.Entry(a).State = EntityState.Deleted;




                ctxt.SaveChanges();
            }

        }
        //*********************************************************
    }
}
