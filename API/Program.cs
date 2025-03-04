using API;
using API.Middleware;
using Application;
using Data;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

// Disable automatic ASP.NET validation
//builder.Services.Configure<ApiBehaviorOptions>(options =>
//{
//    options.SuppressModelStateInvalidFilter = true;
//});

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
