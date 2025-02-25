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
        public void AuthUser_ShouldReturnAppResult()
        {
            // Arrange
            Mock<IGetByUsernameRepo> getByUsernameRepo = new Mock<IGetByUsernameRepo>();
            Mock<IMapper> mapper = new Mock<IMapper>();

            // Act
            AuthUserUseCase authUserUseCase = new AuthUserUseCase(getByUsernameRepo.Object);
            string username = "username";
            string password = "password";
            var result = authUserUseCase.Execute(username, password);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
