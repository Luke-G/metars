using System.Reflection;
using BadWeather.Application.Contracts;
using BadWeather.Application.Services;
using BadWeather.Infrastructure;
using BadWeather.Infrastructure.Metars.AviationWeather;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();

builder.Services.AddPersistence(builder.Configuration);

builder.Services.AddStackExchangeRedisCache(opt =>
{
    opt.ConfigurationOptions = new ConfigurationOptions
    {
        EndPoints = { builder.Configuration.GetConnectionString("Redis") }
    };
});

builder.Services.AddScoped<IMetarProvider, AviationWeatherCsvMetarProvider>();
builder.Services.AddScoped<IMetarImportService, MetarImportService>();
builder.Services.AddScoped<IMetarService, MetarService>();

builder.Services.AddHttpClient();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }