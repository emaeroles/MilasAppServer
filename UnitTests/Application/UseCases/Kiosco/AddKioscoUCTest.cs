using Application.DTOs.Kiosco;
using Application.Entities;
using Application.Enums;
using Application.Interfaces._01_Common;
using Application.UseCases.Kiosco;
using AutoMapper;
using Moq;

namespace UnitTests.Application.UseCases.Kiosco
{
    [TestClass]
    public class AddKioscoUCTest
    {
        [TestMethod]
        public void AddKiosco_ShouldReturnCreated()
        {
            // Arrange
            Mock<IAddRepo<KioscoEntity>> addKioscoRepo = new Mock<IAddRepo<KioscoEntity>>();
            Mock<IGetByIdRepo<UserEntity>> getByIdRepo = new Mock<IGetByIdRepo<UserEntity>>();
            Mock<IMapper> mapper = new Mock<IMapper>();

            AddKioscoInput addKioscoInput = new AddKioscoInput();
            KioscoEntity kioscoEntity = new KioscoEntity();
            UserEntity userEntity = new UserEntity();

            mapper.Setup(m => m.Map<KioscoEntity>(addKioscoInput)).Returns(kioscoEntity);
            getByIdRepo.Setup(r => r.GetByIdAsync(addKioscoInput.UserId)).ReturnsAsync(userEntity);
            addKioscoRepo.Setup(r => r.AddAsync(kioscoEntity)).ReturnsAsync(true);

            AddKioscoUseCase addKioscoUseCase = new AddKioscoUseCase(
                addKioscoRepo.Object, getByIdRepo.Object, mapper.Object);

            ResultState resultState = ResultState.Created;

            // Act
            var result = addKioscoUseCase.Execute(addKioscoInput);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
        }

        [TestMethod]
        public void AddKiosco_ShouldReturnNotFoud()
        {
            // Arrange
            Mock<IAddRepo<KioscoEntity>> addKioscoRepo = new Mock<IAddRepo<KioscoEntity>>();
            Mock<IGetByIdRepo<UserEntity>> getByIdRepo = new Mock<IGetByIdRepo<UserEntity>>();
            Mock<IMapper> mapper = new Mock<IMapper>();

            AddKioscoInput addKioscoInput = new AddKioscoInput();
            UserEntity? userEntity = null;

            getByIdRepo.Setup(r => r.GetByIdAsync(addKioscoInput.UserId)).ReturnsAsync(userEntity);
            
            AddKioscoUseCase addKioscoUseCase = new AddKioscoUseCase(
                addKioscoRepo.Object, getByIdRepo.Object, mapper.Object);

            ResultState resultState = ResultState.NotFound;

            // Act
            var result = addKioscoUseCase.Execute(addKioscoInput);

            // Assert
            Assert.AreEqual(result.Result.ResultState, resultState);
        }
    }
}
