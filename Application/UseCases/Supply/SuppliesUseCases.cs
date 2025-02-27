namespace Application.UseCases.Supply
{
    public record class SuppliesUseCases(
    GetAllSuppliesUseCase GetAllSuppliesUseCase,
    AddSupplyUseCase AddSupplyUseCase,

    GetAllUomsUseCase GetAllUomsUseCase,
    AddUomUseCase AddUomUseCase,
    UpdateUomUseCase UpdateUomUseCase,
    ToggleActiveUomUseCase ToggleActiveUomUseCase);
}
