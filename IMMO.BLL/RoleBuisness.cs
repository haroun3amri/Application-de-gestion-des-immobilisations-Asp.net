using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;

namespace IMMO.BLL
{
    public class RoleBuisness:IRoleBuisness
    {  private IRoleRepository repo;
        //*************************************************************
    public RoleBuisness()
         { this.repo = new RoleRepImp(); }
        //**************************************************************
         public void Ajouter(webpages_Roles r)
        {
            repo.add(r);
        }
        //***************************************************************
         public webpages_Roles Trouver(int roleId)
         {
             return repo.Find(roleId);
         }
        //**************************************************************
         public List<webpages_Roles> Afficher()
         {
             return repo.FindAll();
         }
        //****************************************************************

         public void Mettre_A_Jour(webpages_Roles r)
         {
              repo.Update(r);
         }
        //****************************************************************
         public void Supprimer(webpages_Roles r)
         {
             repo.Delete(r);
         }
    }
}
