using Application.DTOs.User;
using Application.Entities;
using Application.Enums;
using Application.Interfaces._01_Common;
using Application.UseCases.User;
using AutoMapper;
using Moq;

namespace UnitTests.Application.UseCases.User
{
    [TestClass]
    public class UpdateUserUCTestTest
    {
        [TestMethod]
        public void UpdateUser_ShouldReturnSuccsessWithData()
        {
            // Arrange
            Mock<IUpdateRepo<UserEntity>> updateRepo = new Mock<IUpdateRepo<UserEntity>>();
            Mock<IMapper> mapper = new Mock<IMapper>();

            UserEntity userEntity = new UserEntity();
            UpdateUserInput updateUserInput = new UpdateUserInput();

            mapper.Setup(m => m.Map<UserEntity>(updateUserInput)).Returns(userEntity);
            updateRepo.Setup(r => r.UpdateAsync(userEntity)).ReturnsAsync(true);

            //UpdateUserUseCase updateUserUseCase = new UpdateUserUseCase(updateRepo.Object, mapper.Object);

            ResultState resultState = ResultState.Success;

            // Act
            //var result = updateUserUseCase.Execute(updateUserInput);

            // Assert
            //Assert.AreEqual(result.Result.ResultState, resultState);
            //Assert.IsNull(result.Result.Data);
        }

        [TestMethod]
        public void UpdateUser_ShouldReturnNotFoundWithNullData()
        {
            // Arrange
            Mock<IUpdateRepo<UserEntity>> updateUserRepo = new Mock<IUpdateRepo<UserEntity>>();
            Mock<IMapper> mapper = new Mock<IMapper>();

            UserEntity userEntity = new UserEntity();
            UpdateUserInput updateUserInput = new UpdateUserInput();

            mapper.Setup(m => m.Map<UserEntity>(updateUserInput)).Returns(userEntity);
            updateUserRepo.Setup(r => r.UpdateAsync(userEntity)).ReturnsAsync(false);

            //UpdateUserUseCase updateUserUseCase = new UpdateUserUseCase(updateUserRepo.Object, mapper.Object);

            ResultState resultState = ResultState.NotFound;

            // Act
            //var result = updateUserUseCase.Execute(updateUserInput);

            // Assert
            //Assert.AreEqual(result.Result.ResultState, resultState);
            //Assert.IsNull(result.Result.Data);
        }
    }
}
