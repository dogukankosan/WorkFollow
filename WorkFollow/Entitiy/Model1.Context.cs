﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DbWorkFollowEntities : DbContext
    {
        public DbWorkFollowEntities()
            : base("name=DbWorkFollowEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CallDetails> CallDetails { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<CompanyCall> CompanyCall { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Ilceler> Ilceler { get; set; }
        public virtual DbSet<Iller> Iller { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<Personeles> Personeles { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TaskDetails> TaskDetails { get; set; }
        public virtual DbSet<Taskes> Taskes { get; set; }
    }
}