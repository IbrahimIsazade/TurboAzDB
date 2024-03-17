using Microsoft.EntityFrameworkCore;
using TurboAzDB.Models.Entities;

namespace TurboAzDB.Models.DataContexts
{
    public class TurboAzDbContext : DbContext
    {
        public TurboAzDbContext() : base() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Data Source=.;Database=TurboAzDb;User Id=sa;Password=!Dquery20@4;Encrypt=false;App=Orm",
                opt =>
                {
                    opt.MigrationsHistoryTable("MigrationHistory");
                });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TurboAzDbContext).Assembly);

            // one-to-many Announcement and Brand
            modelBuilder.Entity<Announcement>()
                .HasOne<Brand>()
                .WithMany()
                .HasForeignKey(a => a.BrandId)
                .HasPrincipalKey(a => a.Id)
                .OnDelete(DeleteBehavior.NoAction);

            // one-to-many Announcement and Model
            modelBuilder.Entity<Announcement>()
                .HasOne<Model>()
                .WithMany()
                .HasForeignKey(a => a.ModelId)
                .HasPrincipalKey(a => a.Id)
                .OnDelete(DeleteBehavior.NoAction);

            // one-to-many Model and Brand
            modelBuilder.Entity<Model>()
                .HasOne<Brand>()
                .WithMany()
                .HasForeignKey(m => m.BrandId)
                .HasPrincipalKey(a => a.Id)
                .OnDelete(DeleteBehavior.NoAction);

        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
    }
}