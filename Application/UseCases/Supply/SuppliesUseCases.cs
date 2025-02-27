namespace Application.UseCases.Supply
{
    public record class SuppliesUseCases(
    AddSupplyUseCase AddSupplyUseCase,

    GetAllUomsUseCase GetAllUomsUseCase,
    AddUomUseCase AddUomUseCase,
    UpdateUomUseCase UpdateUomUseCase,
    ToggleActiveUomUseCase ToggleActiveUomUseCase);
}
