using Application.DTOs._01_Common;
using Application.Entities;
using Application.Factories;
using Application.Interfaces._01_Common;

namespace Application.UseCases.KioscoProduct
{
    public class DeleteKioscoProductUseCase
    {
        private readonly IDeleteComposedRepo<KioscoProductEntity> _deleteComposedRepo;
        private readonly IGetByIdComposedRepo<KioscoProductEntity> _getByIdComposedRepo;

        public DeleteKioscoProductUseCase(
            IDeleteComposedRepo<KioscoProductEntity> deleteComposedRepo,
            IGetByIdComposedRepo<KioscoProductEntity> getByIdComposedRepo)
        {
            _deleteComposedRepo = deleteComposedRepo;
            _getByIdComposedRepo = getByIdComposedRepo;
        }

        public async Task<AppResult> Execute(Guid productId, Guid kioscoId)
        {
            KioscoProductEntity? kioscoProductEntityExist = await _getByIdComposedRepo
                .GetByIdComposedAsync(productId, kioscoId);

            if (kioscoProductEntityExist == null)
                return ResultFactory.CreateNotFound("The kiosco product does not exists");

            bool isDeleted = await _deleteComposedRepo.DeleteComposedAsync(productId, kioscoId);

            if (!isDeleted)
                return ResultFactory.CreateNotDeleted("The kiosco product was not deleted");

            return ResultFactory.CreateDeleted("The kiosco product was deleted");
        }
    }
}
