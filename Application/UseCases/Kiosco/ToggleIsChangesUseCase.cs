using Application.DTOs._01_Common;
using Application.Entities;
using Application.Factories;
using Application.Interfaces._01_Common;
using Application.Interfaces.Kiosco;

namespace Application.UseCases.Kiosco
{
    public class ToggleIsChangesUseCase
    {
        private readonly IToggleIsChangesRepo _toggleIsChangesRepo;

        public ToggleIsChangesUseCase(IToggleIsChangesRepo toggleIsChangesRepo)
        {
            _toggleIsChangesRepo = toggleIsChangesRepo;
        }

        public async Task<AppResult> Execute(int id)
        {
            var isOk = await _toggleIsChangesRepo.ToggleIsChangesAsync(id);
            if (!isOk)
                return ResultFactory.CreateNotFound("Kiosco was not exist");

            return ResultFactory.CreateSuccess("Changes from kiosco was changed", null);
        }
    }
}
