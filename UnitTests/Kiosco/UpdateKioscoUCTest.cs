using Application.DTOs.Kiosco;
using Application.Entities;
using Application.Interfaces._01_Common;
using Application.UseCases.Kiosco;
using AutoMapper;
using Moq;

namespace UnitTests.Kiosco
{
    [TestClass]
    public class UpdateKioscoUCTest
    {
        [TestMethod]
        public void UpdateKiosco_ShouldReturnAppResult()
        {
            // Arrange
            Mock<IUpdateRepo<KioscoEntity>> updateKioscoRepo = new Mock<IUpdateRepo<KioscoEntity>>();
            Mock<IMapper> mapper = new Mock<IMapper>();

            // Act
            UpdateKioscoUseCase updateKioscoUseCase = new UpdateKioscoUseCase(updateKioscoRepo.Object, mapper.Object);
            UpdateKioscoInput updateKioscoInput = new UpdateKioscoInput();
            var result = updateKioscoUseCase.Execute(updateKioscoInput);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
