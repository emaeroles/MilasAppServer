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
            Mock<IGetByIdRepo<UoMEntity>> getByIdRepo = new Mock<IGetByIdRepo<UoMEntity>>();
            Mock<IMapper> mapper = new Mock<IMapper>();

            AddSupplyInput addSupplyInput = new AddSupplyInput();
            SupplyEntity supplyEntity = new SupplyEntity();
            UoMEntity uomEntity = new UoMEntity();

            mapper.Setup(m => m.Map<SupplyEntity>(addSupplyInput)).Returns(supplyEntity);
            getByIdRepo.Setup(r => r.GetByIdAsync(addSupplyInput.UoMId)).ReturnsAsync(uomEntity);
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
            Mock<IGetByIdRepo<UoMEntity>> getByIdRepo = new Mock<IGetByIdRepo<UoMEntity>>();
            Mock<IMapper> mapper = new Mock<IMapper>();

            AddSupplyInput addSupplyInput = new AddSupplyInput();
            UoMEntity? uomEntity = null;

            getByIdRepo.Setup(r => r.GetByIdAsync(addSupplyInput.UoMId)).ReturnsAsync(uomEntity);

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
