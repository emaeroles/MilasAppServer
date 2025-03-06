﻿using Application.DTOs.Supply;
using Application.Entities;
using Application.Enums;
using Application.Interfaces._01_Common;
using Application.UseCases.Supply;
using Moq;

namespace UnitTests.Application.UseCases.Supply
{
    [TestClass]
    public class UpdateUomUCTest
    {
        [TestMethod]
        public void UpdateUom_ShouldReturnUpdated()
        {
            // Arrange
            Mock<IUpdateRepo<UoMEntity>> updateRepo = new Mock<IUpdateRepo<UoMEntity>>();
            Mock<IGetByIdRepo<UoMEntity>> getByIdRepo = new Mock<IGetByIdRepo<UoMEntity>>();

            UoMEntity uomEntity = new UoMEntity();
            UpdateUomInput updateUomInput = new UpdateUomInput();

            getByIdRepo.Setup(r => r.GetByIdAsync(updateUomInput.Id)).ReturnsAsync(uomEntity);
            updateRepo.Setup(r => r.UpdateAsync(uomEntity)).ReturnsAsync(true);

            UpdateUomUseCase updateUomUseCase = new UpdateUomUseCase(updateRepo.Object, getByIdRepo.Object);

            ResultState resultState = ResultState.Updated;

            // Act
            var result = updateUomUseCase.Execute(updateUomInput);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
        }

        [TestMethod]
        public void UpdateUom_ShouldReturnNotFound()
        {
            // Arrange
            Mock<IUpdateRepo<UoMEntity>> updateRepo = new Mock<IUpdateRepo<UoMEntity>>();
            Mock<IGetByIdRepo<UoMEntity>> getByIdRepo = new Mock<IGetByIdRepo<UoMEntity>>();

            UoMEntity? uomEntity = null;
            UpdateUomInput updateUomInput = new UpdateUomInput();
            
            getByIdRepo.Setup(r => r.GetByIdAsync(updateUomInput.Id)).ReturnsAsync(uomEntity);

            UpdateUomUseCase updateUomUseCase = new UpdateUomUseCase(updateRepo.Object, getByIdRepo.Object);

            ResultState resultState = ResultState.NotFound;

            // Act
            var result = updateUomUseCase.Execute(updateUomInput);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
        }
    }
}
