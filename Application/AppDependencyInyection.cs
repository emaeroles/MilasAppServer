using Application.Configs;
using Application.DTOs.User;
using Application.Entities;
using Application.UseCases.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class AppDependencyInyection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));

            services.AddUserUseCases();

            return services;
        }
        private static IServiceCollection AddUserUseCases(this IServiceCollection services)
        {
            services.AddScoped<UserUseCases>();
            services.AddScoped<GetAllUsersUseCase>();
            services.AddScoped<AddUserUseCase>();
            services.AddScoped<UpdateUserUseCase>();
            services.AddScoped<ToggleActiveUserUseCase>();
            services.AddScoped<AuthUserUseCase>();

            return services;
        }         
    }
}
