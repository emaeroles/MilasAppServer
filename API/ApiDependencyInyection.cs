using API.Validators.Auth;
using API.Validators.User;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace API
{
    public static class ApiDependencyInyection
    {
        public static IServiceCollection AddApi(this IServiceCollection services)
        {
            // Auth
            services.AddValidatorsFromAssemblyContaining<AuthValid>();

            // User
            services.AddValidatorsFromAssemblyContaining<AddUserValid>();
            services.AddValidatorsFromAssemblyContaining<UpdateUserValid>();

            // Fluent Validator
            //services.AddFluentValidationAutoValidation();

            return services;
        }
    }
}
