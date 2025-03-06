using Application.Entities;
using Application.Enums;
using Application.Interfaces._01_Common;
using Application.UseCases.Kiosco;
using Moq;

namespace UnitTests.Application.UseCases.Kiosco
{
    [TestClass]
    public class ToggleIsChangesUCTest
    {
        [TestMethod]
        public void ToggleIsChanges_ShouldReturnUpdated()
        {
            // Arrange
            Mock<IUpdateRepo<KioscoEntity>> updateRepo = new Mock<IUpdateRepo<KioscoEntity>>();
            Mock<IGetByIdRepo<KioscoEntity>> getByIdRepo = new Mock<IGetByIdRepo<KioscoEntity>>();

            Guid entityId = Guid.NewGuid();
            KioscoEntity kioscoEntity = new KioscoEntity();

            getByIdRepo.Setup(r => r.GetByIdAsync(entityId)).ReturnsAsync(kioscoEntity);
            updateRepo.Setup(r => r.UpdateAsync(It.IsAny<KioscoEntity>())).ReturnsAsync(true);

            ToggleIsChangesUseCase toggleIsChangesUseCase = new ToggleIsChangesUseCase(
                updateRepo.Object, getByIdRepo.Object);

            ResultState resultState = ResultState.Updated;

            // Act
            var result = toggleIsChangesUseCase.Execute(entityId);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
        }

        [TestMethod]
        public void ToggleIsChanges_ShouldReturnNotFound()
        {
            // Arrange
            Mock<IUpdateRepo<KioscoEntity>> updateRepo = new Mock<IUpdateRepo<KioscoEntity>>();
            Mock<IGetByIdRepo<KioscoEntity>> getByIdRepo = new Mock<IGetByIdRepo<KioscoEntity>>();

            Guid entityId = Guid.NewGuid();
            KioscoEntity? kioscoEntity = null;

            getByIdRepo.Setup(r => r.GetByIdAsync(entityId)).ReturnsAsync(kioscoEntity);

            ToggleIsChangesUseCase toggleIsChangesUseCase = new ToggleIsChangesUseCase(
                updateRepo.Object, getByIdRepo.Object);

            ResultState resultState = ResultState.NotFound;

            // Act
            var result = toggleIsChangesUseCase.Execute(entityId);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
        }
    }
}
