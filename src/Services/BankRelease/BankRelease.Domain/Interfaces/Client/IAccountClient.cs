using BankRelease.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BankRelease.Domain.Interfaces.Client
{
    public interface IAccountClient
    {
        Task<Uri> CheckingAccountDebit(TransferRelease transferRelease);
        Task<Uri> CheckingAccountCredit(TransferRelease transferRelease);
    }
}
