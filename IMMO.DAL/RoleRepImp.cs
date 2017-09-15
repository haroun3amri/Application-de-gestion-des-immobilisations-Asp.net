using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace IMMO.DAL
{
   public  class RoleRepImp:IRoleRepository
    {
       public void add(webpages_Roles r)
        {
            //instancier le context EF
            using (SimpleMembershipEntities ctxt = new SimpleMembershipEntities())
            {
                ctxt.webpages_Roles.Add(r);
                ctxt.SaveChanges();

            }
        }
        //********************************************************

       public webpages_Roles Find(int roleId)
       {
           using (SimpleMembershipEntities ctxt = new SimpleMembershipEntities())
               return ctxt.webpages_Roles.Find(roleId);
       }
        //*********************************************************

        public List<webpages_Roles> FindAll()
        {
            using (SimpleMembershipEntities ctxt = new SimpleMembershipEntities())
                return ctxt.webpages_Roles.ToList();
        }
        //*********************************************************

       /* public webpages_Roles Update(webpages_Roles r)
        {
            using (SimpleMembershipEntities ctxt = new SimpleMembershipEntities())
            {
                var mod = ctxt.webpages_Roles.Find(r.RoleId);
                if (mod != null)
                {
                    mod.RoleId = r.RoleId;
                    mod.RoleName=r.RoleName;
                    mod.Login1=r.Login1;
                   


                    return r;
                }
                else return null;

            }
        }*/
        //***********************************************************

        //*****************************************************************

        public void Update(webpages_Roles a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {
                ctxt.Entry(a).State = EntityState.Modified;
                ctxt.SaveChanges();
            }
        }
        //******************************************************************
        public void Delete(webpages_Roles a)
        {
            using (IMMODEMOEntities ctxt = new IMMODEMOEntities())
            {

                //ctxt.IMMO_ARTICLE.Remove(a);
                ctxt.Entry(a).State = EntityState.Deleted;




                ctxt.SaveChanges();
            }

        }
       //********************************************
    }
}
