using BankRelease.Domain.Entity;
using BankRelease.Domain.Interfaces.Repository;
using BankRelease.Infrastructure.Data;


namespace BankRelease.Infrastructure.Repository
{
    public class TransferReleaseRepository : EFRepository<TransferRelease>, ITransferReleaseRepository
    {
        public TransferReleaseRepository(BankReleaseContext dbContext) : base(dbContext)
        {

        }
    }
}
