using Application.Entities;
using Application.Interfaces._01_Common;
using Application.Interfaces.Kiosco;
using Application.UseCases.Kiosco;
using Moq;

namespace UnitTests.Kiosco
{
    [TestClass]
    public class ToggleIsChangesUCTest
    {
        [TestMethod]
        public void ToggleIsChanges_ShouldReturnAppResult()
        {
            // Arrange
            Mock<IToggleIsChangesRepo> toggleIsChangesRepo = new Mock<IToggleIsChangesRepo>();
            int id = 1;

            // Act
            ToggleIsChangesUseCase toggleIsChangesUseCase = new ToggleIsChangesUseCase(toggleIsChangesRepo.Object);
            var result = toggleIsChangesUseCase.Execute(id);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
