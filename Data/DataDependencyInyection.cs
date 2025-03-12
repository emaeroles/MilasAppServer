using Application.Entities;
using Application.Interfaces._01_Common;
using Application.Interfaces.KioscoProduct;
using Application.Interfaces.ProductSupply;
using Application.Interfaces.User;
using Application.Interfaces.Visit;
using Data.Context;
using Data.Repositories.Kiosco;
using Data.Repositories.KioscoProduct;
using Data.Repositories.Product;
using Data.Repositories.ProductSupply;
using Data.Repositories.Supply;
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
            services.AddKioscoProductRepos();
            services.AddSupplyRepos();
            services.AddProductSupplyRepos();
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

        private static IServiceCollection AddKioscoProductRepos(this IServiceCollection services)
        {
            services.AddScoped<IGetByIdComposedRepo<KioscoProductEntity>, GetByIdKioscoProductRepo>();
            services.AddScoped<IGetAllKioscoProductsRepo, GetAllKioscoProductsRepo>();
            services.AddScoped<IAddRepo<KioscoProductEntity>, AddKioscoProductRepo>();
            services.AddScoped<IUpdateRepo<KioscoProductEntity>, UpdateKioscoProductRepo>();
            services.AddScoped<IDeleteComposedRepo<KioscoProductEntity>, DeleteKioscoProductRepo>();

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

        private static IServiceCollection AddProductSupplyRepos(this IServiceCollection services)
        {
            services.AddScoped<IGetByIdComposedRepo<ProductSupplyEntity>, GetByIdProductSupplyRepo>();
            services.AddScoped<IGetAllProductSuppliesRepo, GetAllProductSuppliesRepo>();
            services.AddScoped<IAddRepo<ProductSupplyEntity>, AddProductSupplyRepo>();
            services.AddScoped<IDeleteComposedRepo<ProductSupplyEntity>, DeleteProductSupplyRepo>();

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
