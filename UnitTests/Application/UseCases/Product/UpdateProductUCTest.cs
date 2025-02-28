using Application.DTOs.Product;
using Application.Entities;
using Application.Enums;
using Application.Interfaces._01_Common;
using Application.UseCases.Product;
using AutoMapper;
using Moq;

namespace UnitTests.Application.UseCases.Product
{
    [TestClass]
    public class UpdateProductUCTest
    {
        [TestMethod]
        public void UpdateProduct_ShouldReturnSuccsessWithData()
        {
            // Arrange
            Mock<IUpdateRepo<ProductEntity>> updateRepo = new Mock<IUpdateRepo<ProductEntity>>();
            Mock<IMapper> mapper = new Mock<IMapper>();

            ProductEntity productEntity = new ProductEntity();
            UpdateProductInput updateProductInput = new UpdateProductInput();

            mapper.Setup(m => m.Map<ProductEntity>(updateProductInput)).Returns(productEntity);
            updateRepo.Setup(r => r.UpdateAsync(productEntity)).ReturnsAsync(true);

            UpdateProductUseCase updateProductUseCase = new UpdateProductUseCase(updateRepo.Object, mapper.Object);

            ResultState resultState = ResultState.Success;

            // Act
            var result = updateProductUseCase.Execute(updateProductInput);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
            Assert.IsNull(result.Result.Data);
        }

        [TestMethod]
        public void UpdateProduct_ShouldReturnNotFoundWithNullData()
        {
            // Arrange
            Mock<IUpdateRepo<ProductEntity>> updateProductRepo = new Mock<IUpdateRepo<ProductEntity>>();
            Mock<IMapper> mapper = new Mock<IMapper>();

            ProductEntity productEntity = new ProductEntity();
            UpdateProductInput updateProductInput = new UpdateProductInput();

            mapper.Setup(m => m.Map<ProductEntity>(updateProductInput)).Returns(productEntity);
            updateProductRepo.Setup(r => r.UpdateAsync(productEntity)).ReturnsAsync(false);

            UpdateProductUseCase updateProductUseCase = new UpdateProductUseCase(updateProductRepo.Object, mapper.Object);

            ResultState resultState = ResultState.NotFound;

            // Act
            var result = updateProductUseCase.Execute(updateProductInput);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
            Assert.IsNull(result.Result.Data);
        }
    }
}
