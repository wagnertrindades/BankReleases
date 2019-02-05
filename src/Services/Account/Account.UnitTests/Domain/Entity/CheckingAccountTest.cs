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
            //Arrange
            var checkingAccount = new CheckingAccount();
            var value = new decimal(20.00);

            //Act
            checkingAccount.Credit(value);

            //Assert
            Assert.Equal(value, checkingAccount.Balance);
        }

        [Fact]
        public void Debit()
        {
            //Arrange
            var checkingAccount = new CheckingAccount();
            var value = new decimal(20.00);
            checkingAccount.Credit(new decimal(40.00));

            //Act
            checkingAccount.Debit(value);

            //Assert
            Assert.Equal(value, checkingAccount.Balance);
        }
    }
}
