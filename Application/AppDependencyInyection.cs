using Application.Configs;
using Application.Entities;
using Application.UseCases.Kiosco;
using Application.UseCases.KioscoProduct;
using Application.UseCases.Product;
using Application.UseCases.ProductSupply;
using Application.UseCases.Supply;
using Application.UseCases.Uom;
using Application.UseCases.User;
using Application.UseCases.Visit;
using Data.Repositories.KioscoProduct;
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
            services.AddKioscoProductUseCases();
            services.AddSupplyUseCases();
            services.AddProductSupplyUseCases();
            services.AddUomUseCases();
            services.AddUserUseCases();
            services.AddVisitUseCases();

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
            services.AddScoped<ToggleKioscoIsChangesUseCase>();
            services.AddScoped<ToggleActiveKioscoUseCase>();

            return services;
        }

        private static IServiceCollection AddProductsUseCases(this IServiceCollection services)
        {
            services.AddScoped<ProductUseCases>();

            services.AddScoped<GetAllProductsUseCase>();
            services.AddScoped<GetProductCostUseCase>();
            services.AddScoped<AddProductUseCase>();
            services.AddScoped<UpdateProductUseCase>();
            services.AddScoped<ToggleActiveProductUseCase>();

            return services;
        }

        private static IServiceCollection AddKioscoProductUseCases(this IServiceCollection services)
        {
            services.AddScoped<KioscoProductUseCases>();

            services.AddScoped<GetAllKioscoProductsUseCase>();
            services.AddScoped<AddKioscoProductUseCase>();
            services.AddScoped<UpdateKioscoProductPriceUseCase>();
            services.AddScoped<DeleteKioscoProductUseCase>();

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

        private static IServiceCollection AddProductSupplyUseCases(this IServiceCollection services)
        {
            services.AddScoped<ProductSupplyUseCases>();

            services.AddScoped<GetAllProductSuppliesUseCase>();
            services.AddScoped<AddProductSupplyUseCase>();
            services.AddScoped<DeleteProductSupplyUseCase>();

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

        private static IServiceCollection AddVisitUseCases(this IServiceCollection services)
        {
            services.AddScoped<VisitUseCases>();

            services.AddScoped<GetVisitsUseCase>();
            services.AddScoped<AddVisitUseCase>();

            return services;
        }
    }
}
