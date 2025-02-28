using Application.Configs;
using Application.Entities;
using Application.UseCases.Kiosco;
using Application.UseCases.Product;
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
            services.AddScoped<IPasswordHasher<UserEntity>, PasswordHasher<UserEntity>>();

            services.AddUserUseCases();
            services.AddKioscoUseCases();
            services.AddSuppliesUseCases();
            services.AddProductsUseCases();

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
            services.AddScoped<SupplyUseCases>();

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

        private static IServiceCollection AddProductsUseCases(this IServiceCollection services)
        {
            services.AddScoped<ProductUseCases>();

            services.AddScoped<GetAllProductsUseCase>();
            services.AddScoped<AddProductUseCase>();
            services.AddScoped<UpdateProductUseCase>();
            services.AddScoped<ToggleActiveProductUseCase>();

            return services;
        }
    }
}
