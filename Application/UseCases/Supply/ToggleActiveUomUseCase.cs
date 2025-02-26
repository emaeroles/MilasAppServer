using Application.DTOs._01_Common;
using Application.Entities;
using Application.Factories;
using Application.Interfaces._01_Common;

namespace Application.UseCases.Supply
{
    public class ToggleActiveUomUseCase
    {
        private readonly IToggleActiveRepo<UoMEntity> _toggleActiveRepo;

        public ToggleActiveUomUseCase(IToggleActiveRepo<UoMEntity> toggleActiveRepo)
        {
            _toggleActiveRepo = toggleActiveRepo;
        }

        public async Task<AppResult> Execute(int id)
        {
            var isOk = await _toggleActiveRepo.ToggleActiveAsync(id);
            if (!isOk)
                return ResultFactory.CreateNotFound("Unit of Mesure was not exist");

            return ResultFactory.CreateSuccess("Unit of Mesure activation was changed", null);
        }
    }
}
