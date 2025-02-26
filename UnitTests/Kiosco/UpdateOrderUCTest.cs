using Application.DTOs.Kiosco;
using Application.Entities;
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
        public void UpdateOrder_ShouldReturnAppResult()
        {
            // Arrange
            Mock<IUpdateKioscoRepo<KioscoEntity>> updateKioscoRepo = new Mock<IUpdateKioscoRepo<KioscoEntity>>();
            Mock<IMapper> mapper = new Mock<IMapper>();

            // Act
            UpdateOrderUseCase updateOrderUseCase = new UpdateOrderUseCase(updateKioscoRepo.Object, mapper.Object);
            UpdateKioscoOrderInput updateKioscoOrderInput = new UpdateKioscoOrderInput();
            var result = updateOrderUseCase.Execute(updateKioscoOrderInput);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
