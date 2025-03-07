using Application.DTOs._01_Common;
using Application.Entities;
using Application.Factories;
using Application.Interfaces._01_Common;

namespace Application.UseCases.ProductKiosco
{
    public class DeleteProductKioscoUseCase
    {
        private readonly IDeleteComposedRepo<ProductKioscoEntity> _deleteComposedRepo;
        private readonly IGetByIdComposedRepo<ProductKioscoEntity> _getByIdComposedRepo;

        public DeleteProductKioscoUseCase(
            IDeleteComposedRepo<ProductKioscoEntity> deleteComposedRepo,
            IGetByIdComposedRepo<ProductKioscoEntity> getByIdComposedRepo)
        {
            _deleteComposedRepo = deleteComposedRepo;
            _getByIdComposedRepo = getByIdComposedRepo;
        }

        public async Task<AppResult> Execute(Guid productId, Guid kioscoId)
        {
            ProductKioscoEntity? productKioscoEntityExist = await _getByIdComposedRepo
                .GetByIdComposedAsync(productId, kioscoId);

            if (productKioscoEntityExist == null)
                return ResultFactory.CreateNotFound("The kiosco product does not exists");

            bool isDeleted = await _deleteComposedRepo.DeleteComposedAsync(productId, kioscoId);

            if (!isDeleted)
                return ResultFactory.CreateNotDeleted("The kiosco product was not deleted");

            return ResultFactory.CreateDeleted("The kiosco product was deleted");
        }
    }
}
