using Application.DTOs.Kiosco;
using Application.Entities;
using Application.Interfaces._01_Common;
using Application.UseCases.Kiosco;
using AutoMapper;
using Moq;

namespace UnitTests.Kiosco
{
    [TestClass]
    public class AddKioscoUCTest
    {
        [TestMethod]
        public void AddKiosco_ShouldReturnAppResult()
        {
            // Arrange
            Mock<IAddRepo<KioscoEntity>> addKioscoRepo = new Mock<IAddRepo<KioscoEntity>>();
            Mock<IMapper> mapper = new Mock<IMapper>();

            // Act
            AddKioscoUseCase addKioscoUseCase = new AddKioscoUseCase(addKioscoRepo.Object, mapper.Object);
            AddKioscoInput addKioscoInput = new AddKioscoInput();
            var result = addKioscoUseCase.Execute(addKioscoInput);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
