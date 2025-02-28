using Application.DTOs.User;
using Application.Entities;
using Application.Enums;
using Application.Interfaces._01_Common;
using Application.Interfaces.User;
using Application.UseCases.User;
using AutoMapper;
using Moq;

namespace UnitTests.Application.UseCases.User
{
    [TestClass]
    public class AddUserUCTest
    {
        [TestMethod]
        public void AddUser_ShouldReturnCreatedWithData()
        {
            // Arrange
            Mock<IAddRepo<UserEntity>> addUserRepo = new Mock<IAddRepo<UserEntity>>();
            Mock<ICheckUserExistRepo> checkUserRepo = new Mock<ICheckUserExistRepo>();
            Mock<IMapper> mapper = new Mock<IMapper>();

            AddUserInput addUserInput = new AddUserInput();
            UserEntity userEntity = new UserEntity();

            mapper.Setup(m => m.Map<UserEntity>(addUserInput)).Returns(userEntity);
            addUserRepo.Setup(r => r.AddAsync(userEntity)).ReturnsAsync(1);

            AddUserUseCase addUserUseCase = new AddUserUseCase(addUserRepo.Object, checkUserRepo.Object, mapper.Object);

            ResultState resultState = ResultState.Created;

            // Act
            var result = addUserUseCase.Execute(addUserInput);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
            Assert.IsNotNull(result.Result.Data);
        }

        [TestMethod]
        public void AddUser_ShouldReturnConflictWithNullData()
        {
            // Arrange
            Mock<IAddRepo<UserEntity>> addUserRepo = new Mock<IAddRepo<UserEntity>>();
            Mock<ICheckUserExistRepo> checkUserRepo = new Mock<ICheckUserExistRepo>();
            Mock<IMapper> mapper = new Mock<IMapper>();

            AddUserInput addUserInput = new AddUserInput();
            addUserInput.Username = "username";
            UserEntity userEntity = new UserEntity();

            checkUserRepo.Setup(r => r.CheckUserExistAsync(addUserInput.Username)).ReturnsAsync(true);

            AddUserUseCase addUserUseCase = new AddUserUseCase(addUserRepo.Object, checkUserRepo.Object, mapper.Object);

            ResultState resultState = ResultState.Conflict;

            // Act
            var result = addUserUseCase.Execute(addUserInput);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
            Assert.IsNull(result.Result.Data);
        }
    }
}
