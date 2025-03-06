using Application.DTOs.User;
using Application.Entities;
using Application.Enums;
using Application.Interfaces._01_Common;
using Application.Interfaces.User;
using Application.UseCases.User;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace UnitTests.Application.UseCases.User
{
    [TestClass]
    public class AddUserUCTest
    {
        [TestMethod]
        public void AddUser_ShouldReturnCreated()
        {
            // Arrange
            Mock<IAddRepo<UserEntity>> addUserRepo = new Mock<IAddRepo<UserEntity>>();
            Mock<IGetByUsernameRepo> getByUsernameRepo = new Mock<IGetByUsernameRepo>();
            Mock<IPasswordHasher<UserEntity>> passwordHasher = new Mock<IPasswordHasher<UserEntity>>();
            Mock<IMapper> mapper = new Mock<IMapper>();

            AddUserInput addUserInput = new AddUserInput();
            UserEntity? userEntityExist = null;
            UserEntity userEntity = new UserEntity();

            getByUsernameRepo.Setup(r => r.GetByUsernameAsync(addUserInput.Username))
                .ReturnsAsync(userEntityExist);
            mapper.Setup(m => m.Map<UserEntity>(addUserInput)).Returns(userEntity);
            addUserRepo.Setup(r => r.AddAsync(userEntity)).ReturnsAsync(true);

            AddUserUseCase addUserUseCase = new AddUserUseCase(
                addUserRepo.Object, getByUsernameRepo.Object, passwordHasher.Object, mapper.Object);

            ResultState resultState = ResultState.Created;

            // Act
            var result = addUserUseCase.Execute(addUserInput);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
        }

        [TestMethod]
        public void AddUser_ShouldReturnConflict()
        {
            // Arrange
            Mock<IAddRepo<UserEntity>> addUserRepo = new Mock<IAddRepo<UserEntity>>();
            Mock<IGetByUsernameRepo> getByUsernameRepo = new Mock<IGetByUsernameRepo>();
            Mock<IPasswordHasher<UserEntity>> passwordHasher = new Mock<IPasswordHasher<UserEntity>>();
            Mock<IMapper> mapper = new Mock<IMapper>();

            AddUserInput addUserInput = new AddUserInput();
            UserEntity userEntityExist = new UserEntity();

            getByUsernameRepo.Setup(r => r.GetByUsernameAsync(addUserInput.Username))
                .ReturnsAsync(userEntityExist);

            AddUserUseCase addUserUseCase = new AddUserUseCase(
                addUserRepo.Object, getByUsernameRepo.Object, passwordHasher.Object, mapper.Object);

            ResultState resultState = ResultState.Conflict;

            // Act
            var result = addUserUseCase.Execute(addUserInput);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
        }
    }
}
