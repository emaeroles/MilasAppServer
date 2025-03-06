using Application.DTOs._01_Common;
using Application.Entities;
using Application.Factories;
using Application.Interfaces._01_Common;

namespace Application.UseCases.Product
{
    public class ToggleActiveProductUseCase
    {
        private readonly IUpdateRepo<ProductEntity> _updateRepo;
        private readonly IGetByIdRepo<ProductEntity> _getByIdRepo;

        public ToggleActiveProductUseCase(
            IUpdateRepo<ProductEntity> updateRepo,
            IGetByIdRepo<ProductEntity> getByIdRepo)
        {
            _updateRepo = updateRepo;
            _getByIdRepo = getByIdRepo;
        }

        public async Task<AppResult> Execute(Guid id)
        {
            ProductEntity? productEntity = await _getByIdRepo.GetByIdAsync(id);

            if (productEntity == null)
                return ResultFactory.CreateNotFound("The product does not exist");

            productEntity.IsActive = !productEntity.IsActive;

            bool isUpdated = await _updateRepo.UpdateAsync(productEntity);
            if (!isUpdated)
                return ResultFactory.CreateNotUpdated("The product was not updated");

            return ResultFactory.CreateUpdated("The product was updated");
        }
    }
}
