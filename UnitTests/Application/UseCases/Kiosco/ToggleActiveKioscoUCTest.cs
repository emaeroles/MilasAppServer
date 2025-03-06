using Application.Entities;
using Application.Enums;
using Application.Interfaces._01_Common;
using Application.UseCases.Kiosco;
using Moq;

namespace UnitTests.Application.UseCases.Kiosco
{
    [TestClass]
    public class ToggleActiveKioscoUCTest
    {
        [TestMethod]
        public void ToggleActiveKiosco_ShouldReturnUpdated()
        {
            // Arrange
            Mock<IUpdateRepo<KioscoEntity>> updateRepo = new Mock<IUpdateRepo<KioscoEntity>>();
            Mock<IGetByIdRepo<KioscoEntity>> getByIdRepo = new Mock<IGetByIdRepo<KioscoEntity>>();
            
            Guid entityId = Guid.NewGuid();
            KioscoEntity kioscoEntity = new KioscoEntity();

            getByIdRepo.Setup(r => r.GetByIdAsync(entityId)).ReturnsAsync(kioscoEntity);
            updateRepo.Setup(r => r.UpdateAsync(It.IsAny<KioscoEntity>())).ReturnsAsync(true);

            ToggleActiveKioscoUseCase toggleActiveKioscoUseCase = new ToggleActiveKioscoUseCase(
                updateRepo.Object, getByIdRepo.Object);

            ResultState resultState = ResultState.Updated;

            // Act
            var result = toggleActiveKioscoUseCase.Execute(entityId);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
        }

        [TestMethod]
        public void ToggleActiveKiosco_ShouldReturnNotFound()
        {
            // Arrange
            Mock<IUpdateRepo<KioscoEntity>> updateRepo = new Mock<IUpdateRepo<KioscoEntity>>();
            Mock<IGetByIdRepo<KioscoEntity>> getByIdRepo = new Mock<IGetByIdRepo<KioscoEntity>>();

            Guid entityId = Guid.NewGuid();
            KioscoEntity? kioscoEntity = null;

            getByIdRepo.Setup(r => r.GetByIdAsync(entityId)).ReturnsAsync(kioscoEntity);

            ToggleActiveKioscoUseCase toggleActiveKioscoUseCase = new ToggleActiveKioscoUseCase(
                updateRepo.Object, getByIdRepo.Object);

            ResultState resultState = ResultState.NotFound;

            // Act
            var result = toggleActiveKioscoUseCase.Execute(entityId);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
        }
    }
}
