namespace Application.UseCases.Visit
{
    public record class VisitUseCases(
        GetVisitsUseCase GetVisitsUseCase,
        AddVisitUseCase AddVisitUseCase);
}
