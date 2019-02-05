using BankRelease.Api.Controllers;
using BankRelease.Domain.Entity;
using BankRelease.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankRelease.UnitTests.Application.Controllers
{
    public class TransferReleaseControllerTest
    {
        private ITransferReleaseService _transferReleaseServiceMock;
        private TransferReleaseController _transferReleaseController;

        public TransferReleaseControllerTest()
        {
            _transferReleaseServiceMock = Substitute.For<ITransferReleaseService>();

            _transferReleaseController = new TransferReleaseController(_transferReleaseServiceMock);
        }

        [Fact]
        public void GetTransferReleases_on_success()
        {
            //Act
            var result = _transferReleaseController.GetTransferReleases();

            //Assert
            Assert.IsType<List<TransferRelease>>(result.Value);
        }

        [Fact]
        public void GetById_on_success()
        {
            //Arrange
            var transferRelease = new TransferRelease();
            var id = 1;
            _transferReleaseServiceMock.FindById(id).Returns(transferRelease);

            //Act
            var result = _transferReleaseController.GetById(id);
            var okResult = result.Result as OkObjectResult;

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.IsType<TransferRelease>(okResult.Value);
        }

        [Fact]
        public void GetById_when_not_found_checking_account()
        {
            //Arrange
            var id = 1;
            _transferReleaseServiceMock.FindById(id).ReturnsNull();

            //Act
            var result = _transferReleaseController.GetById(id);

            //Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void Post_on_success()
        {
            //Arrange
            var transferRelease = new TransferRelease();

            //Act
            var result = _transferReleaseController.Post(transferRelease);
            var createdAtActionResult = result.Result.Result as CreatedAtActionResult;

            //Assert
            _transferReleaseServiceMock.Received().Add(transferRelease);
            Assert.IsType<CreatedAtActionResult>(result.Result.Result);
            Assert.IsType<TransferRelease>(createdAtActionResult.Value);
        }

        [Fact]
        public void Post_when_has_exception_in_transfer_release_add_operation()
        {
            //Arrange
            var transferRelease = new TransferRelease();

            _transferReleaseServiceMock
                .When(t => t.Add(transferRelease))
                .Do(x => { throw new Exception(); });

            //Act
            var result = _transferReleaseController.Post(transferRelease);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result.Result.Result);
        }
    }
}
