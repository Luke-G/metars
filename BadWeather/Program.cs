using System.Reflection;
using BadWeather.Application.Contracts;
using BadWeather.Infrastructure.Database;
using BadWeather.Infrastructure.Metars;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextPool<ApplicationDbContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("ApplicationDbContext")));

builder.Services.AddScoped<IMetarProvider, AviationWeatherCsvMetarProvider>();

builder.Services.AddHttpClient();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

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

public partial class Program { }