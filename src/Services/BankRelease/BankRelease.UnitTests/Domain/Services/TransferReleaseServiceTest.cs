using BankRelease.Domain.Interfaces.Repository;
using System;
using Xunit;
using NSubstitute;
using BankRelease.Domain.Interfaces.Client;
using BankRelease.Domain.Services;
using System.Linq.Expressions;
using BankRelease.Domain.Entity;

namespace BankRelease.UnitTests.Domain.Services
{
    public class TransferReleaseServiceTest
    {
        private ITransferReleaseRepository transferReleaseRepositoryMock;
        private IAccountClient accountClientMock;
        private TransferReleaseService transferReleaseService;

        public TransferReleaseServiceTest()
        {
            transferReleaseRepositoryMock = Substitute.For<ITransferReleaseRepository>();
            accountClientMock = Substitute.For<IAccountClient>();

            transferReleaseService = new TransferReleaseService(transferReleaseRepositoryMock, accountClientMock);
        }

        [Fact]
        public void Add()
        {
            var transferReleaseMock = Substitute.For<TransferRelease>();
            var value = new decimal(100.00);

            transferReleaseMock.OriginAccount = 1;
            transferReleaseMock.DestinationAccount = 2;
            transferReleaseMock.Value = value;

            transferReleaseService.Add(transferReleaseMock);

            Received.InOrder(() => {
                accountClientMock.CheckingAccountDebit(transferReleaseMock.OriginAccount, transferReleaseMock.Value);
                accountClientMock.CheckingAccountCredit(transferReleaseMock.DestinationAccount, transferReleaseMock.Value);
                transferReleaseRepositoryMock.Add(transferReleaseMock);
            });
        }

        [Fact]
        public void All()
        {
            transferReleaseService.All();

            transferReleaseRepositoryMock.Received().All();
        }

        [Fact]
        public void Find()
        {
            Expression<Func<TransferRelease, bool>> Filter = x => x.Value > new decimal(10.00);

            transferReleaseRepositoryMock.Find(Filter);

            transferReleaseRepositoryMock.Received().Find(Filter);
        }

        [Fact]
        public void FindById()
        {
            var id = 10;
            transferReleaseService.FindById(id);

            transferReleaseRepositoryMock.Received().FindById(id);
        }
    }
}
