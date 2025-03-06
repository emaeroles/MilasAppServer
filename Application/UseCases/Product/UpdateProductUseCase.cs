using Application.DTOs._01_Common;
using Application.DTOs.Product;
using Application.Entities;
using Application.Factories;
using Application.Interfaces._01_Common;

namespace Application.UseCases.Product
{
    public class UpdateProductUseCase
    {
        private readonly IUpdateRepo<ProductEntity> _updateRepo;
        private readonly IGetByIdRepo<ProductEntity> _getByIdRepo;

        public UpdateProductUseCase(
            IUpdateRepo<ProductEntity> updateRepo,
            IGetByIdRepo<ProductEntity> getByIdRepo)
        {
            _updateRepo = updateRepo;
            _getByIdRepo = getByIdRepo;
        }

        public async Task<AppResult> Execute(UpdateProductInput updateProductInput)
        {
            ProductEntity? productEntity = await _getByIdRepo.GetByIdAsync(updateProductInput.Id);

            if (productEntity == null)
                return ResultFactory.CreateNotFound("The product does not exist");

            productEntity.Name = updateProductInput.Name;
            productEntity.IsOwn = updateProductInput.IsOwn;
            productEntity.CostPrice = updateProductInput.CostPrice;
            productEntity.SalePrice = updateProductInput.SalePrice;

            bool isUpdated = await _updateRepo.UpdateAsync(productEntity);
            if (!isUpdated)
                return ResultFactory.CreateNotUpdated("The product was not updated");

            return ResultFactory.CreateUpdated("The product was updated");
        }
    }
}
