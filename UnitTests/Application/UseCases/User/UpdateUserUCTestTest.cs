using Application.DTOs.User;
using Application.Entities;
using Application.Enums;
using Application.Interfaces._01_Common;
using Application.UseCases.User;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace UnitTests.Application.UseCases.User
{
    [TestClass]
    public class UpdateUserUCTestTest
    {
        [TestMethod]
        public void UpdateUser_ShouldReturnUpdate()
        {
            // Arrange
            Mock<IUpdateRepo<UserEntity>> updateRepo = new Mock<IUpdateRepo<UserEntity>>();
            Mock<IGetByIdRepo<UserEntity>> getByIdRepo = new Mock<IGetByIdRepo<UserEntity>>();
            Mock<IPasswordHasher<UserEntity>> passwordHasher = new Mock<IPasswordHasher<UserEntity>>();

            UpdateUserInput updateUserInput = new UpdateUserInput();
            UserEntity userEntity = new UserEntity();

            getByIdRepo.Setup(r => r.GetByIdAsync(updateUserInput.Id)).ReturnsAsync(userEntity);
            updateRepo.Setup(r => r.UpdateAsync(userEntity)).ReturnsAsync(true);

            UpdateUserUseCase updateUserUseCase = new UpdateUserUseCase(
                updateRepo.Object, getByIdRepo.Object, passwordHasher.Object);

            ResultState resultState = ResultState.Updated;

            // Act
            var result = updateUserUseCase.Execute(updateUserInput);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
        }

        [TestMethod]
        public void UpdateUser_ShouldReturnNotUpdate()
        {
            // Arrange
            Mock<IUpdateRepo<UserEntity>> updateRepo = new Mock<IUpdateRepo<UserEntity>>();
            Mock<IGetByIdRepo<UserEntity>> getByIdRepo = new Mock<IGetByIdRepo<UserEntity>>();
            Mock<IPasswordHasher<UserEntity>> passwordHasher = new Mock<IPasswordHasher<UserEntity>>();

            UpdateUserInput updateUserInput = new UpdateUserInput();
            UserEntity userEntity = new UserEntity();

            getByIdRepo.Setup(r => r.GetByIdAsync(updateUserInput.Id)).ReturnsAsync(userEntity);
            updateRepo.Setup(r => r.UpdateAsync(userEntity)).ReturnsAsync(false);

            UpdateUserUseCase updateUserUseCase = new UpdateUserUseCase(
                updateRepo.Object, getByIdRepo.Object, passwordHasher.Object);

            ResultState resultState = ResultState.NotUpdated;

            // Act
            var result = updateUserUseCase.Execute(updateUserInput);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
        }
    }
}
