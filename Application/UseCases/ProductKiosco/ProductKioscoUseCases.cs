using Application.UseCases.ProductKiosco;

namespace Data.Repositories.ProductKiosco
{
    public record class ProductKioscoUseCases(
        GetAllProductsKioscoUseCase GetAllProductsKioscoUseCase,
        AddProductKioscoUseCase AddProductKioscoUseCase,
        UpdateProductKioscoPriceUseCase UpdateProductKioscoPriceUseCase,
        DeleteProductKioscoUseCase DeleteProductKioscoUseCase);
}
