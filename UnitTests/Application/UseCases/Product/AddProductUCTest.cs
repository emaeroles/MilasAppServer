﻿using Application.DTOs.Product;
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
        public void AddProduct_ShouldReturnCreated()
        {
            // Arrange
            Mock<IAddRepo<ProductEntity>> addProductRepo = new Mock<IAddRepo<ProductEntity>>();
            Mock<IMapper> mapper = new Mock<IMapper>();

            AddProductInput addProductInput = new AddProductInput();
            ProductEntity productEntity = new ProductEntity();

            mapper.Setup(m => m.Map<ProductEntity>(addProductInput)).Returns(productEntity);
            addProductRepo.Setup(r => r.AddAsync(productEntity)).ReturnsAsync(true);

            AddProductUseCase addProductUseCase = new AddProductUseCase(addProductRepo.Object, mapper.Object);

            ResultState resultState = ResultState.Created;

            // Act
            var result = addProductUseCase.Execute(addProductInput);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
        }
    }
}
