using CommandsService.Models;
using Microsoft.EntityFrameworkCore;

namespace CommandsService.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Platform> Platforms { get; set; }
    public DbSet<Command> Commands { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Platform>()
            .HasMany(p => p.Commands)
            .WithOne(c => c.Platform)
            .HasForeignKey(c => c.PlatformId);

        modelBuilder
            .Entity<Command>()
            .HasOne(c => c.Platform)
            .WithMany(p => p.Commands)
            .HasForeignKey(c => c.PlatformId);
    }
}