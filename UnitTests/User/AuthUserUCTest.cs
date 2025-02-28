using Application.Entities;
using Application.Enums;
using Application.Interfaces.User;
using Application.UseCases.User;
using AutoMapper;
using Moq;

namespace UnitTests.User
{
    [TestClass]
    public class AuthUserUCTest
    {
        [TestMethod]
        public void AuthUser_ShouldReturnSuccessWithData()
        {

        }

        [TestMethod]
        public void AuthUser_ShouldReturnNotFoundWithNullData()
        {
            // Arrange
            Mock<IGetByUsernameRepo> getByUsernameRepo = new Mock<IGetByUsernameRepo>();
            Mock<IMapper> mapper = new Mock<IMapper>();

            UserEntity userEntity = new UserEntity();
            userEntity.Id = 0;
            string username = "username";
            string password = "password";

            getByUsernameRepo.Setup(r => r.GetByUsernameAsync(username)).ReturnsAsync(userEntity);

            AuthUserUseCase authUserUseCase = new AuthUserUseCase(getByUsernameRepo.Object);

            ResultState resultState = ResultState.NotFound;

            // Act
            var result = authUserUseCase.Execute(username, password);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
            Assert.IsNull(result.Result.Data);
        }
    }
}
