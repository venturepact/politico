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
    
    public partial class Comment
    {
        public long ID { get; set; }
        public string title { get; set; }
        public Nullable<decimal> rating { get; set; }
        public Nullable<int> sectorID { get; set; }
        public Nullable<long> memberID { get; set; }
        public Nullable<long> mpID { get; set; }
        public Nullable<System.DateTime> datetime { get; set; }
    
        public virtual Member Member { get; set; }
        public virtual MP MP { get; set; }
        public virtual Sector Sector { get; set; }
    }
}
