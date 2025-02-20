using Application.Configs;
using Application.UseCases.User;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class AppDependencyInyection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
            => services.AddUserUseCases()
                .AddAutoMapper(typeof(MappingProfile));

        private static IServiceCollection AddUserUseCases(this IServiceCollection services)
            => services.AddScoped<UserUseCases>()
                .AddScoped<AddUserUseCase>()
                .AddScoped<GetAllUsersUseCase>();
    }
}
