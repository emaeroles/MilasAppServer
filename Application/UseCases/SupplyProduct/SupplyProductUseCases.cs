namespace Application.UseCases.SupplyProduct
{
    public record class SupplyProductUseCases(
        GetAllSuppliesProductUseCase GetAllSuppliesProductUseCase,
        AddSupplyProductUseCase AddSupplyProductUseCase,
        DeleteSupplyProductUseCase DeleteSupplyProductUseCase);
}
