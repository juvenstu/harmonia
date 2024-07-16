using System.Text;
using System.Text.Json;
using PlatformService.Dtos;

namespace PlatformService.SyncDataServices.Http;

public class CommandDataClient(HttpClient httpClient, IConfiguration configuration) : ICommandDataClient
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly IConfiguration _configuration = configuration;
    public async Task SendPlatformToCommand(PlatformReadDto platform)
    {
        var httpContent = new StringContent(
            JsonSerializer.Serialize(platform),
            Encoding.UTF8,
            "application/json");

        var response = await _httpClient.PostAsync(_configuration["CommandsService"], httpContent);

        if (response.IsSuccessStatusCode) Console.WriteLine("info: Sync POST to commands service successful!");
        else Console.WriteLine("info: Sync POST to commands service failed!");
    }
}