namespace Application.UseCases.Supply
{
    public record class SuppliesUseCases(
    GetAllSuppliesUseCase GetAllSuppliesUseCase,
    AddSupplyUseCase AddSupplyUseCase,
    UpdateSupplyUseCase UpdateSupplyUseCase,

    GetAllUomsUseCase GetAllUomsUseCase,
    AddUomUseCase AddUomUseCase,
    UpdateUomUseCase UpdateUomUseCase,
    ToggleActiveUomUseCase ToggleActiveUomUseCase);
}
