using BadWeather.Application.Contracts;
using BadWeather.Application.Filters;
using BadWeather.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BadWeather.Api.Controllers;

[ApiController]
[Route("metars")]
public class MetarsController : ControllerBase
{
    private readonly IMetarService _metarService;

    public MetarsController(IMetarService metarService)
    {
        _metarService = metarService;
    }

    [HttpGet("gust")]
    public async Task<ActionResult<List<Metar>>> GetTop20Gusts([FromQuery] string icaoPrefix)
    {
        IEnumerable<Metar> metars = await _metarService.GetHighestGusts();

        IEnumerable<Metar> result = metars
            .FilterByIcaoPrefix(icaoPrefix)
            .Take(20);

        return Ok(result);
    }
    
    [HttpGet("wind")]
    public async Task<ActionResult<List<Metar>>> GetTop20Wind([FromQuery] string icaoPrefix)
    {
        IEnumerable<Metar> metars = await _metarService.GetHighestWinds();

        IEnumerable<Metar> result = metars
            .FilterByIcaoPrefix(icaoPrefix)
            .Take(20);

        return Ok(result);
    }
    
    [HttpGet("lowvisibility")]
    public async Task<ActionResult<List<Metar>>> GetTop20LowVisibility([FromQuery] string icaoPrefix)
    {
        IEnumerable<Metar> metars = await _metarService.GetLowestVisibility();

        IEnumerable<Metar> result = metars
            .FilterByIcaoPrefix(icaoPrefix)
            .Take(20);

        return Ok(result);
    }
    
    [HttpGet("storms")]
    public async Task<ActionResult<List<Metar>>> GetTop20Storms([FromQuery] string icaoPrefix)
    {
        IEnumerable<Metar> metars = await _metarService.GetStorms();

        IEnumerable<Metar> result = metars
            .FilterByIcaoPrefix(icaoPrefix)
            .Take(20);

        return Ok(result);
    }
}