using AutoMapper;
using BadWeather.Application.Responses;
using BadWeather.Domain.Models;
using BadWeather.Infrastructure.Metars.AviationWeather;

namespace BadWeather.Application.Mappings;

public class MetarProfile : Profile
{
    public MetarProfile()
    {
        CreateMap<Metar, MetarResponse>()
            .ForMember(dest => dest.SkyCover, opt => opt.MapFrom(src => src.SkyCover.Where(q => !string.IsNullOrEmpty(q))));

        CreateMap<AviationWeatherCsvMetar, Metar>()
            .ForMember(dest => dest.SkyCover, opt => opt.MapFrom(src => new List<string?>
            {
                src.SkyCoverLayer1 != null ? $"{src.SkyCoverLayer1} {src.CloudBaseFeetAglLayer1}" : null,
                src.SkyCoverLayer2 != null ? $"{src.SkyCoverLayer2} {src.CloudBaseFeetAglLayer2}" : null,
                src.SkyCoverLayer3 != null ? $"{src.SkyCoverLayer3} {src.CloudBaseFeetAglLayer3}" : null,
                src.SkyCoverLayer4 != null ? $"{src.SkyCoverLayer4} {src.CloudBaseFeetAglLayer4}" : null,
            }));
    }
}