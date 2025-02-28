using Application.Entities;
using Application.Enums;
using Application.Interfaces._01_Common;
using Application.UseCases.Product;
using Moq;

namespace UnitTests.Application.UseCases.Product
{
    [TestClass]
    public class ToggleActiveProductUCTest
    {
        [TestMethod]
        public void ToggleActiveProduct_ShouldReturnSuccess()
        {
            // Arrange
            Mock<IToggleActiveRepo<ProductEntity>> toggleActiveProductRepo = new Mock<IToggleActiveRepo<ProductEntity>>();
            int entityId = 1;

            toggleActiveProductRepo.Setup(r => r.ToggleActiveAsync(entityId)).ReturnsAsync(true);

            ToggleActiveProductUseCase toggleActiveProductUseCase = new ToggleActiveProductUseCase(toggleActiveProductRepo.Object);

            ResultState resultState = ResultState.Success;

            // Act
            var result = toggleActiveProductUseCase.Execute(entityId);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
        }

        [TestMethod]
        public void ToggleActiveProduct_ShouldReturnNotFound()
        {
            // Arrange
            Mock<IToggleActiveRepo<ProductEntity>> toggleActiveProductRepo = new Mock<IToggleActiveRepo<ProductEntity>>();
            int entityId = 1;

            toggleActiveProductRepo.Setup(r => r.ToggleActiveAsync(entityId)).ReturnsAsync(false);

            ToggleActiveProductUseCase toggleActiveProductUseCase = new ToggleActiveProductUseCase(toggleActiveProductRepo.Object);

            ResultState resultState = ResultState.NotFound;

            // Act
            var result = toggleActiveProductUseCase.Execute(entityId);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
        }
    }
}
