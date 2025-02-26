using Application.DTOs.Kiosco;
using Application.Entities;
using Application.Interfaces.Kiosco;
using Application.UseCases.Kiosco;
using AutoMapper;
using Moq;

namespace UnitTests.Kiosco
{
    [TestClass]
    public class UpdateNotesUCTest
    {
        [TestMethod]
        public void UpdateNotes_ShouldReturnAppResult()
        {
            // Arrange
            Mock<IUpdateKioscoRepo<KioscoEntity>> updateKioscoRepo = new Mock<IUpdateKioscoRepo<KioscoEntity>>();
            Mock<IMapper> mapper = new Mock<IMapper>();

            // Act
            UpdateNotesUseCase updateNotesUseCase = new UpdateNotesUseCase(updateKioscoRepo.Object, mapper.Object);
            UpdateKioscoNotesInput updateKioscoNotesInput = new UpdateKioscoNotesInput();
            var result = updateNotesUseCase.Execute(updateKioscoNotesInput);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
