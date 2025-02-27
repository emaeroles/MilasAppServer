﻿using Application.Configs;
using Application.DTOs.User;
using Application.Entities;
using Application.UseCases.Kiosco;
using Application.UseCases.Supply;
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
            services.AddSuppliesUseCases();

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

        private static IServiceCollection AddSuppliesUseCases(this IServiceCollection services)
        {
            services.AddScoped<SuppliesUseCases>();

            services.AddScoped<GetAllSuppliesUseCase>();
            services.AddScoped<AddSupplyUseCase>();
            services.AddScoped<UpdateSupplyUseCase>();
            services.AddScoped<ToggleActiveSupplyUseCase>();

            services.AddScoped<GetAllUomsUseCase>();
            services.AddScoped<AddUomUseCase>();
            services.AddScoped<UpdateUomUseCase>();
            services.AddScoped<ToggleActiveUomUseCase>();

            return services;
        }
    }
}
