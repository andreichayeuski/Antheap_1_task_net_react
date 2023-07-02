using Antheap_1_task_net_react.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Antheap_1_task_net_react.Data.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<CompanyEntity> Companies { get; set; }
        public DbSet<PersonEntity> Persons { get; set; }
        public DbSet<RepresentativeEntity> Representatives { get; set; } 

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompanyEntity>()
                .HasMany(c => c.Representatives)
                .WithOne(r => r.Company)
                .HasForeignKey(r => r.CompanyId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PersonEntity>()
                .HasMany(p => p.Representatives)
                .WithOne(r => r.Person)
                .HasForeignKey(r => r.PersonId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RepresentativeEntity>()
                .HasKey(r => new { r.CompanyId, r.PersonId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
