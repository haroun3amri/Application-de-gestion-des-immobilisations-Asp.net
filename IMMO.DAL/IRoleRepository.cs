using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMMO.DAL
{
    public interface IRoleRepository
    {
        void add(webpages_Roles l);
        webpages_Roles Find(int roleID);
        List<webpages_Roles> FindAll();
       void Update(webpages_Roles l);
        void Delete(webpages_Roles l);
    }
}
