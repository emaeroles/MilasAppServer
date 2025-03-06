using Application.Entities;
using Application.Enums;
using Application.Interfaces._01_Common;
using Application.UseCases.User;
using Moq;

namespace UnitTests.Application.UseCases.User
{
    [TestClass]
    public class ToggleActiveUserUCTest
    {
        [TestMethod]
        public void ToggleActiveUser_ShouldReturnUpdated()
        {
            // Arrange
            Mock<IUpdateRepo<UserEntity>> updateRepo = new Mock<IUpdateRepo<UserEntity>>();
            Mock<IGetByIdRepo<UserEntity>> getByIdRepo = new Mock<IGetByIdRepo<UserEntity>>();
            UserEntity userEntity = new UserEntity();
            
            Guid entityId = Guid.NewGuid();

            getByIdRepo.Setup(r => r.GetByIdAsync(entityId)).ReturnsAsync(userEntity);
            updateRepo.Setup(r => r.UpdateAsync(userEntity)).ReturnsAsync(true);

            ToggleActiveUserUseCase toggleActiveUserUseCase = new ToggleActiveUserUseCase(
                updateRepo.Object, getByIdRepo.Object);

            ResultState resultState = ResultState.Updated;

            // Act
            var result = toggleActiveUserUseCase.Execute(entityId);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
        }

        [TestMethod]
        public void ToggleActiveUser_ShouldReturnNotUpdate()
        {
            // Arrange
            Mock<IUpdateRepo<UserEntity>> updateRepo = new Mock<IUpdateRepo<UserEntity>>();
            Mock<IGetByIdRepo<UserEntity>> getByIdRepo = new Mock<IGetByIdRepo<UserEntity>>();
            UserEntity userEntity = new UserEntity();
            Guid entityId = Guid.NewGuid();

            getByIdRepo.Setup(r => r.GetByIdAsync(entityId)).ReturnsAsync(userEntity);
            updateRepo.Setup(r => r.UpdateAsync(userEntity)).ReturnsAsync(false);

            ToggleActiveUserUseCase toggleActiveUserUseCase = new ToggleActiveUserUseCase(
                updateRepo.Object, getByIdRepo.Object);

            ResultState resultState = ResultState.NotUpdated;

            // Act
            var result = toggleActiveUserUseCase.Execute(entityId);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
        }
    }
}
