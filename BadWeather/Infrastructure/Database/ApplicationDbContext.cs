using BadWeather.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BadWeather.Infrastructure.Database;

public class ApplicationDbContext : DbContext
{
    public DbSet<Metar> Metars { get; set; } = null!;

    public ApplicationDbContext(DbContextOptions options) 
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MetarEntityTypeConfiguration).Assembly);
    }
}