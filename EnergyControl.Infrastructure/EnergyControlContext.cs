using EnergyControl.Domain.DataInitializers;
using EnergyControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnergyControl.Infrastructure
{
    public class EnergyControlContext : DbContext
    {
        public DbSet<Organization> Organizations { get; set; } = null!;
        public DbSet<Subsidiary> Subsidiaries { get; set; } = null!;
        public DbSet<ConsumptionObject> ConsumptionObjects { get; set; } = null!;
        public DbSet<SettlementMeter> SettlementMeters { get; set; } = null!;
        public DbSet<ElectricityMeasuringPoint> ElectricityMeasuringPoints { get; set; } = null!;
        public DbSet<ElectricitySupplyPoint> ElectricitySupplyPoints { get; set; } = null!;
        public DbSet<ElectricalEnergyMeter> ElectricalEnergyMeters { get; set; } = null!;
        public DbSet<PowerTransformer> PowerTransformers { get; set; } = null!;
        public DbSet<VoltageTransformer> VoltageTransformers { get; set; } = null!;

        public EnergyControlContext(DbContextOptions<EnergyControlContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options
                .UseLazyLoadingProxies()
                .UseSqlServer(
                    "Server=(localdb)\\MSSQLLocalDB;Database=EnergyControlDb;Trusted_Connection=True;",
                    x => x.MigrationsAssembly("EnergyControl.Infrastructure"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var initializer = new EnergyControlDbInitializer();
            modelBuilder.Entity<Organization>().HasData(initializer.Organizations);
            modelBuilder.Entity<Subsidiary>().HasData(initializer.Subsidiaries);
            modelBuilder.Entity<ConsumptionObject>().HasData(initializer.ConsumptionObjects);
            modelBuilder.Entity<SettlementMeter>().HasData(initializer.SettlementMeters);
            modelBuilder.Entity<ElectricityMeasuringPoint>().HasData(initializer.ElectricityMeasuringPoints);
            modelBuilder.Entity<ElectricitySupplyPoint>().HasData(initializer.ElectricitySupplyPoints);
            modelBuilder.Entity<ElectricalEnergyMeter>().HasData(initializer.ElectricalEnergyMeters);
            modelBuilder.Entity<PowerTransformer>().HasData(initializer.PowerTransformers);
            modelBuilder.Entity<VoltageTransformer>().HasData(initializer.VoltageTransformers);
        }
    }
}
