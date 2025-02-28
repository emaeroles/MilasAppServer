using Application.DTOs.Kiosco;
using Application.Entities;
using Application.Enums;
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
        public void UpdateKiosco_ShouldReturnSuccsessWithData()
        {
            // Arrange
            Mock<IUpdateRepo<KioscoEntity>> updateRepo = new Mock<IUpdateRepo<KioscoEntity>>();
            Mock<IMapper> mapper = new Mock<IMapper>();

            KioscoEntity kioscoEntity = new KioscoEntity();
            UpdateKioscoInput updateKioscoInput = new UpdateKioscoInput();

            mapper.Setup(m => m.Map<KioscoEntity>(updateKioscoInput)).Returns(kioscoEntity);
            updateRepo.Setup(r => r.UpdateAsync(kioscoEntity)).ReturnsAsync(true);

            UpdateKioscoUseCase updateKioscoUseCase = new UpdateKioscoUseCase(updateRepo.Object, mapper.Object);

            ResultState resultState = ResultState.Success;

            // Act
            var result = updateKioscoUseCase.Execute(updateKioscoInput);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
            Assert.IsNull(result.Result.Data);
        }

        [TestMethod]
        public void UpdateKiosco_ShouldReturnNotFoundWithNullData()
        {
            // Arrange
            Mock<IUpdateRepo<KioscoEntity>> updateKioscoRepo = new Mock<IUpdateRepo<KioscoEntity>>();
            Mock<IMapper> mapper = new Mock<IMapper>();

            KioscoEntity kioscoEntity = new KioscoEntity();
            UpdateKioscoInput updateKioscoInput = new UpdateKioscoInput();

            mapper.Setup(m => m.Map<KioscoEntity>(updateKioscoInput)).Returns(kioscoEntity);
            updateKioscoRepo.Setup(r => r.UpdateAsync(kioscoEntity)).ReturnsAsync(false);

            UpdateKioscoUseCase updateKioscoUseCase = new UpdateKioscoUseCase(updateKioscoRepo.Object, mapper.Object);

            ResultState resultState = ResultState.NotFound;

            // Act
            var result = updateKioscoUseCase.Execute(updateKioscoInput);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
            Assert.IsNull(result.Result.Data);
        }
    }
}
