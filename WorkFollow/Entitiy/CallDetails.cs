//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WorkFollow.Entitiy
{
    using System;
    using System.Collections.Generic;
    
    public partial class CallDetails
    {
        public short ID { get; set; }
        public Nullable<short> CompanyCall { get; set; }
        public string DescText { get; set; }
        public Nullable<System.DateTime> C_Date { get; set; }
    
        public virtual CompanyCall CompanyCall1 { get; set; }
    }
}
