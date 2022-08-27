using BadWeather.Application.Contracts;
using BadWeather.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BadWeather.Api.Controllers;

[ApiController]
[Route("api")]
public class ApiController : ControllerBase
{
    private readonly ILogger<ApiController> _logger;
    private readonly IMetarProvider _metarProvider;

    public ApiController(ILogger<ApiController> logger, IMetarProvider metarProvider)
    {
        _logger = logger;
        _metarProvider = metarProvider;
    }

    [HttpGet("gust")]
    public async Task<ActionResult<IEnumerable<Metar>>> GetHighestGustMetars()
    {
        IList<Metar> metars = await _metarProvider.RetrieveMetars();

        IEnumerable<Metar> highestGustMetars = metars
            .OrderByDescending(q => q.WindGustKnots)
            .Take(20);

        return Ok(highestGustMetars);
    }
}