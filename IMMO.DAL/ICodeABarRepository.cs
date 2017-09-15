using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMMO.DAL
{
  public interface ICodeABarRepository
    {
        void add(CODEBAR c);
        CODEBAR Find(string NUM);
        List<CODEBAR> FindAll();
        void Update(CODEBAR c);
        void Delete(CODEBAR c);

    }
}
