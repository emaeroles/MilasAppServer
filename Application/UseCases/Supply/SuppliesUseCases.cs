namespace Application.UseCases.Supply
{
    public record class SuppliesUseCases(
    GetAllUomsUseCase GetAllUomsUseCase,
    AddUomUseCase AddUomUseCase,
    UpdateUomUseCase UpdateUomUseCase,
    ToggleActiveUomUseCase ToggleActiveUomUseCase);
}
