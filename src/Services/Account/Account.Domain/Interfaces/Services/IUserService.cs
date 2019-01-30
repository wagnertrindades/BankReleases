using Account.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Account.Domain.Interfaces.Services
{
    public interface IUserService
    {
        User Add(User entity);
        void Update(User entity);
        void Remove(User entity);

        IEnumerable<User> All();
        User FindById(int id);
        IEnumerable<User> Find(Expression<Func<User, bool>> predicate);
    }
}
