using Application.DTOs.Supply;
using Application.Entities;
using Application.Enums;
using Application.Interfaces._01_Common;
using Application.UseCases.Supply;
using AutoMapper;
using Moq;

namespace UnitTests.Application.UseCases.Supply
{
    [TestClass]
    public class AddUomUCTest
    {
        [TestMethod]
        public void AddUom_ShouldReturnCreated()
        {
            // Arrange
            Mock<IAddRepo<UoMEntity>> addUomRepo = new Mock<IAddRepo<UoMEntity>>();
            Mock<IMapper> mapper = new Mock<IMapper>();

            AddUomInput addUomInput = new AddUomInput();
            UoMEntity uomEntity = new UoMEntity();

            mapper.Setup(m => m.Map<UoMEntity>(addUomInput)).Returns(uomEntity);
            addUomRepo.Setup(r => r.AddAsync(uomEntity)).ReturnsAsync(true);

            AddUomUseCase addUomUseCase = new AddUomUseCase(addUomRepo.Object, mapper.Object);

            ResultState resultState = ResultState.Created;

            // Act
            var result = addUomUseCase.Execute(addUomInput);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
        }
    }
}
