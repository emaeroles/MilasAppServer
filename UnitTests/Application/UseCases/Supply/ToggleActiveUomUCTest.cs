using Application.Entities;
using Application.Enums;
using Application.Interfaces._01_Common;
using Application.UseCases.Supply;
using Moq;

namespace UnitTests.Application.UseCases.Supply
{
    [TestClass]
    public class ToggleActiveUomUCTest
    {
        [TestMethod]
        public void ToggleActiveUom_ShouldReturnUpdated()
        {
            // Arrange
            Mock<IUpdateRepo<UoMEntity>> updateRepo = new Mock<IUpdateRepo<UoMEntity>>();
            Mock<IGetByIdRepo<UoMEntity>> getByIdRepo = new Mock<IGetByIdRepo<UoMEntity>>();

            Guid entityId = Guid.NewGuid();
            UoMEntity uomEntity = new UoMEntity();

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
            Mock<IUpdateRepo<UoMEntity>> updateRepo = new Mock<IUpdateRepo<UoMEntity>>();
            Mock<IGetByIdRepo<UoMEntity>> getByIdRepo = new Mock<IGetByIdRepo<UoMEntity>>();

            Guid entityId = Guid.NewGuid();
            UoMEntity? uomEntity = null;

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
