using Microsoft.EntityFrameworkCore;
using PlatformService.Models;

namespace PlatformService.Data;

public static class PrepDb
{
    public static void PrepPopulation(IApplicationBuilder app, bool IsProduction)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
        SeedData(serviceScope.ServiceProvider.GetRequiredService<AppDbContext>(), IsProduction);
    }

    public static void SeedData(AppDbContext context, bool IsProduction)
    {
        if (IsProduction)
        {
            Console.WriteLine("info: Attempting to apply migrations...");
            try
            {
                context.Database.Migrate();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: Migration failed: {e.Message}");
            }
        }
        if (!context.Platforms.Any())
        {
            Console.WriteLine("info: Seeding Data...");
            context.Platforms.AddRange(
                new Platform() { Name = ".NET", Publisher = "Microsoft", Cost = "Free" },
                new Platform() { Name = "SQL Server", Publisher = "Microsoft", Cost = "Free" },
                new Platform() { Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free" }
            );

            context.SaveChanges();
        }
        else
        {
            Console.WriteLine("info: We already have data!");
        }
    }
}