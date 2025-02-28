using Application.DTOs.Supply;
using Application.Entities;
using Application.Enums;
using Application.Interfaces._01_Common;
using Application.UseCases.Supply;
using AutoMapper;
using Moq;

namespace UnitTests.Application.UseCases.Supply
{
    [TestClass]
    public class UpdateUomUCTest
    {
        [TestMethod]
        public void UpdateUom_ShouldReturnSuccsessWithData()
        {
            // Arrange
            Mock<IUpdateRepo<UoMEntity>> updateRepo = new Mock<IUpdateRepo<UoMEntity>>();
            Mock<IMapper> mapper = new Mock<IMapper>();

            UoMEntity uomEntity = new UoMEntity();
            UpdateUomInput updateUomInput = new UpdateUomInput();

            mapper.Setup(m => m.Map<UoMEntity>(updateUomInput)).Returns(uomEntity);
            updateRepo.Setup(r => r.UpdateAsync(uomEntity)).ReturnsAsync(true);

            UpdateUomUseCase updateUomUseCase = new UpdateUomUseCase(updateRepo.Object, mapper.Object);

            ResultState resultState = ResultState.Success;

            // Act
            var result = updateUomUseCase.Execute(updateUomInput);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
            Assert.IsNull(result.Result.Data);
        }

        [TestMethod]
        public void UpdateUom_ShouldReturnNotFoundWithNullData()
        {
            // Arrange
            Mock<IUpdateRepo<UoMEntity>> updateUomRepo = new Mock<IUpdateRepo<UoMEntity>>();
            Mock<IMapper> mapper = new Mock<IMapper>();

            UoMEntity uomEntity = new UoMEntity();
            UpdateUomInput updateUomInput = new UpdateUomInput();

            mapper.Setup(m => m.Map<UoMEntity>(updateUomInput)).Returns(uomEntity);
            updateUomRepo.Setup(r => r.UpdateAsync(uomEntity)).ReturnsAsync(false);

            UpdateUomUseCase updateUomUseCase = new UpdateUomUseCase(updateUomRepo.Object, mapper.Object);

            ResultState resultState = ResultState.NotFound;

            // Act
            var result = updateUomUseCase.Execute(updateUomInput);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
            Assert.IsNull(result.Result.Data);
        }
    }
}
