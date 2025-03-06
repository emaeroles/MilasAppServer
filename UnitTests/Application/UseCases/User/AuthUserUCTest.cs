using Application.Entities;
using Application.Enums;
using Application.Interfaces.User;
using Application.UseCases.User;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace UnitTests.Application.UseCases.User
{
    [TestClass]
    public class AuthUserUCTest
    {
        [TestMethod]
        public void AuthUser_ShouldReturnAuthorized()
        {
            Mock<IGetByUsernameRepo> getByUsernameRepo = new Mock<IGetByUsernameRepo>();
            Mock<IPasswordHasher<UserEntity>> passwordHasher = new Mock<IPasswordHasher<UserEntity>>();

            UserEntity userEntity = new UserEntity();
            string username = "username";
            string password = "password";

            getByUsernameRepo.Setup(r => r.GetByUsernameAsync(username)).ReturnsAsync(userEntity);
            passwordHasher.Setup(p => p.VerifyHashedPassword(
                userEntity, userEntity.Password, password)).Returns(PasswordVerificationResult.Success);

            AuthUserUseCase authUserUseCase = new AuthUserUseCase(getByUsernameRepo.Object, passwordHasher.Object);

            ResultState resultState = ResultState.Authorized;

            // Act
            var result = authUserUseCase.Execute(username, password);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
        }

        [TestMethod]
        public void AuthUser_ShouldReturnUnauthorized()
        {
            Mock<IGetByUsernameRepo> getByUsernameRepo = new Mock<IGetByUsernameRepo>();
            Mock<IPasswordHasher<UserEntity>> passwordHasher = new Mock<IPasswordHasher<UserEntity>>();

            UserEntity userEntity = new UserEntity();
            string username = "username";
            string password = "password";

            getByUsernameRepo.Setup(r => r.GetByUsernameAsync(username)).ReturnsAsync(userEntity);
            passwordHasher.Setup(p => p.VerifyHashedPassword(
                userEntity, userEntity.Password, password)).Returns(PasswordVerificationResult.Failed);

            AuthUserUseCase authUserUseCase = new AuthUserUseCase(
                getByUsernameRepo.Object, passwordHasher.Object);

            ResultState resultState = ResultState.Unauthorized;

            // Act
            var result = authUserUseCase.Execute(username, password);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
        }

        [TestMethod]
        public void AuthUser_ShouldReturnNotFound()
        {
            // Arrange
            Mock<IGetByUsernameRepo> getByUsernameRepo = new Mock<IGetByUsernameRepo>();
            Mock<IPasswordHasher<UserEntity>> passwordHasher = new Mock<IPasswordHasher<UserEntity>>();

            UserEntity? userEntity = null;
            string username = "username";
            string password = "password";

            getByUsernameRepo.Setup(r => r.GetByUsernameAsync(username)).ReturnsAsync(userEntity);

            AuthUserUseCase authUserUseCase = new AuthUserUseCase(
                getByUsernameRepo.Object, passwordHasher.Object);

            ResultState resultState = ResultState.NotFound;

            // Act
            var result = authUserUseCase.Execute(username, password);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
        }
    }
}
