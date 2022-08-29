using AutoMapper;
using Metars.Api.Application.Contracts;
using Metars.Api.Application.Responses;
using Metars.Api.Domain.Models;
using Metars.Api.Application.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Metars.Api.Presentation.Controllers;

[ApiController]
[Route("Api/Bad")]
public class BadWeatherController : ControllerBase
{
    private readonly IMetarService _metarService;
    private readonly IMapper _mapper;

    public BadWeatherController(IMetarService metarService, IMapper mapper)
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