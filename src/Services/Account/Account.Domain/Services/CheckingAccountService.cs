using Account.Domain.Entity;
using Account.Domain.Interfaces.Repository;
using Account.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Account.Domain.Services
{
    public class CheckingAccountService : ICheckingAccountService
    {
        private readonly ICheckingAccountRepository _checkingAccountRepository;

        public CheckingAccountService(ICheckingAccountRepository checkingAccountRepository)
        {
            _checkingAccountRepository = checkingAccountRepository;
        }

        public CheckingAccount Add(CheckingAccount entity)
        {
            return _checkingAccountRepository.Add(entity);
        }

        public void Remove(CheckingAccount entity)
        {
            _checkingAccountRepository.Remove(entity);
        }

        public void Update(CheckingAccount entity)
        {
            _checkingAccountRepository.Update(entity);
        }

        public IEnumerable<CheckingAccount> All()
        {
            return _checkingAccountRepository.All();
        }

        public IEnumerable<CheckingAccount> Find(Expression<Func<CheckingAccount, bool>> predicate)
        {
            return _checkingAccountRepository.Find(predicate);
        }

        public CheckingAccount FindById(int id)
        {
            return _checkingAccountRepository.FindById(id);
        }
        
        public void Credit(CheckingAccount entity, decimal value)
        {
            if(value < 0) { throw new InvalidOperationException("[value] cannot less then zero."); }

            entity.Credit(value);
            _checkingAccountRepository.Update(entity);
        }

        public void Debit(CheckingAccount entity, decimal value)
        {
            if (value < 0) { throw new InvalidOperationException("[value] cannot less then zero."); }
            if (value > entity.Balance) { throw new InvalidOperationException("[value] insufficient balance for debit."); }

            entity.Debit(value);
            _checkingAccountRepository.Update(entity);
        }
    }
}
