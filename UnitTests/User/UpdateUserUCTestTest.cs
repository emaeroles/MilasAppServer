using Application.DTOs.User;
using Application.Entities;
using Application.Interfaces._01_Common;
using Application.UseCases.User;
using AutoMapper;
using Moq;

namespace UnitTests.User
{
    [TestClass]
    public class UpdateUserUCTestTest
    {
        [TestMethod]
        public void UpdateUser_ShouldReturnAppResult()
        {
            // Arrange
            Mock<IUpdateRepo<UserEntity>> updateUserRepo = new Mock<IUpdateRepo<UserEntity>>();
            Mock<IMapper> mapper = new Mock<IMapper>();

            // Act
            UpdateUserUseCase updateUserUseCase = new UpdateUserUseCase(updateUserRepo.Object, mapper.Object);
            UpdateUserInput updateUserInput = new UpdateUserInput();
            var result = updateUserUseCase.Execute(updateUserInput);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
