using BankRelease.Domain.Entity;
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

        public TransferReleaseService(ITransferReleaseRepository transferReleaseRepository)
        {
            _transferReleaseRepository = transferReleaseRepository;
        }

        public TransferRelease Add(TransferRelease entity)
        {

            return _transferReleaseRepository.Add(entity);
        }

        public void Update(TransferRelease entity)
        {
            _transferReleaseRepository.Update(entity);
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
