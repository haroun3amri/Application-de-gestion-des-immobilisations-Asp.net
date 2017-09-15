using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMMO.DAL;
namespace Immo_Demo.Models
{
    public class LoginLite
    {
        public LoginLite()
        {
            this.webpages_Roles = new HashSet<webpages_Roles>();
        }
    
        public string Password { get; set; }
    
        public virtual ICollection<webpages_Roles> webpages_Roles { get; set; }
    }
}