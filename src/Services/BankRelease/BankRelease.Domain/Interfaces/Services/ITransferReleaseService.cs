using BankRelease.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BankRelease.Domain.Interfaces.Services
{
    public interface ITransferReleaseService
    {
        TransferRelease Add(TransferRelease entity);
        void Update(TransferRelease entity);

        IEnumerable<TransferRelease> All();
        TransferRelease FindById(int id);
        IEnumerable<TransferRelease> Find(Expression<Func<TransferRelease, bool>> predicate);
    }
}
