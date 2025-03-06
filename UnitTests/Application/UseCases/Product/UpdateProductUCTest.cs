using Application.DTOs.Product;
using Application.Entities;
using Application.Enums;
using Application.Interfaces._01_Common;
using Application.UseCases.Product;
using Moq;

namespace UnitTests.Application.UseCases.Product
{
    [TestClass]
    public class UpdateProductUCTest
    {
        [TestMethod]
        public void UpdateProduct_ShouldReturnUpdated()
        {
            // Arrange
            Mock<IUpdateRepo<ProductEntity>> updateRepo = new Mock<IUpdateRepo<ProductEntity>>();
            Mock<IGetByIdRepo<ProductEntity>> getByIdRepo = new Mock<IGetByIdRepo<ProductEntity>>();

            ProductEntity productEntity = new ProductEntity();
            UpdateProductInput updateProductInput = new UpdateProductInput();

            getByIdRepo.Setup(r => r.GetByIdAsync(updateProductInput.Id)).ReturnsAsync(productEntity);
            updateRepo.Setup(r => r.UpdateAsync(productEntity)).ReturnsAsync(true);

            UpdateProductUseCase updateProductUseCase = new UpdateProductUseCase(
                updateRepo.Object, getByIdRepo.Object);

            ResultState resultState = ResultState.Updated;

            // Act
            var result = updateProductUseCase.Execute(updateProductInput);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
        }

        [TestMethod]
        public void UpdateProduct_ShouldReturnNotFound()
        {
            // Arrange
            Mock<IUpdateRepo<ProductEntity>> updateProductRepo = new Mock<IUpdateRepo<ProductEntity>>();
            Mock<IGetByIdRepo<ProductEntity>> getByIdRepo = new Mock<IGetByIdRepo<ProductEntity>>();

            ProductEntity? productEntity = null;
            UpdateProductInput updateProductInput = new UpdateProductInput();

            getByIdRepo.Setup(r => r.GetByIdAsync(updateProductInput.Id)).ReturnsAsync(productEntity);

            UpdateProductUseCase updateProductUseCase = new UpdateProductUseCase(
                updateProductRepo.Object, getByIdRepo.Object);

            ResultState resultState = ResultState.NotFound;

            // Act
            var result = updateProductUseCase.Execute(updateProductInput);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
        }
    }
}
