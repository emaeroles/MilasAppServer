using Application.Entities;
using Application.Interfaces._01_Common;
using Application.Interfaces.User;
using Data.Context;
using Data.Repositories.User;
using Microsoft.Extensions.DependencyInjection;

namespace Data
{
    public static class DataDependencyInyection
    {
        public static IServiceCollection AddData(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>();
            services.AddScoped<IAddRepo<UserEntity>, AddUserRepo>();
            services.AddScoped<IGetAllByActiveRepo<UserEntity>, GetAllUsersRepo>();
            services.AddScoped<ICheckUserExistRepo, CheckUserExistRepo>();
            return services;
        }
    }
}
