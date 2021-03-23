using Microsoft.EntityFrameworkCore;
using SoftwareInstallationDatabaseImplement.Models;

namespace SoftwareInstallationDatabaseImplement
{
    public class SoftwareInstallationDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SoftwareInstallationsDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Component> Components { get; set; }
        public virtual DbSet<Package> Packages { get; set; }
        public virtual DbSet<PackageComponent> PackageComponents { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<WarehouseComponent> WarehouseComponents { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }
    }
}