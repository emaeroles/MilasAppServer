namespace Application.UseCases.Uom
{
    public record class UomUseCases(
        GetAllUomsUseCase GetAllUomsUseCase,
        AddUomUseCase AddUomUseCase,
        UpdateUomUseCase UpdateUomUseCase,
        ToggleActiveUomUseCase ToggleActiveUomUseCase);
}
