using BankRelease.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BankRelease.Domain.Interfaces.Services
{
    public interface ITransferReleaseService
    {
        Task<TransferRelease> Add(TransferRelease entity);

        IEnumerable<TransferRelease> All();
        TransferRelease FindById(int id);
        IEnumerable<TransferRelease> Find(Expression<Func<TransferRelease, bool>> predicate);
    }
}
