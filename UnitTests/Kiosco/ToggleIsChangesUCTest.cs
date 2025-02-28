using Application.Enums;
using Application.Interfaces.Kiosco;
using Application.UseCases.Kiosco;
using Moq;

namespace UnitTests.Kiosco
{
    [TestClass]
    public class ToggleIsChangesUCTest
    {
        [TestMethod]
        public void ToggleIsChanges_ShouldReturnSuccess()
        {
            // Arrange
            Mock<IToggleIsChangesRepo> toggleIsChangesRepo = new Mock<IToggleIsChangesRepo>();
            int entityId = 1;

            toggleIsChangesRepo.Setup(r => r.ToggleIsChangesAsync(entityId)).ReturnsAsync(true);

            ToggleIsChangesUseCase toggleIsChangesUseCase = new ToggleIsChangesUseCase(toggleIsChangesRepo.Object);

            ResultState resultState = ResultState.Success;

            // Act
            var result = toggleIsChangesUseCase.Execute(entityId);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
        }

        [TestMethod]
        public void ToggleIsChanges_ShouldReturnNotFound()
        {
            // Arrange
            Mock<IToggleIsChangesRepo> toggleIsChangesRepo = new Mock<IToggleIsChangesRepo>();
            int entityId = 1;

            toggleIsChangesRepo.Setup(r => r.ToggleIsChangesAsync(entityId)).ReturnsAsync(false);

            ToggleIsChangesUseCase toggleIsChangesUseCase = new ToggleIsChangesUseCase(toggleIsChangesRepo.Object);

            ResultState resultState = ResultState.NotFound;

            // Act
            var result = toggleIsChangesUseCase.Execute(entityId);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
        }
    }
}
