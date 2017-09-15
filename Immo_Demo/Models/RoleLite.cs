using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMMO.DAL;
namespace Immo_Demo.Models
{
    public class RoleLite
    {
        public RoleLite()
        {
            this.Login1 = new HashSet<Login1>();
        }
    
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    
        public virtual ICollection<Login1> Login1 { get; set; }
    }
}