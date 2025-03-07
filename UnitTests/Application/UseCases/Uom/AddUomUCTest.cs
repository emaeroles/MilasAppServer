using Application.DTOs.Uom;
using Application.Entities;
using Application.Enums;
using Application.Interfaces._01_Common;
using Application.UseCases.Uom;
using AutoMapper;
using Moq;

namespace UnitTests.Application.UseCases.Uom
{
    [TestClass]
    public class AddUomUCTest
    {
        [TestMethod]
        public void AddUom_ShouldReturnCreated()
        {
            // Arrange
            Mock<IAddRepo<UomEntity>> addUomRepo = new Mock<IAddRepo<UomEntity>>();
            Mock<IMapper> mapper = new Mock<IMapper>();

            AddUomInput addUomInput = new AddUomInput();
            UomEntity uomEntity = new UomEntity();

            mapper.Setup(m => m.Map<UomEntity>(addUomInput)).Returns(uomEntity);
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
