using Application.Entities;
using Application.Interfaces._01_Common;
using Application.Interfaces.Kiosco;
using Application.Interfaces.User;
using Data.Context;
using Data.Repositories.Kiosco;
using Data.Repositories.Supply;
using Data.Repositories.User;
using Microsoft.Extensions.DependencyInjection;

namespace Data
{
    public static class DataDependencyInyection
    {
        public static IServiceCollection AddData(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>();

            services.AddUserRepos();
            services.AddKioscosRepos();
            services.AddSuppliesRepos();

            return services;
        }

        private static IServiceCollection AddUserRepos(this IServiceCollection services)
        {
            services.AddScoped<IGetAllByActiveRepo<UserEntity>, GetAllUsersRepo>();
            services.AddScoped<IAddRepo<UserEntity>, AddUserRepo>();
            services.AddScoped<IUpdateRepo<UserEntity>, UpdateUserRepo>();
            services.AddScoped<IToggleActiveRepo<UserEntity>, ToggleActiveUserRepo>();
            services.AddScoped<ICheckUserExistRepo, CheckUserExistRepo>();
            services.AddScoped<IGetByUsernameRepo, GetByUsernameRepo>();

            return services;
        }

        private static IServiceCollection AddKioscosRepos(this IServiceCollection services)
        {
            services.AddScoped<IGetAllByActiveRepo<KioscoEntity>, GetAllKioscosRepo>();
            services.AddScoped<IAddRepo<KioscoEntity>, AddKioscoRepo>();
            services.AddScoped<IUpdateRepo<KioscoEntity>, UpdateKioscoRepo>();
            services.AddScoped<IUpdateKioscoRepo<KioscoEntity>, UpdateKioscoRepo>();
            services.AddScoped<IToggleIsChangesRepo, ToggleIsChangesRepo>();
            services.AddScoped<IToggleActiveRepo<KioscoEntity>, ToggleActiveKioscoRepo>();

            return services;
        }

        private static IServiceCollection AddSuppliesRepos(this IServiceCollection services)
        {
            services.AddScoped<IGetAllByActiveRepo<SupplyEntity>, GetAllSuppliesRepo>();
            services.AddScoped<IAddRepo<SupplyEntity>, AddSupplyRepo>();
            services.AddScoped<IUpdateRepo<SupplyEntity>, UpdateSupplyRepo>();
            services.AddScoped<IToggleActiveRepo<SupplyEntity>, ToggleActiveSupplyRepo>();

            services.AddScoped<IGetAllByActiveRepo<UoMEntity>, GetAllUomRepo>();
            services.AddScoped<IAddRepo<UoMEntity>, AddUomRepo>();
            services.AddScoped<IUpdateRepo<UoMEntity>, UpdateUomRepo>();
            services.AddScoped<IToggleActiveRepo<UoMEntity>, ToggleActiveUomRepo>();

            return services;
        }
    }
}
