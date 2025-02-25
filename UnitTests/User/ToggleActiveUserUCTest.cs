using Application.Interfaces._01_Common;
using Application.Interfaces.User;
using Application.UseCases.User;
using AutoMapper;
using Moq;

namespace UnitTests.User
{
    [TestClass]
    public class ToggleActiveUserUCTest
    {
        [TestMethod]
        public void ToggleActiveUser_ShouldReturnAppResult()
        {
            // Arrange
            Mock<IToggleActiveRepo> toggleActiveUserRepo = new Mock<IToggleActiveRepo>();
            Mock<ICheckUserExistRepo> checkUserRepo = new Mock<ICheckUserExistRepo>();
            Mock<IMapper> mapper = new Mock<IMapper>();
            int id = 1;

            // Act
            ToggleActiveUserUseCase toggleActiveUserUseCase = new ToggleActiveUserUseCase(toggleActiveUserRepo.Object, checkUserRepo.Object, mapper.Object);
            var result = toggleActiveUserUseCase.Execute(id);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
