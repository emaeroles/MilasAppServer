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
    public class AddSupplyUCTest
    {
        [TestMethod]
        public void AddSupply_ShouldReturnCreatedWithData()
        {
            // Arrange
            Mock<IAddRepo<SupplyEntity>> addSupplyRepo = new Mock<IAddRepo<SupplyEntity>>();
            Mock<IMapper> mapper = new Mock<IMapper>();

            AddSupplyInput addSupplyInput = new AddSupplyInput();
            SupplyEntity supplyEntity = new SupplyEntity();

            mapper.Setup(m => m.Map<SupplyEntity>(addSupplyInput)).Returns(supplyEntity);
            addSupplyRepo.Setup(r => r.AddAsync(supplyEntity)).ReturnsAsync(1);

            AddSupplyUseCase addSupplyUseCase = new AddSupplyUseCase(addSupplyRepo.Object, mapper.Object);

            ResultState resultState = ResultState.Created;

            // Act
            var result = addSupplyUseCase.Execute(addSupplyInput);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
            Assert.IsNotNull(result.Result.Data);
        }

        [TestMethod]
        public void AddSupply_ShouldReturnCreatedWithNullData()
        {
            // Arrange
            Mock<IAddRepo<SupplyEntity>> addSupplyRepo = new Mock<IAddRepo<SupplyEntity>>();
            Mock<IMapper> mapper = new Mock<IMapper>();

            SupplyEntity supplyEntity = new SupplyEntity();
            AddSupplyInput addSupplyInput = new AddSupplyInput();

            mapper.Setup(m => m.Map<SupplyEntity>(addSupplyInput)).Returns(supplyEntity);
            addSupplyRepo.Setup(r => r.AddAsync(supplyEntity)).ReturnsAsync(0);

            AddSupplyUseCase addSupplyUseCase = new AddSupplyUseCase(addSupplyRepo.Object, mapper.Object);

            ResultState resultState = ResultState.NotFound;

            // Act
            var result = addSupplyUseCase.Execute(addSupplyInput);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
            Assert.IsNull(result.Result.Data);
        }
    }
}
