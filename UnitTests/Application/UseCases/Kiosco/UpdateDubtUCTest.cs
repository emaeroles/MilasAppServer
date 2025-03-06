using Application.DTOs.Kiosco;
using Application.Entities;
using Application.Enums;
using Application.Interfaces._01_Common;
using Application.UseCases.Kiosco;
using Moq;

namespace UnitTests.Application.UseCases.Kiosco
{
    [TestClass]
    public class UpdateDubtUCTest
    {
        [TestMethod]
        public void UpdateDubt_ShouldReturnUpdated()
        {
            // Arrange
            Mock<IUpdateRepo<KioscoEntity>> updateRepo = new Mock<IUpdateRepo<KioscoEntity>>();
            Mock<IGetByIdRepo<KioscoEntity>> getByIdRepo = new Mock<IGetByIdRepo<KioscoEntity>>();

            KioscoEntity kioscoEntity = new KioscoEntity();
            UpdateKioscoDubtInput updateKioscoDubtInput = new UpdateKioscoDubtInput();

            getByIdRepo.Setup(r => r.GetByIdAsync(updateKioscoDubtInput.Id)).ReturnsAsync(kioscoEntity);
            updateRepo.Setup(r => r.UpdateAsync(It.IsAny<KioscoEntity>())).ReturnsAsync(true);

            UpdateKioscoDubtUseCase updateKioscoDubtUseCase = new UpdateKioscoDubtUseCase(
                updateRepo.Object, getByIdRepo.Object);

            ResultState resultState = ResultState.Updated;

            // Act
            var result = updateKioscoDubtUseCase.Execute(updateKioscoDubtInput);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
        }

        [TestMethod]
        public void UpdateDubt_ShouldReturnNotFound()
        {
            // Arrange
            Mock<IUpdateRepo<KioscoEntity>> updateRepo = new Mock<IUpdateRepo<KioscoEntity>>();
            Mock<IGetByIdRepo<KioscoEntity>> getByIdRepo = new Mock<IGetByIdRepo<KioscoEntity>>();

            KioscoEntity? kioscoEntity = null;
            UpdateKioscoDubtInput updateKioscoDubtInput = new UpdateKioscoDubtInput();

            getByIdRepo.Setup(r => r.GetByIdAsync(updateKioscoDubtInput.Id)).ReturnsAsync(kioscoEntity);

            UpdateKioscoDubtUseCase updateKioscoDubtUseCase = new UpdateKioscoDubtUseCase(
                updateRepo.Object, getByIdRepo.Object);

            ResultState resultState = ResultState.NotFound;

            // Act
            var result = updateKioscoDubtUseCase.Execute(updateKioscoDubtInput);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
        }
    }
}
