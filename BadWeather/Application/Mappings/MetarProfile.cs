using AutoMapper;
using BadWeather.Domain.Models;

namespace BadWeather.Application.Mappings;

public class MetarProfile : Profile
{
    public MetarProfile()
    {
        CreateMap<AviationWeatherCsvMetar, Metar>()
            .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.RawText))
            .ForMember(dest => dest.StationIcao, opt => opt.MapFrom(src => src.StationId))
            .ForMember(dest => dest.ObservationTime, opt => opt.MapFrom(src => src.ObservationTime))
            .ForMember(dest => dest.WindDirectionDegrees, opt => opt.MapFrom(src => src.WindDirDegrees))
            .ForMember(dest => dest.WindSpeedKnots, opt => opt.MapFrom(src => src.WindSpeedKt))
            .ForMember(dest => dest.WindGustKnots, opt => opt.MapFrom(src => src.WindGustKt))
            .ForMember(dest => dest.Visibility, opt => opt.MapFrom(src => src.VisibilityStatuteMi))
            .ForMember(dest => dest.AltimeterInHg, opt => opt.MapFrom(src => src.AltimInHg))
            .ForMember(dest => dest.FlightCategory, opt => opt.MapFrom(src => src.FlightCategory));
    }
}