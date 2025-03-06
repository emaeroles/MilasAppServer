using Application.DTOs.Supply;
using Application.Entities;
using Application.Enums;
using Application.Interfaces._01_Common;
using Application.UseCases.Supply;
using Moq;

namespace UnitTests.Application.UseCases.Supply
{
    [TestClass]
    public class UpdateSupplyUCTest
    {
        [TestMethod]
        public void UpdateSupply_ShouldReturnUpdated()
        {
            // Arrange
            Mock<IUpdateRepo<SupplyEntity>> updateRepo = new Mock<IUpdateRepo<SupplyEntity>>();
            Mock<IGetByIdRepo<SupplyEntity>> getByIdRepo = new Mock<IGetByIdRepo<SupplyEntity>>();

            SupplyEntity supplyEntity = new SupplyEntity();
            UpdateSupplyInput updateSupplyInput = new UpdateSupplyInput();

            getByIdRepo.Setup(r => r.GetByIdAsync(updateSupplyInput.Id)).ReturnsAsync(supplyEntity);
            updateRepo.Setup(r => r.UpdateAsync(supplyEntity)).ReturnsAsync(true);

            UpdateSupplyUseCase updateSupplyUseCase = new UpdateSupplyUseCase(
                updateRepo.Object, getByIdRepo.Object);

            ResultState resultState = ResultState.Updated;

            // Act
            var result = updateSupplyUseCase.Execute(updateSupplyInput);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
        }

        [TestMethod]
        public void UpdateSupply_ShouldReturnNotFound()
        {
            // Arrange
            Mock<IUpdateRepo<SupplyEntity>> updateRepo = new Mock<IUpdateRepo<SupplyEntity>>();
            Mock<IGetByIdRepo<SupplyEntity>> getByIdRepo = new Mock<IGetByIdRepo<SupplyEntity>>();

            SupplyEntity? supplyEntity = null;
            UpdateSupplyInput updateSupplyInput = new UpdateSupplyInput();

            getByIdRepo.Setup(r => r.GetByIdAsync(updateSupplyInput.Id)).ReturnsAsync(supplyEntity);

            UpdateSupplyUseCase updateSupplyUseCase = new UpdateSupplyUseCase(
                updateRepo.Object, getByIdRepo.Object);

            ResultState resultState = ResultState.NotFound;

            // Act
            var result = updateSupplyUseCase.Execute(updateSupplyInput);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
        }
    }
}
