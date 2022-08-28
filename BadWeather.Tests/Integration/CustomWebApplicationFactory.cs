using BadWeather.Application.Contracts;
using BadWeather.Tests.Mocks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace BadWeather.Tests.Integration;

public class CustomWebApplicationFactory<TStartup>
    : WebApplicationFactory<TStartup> where TStartup: class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            // Replace IMetarProvider
            var descriptor = services.Single(d => d.ServiceType == typeof(IMetarProvider));
            services.Remove(descriptor);
            services.AddScoped<IMetarProvider, MockMetarProvider>();
        });
    }
}