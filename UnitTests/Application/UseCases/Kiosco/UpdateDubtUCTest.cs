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
    public class UpdateDubtUCTest
    {
        [TestMethod]
        public void UpdateDubt_ShouldReturnSuccsessWithData()
        {
            // Arrange
            Mock<IUpdateKioscoRepo<KioscoEntity>> updateKioscoRepo = new Mock<IUpdateKioscoRepo<KioscoEntity>>();
            Mock<IMapper> mapper = new Mock<IMapper>();

            KioscoEntity kioscoEntity = new KioscoEntity();
            UpdateKioscoDubtInput updateKioscoDubtInput = new UpdateKioscoDubtInput();

            mapper.Setup(m => m.Map<KioscoEntity>(updateKioscoDubtInput)).Returns(kioscoEntity);
            updateKioscoRepo.Setup(r => r.UpdateDubtAsync(kioscoEntity)).ReturnsAsync(true);

            UpdateDubtUseCase updateDubtUseCase = new UpdateDubtUseCase(updateKioscoRepo.Object, mapper.Object);

            ResultState resultState = ResultState.Success;

            // Act
            var result = updateDubtUseCase.Execute(updateKioscoDubtInput);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
            Assert.IsNull(result.Result.Data);
        }

        [TestMethod]
        public void UpdateDubt_ShouldReturnNotFoundWithNullData()
        {
            // Arrange
            Mock<IUpdateKioscoRepo<KioscoEntity>> updateKioscoRepo = new Mock<IUpdateKioscoRepo<KioscoEntity>>();
            Mock<IMapper> mapper = new Mock<IMapper>();

            KioscoEntity kioscoEntity = new KioscoEntity();
            UpdateKioscoDubtInput updateKioscoDubtInput = new UpdateKioscoDubtInput();

            mapper.Setup(m => m.Map<KioscoEntity>(updateKioscoDubtInput)).Returns(kioscoEntity);
            updateKioscoRepo.Setup(r => r.UpdateDubtAsync(kioscoEntity)).ReturnsAsync(false);

            UpdateDubtUseCase updateDubtUseCase = new UpdateDubtUseCase(updateKioscoRepo.Object, mapper.Object);

            ResultState resultState = ResultState.NotFound;

            // Act
            var result = updateDubtUseCase.Execute(updateKioscoDubtInput);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
            Assert.IsNull(result.Result.Data);
        }
    }
}
