//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Politico.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sector
    {
        public Sector()
        {
            this.Comments = new HashSet<Comment>();
        }
    
        public int ID { get; set; }
        public string title { get; set; }
    
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
