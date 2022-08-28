using BadWeather.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BadWeather.Infrastructure.Database;

public class MetarEntityTypeConfiguration : IEntityTypeConfiguration<Metar>
{
    public void Configure(EntityTypeBuilder<Metar> builder)
    {
        builder
            .Property(m => m.StationIcao)
            .IsRequired();
    }
}