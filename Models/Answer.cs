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
    
    public partial class Answer
    {
        public long ID { get; set; }
        public Nullable<int> questionID { get; set; }
        public Nullable<long> userID { get; set; }
        public Nullable<System.DateTime> datetime { get; set; }
        public Nullable<bool> isAgree { get; set; }
    
        public virtual Member Member { get; set; }
        public virtual Question Question { get; set; }
    }
}
