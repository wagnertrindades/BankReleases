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
            checkingAccountService.Add(checkingAccountMock);

            checkingAccountRepositoryMock.Received().Add(checkingAccountMock);
        }

        [Fact]
        public void Remove()
        {
            checkingAccountService.Remove(checkingAccountMock);

            checkingAccountRepositoryMock.Received().Remove(checkingAccountMock);
        }

        [Fact]
        public void Update()
        {
            checkingAccountService.Update(checkingAccountMock);

            checkingAccountRepositoryMock.Received().Update(checkingAccountMock);
        }

        [Fact]
        public void All()
        {
            checkingAccountService.All();

            checkingAccountRepositoryMock.Received().All();
        }

        [Fact]
        public void Find()
        {

            Expression<Func<CheckingAccount, bool>> Filter = x => x.Balance > new decimal(10.00);

            checkingAccountService.Find(Filter);

            checkingAccountRepositoryMock.Received().Find(Filter);
        }

        [Fact]
        public void FindById()
        {
            var id = 1;
            checkingAccountService.FindById(id);

            checkingAccountRepositoryMock.Received().FindById(id);
        }

        [Fact]
        public void Credit_when_value_less_than_zero()
        {
            var value = new decimal(-10.00);

            Assert.Throws<InvalidOperationException>(
                () => checkingAccountService.Credit(checkingAccountMock, value)
            );
        }

        [Fact]
        public void Credit_when_value_bigger_than_zero()
        {
            var value = new decimal(10.00);

            checkingAccountService.Credit(checkingAccountMock, value);

            Received.InOrder(() => {
                checkingAccountMock.Credit(value);
                checkingAccountRepositoryMock.Update(checkingAccountMock);
            });
        }

        [Fact]
        public void Debit_when_value_less_than_zero()
        {
            var value = new decimal(-10.00);

            Assert.Throws<InvalidOperationException>(
                () => checkingAccountService.Debit(checkingAccountMock, value)
            );
        }

        [Fact]
        public void Debit_when_value_bigger_than_balance()
        {
            var value = new decimal(100.00);

            Assert.Throws<InvalidOperationException>(
                () => checkingAccountService.Debit(checkingAccountMock, value)
            );
        }

        [Fact]
        public void Debit_when_value_bigger_than_zero_and_balance()
        {
            checkingAccountMock.Balance.Returns(new decimal(20.00));
            var value = new decimal(10.00);

            checkingAccountService.Debit(checkingAccountMock, value);

            Received.InOrder(() => {
                checkingAccountMock.Debit(value);
                checkingAccountRepositoryMock.Update(checkingAccountMock);
            });
        }
    }
}
