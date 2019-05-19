﻿using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using WebServices.Models;

namespace WebServices.Concrete{

    public class EFContext:DbContext{

        public EFContext() : base("EFContext") { }

        public DbSet<HeadReserve> HeadReserve { get; set; }
        public DbSet<BoxesReserve> BoxesReserve { get; set; }
        public DbSet<MarksReserve> MarksReserve { get; set; }

        public DbSet<Arrival> Arrival { get; set; }
        public DbSet<Material> Material { get; set; }
        public DbSet<Pallet> Pallet { get; set; }
        public DbSet<Carton> Carton { get; set; }
        public DbSet<Mark> Mark { get; set; }
    }

    //protected override void OnModelCreating(DbModelBuilder modelBuilder){
    //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
    //}
}