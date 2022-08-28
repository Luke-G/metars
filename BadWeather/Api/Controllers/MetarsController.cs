using BadWeather.Application.Contracts;
using BadWeather.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BadWeather.Api.Controllers;

[ApiController]
[Route("metars")]
public class MetarsController : ControllerBase
{
    private readonly IMetarProvider _metarProvider;

    public MetarsController(IMetarProvider metarProvider)
    {
        _metarProvider = metarProvider;
    }

    [HttpGet("gust")]
    public async Task<ActionResult<List<Metar>>> GetTop20Gusts([FromQuery] string icaoPrefix)
    {
        IList<Metar> allMetars = await _metarProvider.RetrieveMetars();

        IEnumerable<Metar> metars = allMetars
            .OrderByDescending(q => q.WindGustKnots)
            .Where(q => q.StationIcao.StartsWith(icaoPrefix.ToUpperInvariant()))
            .Take(20);

        return Ok(metars.ToList());
    }
    
    [HttpGet("wind")]
    public async Task<ActionResult<List<Metar>>> GetTop20Wind([FromQuery] string icaoPrefix)
    {
        IList<Metar> allMetars = await _metarProvider.RetrieveMetars();

        IEnumerable<Metar> metars = allMetars
            .OrderByDescending(q => q.WindSpeedKnots)
            .Where(q => q.StationIcao.StartsWith(icaoPrefix.ToUpperInvariant()))
            .Take(20);

        return Ok(metars.ToList());
    }
    
    [HttpGet("lowvisibility")]
    public async Task<ActionResult<List<Metar>>> GetTop20LowVisibility([FromQuery] string icaoPrefix)
    {
        IList<Metar> allMetars = await _metarProvider.RetrieveMetars();

        IEnumerable<Metar> metars = allMetars
            .Where(q => q.Visibility != null)
            .Where(q => q.StationIcao.StartsWith(icaoPrefix.ToUpperInvariant()))
            .OrderBy(q => q.Visibility)
            .Take(20);

        return Ok(metars.ToList());
    }
}