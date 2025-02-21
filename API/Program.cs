using API;
using API.Middleware;
using Application;
using Data;
using Microsoft.AspNetCore.Mvc;
using Serilog;

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

// Disable automatic ASP.NET validation
//builder.Services.Configure<ApiBehaviorOptions>(options =>
//{
//    options.SuppressModelStateInvalidFilter = true;
//});

// Serilog
var configuration = builder.Configuration;
string filePath = configuration["FilePaths:LogsFilePath"] ?? "";

Log.Logger = new LoggerConfiguration()
                .WriteTo.File(filePath + @"\logs.txt",
                    outputTemplate: "{Timestamp:dd-MM-yyyy HH:mm:ss} [{Level:u3}]" +
                        " {Message:lj}{NewLine}{Exception}")
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

app.UseHttpsRedirection();

// Middleeare
app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
