using BankRelease.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankRelease.Infrastructure.EntityConfig
{
    public class TransferReleaseMap : IEntityTypeConfiguration<TransferRelease>
    {
        public void Configure(EntityTypeBuilder<TransferRelease> builder)
        {
            builder.HasKey(e => e.Id);
        }
    }
}
