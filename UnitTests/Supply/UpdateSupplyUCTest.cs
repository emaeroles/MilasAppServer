using Application.DTOs.Supply;
using Application.Entities;
using Application.Enums;
using Application.Interfaces._01_Common;
using Application.UseCases.Supply;
using AutoMapper;
using Moq;

namespace UnitTests.Supply
{
    [TestClass]
    public class UpdateSupplyUCTest
    {
        [TestMethod]
        public void UpdateSupply_ShouldReturnSuccsessWithData()
        {
            // Arrange
            Mock<IUpdateRepo<SupplyEntity>> updateRepo = new Mock<IUpdateRepo<SupplyEntity>>();
            Mock<IMapper> mapper = new Mock<IMapper>();

            SupplyEntity supplyEntity = new SupplyEntity();
            UpdateSupplyInput updateSupplyInput = new UpdateSupplyInput();

            mapper.Setup(m => m.Map<SupplyEntity>(updateSupplyInput)).Returns(supplyEntity);
            updateRepo.Setup(r => r.UpdateAsync(supplyEntity)).ReturnsAsync(true);

            UpdateSupplyUseCase updateSupplyUseCase = new UpdateSupplyUseCase(updateRepo.Object, mapper.Object);

            ResultState resultState = ResultState.Success;

            // Act
            var result = updateSupplyUseCase.Execute(updateSupplyInput);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
            Assert.IsNull(result.Result.Data);
        }

        [TestMethod]
        public void UpdateSupply_ShouldReturnNotFoundWithNullData()
        {
            // Arrange
            Mock<IUpdateRepo<SupplyEntity>> updateSupplyRepo = new Mock<IUpdateRepo<SupplyEntity>>();
            Mock<IMapper> mapper = new Mock<IMapper>();

            SupplyEntity supplyEntity = new SupplyEntity();
            UpdateSupplyInput updateSupplyInput = new UpdateSupplyInput();

            mapper.Setup(m => m.Map<SupplyEntity>(updateSupplyInput)).Returns(supplyEntity);
            updateSupplyRepo.Setup(r => r.UpdateAsync(supplyEntity)).ReturnsAsync(false);

            UpdateSupplyUseCase updateSupplyUseCase = new UpdateSupplyUseCase(updateSupplyRepo.Object, mapper.Object);

            ResultState resultState = ResultState.NotFound;

            // Act
            var result = updateSupplyUseCase.Execute(updateSupplyInput);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
            Assert.IsNull(result.Result.Data);
        }
    }
}
