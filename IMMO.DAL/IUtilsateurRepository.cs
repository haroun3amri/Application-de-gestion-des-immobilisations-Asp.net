using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMMO.DAL
{
    public interface IUtilsateurRepository
    {
        void add(Login1 l);
        Login1 Find(int username);
        List<Login1> FindAll();
        void Update(Login1 l);
        void Delete(Login1 l);
    }
}
