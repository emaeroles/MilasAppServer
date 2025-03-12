using Application.DTOs._01_Common;
using Application.DTOs.KioscoProduct;
using Application.Entities;
using Application.Factories;
using Application.Interfaces._01_Common;

namespace Application.UseCases.KioscoProduct
{
    public class UpdateKioscoProductPriceUseCase
    {
        private readonly IUpdateRepo<KioscoProductEntity> _updateRepo;
        private readonly IGetByIdComposedRepo<KioscoProductEntity> _getByIdComposedRepo;

        public UpdateKioscoProductPriceUseCase(
            IUpdateRepo<KioscoProductEntity> updateRepo,
            IGetByIdComposedRepo<KioscoProductEntity> getByIdComposedRepo)
        {
            _updateRepo = updateRepo;
            _getByIdComposedRepo = getByIdComposedRepo;
        }

        public async Task<AppResult> Execute(UpdateKioscoProductPriceIuput updateKioscoProductPriceIuput)
        {
            KioscoProductEntity? kioscoProductEntity = await _getByIdComposedRepo
                .GetByIdComposedAsync(updateKioscoProductPriceIuput.ProductId, updateKioscoProductPriceIuput.KioscoId);
            if (kioscoProductEntity == null)
                return ResultFactory.CreateNotFound("The kiosco product does not exists");

            kioscoProductEntity.KioscoSalePrice = updateKioscoProductPriceIuput.KioscoSalePrice;

            bool isUpdated = await _updateRepo.UpdateAsync(kioscoProductEntity);

            if (!isUpdated)
                return ResultFactory.CreateNotDeleted("The kiosco product was not updated");

            return ResultFactory.CreateDeleted("The kiosco product was updated");
        }
    }
}
