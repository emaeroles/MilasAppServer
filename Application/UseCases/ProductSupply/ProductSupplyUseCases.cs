namespace Application.UseCases.ProductSupply
{
    public record class ProductSupplyUseCases(
        GetAllProductSuppliesUseCase GetAllProductSuppliesUseCase,
        AddProductSupplyUseCase AddProductSupplyUseCase,
        DeleteProductSupplyUseCase DeleteProductSupplyUseCase);
}
