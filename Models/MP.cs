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
    
    public partial class MP
    {
        public MP()
        {
            this.Comments = new HashSet<Comment>();
        }
    
        public long ID { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public Nullable<int> constituencyID { get; set; }
        public Nullable<int> partyID { get; set; }
        public Nullable<int> electedYear { get; set; }
        public string phone { get; set; }
        public string mobile { get; set; }
        public string qualification { get; set; }
        public string image { get; set; }
        public Nullable<decimal> avgRating { get; set; }
    
        public virtual Constituency Constituency { get; set; }
        public virtual Party Party { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
