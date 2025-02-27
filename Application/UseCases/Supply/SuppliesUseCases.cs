namespace Application.UseCases.Supply
{
    public record class SuppliesUseCases(
    GetAllSuppliesUseCase GetAllSuppliesUseCase,
    AddSupplyUseCase AddSupplyUseCase,
    UpdateSupplyUseCase UpdateSupplyUseCase,
    ToggleActiveSupplyUseCase ToggleActiveSupplyUseCase,

    GetAllUomsUseCase GetAllUomsUseCase,
    AddUomUseCase AddUomUseCase,
    UpdateUomUseCase UpdateUomUseCase,
    ToggleActiveUomUseCase ToggleActiveUomUseCase);
}
