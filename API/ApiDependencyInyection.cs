using API.Validators.Auth;
using API.Validators.Kiosco;
using API.Validators.Product;
using API.Validators.Supply;
using API.Validators.User;
using Application.DTOs.Auth;
using Application.DTOs.Kiosco;
using Application.DTOs.Product;
using Application.DTOs.Supply;
using Application.DTOs.User;
using FluentValidation;

namespace API
{
    public static class ApiDependencyInyection
    {
        public static IServiceCollection AddApi(this IServiceCollection services)
        {
            // Auth
            services.AddScoped<IValidator<AuthInput>, AuthValid>();

            // User Validations
            services.AddScoped<IValidator<AddUserInput>, AddUserValid>();
            services.AddScoped<IValidator<UpdateUserInput>, UpdateUserValid>();

            // Kiosco Validations
            services.AddScoped<IValidator<AddKioscoInput>, AddKioscoValid>();
            services.AddScoped<IValidator<UpdateKioscoInput>, UpdateKioscoValid>();
            services.AddScoped<IValidator<UpdateKioscoNotesInput>, UpdateNotesValid>();
            services.AddScoped<IValidator<UpdateKioscoDubtInput>, UpdateDubtValid>();
            services.AddScoped<IValidator<UpdateKioscoOrderInput>, UpdateOrderValid>();

            // Supply
            services.AddScoped<IValidator<AddSupplyInput>, AddSupplyValid>();
            services.AddScoped<IValidator<UpdateSupplyInput>, UpdateSupplyValid>();

            services.AddScoped<IValidator<AddUomInput>, AddUomValid>();
            services.AddScoped<IValidator<UpdateUomInput>, UpdateUomValid>();

            // Product Validation
            services.AddScoped<IValidator<AddProductInput>, AddProductValid>();

            // Fluent Validator
            //services.AddFluentValidationAutoValidation();

            return services;
        }
    }
}
