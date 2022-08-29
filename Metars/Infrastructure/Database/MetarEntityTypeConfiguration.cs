using Metars.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Metars.Infrastructure.Database;

public class MetarEntityTypeConfiguration : IEntityTypeConfiguration<Metar>
{
    public void Configure(EntityTypeBuilder<Metar> builder)
    {
        builder
            .Property(m => m.Id)
            .IsRequired();

        builder
            .Property(m => m.StationIcao)
            .IsRequired();

        builder
            .Property(m => m.Text)
            .IsRequired();
    }
}