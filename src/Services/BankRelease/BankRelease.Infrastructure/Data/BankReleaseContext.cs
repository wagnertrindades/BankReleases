using BankRelease.Domain.Entity;
using BankRelease.Infrastructure.EntityConfig;
using Microsoft.EntityFrameworkCore;

namespace BankRelease.Infrastructure.Data
{
    public class BankReleaseContext : DbContext
    {
        public BankReleaseContext(DbContextOptions<BankReleaseContext> options) : base(options)
        {

        }

        public DbSet<TransferRelease> TransferReleases { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TransferRelease>().ToTable("TransferRelease");
            modelBuilder.ApplyConfiguration(new TransferReleaseMap());
        }
    }
}
