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
    public class AddProductUCTest
    {
        [TestMethod]
        public void AddProduct_ShouldReturnCreatedWithData()
        {
            // Arrange
            Mock<IAddRepo<ProductEntity>> addProductRepo = new Mock<IAddRepo<ProductEntity>>();
            Mock<IMapper> mapper = new Mock<IMapper>();

            AddProductInput addProductInput = new AddProductInput();
            ProductEntity productEntity = new ProductEntity();

            mapper.Setup(m => m.Map<ProductEntity>(addProductInput)).Returns(productEntity);
            addProductRepo.Setup(r => r.AddAsync(productEntity)).ReturnsAsync(1);

            AddProductUseCase addProductUseCase = new AddProductUseCase(addProductRepo.Object, mapper.Object);

            ResultState resultState = ResultState.Created;

            // Act
            var result = addProductUseCase.Execute(addProductInput);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
            Assert.IsNotNull(result.Result.Data);
        }

        [TestMethod]
        public void AddProduct_ShouldReturnCreatedWithNullData()
        {
            // Arrange
            Mock<IAddRepo<ProductEntity>> addProductRepo = new Mock<IAddRepo<ProductEntity>>();
            Mock<IMapper> mapper = new Mock<IMapper>();

            ProductEntity productEntity = new ProductEntity();
            AddProductInput addProductInput = new AddProductInput();

            mapper.Setup(m => m.Map<ProductEntity>(addProductInput)).Returns(productEntity);
            addProductRepo.Setup(r => r.AddAsync(productEntity)).ReturnsAsync(0);

            AddProductUseCase addProductUseCase = new AddProductUseCase(addProductRepo.Object, mapper.Object);

            ResultState resultState = ResultState.NotFound;

            // Act
            var result = addProductUseCase.Execute(addProductInput);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
            Assert.IsNull(result.Result.Data);
        }
    }
}
