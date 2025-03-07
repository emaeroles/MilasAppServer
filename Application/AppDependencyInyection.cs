using Application.Configs;
using Application.Entities;
using Application.UseCases.Kiosco;
using Application.UseCases.Product;
using Application.UseCases.ProductKiosco;
using Application.UseCases.Supply;
using Application.UseCases.SupplyProduct;
using Application.UseCases.Uom;
using Application.UseCases.User;
using Data.Repositories.ProductKiosco;
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

            services.AddKioscoUseCases();
            services.AddProductsUseCases();
            services.AddProductKioscoUseCases();
            services.AddSupplyUseCases();
            services.AddSupplyProductUseCases();
            services.AddUomUseCases();
            services.AddUserUseCases();

            return services;
        }

        private static IServiceCollection AddKioscoUseCases(this IServiceCollection services)
        {
            services.AddScoped<KioscoUseCases>();

            services.AddScoped<GetAllKioscosUseCase>();
            services.AddScoped<AddKioscoUseCase>();
            services.AddScoped<UpdateKioscoUseCase>();
            services.AddScoped<UpdateKioscoNotesUseCase>();
            services.AddScoped<UpdateKioscoDubtUseCase>();
            services.AddScoped<UpdateKioscoOrderUseCase>();
            services.AddScoped<UpdateKioscoIsChangesUseCase>();
            services.AddScoped<ToggleActiveKioscoUseCase>();

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

        private static IServiceCollection AddProductKioscoUseCases(this IServiceCollection services)
        {
            services.AddScoped<ProductKioscoUseCases>();

            services.AddScoped<AddProductKioscoUseCase>();

            return services;
        }

        private static IServiceCollection AddSupplyUseCases(this IServiceCollection services)
        {
            services.AddScoped<SupplyUseCases>();

            services.AddScoped<GetAllSuppliesUseCase>();
            services.AddScoped<AddSupplyUseCase>();
            services.AddScoped<UpdateSupplyUseCase>();
            services.AddScoped<ToggleActiveSupplyUseCase>();

            return services;
        }

        private static IServiceCollection AddSupplyProductUseCases(this IServiceCollection services)
        {
            services.AddScoped<SupplyProductUseCases>();

            services.AddScoped<GetAllSuppliesProductUseCase>();
            services.AddScoped<GetProductCostUseCase>();
            services.AddScoped<AddSupplyProductUseCase>();
            services.AddScoped<DeleteSupplyProductUseCase>();

            return services;
        }

        private static IServiceCollection AddUomUseCases(this IServiceCollection services)
        {
            services.AddScoped<UomUseCases>();

            services.AddScoped<GetAllUomsUseCase>();
            services.AddScoped<AddUomUseCase>();
            services.AddScoped<UpdateUomUseCase>();
            services.AddScoped<ToggleActiveUomUseCase>();

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
