using Account.Domain.Entity;
using Account.Infrastructure.EntityConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Account.Infrastructure.Data
{
    public class AccountContext : DbContext
    {
        public AccountContext(DbContextOptions<AccountContext> options) : base(options)
        {

        }

        public DbSet<CheckingAccount> CheckingAccounts { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CheckingAccount>().ToTable("CheckingAccount");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<User>().HasIndex(u => u.CPF).IsUnique();

            modelBuilder.ApplyConfiguration(new CheckingAccountMap());
            modelBuilder.ApplyConfiguration(new UserMap());
        }
    }
}
