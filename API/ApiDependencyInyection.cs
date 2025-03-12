using API.Validators.Auth;
using API.Validators.Kiosco;
using API.Validators.KioscoProduct;
using API.Validators.Product;
using API.Validators.ProductSupply;
using API.Validators.Supply;
using API.Validators.Uom;
using API.Validators.User;
using API.Validators.Visit;
using Application.DTOs.Auth;
using Application.DTOs.Kiosco;
using Application.DTOs.KioscoProduct;
using Application.DTOs.Product;
using Application.DTOs.ProductSupply;
using Application.DTOs.Supply;
using Application.DTOs.Uom;
using Application.DTOs.User;
using Application.DTOs.Visit;
using FluentValidation;

namespace API
{
    public static class ApiDependencyInyection
    {
        public static IServiceCollection AddApi(this IServiceCollection services)
        {
            // Auth Validations
            services.AddScoped<IValidator<AuthInput>, AuthValid>();

            // Kiosco Validations
            services.AddScoped<IValidator<AddKioscoInput>, AddKioscoValid>();
            services.AddScoped<IValidator<UpdateKioscoInput>, UpdateKioscoValid>();
            services.AddScoped<IValidator<UpdateKioscoNotesInput>, UpdateNotesValid>();
            services.AddScoped<IValidator<UpdateKioscoDubtInput>, UpdateDubtValid>();
            services.AddScoped<IValidator<UpdateKioscoOrderInput>, UpdateOrderValid>();

            // Product Validation
            services.AddScoped<IValidator<AddProductInput>, AddProductValid>();
            services.AddScoped<IValidator<UpdateProductInput>, UpdateProductValid>();

            // Product Kiosco Validation
            services.AddScoped<IValidator<AddKioscoProductInput>, AddKioscoProductValid>();
            services.AddScoped<IValidator<UpdateKioscoProductPriceIuput>, UpdateKioscoProductPriceValid>();

            // Supply Validations
            services.AddScoped<IValidator<AddSupplyInput>, AddSupplyValid>();
            services.AddScoped<IValidator<UpdateSupplyInput>, UpdateSupplyValid>();

            // Supply Product Validations
            services.AddScoped<IValidator<AddProductSupplyInput>, AddProductSupplyValid>();

            // Uom Validations
            services.AddScoped<IValidator<AddUomInput>, AddUomValid>();
            services.AddScoped<IValidator<UpdateUomInput>, UpdateUomValid>();

            // User Validations
            services.AddScoped<IValidator<AddUserInput>, AddUserValid>();
            services.AddScoped<IValidator<UpdateUserInput>, UpdateUserValid>();

            // Visit Validations
            services.AddScoped<IValidator<AddVisitInput>, AddVisitValid>();

            return services;
        }
    }
}
