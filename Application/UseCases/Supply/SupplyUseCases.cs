namespace Application.UseCases.Supply
{
    public record class SupplyUseCases(
    GetAllSuppliesUseCase GetAllSuppliesUseCase,
    AddSupplyUseCase AddSupplyUseCase,
    UpdateSupplyUseCase UpdateSupplyUseCase,
    ToggleActiveSupplyUseCase ToggleActiveSupplyUseCase,

    GetAllSuppliesProductUseCase GetAllSuppliesProductUseCase,
    AddSupplyProductUseCase AddSupplyProductUseCase,
    DeleteSupplyProductUseCase DeleteSupplyProductUseCase,

    GetAllUomsUseCase GetAllUomsUseCase,
    AddUomUseCase AddUomUseCase,
    UpdateUomUseCase UpdateUomUseCase,
    ToggleActiveUomUseCase ToggleActiveUomUseCase);
}
