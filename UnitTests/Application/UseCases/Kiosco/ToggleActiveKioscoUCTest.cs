using Application.Entities;
using Application.Enums;
using Application.Interfaces._01_Common;
using Application.UseCases.Kiosco;
using Moq;

namespace UnitTests.Kiosco
{
    [TestClass]
    public class ToggleActiveKioscoUCTest
    {
        [TestMethod]
        public void ToggleActiveKiosco_ShouldReturnSuccess()
        {
            // Arrange
            Mock<IToggleActiveRepo<KioscoEntity>> toggleActiveKioscoRepo = new Mock<IToggleActiveRepo<KioscoEntity>>();
            int entityId = 1;

            toggleActiveKioscoRepo.Setup(r => r.ToggleActiveAsync(entityId)).ReturnsAsync(true);

            ToggleActiveKioscoUseCase toggleActiveKioscoUseCase = new ToggleActiveKioscoUseCase(toggleActiveKioscoRepo.Object);

            ResultState resultState = ResultState.Success;

            // Act
            var result = toggleActiveKioscoUseCase.Execute(entityId);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
        }

        [TestMethod]
        public void ToggleActiveKiosco_ShouldReturnNotFound()
        {
            // Arrange
            Mock<IToggleActiveRepo<KioscoEntity>> toggleActiveKioscoRepo = new Mock<IToggleActiveRepo<KioscoEntity>>();
            int entityId = 1;

            toggleActiveKioscoRepo.Setup(r => r.ToggleActiveAsync(entityId)).ReturnsAsync(false);

            ToggleActiveKioscoUseCase toggleActiveKioscoUseCase = new ToggleActiveKioscoUseCase(toggleActiveKioscoRepo.Object);

            ResultState resultState = ResultState.NotFound;

            // Act
            var result = toggleActiveKioscoUseCase.Execute(entityId);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
        }
    }
}
