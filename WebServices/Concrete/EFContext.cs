using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using WebServices.Models;

namespace WebServices.Concrete{

    public class EFContext:DbContext{

        public EFContext() : base("EFContext") { }

        public DbSet<HeadReserve> HeadReserve { get; set; }
        public DbSet<BoxesReserve> BoxesReserve { get; set; }
        public DbSet<MarksReserve> MarksReserve { get; set; }
    }

    //protected override void OnModelCreating(DbModelBuilder modelBuilder){
    //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
    //}
}