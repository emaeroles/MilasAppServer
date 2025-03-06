using Application.DTOs.Kiosco;
using Application.Entities;
using Application.Enums;
using Application.Interfaces._01_Common;
using Application.UseCases.Kiosco;
using Moq;

namespace UnitTests.Application.UseCases.Kiosco
{
    [TestClass]
    public class UpdateKioscoUCTest
    {
        [TestMethod]
        public void UpdateKiosco_ShouldReturnUpdated()
        {
            // Arrange
            Mock<IUpdateRepo<KioscoEntity>> updateRepo = new Mock<IUpdateRepo<KioscoEntity>>();
            Mock<IGetByIdRepo<KioscoEntity>> getByIdRepo = new Mock<IGetByIdRepo<KioscoEntity>>();

            KioscoEntity kioscoEntity = new KioscoEntity();
            UpdateKioscoInput updateKioscoInput = new UpdateKioscoInput();

            getByIdRepo.Setup(r => r.GetByIdAsync(updateKioscoInput.Id)).ReturnsAsync(kioscoEntity);
            updateRepo.Setup(r => r.UpdateAsync(It.IsAny<KioscoEntity>())).ReturnsAsync(true);

            UpdateKioscoUseCase updateKioscoUseCase = new UpdateKioscoUseCase(
                updateRepo.Object, getByIdRepo.Object);

            ResultState resultState = ResultState.Updated;

            // Act
            var result = updateKioscoUseCase.Execute(updateKioscoInput);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
        }

        [TestMethod]
        public void UpdateKiosco_ShouldReturnNotFound()
        {
            // Arrange
            Mock<IUpdateRepo<KioscoEntity>> updateRepo = new Mock<IUpdateRepo<KioscoEntity>>();
            Mock<IGetByIdRepo<KioscoEntity>> getByIdRepo = new Mock<IGetByIdRepo<KioscoEntity>>();

            KioscoEntity? kioscoEntity = null;
            UpdateKioscoInput updateKioscoInput = new UpdateKioscoInput();

            getByIdRepo.Setup(r => r.GetByIdAsync(updateKioscoInput.Id)).ReturnsAsync(kioscoEntity);

            UpdateKioscoUseCase updateKioscoUseCase = new UpdateKioscoUseCase(
                updateRepo.Object, getByIdRepo.Object);

            ResultState resultState = ResultState.NotFound;

            // Act
            var result = updateKioscoUseCase.Execute(updateKioscoInput);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
        }
    }
}
