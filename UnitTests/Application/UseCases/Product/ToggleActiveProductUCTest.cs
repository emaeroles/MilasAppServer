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
        public void ToggleActiveProduct_ShouldUpdated()
        {
            // Arrange
            Mock<IUpdateRepo<ProductEntity>> updateRepo = new Mock<IUpdateRepo<ProductEntity>>();
            Mock<IGetByIdRepo<ProductEntity>> getByIdRepo = new Mock<IGetByIdRepo<ProductEntity>>();

            Guid entityId = Guid.NewGuid();
            ProductEntity productEntity = new ProductEntity();

            getByIdRepo.Setup(r => r.GetByIdAsync(entityId)).ReturnsAsync(productEntity);
            updateRepo.Setup(r => r.UpdateAsync(productEntity)).ReturnsAsync(true);

            ToggleActiveProductUseCase toggleActiveProductUseCase = new ToggleActiveProductUseCase(
                updateRepo.Object, getByIdRepo.Object);

            ResultState resultState = ResultState.Updated;

            // Act
            var result = toggleActiveProductUseCase.Execute(entityId);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
        }

        [TestMethod]
        public void ToggleActiveProduct_ShouldReturnNotFound()
        {
            // Arrange
            Mock<IUpdateRepo<ProductEntity>> updateRepo = new Mock<IUpdateRepo<ProductEntity>>();
            Mock<IGetByIdRepo<ProductEntity>> getByIdRepo = new Mock<IGetByIdRepo<ProductEntity>>();

            Guid entityId = Guid.NewGuid();
            ProductEntity? productEntity = null;

            getByIdRepo.Setup(r => r.GetByIdAsync(entityId)).ReturnsAsync(productEntity);

            ToggleActiveProductUseCase toggleActiveProductUseCase = new ToggleActiveProductUseCase(
                updateRepo.Object, getByIdRepo.Object);

            ResultState resultState = ResultState.NotFound;

            // Act
            var result = toggleActiveProductUseCase.Execute(entityId);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
        }
    }
}
