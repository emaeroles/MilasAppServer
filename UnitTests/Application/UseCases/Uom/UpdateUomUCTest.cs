using Application.DTOs.Uom;
using Application.Entities;
using Application.Enums;
using Application.Interfaces._01_Common;
using Application.UseCases.Uom;
using Moq;

namespace UnitTests.Application.UseCases.Uom
{
    [TestClass]
    public class UpdateUomUCTest
    {
        [TestMethod]
        public void UpdateUom_ShouldReturnUpdated()
        {
            // Arrange
            Mock<IUpdateRepo<UomEntity>> updateRepo = new Mock<IUpdateRepo<UomEntity>>();
            Mock<IGetByIdRepo<UomEntity>> getByIdRepo = new Mock<IGetByIdRepo<UomEntity>>();

            UomEntity uomEntity = new UomEntity();
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
            Mock<IUpdateRepo<UomEntity>> updateRepo = new Mock<IUpdateRepo<UomEntity>>();
            Mock<IGetByIdRepo<UomEntity>> getByIdRepo = new Mock<IGetByIdRepo<UomEntity>>();

            UomEntity? uomEntity = null;
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
