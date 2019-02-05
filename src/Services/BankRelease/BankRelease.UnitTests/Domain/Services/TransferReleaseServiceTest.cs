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
        public async void Add()
        {
            //Arrange
            var transferReleaseMock = Substitute.For<TransferRelease>();
            var value = new decimal(100.00);

            transferReleaseMock.OriginAccount = 1;
            transferReleaseMock.DestinationAccount = 2;
            transferReleaseMock.Value = value;

            //Act
            await transferReleaseService.Add(transferReleaseMock);

            //Assert
            Received.InOrder(() => {
                accountClientMock.CheckingAccountDebit(transferReleaseMock);
                accountClientMock.CheckingAccountCredit(transferReleaseMock);
                transferReleaseRepositoryMock.Add(transferReleaseMock);
            });
        }

        [Fact]
        public void All()
        {
            //Act
            transferReleaseService.All();

            //Assert
            transferReleaseRepositoryMock.Received().All();
        }

        [Fact]
        public void Find()
        {
            //Arrange
            Expression<Func<TransferRelease, bool>> Filter = x => x.Value > new decimal(10.00);
            
            //Act
            transferReleaseRepositoryMock.Find(Filter);
            
            //Assert
            transferReleaseRepositoryMock.Received().Find(Filter);
        }

        [Fact]
        public void FindById()
        {
            //Arrange
            var id = 10;

            //Act
            transferReleaseService.FindById(id);
            
            //Assert
            transferReleaseRepositoryMock.Received().FindById(id);
        }
    }
}
