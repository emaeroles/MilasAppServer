using Application.DTOs._01_Common;
using Application.Entities;
using Application.Factories;
using Application.Interfaces._01_Common;

namespace Application.UseCases.Supply
{
    public class ToggleActiveSupplyUseCase
    {
        private readonly IToggleActiveRepo<SupplyEntity> _toggleActiveRepo;

        public ToggleActiveSupplyUseCase(IToggleActiveRepo<SupplyEntity> toggleActiveRepo)
        {
            _toggleActiveRepo = toggleActiveRepo;
        }

        public async Task<AppResult> Execute(int id)
        {
            var isOk = await _toggleActiveRepo.ToggleActiveAsync(id);
            if (!isOk)
                return ResultFactory.CreateNotFound("Supply was not exist");

            return ResultFactory.CreateSuccess("Supply activation was changed", null);
        }
    }
}
