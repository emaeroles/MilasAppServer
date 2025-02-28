using Application.Entities;
using Application.Enums;
using Application.Interfaces._01_Common;
using Application.UseCases.Supply;
using Moq;

namespace UnitTests.Supply
{
    [TestClass]
    public class ToggleActiveSupplyUCTest
    {
        [TestMethod]
        public void ToggleActiveSupply_ShouldReturnSuccess()
        {
            // Arrange
            Mock<IToggleActiveRepo<SupplyEntity>> toggleActiveSupplyRepo = new Mock<IToggleActiveRepo<SupplyEntity>>();
            int entityId = 1;

            toggleActiveSupplyRepo.Setup(r => r.ToggleActiveAsync(entityId)).ReturnsAsync(true);

            ToggleActiveSupplyUseCase toggleActiveSupplyUseCase = new ToggleActiveSupplyUseCase(toggleActiveSupplyRepo.Object);

            ResultState resultState = ResultState.Success;

            // Act
            var result = toggleActiveSupplyUseCase.Execute(entityId);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
        }

        [TestMethod]
        public void ToggleActiveSupply_ShouldReturnNotFound()
        {
            // Arrange
            Mock<IToggleActiveRepo<SupplyEntity>> toggleActiveSupplyRepo = new Mock<IToggleActiveRepo<SupplyEntity>>();
            int entityId = 1;

            toggleActiveSupplyRepo.Setup(r => r.ToggleActiveAsync(entityId)).ReturnsAsync(false);

            ToggleActiveSupplyUseCase toggleActiveSupplyUseCase = new ToggleActiveSupplyUseCase(toggleActiveSupplyRepo.Object);

            ResultState resultState = ResultState.NotFound;

            // Act
            var result = toggleActiveSupplyUseCase.Execute(entityId);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
        }
    }
}
