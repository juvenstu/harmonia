using Microsoft.EntityFrameworkCore;
using PlatformService.AsyncDataServices;
using PlatformService.Data;
using PlatformService.SyncDataServices.Http;

var builder = WebApplication.CreateBuilder(args);

var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");
var connectionString = builder.Configuration.GetConnectionString("PlatformService")?.Replace("Password=;", $"Password={dbPassword};");

builder.Services.AddControllers();

if (builder.Environment.IsProduction())
{
    Console.WriteLine("info: Using MS SQL Server Database.");
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(connectionString));
}
else
{
    Console.WriteLine("info: Using InMemory database.");
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseInMemoryDatabase("PlatformService"));
}

builder.Services.AddScoped<IPlatformRepo, PlatformRepo>();
builder.Services.AddHttpClient<ICommandDataClient, CommandDataClient>();
builder.Services.AddSingleton<IMessageBusClient, MessageBusClient>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

ConsoleColor originalColor = Console.ForegroundColor;
Console.ForegroundColor = ConsoleColor.Blue;
Console.Write("info: ");
Console.ForegroundColor = originalColor;
Console.WriteLine($"Commands Service\n      Listening on: {builder.Configuration["CommandsService"]}");

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

PrepDb.PrepPopulation(app, app.Environment.IsProduction());

await app.RunAsync();