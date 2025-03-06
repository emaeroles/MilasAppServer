using Application.DTOs._01_Common;
using Application.DTOs.Supply;
using Application.Entities;
using Application.Factories;
using Application.Interfaces._01_Common;

namespace Application.UseCases.Supply
{
    public class DeleteSupplyProductUseCase
    {
        private readonly IDeleteComposedRepo<SupplyProductEntity> _deleteComposedRepo;
        private readonly IGetByIdComposedRepo<SupplyProductEntity> _getByIdComposedRepo;

        public DeleteSupplyProductUseCase(
            IDeleteComposedRepo<SupplyProductEntity> deleteComposedRepo, 
            IGetByIdComposedRepo<SupplyProductEntity> getByIdComposedRepo)
        {
            _deleteComposedRepo = deleteComposedRepo;
            _getByIdComposedRepo = getByIdComposedRepo;
        }

        public async Task<AppResult> Execute(Guid supplyId, Guid productId)
        {
            SupplyProductEntity? supplyProductEntityExist = await _getByIdComposedRepo
                .GetByIdComposedAsync(supplyId, productId);

            if (supplyProductEntityExist == null)
                return ResultFactory.CreateNotFound("The supply product does not exists");

            bool isDeleted = await _deleteComposedRepo.DeleteComposedAsync(supplyId, productId);

            if (!isDeleted)
                return ResultFactory.CreateNotDeleted("The supply product was not deleted");

            return ResultFactory.CreateDeleted("The supply product was deleted");
        }
    }
}
