namespace Application.UseCases.User
{
    public record class UserUseCases(
        AddUserUseCase AddUserUseCase,
        GetAllUsersUseCase GetAllUsersUseCase);
}
