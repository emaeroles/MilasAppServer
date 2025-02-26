using Application.Configs;
using Application.DTOs.User;
using Application.Entities;
using Application.UseCases.Kiosco;
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
            services.AddKioscoUseCases();

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

        private static IServiceCollection AddKioscoUseCases(this IServiceCollection services)
        {
            services.AddScoped<KioscoUseCases>();
            services.AddScoped<GetAllKioscosUseCase>();
            services.AddScoped<AddKioscoUseCase>();
            services.AddScoped<UpdateKioscoUseCase>();
            services.AddScoped<UpdateNotesUseCase>();
            services.AddScoped<UpdateDubtUseCase>();
            services.AddScoped<UpdateOrderUseCase>();
            services.AddScoped<ToggleIsChangesUseCase>();
            services.AddScoped<ToggleActiveKioscoUseCase>();

            return services;
        }
    }
}
