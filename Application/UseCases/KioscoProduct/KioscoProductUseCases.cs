using Application.UseCases.KioscoProduct;

namespace Data.Repositories.KioscoProduct
{
    public record class KioscoProductUseCases(
        GetAllKioscoProductsUseCase GetAllKioscoProductsUseCase,
        AddKioscoProductUseCase AddKioscoProductUseCase,
        UpdateKioscoProductPriceUseCase UpdateKioscoProductPriceUseCase,
        DeleteKioscoProductUseCase DeleteKioscoProductUseCase);
}
