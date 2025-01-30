
using Microsoft.AspNetCore.Mvc.Routing;
using Repository.Core.Interface;
using Repository.Core;
using Data.Core;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddTransient<emailService>();



// void ConfigureServices(IServiceCollection services)
//{
//    services.AddControllersWithViews();

//    // Register EmailService for Dependency Injection
//    services.AddTransient<emailService>();
//}

// Register database helper (ADO.NET)
builder.Services.AddSingleton<CoreSQLDbHelper>();

// Register repository layer
builder.Services.AddScoped<IBusinessRepository, BusinessRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ERP API", Version = "v1" });
});
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
