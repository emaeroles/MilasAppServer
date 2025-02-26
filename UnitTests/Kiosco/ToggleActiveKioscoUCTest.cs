using Application.Entities;
using Application.Interfaces._01_Common;
using Application.UseCases.Kiosco;
using Moq;

namespace UnitTests.Kiosco
{
    [TestClass]
    public class ToggleActiveKioscoUCTest
    {
        [TestMethod]
        public void ToggleActiveKiosco_ShouldReturnAppResult()
        {
            // Arrange
            Mock<IToggleActiveRepo<KioscoEntity>> toggleActiveKioscoRepo = new Mock<IToggleActiveRepo<KioscoEntity>>();
            int id = 1;

            // Act
            ToggleActiveKioscoUseCase toggleActiveKioscoUseCase = new ToggleActiveKioscoUseCase(toggleActiveKioscoRepo.Object);
            var result = toggleActiveKioscoUseCase.Execute(id);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
