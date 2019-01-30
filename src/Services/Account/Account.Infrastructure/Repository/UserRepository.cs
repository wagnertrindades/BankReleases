using Account.Domain.Entity;
using Account.Domain.Interfaces.Repository;
using Account.Infrastructure.Data;

namespace Account.Infrastructure.Repository
{
    public class UserRepository : EFRepository<User>, IUserRepository
    {
        public UserRepository(AccountContext dbContext) : base(dbContext)
        {

        }
    }
}
