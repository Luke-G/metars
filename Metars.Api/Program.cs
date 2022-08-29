using System.Reflection;
using Metars.Api.Application.Contracts;
using Metars.Api.Application.Services;
using Metars.Api.Infrastructure;
using Metars.Api.Infrastructure.Metars.AviationWeather;
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

// Setup the target host - for Google Cloud Run compatibility
string port = Environment.GetEnvironmentVariable("PORT") ?? "7175";
string scheme = port == "7175" ? "https" : "http";
var url = $"{scheme}://0.0.0.0:{port}";

app.Run(url);

public partial class Program { }