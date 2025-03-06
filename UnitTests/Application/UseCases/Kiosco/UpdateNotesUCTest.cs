using Application.DTOs.Kiosco;
using Application.Entities;
using Application.Enums;
using Application.Interfaces._01_Common;
using Application.UseCases.Kiosco;
using Moq;

namespace UnitTests.Application.UseCases.Kiosco
{
    [TestClass]
    public class UpdateNotesUCTest
    {
        [TestMethod]
        public void UpdateNotes_ShouldReturnUpdated()
        {
            // Arrange
            Mock<IUpdateRepo<KioscoEntity>> updateRepo = new Mock<IUpdateRepo<KioscoEntity>>();
            Mock<IGetByIdRepo<KioscoEntity>> getByIdRepo = new Mock<IGetByIdRepo<KioscoEntity>>();

            KioscoEntity kioscoEntity = new KioscoEntity();
            UpdateKioscoNotesInput updateKioscoNotesInput = new UpdateKioscoNotesInput();

            getByIdRepo.Setup(r => r.GetByIdAsync(updateKioscoNotesInput.Id)).ReturnsAsync(kioscoEntity);
            updateRepo.Setup(r => r.UpdateAsync(It.IsAny<KioscoEntity>())).ReturnsAsync(true);

            UpdateNotesUseCase updateNotesUseCase = new UpdateNotesUseCase(
                updateRepo.Object, getByIdRepo.Object);

            ResultState resultState = ResultState.Updated;

            // Act
            var result = updateNotesUseCase.Execute(updateKioscoNotesInput);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
        }

        [TestMethod]
        public void UpdateNotes_ShouldReturnNotFound()
        {
            // Arrange
            Mock<IUpdateRepo<KioscoEntity>> updateRepo = new Mock<IUpdateRepo<KioscoEntity>>();
            Mock<IGetByIdRepo<KioscoEntity>> getByIdRepo = new Mock<IGetByIdRepo<KioscoEntity>>();

            KioscoEntity? kioscoEntity = null;
            UpdateKioscoNotesInput updateKioscoNotesInput = new UpdateKioscoNotesInput();

            getByIdRepo.Setup(r => r.GetByIdAsync(updateKioscoNotesInput.Id)).ReturnsAsync(kioscoEntity);

            UpdateNotesUseCase updateNotesUseCase = new UpdateNotesUseCase(
                updateRepo.Object, getByIdRepo.Object);

            ResultState resultState = ResultState.NotFound;

            // Act
            var result = updateNotesUseCase.Execute(updateKioscoNotesInput);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
        }
    }
}
