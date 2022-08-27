using BadWeather.Application.Contracts;
using BadWeather.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BadWeather.Api.Controllers;

[ApiController]
[Route("metars")]
public class MetarsController : ControllerBase
{
    private readonly ILogger<MetarsController> _logger;
    private readonly IMetarProvider _metarProvider;

    public MetarsController(ILogger<MetarsController> logger, IMetarProvider metarProvider)
    {
        _logger = logger;
        _metarProvider = metarProvider;
    }

    [HttpGet("gust")]
    public async Task<ActionResult<List<Metar>>> GetTop20Gusts()
    {
        IList<Metar> metars = await _metarProvider.RetrieveMetars();

        IEnumerable<Metar> highestGustMetars = metars
            .OrderByDescending(q => q.WindGustKnots)
            .Take(20);

        return Ok(highestGustMetars.ToList());
    }
}