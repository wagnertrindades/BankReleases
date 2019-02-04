using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BankRelease.Domain.Interfaces.Client
{
    public interface IAccountClient
    {
        Task<Uri> CheckingAccountDebit(int accountId, decimal value);
        Task<Uri> CheckingAccountCredit(int accountId, decimal value);
    }
}
