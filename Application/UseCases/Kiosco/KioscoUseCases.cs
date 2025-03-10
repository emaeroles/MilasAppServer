namespace Application.UseCases.Kiosco
{
    public record class KioscoUseCases(
        GetAllKioscosUseCase GetAllKioscosUseCase,
        AddKioscoUseCase AddKioscoUseCase,
        UpdateKioscoUseCase UpdateKioscoUseCase,
        UpdateKioscoNotesUseCase UpdateKioscoNotesUseCase,
        UpdateKioscoDubtUseCase UpdateKioscoDubtUseCase,
        UpdateKioscoOrderUseCase UpdateKioscoOrderUseCase,
        ToggleKioscoIsChangesUseCase ToggleKioscoIsChangesUseCase,
        ToggleActiveKioscoUseCase ToggleActiveKioscoUseCase);
}
