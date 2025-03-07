using Application.DTOs._01_Common;
using Application.DTOs.ProductKiosco;
using Application.Entities;
using Application.Factories;
using Application.Interfaces._01_Common;

namespace Application.UseCases.ProductKiosco
{
    public class UpdateProductKioscoPriceUseCase
    {
        private readonly IUpdateRepo<ProductKioscoEntity> _updateRepo;
        private readonly IGetByIdComposedRepo<ProductKioscoEntity> _getByIdComposedRepo;
        private readonly IGetByIdRepo<KioscoEntity> _getByIdKioscoRepo;
        private readonly IGetByIdRepo<ProductEntity> _getByIdProductRepo;

        public UpdateProductKioscoPriceUseCase(
            IUpdateRepo<ProductKioscoEntity> updateRepo,
            IGetByIdComposedRepo<ProductKioscoEntity> getByIdComposedRepo,
            IGetByIdRepo<KioscoEntity> getByIdKioscoRepo,
            IGetByIdRepo<ProductEntity> getByIdProductRepo)
        {
            _updateRepo = updateRepo;
            _getByIdComposedRepo = getByIdComposedRepo;
            _getByIdKioscoRepo = getByIdKioscoRepo;
            _getByIdProductRepo = getByIdProductRepo;
        }

        public async Task<AppResult> Execute(UpdateProductKioscoPriceIuput updateProductKioscoPriceIuput)
        {
            ProductKioscoEntity? productKioscoEntity = await _getByIdComposedRepo
                .GetByIdComposedAsync(updateProductKioscoPriceIuput.ProductId, updateProductKioscoPriceIuput.KioscoId);
            if (productKioscoEntity == null)
                return ResultFactory.CreateNotFound("The kiosco product does not exists");

            KioscoEntity? kioscoEntity = await _getByIdKioscoRepo.GetByIdAsync(updateProductKioscoPriceIuput.KioscoId);
            if (kioscoEntity == null)
                return ResultFactory.CreateNotFound("The kiosco does not exist");

            ProductEntity? productEntity = await _getByIdProductRepo.GetByIdAsync(updateProductKioscoPriceIuput.ProductId);
            if (productEntity == null)
                return ResultFactory.CreateNotFound("The product does not exist");

            productKioscoEntity.KioscoSalePrice = updateProductKioscoPriceIuput.KioscoSalePrice;

            bool isUpdated = await _updateRepo.UpdateAsync(productKioscoEntity);

            if (!isUpdated)
                return ResultFactory.CreateNotDeleted("The kiosco product was not updated");

            return ResultFactory.CreateDeleted("The kiosco product was updated");
        }
    }
}
