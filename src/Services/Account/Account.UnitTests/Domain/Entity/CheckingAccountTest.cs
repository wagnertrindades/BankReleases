using Xunit;
using NSubstitute;
using Account.Domain.Entity;

namespace Account.UnitTests.Domain.Entity
{
    public class CheckingAccountTest
    {

        [Fact]
        public void Credit()
        {
            var checkingAccount = new CheckingAccount();
            var value = new decimal(20.00);

            checkingAccount.Credit(value);

            Assert.Equal(value, checkingAccount.Balance);
        }

        [Fact]
        public void Debit()
        {
            var checkingAccount = new CheckingAccount();
            var value = new decimal(20.00);
            checkingAccount.Credit(new decimal(40.00));

            checkingAccount.Debit(value);

            Assert.Equal(value, checkingAccount.Balance);
        }
    }
}
