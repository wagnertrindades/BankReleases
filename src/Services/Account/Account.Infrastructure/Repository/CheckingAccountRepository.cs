using Account.Domain.Entity;
using Account.Domain.Interfaces.Repository;
using Account.Infrastructure.Data;

namespace Account.Infrastructure.Repository
{
    public class CheckingAccountRepository : EFRepository<CheckingAccount>, ICheckingAccountRepository
    {
        public CheckingAccountRepository(AccountContext dbContext) : base(dbContext)
        {

        }
    }
}
