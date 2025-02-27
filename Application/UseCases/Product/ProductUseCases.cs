namespace Application.UseCases.Product
{
    public record class ProductUseCases(
        AddProductUseCase AddProductUseCase,
        GetAllProductsUseCase GetAllProductsUseCase,
        UpdateProductUseCase UpdateProductUseCase);
}
