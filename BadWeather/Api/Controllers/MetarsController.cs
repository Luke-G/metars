using AutoMapper;
using BadWeather.Application.Contracts;
using BadWeather.Application.Filters;
using BadWeather.Application.Responses;
using BadWeather.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BadWeather.Api.Controllers;

[ApiController]
[Route("Api")]
public class MetarsController : ControllerBase
{
    private readonly IMetarService _metarService;
    private readonly IMapper _mapper;

    public MetarsController(IMetarService metarService, IMapper mapper)
    {
        _metarService = metarService;
        _mapper = mapper;
    }

    [HttpGet("Gusts")]
    public async Task<ActionResult<List<MetarResponse>>> GetTop20Gusts([FromQuery] string? icaoPrefix)
    {
        IEnumerable<Metar> metars = await _metarService.GetHighestGusts();

        IEnumerable<Metar> result = metars
            .FilterByIcaoPrefix(icaoPrefix)
            .Take(20);

        return Ok(_mapper.Map<List<MetarResponse>>(result));
    }
    
    [HttpGet("Wind")]
    public async Task<ActionResult<List<MetarResponse>>> GetTop20Wind([FromQuery] string? icaoPrefix)
    {
        IEnumerable<Metar> metars = await _metarService.GetHighestWinds();

        IEnumerable<Metar> result = metars
            .FilterByIcaoPrefix(icaoPrefix)
            .Take(20);

        return Ok(_mapper.Map<List<MetarResponse>>(result));
    }
    
    [HttpGet("LowVisibility")]
    public async Task<ActionResult<List<MetarResponse>>> GetTop20LowVisibility([FromQuery] string? icaoPrefix)
    {
        IEnumerable<Metar> metars = await _metarService.GetLowestVisibility();

        IEnumerable<Metar> result = metars
            .FilterByIcaoPrefix(icaoPrefix)
            .Take(20);

        return Ok(_mapper.Map<List<MetarResponse>>(result));
    }
    
    [HttpGet("Storms")]
    public async Task<ActionResult<List<MetarResponse>>> GetTop20Storms([FromQuery] string? icaoPrefix)
    {
        IEnumerable<Metar> metars = await _metarService.GetStorms();

        IEnumerable<Metar> result = metars
            .FilterByIcaoPrefix(icaoPrefix)
            .Take(20);

        return Ok(_mapper.Map<List<MetarResponse>>(result));
    }
}