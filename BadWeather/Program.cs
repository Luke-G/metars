using System.Reflection;
using BadWeather.Application.Contracts;
using BadWeather.Application.Services;
using BadWeather.Infrastructure;
using BadWeather.Infrastructure.Metars;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddScoped<IMetarProvider, AviationWeatherCsvMetarProvider>();
builder.Services.AddScoped<IMetarImportService, MetarImportService>();

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