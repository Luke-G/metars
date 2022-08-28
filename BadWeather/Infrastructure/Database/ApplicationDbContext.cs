using BadWeather.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BadWeather.Infrastructure.Database;

public class ApplicationDbContext : DbContext
{
    public DbSet<Metar> Metars { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Port=54322;Database=badweather;Username=postgres;Password=secret;");
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MetarEntityTypeConfiguration).Assembly);
    }
}