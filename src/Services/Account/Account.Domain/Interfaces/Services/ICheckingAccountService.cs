using Account.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Account.Domain.Interfaces.Services
{
    public interface ICheckingAccountService
    {
        CheckingAccount Add(CheckingAccount entity);
        void Update(CheckingAccount entity);
        void Remove(CheckingAccount entity);

        IEnumerable<CheckingAccount> All();
        CheckingAccount FindById(int id);
        IEnumerable<CheckingAccount> Find(Expression<Func<CheckingAccount, bool>> predicate);

        void Credit(CheckingAccount entity, decimal value);
        void Debit(CheckingAccount entity, decimal value);
    }
}
