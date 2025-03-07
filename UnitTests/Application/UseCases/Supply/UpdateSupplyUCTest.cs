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
            Mock<IGetByIdRepo<SupplyEntity>> getByIdSupplyRepo = new Mock<IGetByIdRepo<SupplyEntity>>();
            Mock<IGetByIdRepo<UomEntity>> getByIdUomRepo = new Mock<IGetByIdRepo<UomEntity>>();

            SupplyEntity supplyEntity = new SupplyEntity();
            UomEntity uomEntity = new UomEntity();
            UpdateSupplyInput updateSupplyInput = new UpdateSupplyInput();

            getByIdUomRepo.Setup(r => r.GetByIdAsync(updateSupplyInput.UomId)).ReturnsAsync(uomEntity);
            getByIdSupplyRepo.Setup(r => r.GetByIdAsync(updateSupplyInput.Id)).ReturnsAsync(supplyEntity);
            updateRepo.Setup(r => r.UpdateAsync(supplyEntity)).ReturnsAsync(true);

            UpdateSupplyUseCase updateSupplyUseCase = new UpdateSupplyUseCase(
                updateRepo.Object, getByIdSupplyRepo.Object, getByIdUomRepo.Object);

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
            Mock<IGetByIdRepo<SupplyEntity>> getByIdSupplyRepo = new Mock<IGetByIdRepo<SupplyEntity>>();
            Mock<IGetByIdRepo<UomEntity>> getByIdUomRepo = new Mock<IGetByIdRepo<UomEntity>>();

            SupplyEntity? supplyEntity = null;
            UomEntity uomEntity = new UomEntity();
            UpdateSupplyInput updateSupplyInput = new UpdateSupplyInput();

            getByIdUomRepo.Setup(r => r.GetByIdAsync(updateSupplyInput.UomId)).ReturnsAsync(uomEntity);
            getByIdSupplyRepo.Setup(r => r.GetByIdAsync(updateSupplyInput.Id)).ReturnsAsync(supplyEntity);

            UpdateSupplyUseCase updateSupplyUseCase = new UpdateSupplyUseCase(
                updateRepo.Object, getByIdSupplyRepo.Object, getByIdUomRepo.Object);

            ResultState resultState = ResultState.NotFound;

            // Act
            var result = updateSupplyUseCase.Execute(updateSupplyInput);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
        }
    }
}
