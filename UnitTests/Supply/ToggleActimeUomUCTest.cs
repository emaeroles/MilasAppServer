using Application.Entities;
using Application.Enums;
using Application.Interfaces._01_Common;
using Application.UseCases.Supply;
using Moq;

namespace UnitTests.Supply
{
    [TestClass]
    public class ToggleActimeUomUCTest
    {
        [TestMethod]
        public void ToggleActiveUom_ShouldReturnSuccess()
        {
            // Arrange
            Mock<IToggleActiveRepo<UoMEntity>> toggleActiveUomRepo = new Mock<IToggleActiveRepo<UoMEntity>>();
            int entityId = 1;

            toggleActiveUomRepo.Setup(r => r.ToggleActiveAsync(entityId)).ReturnsAsync(true);

            ToggleActiveUomUseCase toggleActiveUomUseCase = new ToggleActiveUomUseCase(toggleActiveUomRepo.Object);

            ResultState resultState = ResultState.Success;

            // Act
            var result = toggleActiveUomUseCase.Execute(entityId);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
        }

        [TestMethod]
        public void ToggleActiveUom_ShouldReturnNotFound()
        {
            // Arrange
            Mock<IToggleActiveRepo<UoMEntity>> toggleActiveUomRepo = new Mock<IToggleActiveRepo<UoMEntity>>();
            int entityId = 1;

            toggleActiveUomRepo.Setup(r => r.ToggleActiveAsync(entityId)).ReturnsAsync(false);

            ToggleActiveUomUseCase toggleActiveUomUseCase = new ToggleActiveUomUseCase(toggleActiveUomRepo.Object);

            ResultState resultState = ResultState.NotFound;

            // Act
            var result = toggleActiveUomUseCase.Execute(entityId);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
        }
    }
}
