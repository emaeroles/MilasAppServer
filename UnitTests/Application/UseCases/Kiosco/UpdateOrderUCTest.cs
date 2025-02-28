using Application.DTOs.Kiosco;
using Application.Entities;
using Application.Enums;
using Application.Interfaces.Kiosco;
using Application.UseCases.Kiosco;
using AutoMapper;
using Moq;

namespace UnitTests.Kiosco
{
    [TestClass]
    public class UpdateOrderUCTest
    {
        [TestMethod]
        public void UpdateOrder_ShouldReturnSuccsessWithData()
        {
            // Arrange
            Mock<IUpdateKioscoRepo<KioscoEntity>> updateKioscoRepo = new Mock<IUpdateKioscoRepo<KioscoEntity>>();
            Mock<IMapper> mapper = new Mock<IMapper>();

            KioscoEntity kioscoEntity = new KioscoEntity();
            UpdateKioscoOrderInput updateKioscoOrderInput = new UpdateKioscoOrderInput();

            mapper.Setup(m => m.Map<KioscoEntity>(updateKioscoOrderInput)).Returns(kioscoEntity);
            updateKioscoRepo.Setup(r => r.UpdateOrderAsync(kioscoEntity)).ReturnsAsync(true);

            UpdateOrderUseCase updateOrderUseCase = new UpdateOrderUseCase(updateKioscoRepo.Object, mapper.Object);

            ResultState resultState = ResultState.Success;

            // Act
            var result = updateOrderUseCase.Execute(updateKioscoOrderInput);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
            Assert.IsNull(result.Result.Data);
        }

        [TestMethod]
        public void UpdateOrder_ShouldReturnNotFoundWithNullData()
        {
            // Arrange
            Mock<IUpdateKioscoRepo<KioscoEntity>> updateKioscoRepo = new Mock<IUpdateKioscoRepo<KioscoEntity>>();
            Mock<IMapper> mapper = new Mock<IMapper>();

            KioscoEntity kioscoEntity = new KioscoEntity();
            UpdateKioscoOrderInput updateKioscoOrderInput = new UpdateKioscoOrderInput();

            mapper.Setup(m => m.Map<KioscoEntity>(updateKioscoOrderInput)).Returns(kioscoEntity);
            updateKioscoRepo.Setup(r => r.UpdateOrderAsync(kioscoEntity)).ReturnsAsync(false);

            UpdateOrderUseCase updateOrderUseCase = new UpdateOrderUseCase(updateKioscoRepo.Object, mapper.Object);

            ResultState resultState = ResultState.NotFound;

            // Act
            var result = updateOrderUseCase.Execute(updateKioscoOrderInput);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
            Assert.IsNull(result.Result.Data);
        }
    }
}
