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
    
    public partial class Company
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Company()
        {
            this.CompanyCall = new HashSet<CompanyCall>();
            this.Message = new HashSet<Message>();
            this.Message1 = new HashSet<Message>();
            this.Taskes = new HashSet<Taskes>();
        }
    
        public short ID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyOfficial { get; set; }
        public string CompanyTel { get; set; }
        public string CompanyMail { get; set; }
        public string Password { get; set; }
        public string CompanyActivity { get; set; }
        public Nullable<byte> CompanyCity { get; set; }
        public Nullable<short> CompanyTown { get; set; }
        public string CompanyAdress { get; set; }
        public byte[] CompanyImage { get; set; }
        public Nullable<bool> IsAdmin { get; set; }
    
        public virtual Ilceler Ilceler { get; set; }
        public virtual Iller Iller { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompanyCall> CompanyCall { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Message> Message { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Message> Message1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Taskes> Taskes { get; set; }
    }
}