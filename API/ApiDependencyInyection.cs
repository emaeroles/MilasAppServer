using API.Validators.Auth;
using API.Validators.Kiosco;
using API.Validators.User;
using FluentValidation;

namespace API
{
    public static class ApiDependencyInyection
    {
        public static IServiceCollection AddApi(this IServiceCollection services)
        {
            // Auth
            services.AddValidatorsFromAssemblyContaining<AuthValid>();

            // User Validations
            services.AddValidatorsFromAssemblyContaining<AddUserValid>();
            services.AddValidatorsFromAssemblyContaining<UpdateUserValid>();

            // Kiosco Validations
            services.AddValidatorsFromAssemblyContaining<AddKioscoValid>();
            services.AddValidatorsFromAssemblyContaining<UpdateKioscoValid>();
            services.AddValidatorsFromAssemblyContaining<UpdateNotesValid>();
            services.AddValidatorsFromAssemblyContaining<UpdateDubtValid>();
            services.AddValidatorsFromAssemblyContaining<UpdateOrderValid>();

            // Fluent Validator
            //services.AddFluentValidationAutoValidation();

            return services;
        }
    }
}
