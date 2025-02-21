namespace Application.UseCases.User
{
    public record class UserUseCases(
        GetAllUsersUseCase GetAllUsersUseCase,
        AddUserUseCase AddUserUseCase,
        UpdateUserUseCase UpdateUserUseCase,
        ToggleActiveUserUseCase ToggleActiveUserUseCase);
}
