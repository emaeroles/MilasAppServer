using Application.Entities;
using Application.Interfaces._01_Common;
using Application.UseCases.User;
using AutoMapper;
using Moq;

namespace UnitTests.User
{
    [TestClass]
    public class GetAllUsersUCTest
    {
        [TestMethod]
        public void GetAllUsers_ShouldReturnAppResult()
        {
            // Arrange
            Mock<IGetAllByActiveRepo<UserEntity>> getAllByActiveRepo = new Mock<IGetAllByActiveRepo<UserEntity>>();
            Mock<IMapper> mapper = new Mock<IMapper>();
            bool isActive = true;

            // Act
            GetAllUsersUseCase getAllUsersUseCase = new GetAllUsersUseCase(getAllByActiveRepo.Object, mapper.Object);
            var result = getAllUsersUseCase.Execute(isActive);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
