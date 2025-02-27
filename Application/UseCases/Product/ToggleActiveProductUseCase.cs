using Application.DTOs._01_Common;
using Application.Entities;
using Application.Factories;
using Application.Interfaces._01_Common;

namespace Application.UseCases.Product
{
    public class ToggleActiveProductUseCase
    {
        private readonly IToggleActiveRepo<ProductEntity> _toggleActiveRepo;

        public ToggleActiveProductUseCase(IToggleActiveRepo<ProductEntity> toggleActiveRepo)
        {
            _toggleActiveRepo = toggleActiveRepo;
        }

        public async Task<AppResult> Execute(int id)
        {
            var isOk = await _toggleActiveRepo.ToggleActiveAsync(id);
            if (!isOk)
                return ResultFactory.CreateNotFound("Product was not exist");

            return ResultFactory.CreateSuccess("Product activation was changed", null);
        }
    }
}
