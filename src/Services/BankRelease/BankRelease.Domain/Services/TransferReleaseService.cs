using BankRelease.Domain.Entity;
using BankRelease.Domain.Interfaces.Client;
using BankRelease.Domain.Interfaces.Repository;
using BankRelease.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BankRelease.Domain.Services
{
    public class TransferReleaseService : ITransferReleaseService
    {
        private readonly ITransferReleaseRepository _transferReleaseRepository;
        private readonly IAccountClient _accountClient;

        public TransferReleaseService(ITransferReleaseRepository transferReleaseRepository, IAccountClient accountClient)
        {
            _transferReleaseRepository = transferReleaseRepository;
            _accountClient = accountClient;
        }

        public TransferRelease Add(TransferRelease entity)
        {
            _accountClient.CheckingAccountDebit(entity.OriginAccount, entity.Value);
            _accountClient.CheckingAccountCredit(entity.DestinationAccount, entity.Value);
            return _transferReleaseRepository.Add(entity);
        }

        public IEnumerable<TransferRelease> All()
        {
            return _transferReleaseRepository.All();
        }

        public IEnumerable<TransferRelease> Find(Expression<Func<TransferRelease, bool>> predicate)
        {
            return _transferReleaseRepository.Find(predicate);
        }

        public TransferRelease FindById(int id)
        {
            return _transferReleaseRepository.FindById(id);
        }
    }
}
