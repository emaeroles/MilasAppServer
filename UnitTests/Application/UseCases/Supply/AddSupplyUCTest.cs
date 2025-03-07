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
        public void AddSupply_ShouldReturnCreated()
        {
            // Arrange
            Mock<IAddRepo<SupplyEntity>> addSupplyRepo = new Mock<IAddRepo<SupplyEntity>>();
            Mock<IGetByIdRepo<UomEntity>> getByIdRepo = new Mock<IGetByIdRepo<UomEntity>>();
            Mock<IMapper> mapper = new Mock<IMapper>();

            AddSupplyInput addSupplyInput = new AddSupplyInput();
            SupplyEntity supplyEntity = new SupplyEntity();
            UomEntity uomEntity = new UomEntity();

            mapper.Setup(m => m.Map<SupplyEntity>(addSupplyInput)).Returns(supplyEntity);
            getByIdRepo.Setup(r => r.GetByIdAsync(addSupplyInput.UomId)).ReturnsAsync(uomEntity);
            addSupplyRepo.Setup(r => r.AddAsync(supplyEntity)).ReturnsAsync(true);

            AddSupplyUseCase addSupplyUseCase = new AddSupplyUseCase(
                addSupplyRepo.Object, getByIdRepo.Object, mapper.Object);

            ResultState resultState = ResultState.Created;

            // Act
            var result = addSupplyUseCase.Execute(addSupplyInput);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
        }

        [TestMethod]
        public void AddSupply_ShouldReturnNotFound()
        {
            // Arrange
            Mock<IAddRepo<SupplyEntity>> addSupplyRepo = new Mock<IAddRepo<SupplyEntity>>();
            Mock<IGetByIdRepo<UomEntity>> getByIdRepo = new Mock<IGetByIdRepo<UomEntity>>();
            Mock<IMapper> mapper = new Mock<IMapper>();

            AddSupplyInput addSupplyInput = new AddSupplyInput();
            UomEntity? uomEntity = null;

            getByIdRepo.Setup(r => r.GetByIdAsync(addSupplyInput.UomId)).ReturnsAsync(uomEntity);

            AddSupplyUseCase addSupplyUseCase = new AddSupplyUseCase(
                addSupplyRepo.Object, getByIdRepo.Object, mapper.Object);

            ResultState resultState = ResultState.NotFound;

            // Act
            var result = addSupplyUseCase.Execute(addSupplyInput);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
        }
    }
}
