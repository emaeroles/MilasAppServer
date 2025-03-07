using Application.Entities;
using Application.Enums;
using Application.Interfaces._01_Common;
using Application.UseCases.Uom;
using Moq;

namespace UnitTests.Application.UseCases.Uom
{
    [TestClass]
    public class ToggleActiveUomUCTest
    {
        [TestMethod]
        public void ToggleActiveUom_ShouldReturnUpdated()
        {
            // Arrange
            Mock<IUpdateRepo<UomEntity>> updateRepo = new Mock<IUpdateRepo<UomEntity>>();
            Mock<IGetByIdRepo<UomEntity>> getByIdRepo = new Mock<IGetByIdRepo<UomEntity>>();

            Guid entityId = Guid.NewGuid();
            UomEntity uomEntity = new UomEntity();

            getByIdRepo.Setup(r => r.GetByIdAsync(entityId)).ReturnsAsync(uomEntity);
            updateRepo.Setup(r => r.UpdateAsync(uomEntity)).ReturnsAsync(true);

            ToggleActiveUomUseCase toggleActiveUomUseCase = new ToggleActiveUomUseCase(
                updateRepo.Object, getByIdRepo.Object);

            ResultState resultState = ResultState.Updated;

            // Act
            var result = toggleActiveUomUseCase.Execute(entityId);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
        }

        [TestMethod]
        public void ToggleActiveUom_ShouldReturnNotFound()
        {
            // Arrange
            Mock<IUpdateRepo<UomEntity>> updateRepo = new Mock<IUpdateRepo<UomEntity>>();
            Mock<IGetByIdRepo<UomEntity>> getByIdRepo = new Mock<IGetByIdRepo<UomEntity>>();

            Guid entityId = Guid.NewGuid();
            UomEntity? uomEntity = null;

            getByIdRepo.Setup(r => r.GetByIdAsync(entityId)).ReturnsAsync(uomEntity);

            ToggleActiveUomUseCase toggleActiveUomUseCase = new ToggleActiveUomUseCase(
                updateRepo.Object, getByIdRepo.Object);

            ResultState resultState = ResultState.NotFound;

            // Act
            var result = toggleActiveUomUseCase.Execute(entityId);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
        }
    }
}
