using Application.DTOs._01_Common;
using Application.Entities;
using Application.Factories;
using Application.Interfaces._01_Common;

namespace Application.UseCases.Kiosco
{
    public class ToggleActiveKioscoUseCase
    {
        private readonly IToggleActiveRepo<KioscoEntity> _toggleActiveRepo;

        public ToggleActiveKioscoUseCase(IToggleActiveRepo<KioscoEntity> toggleActiveRepo)
        {
            _toggleActiveRepo = toggleActiveRepo;
        }

        public async Task<AppResult> Execute(int id)
        {
            var isOk = await _toggleActiveRepo.ToggleActiveAsync(id);
            if (!isOk)
                return ResultFactory.CreateNotFound("Kiosco was not exist");

            return ResultFactory.CreateSuccess("Kiosco activation was changed", null);
        }
    }
}
