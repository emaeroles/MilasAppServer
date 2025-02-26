namespace Application.UseCases.Kiosco
{
    public record class KioscoUseCases(
        GetAllKioscosUseCase GetAllKioscosUseCase,
        AddKioscoUseCase AddKioscoUseCase,
        UpdateKioscoUseCase UpdateKioscoUseCase,
        UpdateNotesUseCase UpdateNotesUseCase,
        UpdateDubtUseCase UpdateDubtUseCase,
        UpdateOrderUseCase UpdateOrderUseCase,
        ToggleIsChangesUseCase ToggleIsChangesUseCase,
        ToggleActiveKioscoUseCase ToggleActiveKioscoUseCase);
}
