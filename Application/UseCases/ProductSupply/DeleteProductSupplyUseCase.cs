using Application.DTOs._01_Common;
using Application.Entities;
using Application.Factories;
using Application.Interfaces._01_Common;

namespace Application.UseCases.ProductSupply
{
    public class DeleteProductSupplyUseCase
    {
        private readonly IDeleteComposedRepo<ProductSupplyEntity> _deleteComposedRepo;
        private readonly IGetByIdComposedRepo<ProductSupplyEntity> _getByIdComposedRepo;

        public DeleteProductSupplyUseCase(
            IDeleteComposedRepo<ProductSupplyEntity> deleteComposedRepo, 
            IGetByIdComposedRepo<ProductSupplyEntity> getByIdComposedRepo)
        {
            _deleteComposedRepo = deleteComposedRepo;
            _getByIdComposedRepo = getByIdComposedRepo;
        }

        public async Task<AppResult> Execute(Guid supplyId, Guid productId)
        {
            ProductSupplyEntity? productSupplyEntityExist = await _getByIdComposedRepo
                .GetByIdComposedAsync(supplyId, productId);

            if (productSupplyEntityExist == null)
                return ResultFactory.CreateNotFound("The product supply does not exists");

            bool isDeleted = await _deleteComposedRepo.DeleteComposedAsync(supplyId, productId);

            if (!isDeleted)
                return ResultFactory.CreateNotDeleted("The product supply was not deleted");

            return ResultFactory.CreateDeleted("The product supply was deleted");
        }
    }
}
