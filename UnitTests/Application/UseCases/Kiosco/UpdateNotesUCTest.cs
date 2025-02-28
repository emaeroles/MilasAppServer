using Application.DTOs.Kiosco;
using Application.Entities;
using Application.Enums;
using Application.Interfaces.Kiosco;
using Application.UseCases.Kiosco;
using AutoMapper;
using Moq;

namespace UnitTests.Application.UseCases.Kiosco
{
    [TestClass]
    public class UpdateNotesUCTest
    {
        [TestMethod]
        public void UpdateNotes_ShouldReturnSuccsessWithData()
        {
            // Arrange
            Mock<IUpdateKioscoRepo<KioscoEntity>> updateKioscoRepo = new Mock<IUpdateKioscoRepo<KioscoEntity>>();
            Mock<IMapper> mapper = new Mock<IMapper>();

            KioscoEntity kioscoEntity = new KioscoEntity();
            UpdateKioscoNotesInput updateKioscoNotesInput = new UpdateKioscoNotesInput();

            mapper.Setup(m => m.Map<KioscoEntity>(updateKioscoNotesInput)).Returns(kioscoEntity);
            updateKioscoRepo.Setup(r => r.UpdateNotesAsync(kioscoEntity)).ReturnsAsync(true);

            UpdateNotesUseCase updateNotesUseCase = new UpdateNotesUseCase(updateKioscoRepo.Object, mapper.Object);

            ResultState resultState = ResultState.Success;

            // Act
            var result = updateNotesUseCase.Execute(updateKioscoNotesInput);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
            Assert.IsNull(result.Result.Data);
        }

        [TestMethod]
        public void UpdateNotes_ShouldReturnNotFoundWithNullData()
        {
            // Arrange
            Mock<IUpdateKioscoRepo<KioscoEntity>> updateKioscoRepo = new Mock<IUpdateKioscoRepo<KioscoEntity>>();
            Mock<IMapper> mapper = new Mock<IMapper>();

            KioscoEntity kioscoEntity = new KioscoEntity();
            UpdateKioscoNotesInput updateKioscoNotesInput = new UpdateKioscoNotesInput();

            mapper.Setup(m => m.Map<KioscoEntity>(updateKioscoNotesInput)).Returns(kioscoEntity);
            updateKioscoRepo.Setup(r => r.UpdateNotesAsync(kioscoEntity)).ReturnsAsync(false);

            UpdateNotesUseCase updateNotesUseCase = new UpdateNotesUseCase(updateKioscoRepo.Object, mapper.Object);

            ResultState resultState = ResultState.NotFound;

            // Act
            var result = updateNotesUseCase.Execute(updateKioscoNotesInput);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
            Assert.IsNull(result.Result.Data);
        }
    }
}
