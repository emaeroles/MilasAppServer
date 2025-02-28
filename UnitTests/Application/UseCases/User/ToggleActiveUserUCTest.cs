using Application.Entities;
using Application.Enums;
using Application.Interfaces._01_Common;
using Application.UseCases.User;
using Moq;

namespace UnitTests.User
{
    [TestClass]
    public class ToggleActiveUserUCTest
    {
        [TestMethod]
        public void ToggleActiveUser_ShouldReturnSuccess()
        {
            // Arrange
            Mock<IToggleActiveRepo<UserEntity>> toggleActiveUserRepo = new Mock<IToggleActiveRepo<UserEntity>>();
            int entityId = 1;

            toggleActiveUserRepo.Setup(r => r.ToggleActiveAsync(entityId)).ReturnsAsync(true);

            ToggleActiveUserUseCase toggleActiveUserUseCase = new ToggleActiveUserUseCase(toggleActiveUserRepo.Object);

            ResultState resultState = ResultState.Success;

            // Act
            var result = toggleActiveUserUseCase.Execute(entityId);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
        }

        [TestMethod]
        public void ToggleActiveUser_ShouldReturnNotFound()
        {
            // Arrange
            Mock<IToggleActiveRepo<UserEntity>> toggleActiveUserRepo = new Mock<IToggleActiveRepo<UserEntity>>();
            int entityId = 1;

            toggleActiveUserRepo.Setup(r => r.ToggleActiveAsync(entityId)).ReturnsAsync(false);

            ToggleActiveUserUseCase toggleActiveUserUseCase = new ToggleActiveUserUseCase(toggleActiveUserRepo.Object);

            ResultState resultState = ResultState.NotFound;

            // Act
            var result = toggleActiveUserUseCase.Execute(entityId);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
        }
    }
}
