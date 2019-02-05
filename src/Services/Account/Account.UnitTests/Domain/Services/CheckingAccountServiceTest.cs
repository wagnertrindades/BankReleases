using Account.Domain.Entity;
using Account.Domain.Services;
using Account.Infrastructure.Data;
using Account.Infrastructure.Repository;
using System;
using Xunit;
using NSubstitute;
using Account.Domain.Interfaces.Repository;
using System.Linq.Expressions;

namespace Account.UnitTests.Domain.Services
{
    public class CheckingAccountServiceTest
    {
        private CheckingAccount checkingAccountMock;
        private ICheckingAccountRepository checkingAccountRepositoryMock;
        private CheckingAccountService checkingAccountService;

        public CheckingAccountServiceTest()
        {
            checkingAccountMock = Substitute.For<CheckingAccount>();
            checkingAccountRepositoryMock = Substitute.For<ICheckingAccountRepository>();

            checkingAccountService = new CheckingAccountService(checkingAccountRepositoryMock);
        }

        [Fact]
        public void Add()
        {
            //Act
            checkingAccountService.Add(checkingAccountMock);

            //Assert
            checkingAccountRepositoryMock.Received().Add(checkingAccountMock);
        }

        [Fact]
        public void Remove()
        {
            //Act
            checkingAccountService.Remove(checkingAccountMock);

            //Assert
            checkingAccountRepositoryMock.Received().Remove(checkingAccountMock);
        }

        [Fact]
        public void Update()
        {
            //Act
            checkingAccountService.Update(checkingAccountMock);

            //Assert
            checkingAccountRepositoryMock.Received().Update(checkingAccountMock);
        }

        [Fact]
        public void All()
        {
            //Act
            checkingAccountService.All();

            //Assert
            checkingAccountRepositoryMock.Received().All();
        }

        [Fact]
        public void Find()
        {
            //Arrange
            Expression<Func<CheckingAccount, bool>> Filter = x => x.Balance > new decimal(10.00);

            //Act
            checkingAccountService.Find(Filter);

            //Assert
            checkingAccountRepositoryMock.Received().Find(Filter);
        }

        [Fact]
        public void FindById()
        {
            //Arrange
            var id = 1;

            //Act
            checkingAccountService.FindById(id);

            //Assert
            checkingAccountRepositoryMock.Received().FindById(id);
        }

        [Fact]
        public void Credit_when_value_less_than_zero()
        {
            //Arrange
            var value = new decimal(-10.00);

            //Assert
            Assert.Throws<InvalidOperationException>(
                //Act
                () => checkingAccountService.Credit(checkingAccountMock, value)
            );
        }

        [Fact]
        public void Credit_when_value_bigger_than_zero()
        {
            //Arrange
            var value = new decimal(10.00);

            //Act
            checkingAccountService.Credit(checkingAccountMock, value);

            //Assert
            Received.InOrder(() => {
                checkingAccountMock.Credit(value);
                checkingAccountRepositoryMock.Update(checkingAccountMock);
            });
        }

        [Fact]
        public void Debit_when_value_less_than_zero()
        {
            //Arrange
            var value = new decimal(-10.00);

            //Assert
            Assert.Throws<InvalidOperationException>(
                //Act
                () => checkingAccountService.Debit(checkingAccountMock, value)
            );
        }

        [Fact]
        public void Debit_when_value_bigger_than_balance()
        {
            //Arrange
            var value = new decimal(100.00);

            //Assert
            Assert.Throws<InvalidOperationException>(
                //Act
                () => checkingAccountService.Debit(checkingAccountMock, value)
            );
        }

        [Fact]
        public void Debit_when_value_bigger_than_zero_and_balance()
        {
            //Arrange
            checkingAccountMock.Balance.Returns(new decimal(20.00));
            var value = new decimal(10.00);
            
            //Act
            checkingAccountService.Debit(checkingAccountMock, value);

            //Assert
            Received.InOrder(() => {
                checkingAccountMock.Debit(value);
                checkingAccountRepositoryMock.Update(checkingAccountMock);
            });
        }
    }
}
