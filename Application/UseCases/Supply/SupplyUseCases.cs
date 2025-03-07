namespace Application.UseCases.Supply
{
    public record class SupplyUseCases(
        GetAllSuppliesUseCase GetAllSuppliesUseCase,
        AddSupplyUseCase AddSupplyUseCase,
        UpdateSupplyUseCase UpdateSupplyUseCase,
        ToggleActiveSupplyUseCase ToggleActiveSupplyUseCase);
}
