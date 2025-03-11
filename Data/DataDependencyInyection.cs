using Application.Entities;
using Application.Interfaces._01_Common;
using Application.Interfaces.ProductKiosco;
using Application.Interfaces.SupplyProduct;
using Application.Interfaces.User;
using Application.Interfaces.Visit;
using Data.Context;
using Data.Repositories.Kiosco;
using Data.Repositories.Product;
using Data.Repositories.ProductKiosco;
using Data.Repositories.Supply;
using Data.Repositories.SupplyProduct;
using Data.Repositories.Uom;
using Data.Repositories.User;
using Data.Repositories.Visit;
using Microsoft.Extensions.DependencyInjection;

namespace Data
{
    public static class DataDependencyInyection
    {
        public static IServiceCollection AddData(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>();

            services.AddKioscoRepos();
            services.AddProductRepos();
            services.AddProductKioscoRepos();
            services.AddSupplyRepos();
            services.AddSupplyProductsRepos();
            services.AddUomRepos();
            services.AddUserRepos();
            services.AddVisitsRepos();

            return services;
        }

        private static IServiceCollection AddKioscoRepos(this IServiceCollection services)
        {
            services.AddScoped<IGetByIdRepo<KioscoEntity>, GetByIdKioscoRepo>();
            services.AddScoped<IGetAllByActiveAndUserRepo, GetAllKioscosRepo>();
            services.AddScoped<IAddRepo<KioscoEntity>, AddKioscoRepo>();
            services.AddScoped<IUpdateRepo<KioscoEntity>, UpdateKioscoRepo>();

            return services;
        }

        private static IServiceCollection AddProductRepos(this IServiceCollection services)
        {
            services.AddScoped<IGetByIdRepo<ProductEntity>, GetByIdProductRepo>();
            services.AddScoped<IGetAllByActiveRepo<ProductEntity>, GetAllProductsRepo>();
            services.AddScoped<IAddRepo<ProductEntity>, AddProductRepo>();
            services.AddScoped<IUpdateRepo<ProductEntity>, UpdateProductRepo>();

            return services;
        }

        private static IServiceCollection AddProductKioscoRepos(this IServiceCollection services)
        {
            services.AddScoped<IGetByIdComposedRepo<ProductKioscoEntity>, GetByIdProductKioscoRepo>();
            services.AddScoped<IGetAllProductsKioscoRepo, GetAllProductsKioscoRepo>();
            services.AddScoped<IAddRepo<ProductKioscoEntity>, AddProductKioscoRepo>();
            services.AddScoped<IUpdateRepo<ProductKioscoEntity>, UpdateProductKioscoRepo>();
            services.AddScoped<IDeleteComposedRepo<ProductKioscoEntity>, DeleteProductKioscoRepo>();

            return services;
        }

        private static IServiceCollection AddSupplyRepos(this IServiceCollection services)
        {
            services.AddScoped<IGetByIdRepo<SupplyEntity>, GetByIdSupplyRepo>();
            services.AddScoped<IGetAllByActiveRepo<SupplyEntity>, GetAllSuppliesRepo>();
            services.AddScoped<IAddRepo<SupplyEntity>, AddSupplyRepo>();
            services.AddScoped<IUpdateRepo<SupplyEntity>, UpdateSupplyRepo>();

            return services;
        }

        private static IServiceCollection AddSupplyProductsRepos(this IServiceCollection services)
        {
            services.AddScoped<IGetByIdComposedRepo<SupplyProductEntity>, GetByIdSupplyProductRepo>();
            services.AddScoped<IGetAllSuppliesProductRepo, GetAllSuppliesProductRepo>();
            services.AddScoped<IAddRepo<SupplyProductEntity>, AddSupplyProductRepo>();
            services.AddScoped<IDeleteComposedRepo<SupplyProductEntity>, DeleteSupplyProductRepo>();

            return services;
        }

        private static IServiceCollection AddUomRepos(this IServiceCollection services)
        {
            services.AddScoped<IGetByIdRepo<UomEntity>, GetByIdUomRepo>();
            services.AddScoped<IGetAllByActiveRepo<UomEntity>, GetAllUomRepo>();
            services.AddScoped<IAddRepo<UomEntity>, AddUomRepo>();
            services.AddScoped<IUpdateRepo<UomEntity>, UpdateUomRepo>();

            return services;
        }

        private static IServiceCollection AddUserRepos(this IServiceCollection services)
        {
            services.AddScoped<IGetByIdRepo<UserEntity>, GetByIdUserRepo>();
            services.AddScoped<IGetAllByActiveRepo<UserEntity>, GetAllUsersRepo>();
            services.AddScoped<IGetByUsernameRepo, GetByUsernameRepo>();
            services.AddScoped<IAddRepo<UserEntity>, AddUserRepo>();
            services.AddScoped<IUpdateRepo<UserEntity>, UpdateUserRepo>();
            
            return services;
        }

        private static IServiceCollection AddVisitsRepos(this IServiceCollection services)
        {
            services.AddScoped<IGetStartingDateVisitsRepo, GetStartingDateVisitsRepo>();
            services.AddScoped<IAddVisitAndUptadeStockRepo, AddVisitAndUptadeStockRepo>();

            return services;
        }
    }
}
