using Application.DTOs.Kiosco;
using Application.Entities;
using Application.Interfaces.Kiosco;
using Application.UseCases.Kiosco;
using AutoMapper;
using Moq;

namespace UnitTests.Kiosco
{
    [TestClass]
    public class UpdateDubtUCTest
    {
        [TestMethod]
        public void UpdateDubt_ShouldReturnAppResult()
        {
            // Arrange
            Mock<IUpdateKioscoRepo<KioscoEntity>> updateKioscoRepo = new Mock<IUpdateKioscoRepo<KioscoEntity>>();
            Mock<IMapper> mapper = new Mock<IMapper>();

            // Act
            UpdateDubtUseCase updateDubtUseCase = new UpdateDubtUseCase(updateKioscoRepo.Object, mapper.Object);
            UpdateKioscoDubtInput updateKioscoDubtInput = new UpdateKioscoDubtInput();
            var result = updateDubtUseCase.Execute(updateKioscoDubtInput);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
