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
    
    public partial class Message
    {
        public short ID { get; set; }
        public Nullable<short> Sender { get; set; }
        public short Receiver { get; set; }
        public string MessageContent { get; set; }
        public Nullable<System.DateTime> C_Date { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<bool> IsRead { get; set; }
    
        public virtual Company Company { get; set; }
        public virtual Company Company1 { get; set; }
    }
}
