using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMMO.DAL;

namespace IMMO.BLL
{
   public interface IRoleBuisness
    {
        void Ajouter(webpages_Roles r);
        webpages_Roles Trouver(int roleId);
        List<webpages_Roles> Afficher();
       void Mettre_A_Jour(webpages_Roles r);
        void Supprimer(webpages_Roles r);
    }
}
