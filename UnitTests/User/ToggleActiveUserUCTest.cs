using Application.Entities;
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
            Mock<IToggleActiveRepo<UserEntity>> toggleActiveUserRepo = new Mock<IToggleActiveRepo<UserEntity>>();
            int id = 1;

            // Act
            ToggleActiveUserUseCase toggleActiveUserUseCase = new ToggleActiveUserUseCase(toggleActiveUserRepo.Object);
            var result = toggleActiveUserUseCase.Execute(id);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
