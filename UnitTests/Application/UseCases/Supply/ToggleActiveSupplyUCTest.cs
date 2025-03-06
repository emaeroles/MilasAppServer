using Application.Entities;
using Application.Enums;
using Application.Interfaces._01_Common;
using Application.UseCases.Supply;
using Moq;

namespace UnitTests.Application.UseCases.Supply
{
    [TestClass]
    public class ToggleActiveSupplyUCTest
    {
        [TestMethod]
        public void ToggleActiveSupply_ShouldReturnUpdated()
        {
            // Arrange
            Mock<IUpdateRepo<SupplyEntity>> updateRepo = new Mock<IUpdateRepo<SupplyEntity>>();
            Mock<IGetByIdRepo<SupplyEntity>> getByIdRepo = new Mock<IGetByIdRepo<SupplyEntity>>();

            Guid entityId = Guid.NewGuid();
            SupplyEntity supplyEntity = new SupplyEntity();

            getByIdRepo.Setup(r => r.GetByIdAsync(entityId)).ReturnsAsync(supplyEntity);
            updateRepo.Setup(r => r.UpdateAsync(supplyEntity)).ReturnsAsync(true);

            ToggleActiveSupplyUseCase toggleActiveSupplyUseCase = new ToggleActiveSupplyUseCase(
                updateRepo.Object, getByIdRepo.Object);

            ResultState resultState = ResultState.Updated;

            // Act
            var result = toggleActiveSupplyUseCase.Execute(entityId);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
        }

        [TestMethod]
        public void ToggleActiveSupply_ShouldReturnNotFound()
        {
            // Arrange
            Mock<IUpdateRepo<SupplyEntity>> updateRepo = new Mock<IUpdateRepo<SupplyEntity>>();
            Mock<IGetByIdRepo<SupplyEntity>> getByIdRepo = new Mock<IGetByIdRepo<SupplyEntity>>();

            Guid entityId = Guid.NewGuid();
            SupplyEntity? supplyEntity = null;

            getByIdRepo.Setup(r => r.GetByIdAsync(entityId)).ReturnsAsync(supplyEntity);

            ToggleActiveSupplyUseCase toggleActiveSupplyUseCase = new ToggleActiveSupplyUseCase(
                updateRepo.Object, getByIdRepo.Object);

            ResultState resultState = ResultState.NotFound;

            // Act
            var result = toggleActiveSupplyUseCase.Execute(entityId);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
        }
    }
}
