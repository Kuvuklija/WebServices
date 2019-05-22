using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using WebServices.Models;

namespace WebServices.Concrete{

    public class EFContext:DbContext{

        public EFContext() : base("EFContext") {
            Database.Log = Console.WriteLine;
        }

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