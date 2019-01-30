using Account.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Account.Infrastructure.EntityConfig
{
    public class CheckingAccountMap : IEntityTypeConfiguration<CheckingAccount>
    {
        public void Configure(EntityTypeBuilder<CheckingAccount> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Balance)
                .HasDefaultValue(0.00);
        }
    }
}
