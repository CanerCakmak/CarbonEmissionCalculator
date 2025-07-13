using CarbonEmissionCalculator.Domain.Common;
using CarbonEmissionCalculator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection;

namespace CarbonEmissionCalculator.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        #region AllEntities
        public DbSet<FixedCombustionLPGCalculation> FixedCombustionLPGCalculations { get; set; }
        public DbSet<FixedCombustionDieselCalculation> FixedCombustionDieselCalculations { get; set; }
        public DbSet<FixedCombustionGasolineCalculation> FixedCombustionGasolineCalculations { get; set; }
        public DbSet<FixedCombustionNaturalGasCalculation> FixedCombustionNaturalGasCalculations { get; set; }
        public DbSet<MobileOffRoadDieselCalculation> MobileOffRoadDieselCalculations { get; set; }
        public DbSet<MobileOffRoadGasolineCalculation> MobileOffRoadGasolineCalculations { get; set; }
        public DbSet<MobileOnRoadDieselCalculation> MobileOnRoadDieselCalculations { get; set; }
        public DbSet<MobileOnRoadGasolineCalculation> MobileOnRoadGasolineCalculations { get; set; }
        public DbSet<MobileOnRoadLPGCalculation> MobileOnRoadLPGCalculations { get; set; }
        public DbSet<CarbonContainingMaterialCalculation> CarbonContainingMaterialCalculations { get; set; }
        public DbSet<ElectricityCalculation> ElectricityCalculations { get; set; }

        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<BaseEntity>();

            foreach (var entry in entries)
            {
                DateTime Now = DateTime.Now;

                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = Now;
                        entry.Entity.IsDeleted = false;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = Now;

                        entry.Property(nameof(BaseEntity.CreatedAt)).IsModified = false;

                        // SoftDelete
                        if (entry.Property(nameof(BaseEntity.IsDeleted)).IsModified && entry.Entity.IsDeleted)
                        {
                            entry.Entity.DeletedDate = Now;
                            entry.Property(nameof(BaseEntity.DeletedDate)).IsModified = true;
                        }
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
