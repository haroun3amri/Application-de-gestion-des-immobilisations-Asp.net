//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IMMO.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Login1
    {
        public Login1()
        {
            this.webpages_Roles = new HashSet<webpages_Roles>();
        }
    
        public int Username { get; set; }
        public string Password { get; set; }
    
        public virtual ICollection<webpages_Roles> webpages_Roles { get; set; }
    }
}
