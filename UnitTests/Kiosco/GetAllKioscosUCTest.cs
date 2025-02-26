using Application.Entities;
using Application.Interfaces._01_Common;
using Application.UseCases.Kiosco;
using AutoMapper;
using Moq;

namespace UnitTests.Kiosco
{
    [TestClass]
    public class GetAllKioscosUCTest
    {
        [TestMethod]
        public void GetAllKioscos_ShouldReturnAppResult()
        {
            // Arrange
            Mock<IGetAllByActiveRepo<KioscoEntity>> getAllByActiveRepo = new Mock<IGetAllByActiveRepo<KioscoEntity>>();
            Mock<IMapper> mapper = new Mock<IMapper>();
            bool isActive = true;

            // Act
            GetAllKioscosUseCase getAllKioscosUseCase = new GetAllKioscosUseCase(getAllByActiveRepo.Object, mapper.Object);
            var result = getAllKioscosUseCase.Execute(isActive);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
