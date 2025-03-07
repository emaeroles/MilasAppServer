using API;
using API.Middleware;
using API.Response;
using Application;
using Data;
using Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Globalization;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Set ASP.NET to English by default
var cultureInfo = new CultureInfo("en-US");
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

// Inyections
builder.Services
    .AddApi()
    .AddApplication()
    .AddData();

// JWT
builder.Services.AddAuthentication();
builder.Services.AddAuthentication("Bearer").AddJwtBearer(opt =>
{
    var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:SecretKey"]!));

    opt.RequireHttpsMetadata = false;
    opt.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateLifetime = true,

        ValidateAudience = true,
        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],

        ValidateIssuer = true,
        ValidAudience = builder.Configuration["JwtSettings:Audience"],

        ValidateIssuerSigningKey = true,
        IssuerSigningKey = signingKey
    };
});

// Modifying ASP.NET default messages
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var errors = context.ModelState
            .Where(m => m.Value?.Errors.Count > 0)
            .SelectMany(m => m.Value!.Errors.Select(
                e => $"'{m.Key.First().ToString().ToUpper() + m.Key.Substring(1)}'" +
                $" {e.ErrorMessage.First().ToString().ToLower() + e.ErrorMessage.Substring(1)}"))
            .ToList();

        var apiResp = new ApiResponse(
            false, 
            "Error in data type validation. You can find the correct format in the documentation.",
            errors);

        return new JsonResult(apiResp)
        {
            StatusCode = StatusCodes.Status400BadRequest
        };
    };
});

// Use PascalCase in JesonResult
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});

// Serilog
string filePath = builder.Configuration["FilePaths:LogsFilePath"]!;

Log.Logger = new LoggerConfiguration()
                .WriteTo.File(filePath + @"\logs.txt",
                    outputTemplate: "{Timestamp:dd-MM-yyyy HH:mm:ss} [{Level:u3}]" +
                        "{NewLine}{NewLine}{Message:lj}{NewLine}{Exception}" +
                        "{NewLine}=================================================={NewLine}{NewLine}")
                .MinimumLevel.Error()
.CreateLogger();

builder.Host.UseSerilog();

// Build
var app = builder.Build();

// ==============================================================================

// Entity Framework Warm-up Query
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Users.FirstOrDefault();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// CORS
app.UseCors((config) =>
{
    config.WithOrigins(builder.Configuration["CorsSettings:AllowedOrigin"]!);
    config.AllowAnyHeader();
    config.AllowAnyMethod();
    config.AllowCredentials();
});

app.UseHttpsRedirection();

// Middleeare
app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
