﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MakeSolution.HomeRepairVR.DataAccess.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BDHomeRepairVREntities : DbContext
    {
        public BDHomeRepairVREntities()
            : base("name=BDHomeRepairVREntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Activity> Activity { get; set; }
        public virtual DbSet<ActivityMaterial> ActivityMaterial { get; set; }
        public virtual DbSet<Material> Material { get; set; }
        public virtual DbSet<Statistics> Statistics { get; set; }
        public virtual DbSet<StatisticsDetail> StatisticsDetail { get; set; }
        public virtual DbSet<Step> Step { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserActivity> UserActivity { get; set; }
    }
}
