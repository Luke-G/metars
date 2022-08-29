using Metars.Api.Application.Contracts;
using Metars.Tests.Mocks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace Metars.Tests.Integration;

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