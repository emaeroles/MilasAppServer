namespace Application.UseCases.Product
{
    public record class ProductUseCases(
        AddProductUseCase AddProductUseCase,
        GetAllProductsUseCase GetAllProductsUseCase,
        GetProductCostUseCase GetProductCostUseCase,
        UpdateProductUseCase UpdateProductUseCase,
        ToggleActiveProductUseCase ToggleActiveProductUseCase);
}
