using Account.Api.Controllers;
using Account.Domain.Entity;
using Account.Domain.Interfaces.Services;
using Account.Domain.ValueObject;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Account.UnitTests.Application.Controllers
{
    public class CheckingAccountControllerTest
    {
        private ICheckingAccountService _checkingAccountServiceMock;
        private CheckingAccountController _checkingAccountController;

        public CheckingAccountControllerTest()
        {
            _checkingAccountServiceMock = Substitute.For<ICheckingAccountService>();

            _checkingAccountController = new CheckingAccountController(_checkingAccountServiceMock);
        }

        [Fact]
        public void GetCheckingAccounts_on_success()
        {
            //Act
            var result = _checkingAccountController.GetCheckingAccounts();

            //Assert
            Assert.IsType<List<CheckingAccount>>(result.Value);
        }

        [Fact]
        public void GetById_on_success()
        {
            //Arrange
            var checkingAccount = new CheckingAccount();
            var id = 1;
            _checkingAccountServiceMock.FindById(id).Returns(checkingAccount);

            //Act
            var result = _checkingAccountController.GetById(id);
            var okResult = result.Result as OkObjectResult;

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.IsType<CheckingAccount>(okResult.Value);
        }

        [Fact]
        public void GetById_when_not_found_checking_account()
        {
            //Arrange
            var id = 1;
            _checkingAccountServiceMock.FindById(id).ReturnsNull();

            //Act
            var result = _checkingAccountController.GetById(id);

            //Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void Post_returns_added_checking_account()
        {
            //Arrange
            var checkingAccount = new CheckingAccount();

            //Act
            var result = _checkingAccountController.Post(checkingAccount);
            var createdAtActionResult = result.Result as CreatedAtActionResult;

            //Assert
            Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.IsType<CheckingAccount>(createdAtActionResult.Value);
        }

        [Fact]
        public void Put_on_success()
        {
            //Arrange
            var id = 1;
            var checkingAccount = new CheckingAccount();
            checkingAccount.Id = id;
            
            //Act
            var result = _checkingAccountController.Put(id, checkingAccount);

            //Assert
            _checkingAccountServiceMock.Received().Update(checkingAccount);
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void Put_when_url_id_not_equal_checking_account_id()
        {
            //Arrange
            var checkingAccount = new CheckingAccount();
            checkingAccount.Id = 2;

            //Act
            var result = _checkingAccountController.Put(1, checkingAccount);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void Delete_when_found_checking_account()
        {
            //Arrange
            var id = 1;
            var checkingAccount = new CheckingAccount();
            _checkingAccountServiceMock.FindById(id).Returns(checkingAccount);

            //Act
            var result = _checkingAccountController.Delete(id);

            //Assert
            _checkingAccountServiceMock.Received().Remove(checkingAccount);
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void Delete_when_not_found_checking_account()
        {
            //Arrange
            var id = 1;
            _checkingAccountServiceMock.FindById(id).ReturnsNull();

            //Act
            var result = _checkingAccountController.Delete(id);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void PostCredit_on_success()
        {
            //Arrange
            var id = 1;
            var checkingAccount = new CheckingAccount();
            var money = new Money();

            _checkingAccountServiceMock.FindById(id).Returns(checkingAccount);

            //Act
            var result = _checkingAccountController.PostCredit(id, money);

            //Assert
            _checkingAccountServiceMock.Received().Credit(checkingAccount, money.Value);
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void PostCredit_when_not_found_checking_account()
        {
            //Arrange
            var id = 1;
            var money = new Money();
            _checkingAccountServiceMock.FindById(id).ReturnsNull();

            //Act
            var result = _checkingAccountController.PostCredit(id, money);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void PostCredit_when_has_exception_in_credit_operation()
        {
            //Arrange
            var id = 1;
            var checkingAccount = new CheckingAccount();
            var money = new Money();

            _checkingAccountServiceMock.FindById(id).Returns(checkingAccount);
            _checkingAccountServiceMock
                .When(c => c.Credit(checkingAccount, money.Value))
                .Do(x => { throw new Exception(); });

            //Act
            var result = _checkingAccountController.PostCredit(id, money);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void PostDebit_on_success()
        {
            //Arrange
            var id = 1;
            var checkingAccount = new CheckingAccount();
            var money = new Money();

            _checkingAccountServiceMock.FindById(id).Returns(checkingAccount);

            //Act
            var result = _checkingAccountController.PostDebit(id, money);

            //Assert
            _checkingAccountServiceMock.Received().Debit(checkingAccount, money.Value);
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void PostDebit_when_not_found_checking_account()
        {
            //Arrange
            var id = 1;
            var money = new Money();
            _checkingAccountServiceMock.FindById(id).ReturnsNull();

            //Act
            var result = _checkingAccountController.PostDebit(id, money);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void PostDebit_when_has_exception_in_credit_operation()
        {
            //Arrange
            var id = 1;
            var checkingAccount = new CheckingAccount();
            var money = new Money();

            _checkingAccountServiceMock.FindById(id).Returns(checkingAccount);
            _checkingAccountServiceMock
                .When(c => c.Debit(checkingAccount, money.Value))
                .Do(x => { throw new Exception(); });

            //Act
            var result = _checkingAccountController.PostDebit(id, money);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
