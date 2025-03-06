using Application.DTOs.Kiosco;
using Application.Entities;
using Application.Enums;
using Application.Interfaces._01_Common;
using Application.UseCases.Kiosco;
using Moq;

namespace UnitTests.Application.UseCases.Kiosco
{
    [TestClass]
    public class UpdateOrderUCTest
    {
        [TestMethod]
        public void UpdateOrder_ShouldReturnUpdated()
        {
            // Arrange
            Mock<IUpdateRepo<KioscoEntity>> updateRepo = new Mock<IUpdateRepo<KioscoEntity>>();
            Mock<IGetByIdRepo<KioscoEntity>> getByIdRepo = new Mock<IGetByIdRepo<KioscoEntity>>();

            KioscoEntity kioscoEntity = new KioscoEntity();
            UpdateKioscoOrderInput updateKioscoOrderInput = new UpdateKioscoOrderInput();

            getByIdRepo.Setup(r => r.GetByIdAsync(updateKioscoOrderInput.Id)).ReturnsAsync(kioscoEntity);
            updateRepo.Setup(r => r.UpdateAsync(It.IsAny<KioscoEntity>())).ReturnsAsync(true);

            UpdateOrderUseCase updateOrderUseCase = new UpdateOrderUseCase(
                updateRepo.Object, getByIdRepo.Object);

            ResultState resultState = ResultState.Updated;

            // Act
            var result = updateOrderUseCase.Execute(updateKioscoOrderInput);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
        }

        [TestMethod]
        public void UpdateOrder_ShouldReturnNotFound()
        {
            // Arrange
            Mock<IUpdateRepo<KioscoEntity>> updateRepo = new Mock<IUpdateRepo<KioscoEntity>>();
            Mock<IGetByIdRepo<KioscoEntity>> getByIdRepo = new Mock<IGetByIdRepo<KioscoEntity>>();

            KioscoEntity? kioscoEntity = null;
            UpdateKioscoOrderInput updateKioscoOrderInput = new UpdateKioscoOrderInput();

            getByIdRepo.Setup(r => r.GetByIdAsync(updateKioscoOrderInput.Id)).ReturnsAsync(kioscoEntity);

            UpdateOrderUseCase updateOrderUseCase = new UpdateOrderUseCase(
                updateRepo.Object, getByIdRepo.Object);

            ResultState resultState = ResultState.NotFound;

            // Act
            var result = updateOrderUseCase.Execute(updateKioscoOrderInput);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
        }
    }
}
