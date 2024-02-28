using AppCore.Configs;
using MainData;
using MainData.Middlewares;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DatabaseContext>(options =>
{
    //var connectString = EnvironmentExtension.GetAppConnectionString();
    var connectString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectString,
        b =>
        {
            // b.MigrationsAssembly(Assembly.GetEntryAssembly()?.GetName().Name);
            b.CommandTimeout(1200);
        }
    );
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    options.EnableDetailedErrors();
}, ServiceLifetime.Transient);
builder.Services.AddScoped<MainUnitOfWork>();
builder.Services.AddConfig(new List<string>
{
    "AppCore",
    "MainData",
    Assembly.GetEntryAssembly()?.GetName().Name ?? string.Empty
}, new List<string>
{
    nameof(IApiVersionDescriptionProvider),
    "UnitOfWork",
    "IUnitOfWork"
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

app.UseMiddleware<AuthMiddleware>();

app.Run();
