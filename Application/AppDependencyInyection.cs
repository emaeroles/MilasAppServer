using Application.Configs;
using Application.DTOs.User;
using Application.Entities;
using Application.UseCases.Auth;
using Application.UseCases.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class AppDependencyInyection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
            => services.AddUserUseCases()
                .AddAuthUseCases()
                .AddAutoMapper(typeof(MappingProfile));

        private static IServiceCollection AddAuthUseCases(this IServiceCollection services)
            => services.AddScoped<AuthUseCase>();

        private static IServiceCollection AddUserUseCases(this IServiceCollection services)
            => services.AddScoped<UserUseCases>()
                .AddScoped<GetAllUsersUseCase>()
                .AddScoped<AddUserUseCase>()
                .AddScoped<UpdateUserUseCase>()
                .AddScoped<ToggleActiveUserUseCase>();
                
    }
}
