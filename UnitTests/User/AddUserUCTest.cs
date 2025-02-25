using Application.DTOs.User;
using Application.Entities;
using Application.Interfaces._01_Common;
using Application.Interfaces.User;
using Application.UseCases.User;
using AutoMapper;
using Moq;

namespace UnitTests.User
{
    [TestClass]
    public class AddUserUCTest
    {
        [TestMethod]
        public void AddUser_ShouldReturnAppResult()
        {
            // Arrange
            Mock<IAddRepo<UserEntity>> addUserRepo = new Mock<IAddRepo<UserEntity>>();
            Mock<ICheckUserExistRepo> checkUserRepo = new Mock<ICheckUserExistRepo>();
            Mock<IMapper> mapper = new Mock<IMapper>();

            // Act
            AddUserUseCase addUserUseCase = new AddUserUseCase(addUserRepo.Object, checkUserRepo.Object, mapper.Object);
            AddUserInput addUserInput = new AddUserInput();
            var result = addUserUseCase.Execute(addUserInput);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
