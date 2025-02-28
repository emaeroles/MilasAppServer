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
    public class AddKioscoUCTest
    {
        [TestMethod]
        public void AddKiosco_ShouldReturnCreatedWithData()
        {
            // Arrange
            Mock<IAddRepo<KioscoEntity>> addKioscoRepo = new Mock<IAddRepo<KioscoEntity>>();
            Mock<IMapper> mapper = new Mock<IMapper>();

            AddKioscoInput addKioscoInput = new AddKioscoInput();
            KioscoEntity kioscoEntity = new KioscoEntity();

            mapper.Setup(m => m.Map<KioscoEntity>(addKioscoInput)).Returns(kioscoEntity);
            addKioscoRepo.Setup(r => r.AddAsync(kioscoEntity)).ReturnsAsync(1);

            AddKioscoUseCase addKioscoUseCase = new AddKioscoUseCase(addKioscoRepo.Object, mapper.Object);

            ResultState resultState = ResultState.Created;
            
            // Act
            var result = addKioscoUseCase.Execute(addKioscoInput);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
            Assert.IsNotNull(result.Result.Data);
        }

        [TestMethod]
        public void AddKiosco_ShouldReturnCreatedWithNullData()
        {
            // Arrange
            Mock<IAddRepo<KioscoEntity>> addKioscoRepo = new Mock<IAddRepo<KioscoEntity>>();
            Mock<IMapper> mapper = new Mock<IMapper>();

            KioscoEntity kioscoEntity = new KioscoEntity();
            AddKioscoInput addKioscoInput = new AddKioscoInput();

            mapper.Setup(m => m.Map<KioscoEntity>(addKioscoInput)).Returns(kioscoEntity);
            addKioscoRepo.Setup(r => r.AddAsync(kioscoEntity)).ReturnsAsync(0);

            AddKioscoUseCase addKioscoUseCase = new AddKioscoUseCase(addKioscoRepo.Object, mapper.Object);

            ResultState resultState = ResultState.NotFound;

            // Act
            var result = addKioscoUseCase.Execute(addKioscoInput);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
            Assert.IsNull(result.Result.Data);
        }
    }
}
