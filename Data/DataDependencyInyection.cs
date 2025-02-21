using Application.Entities;
using Application.Interfaces._01_Common;
using Application.Interfaces.Auth;
using Application.Interfaces.User;
using Data.Context;
using Data.Repositories.Auth;
using Data.Repositories.User;
using Microsoft.Extensions.DependencyInjection;

namespace Data
{
    public static class DataDependencyInyection
    {
        public static IServiceCollection AddData(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>();

            // Auth
            services.AddScoped<IGetByUsernameRepo, GetByUsernameRepo>();

            // User
            services.AddScoped<IGetAllByActiveRepo<UserEntity>, GetAllUsersRepo>();
            services.AddScoped<IAddRepo<UserEntity>, AddUserRepo>();
            services.AddScoped<IUpdateRepo<UserEntity>, UpdateUserRepo>();
            services.AddScoped<IToggleActiveRepo, ToggleActiveRepo>();
            services.AddScoped<ICheckUserExistRepo, CheckUserExistRepo>();
            
            return services;
        }
    }
}
