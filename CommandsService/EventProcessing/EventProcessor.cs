using System.Text.Json;
using AutoMapper;
using CommandsService.Data;
using CommandsService.Dtos;
using CommandsService.Models;
using PlatformService.Dtos;

namespace CommandsService.EventProcessing;

public class EventProcessor(IServiceScopeFactory serviceScopeFactory, IMapper mapper) : IEventProcessor
{
    private readonly IServiceScopeFactory _serviceScopeFactory = serviceScopeFactory;
    private readonly IMapper _mapper = mapper;

    public void ProcessEvent(string message)
    {
        var eventType = DetermineEvent(message);
        if (eventType == EventType.PlatformPublished)
        {
            // To DO
        }
    }

    private static EventType DetermineEvent(string notificationMessage)
    {
        var eventType = JsonSerializer.Deserialize<GenericEventDto>(notificationMessage);
        switch (eventType?.Event)
        {
            case "Platform_Published":
                Console.WriteLine("info: Platform published event detected.");
                return EventType.PlatformPublished;
            default:
                Console.WriteLine("info: Could not determine the event type!");
                return EventType.Undetermined;
        }
    }

    private void AddPlatform(string platformPublishedMessage)
    {
        using var scope = _serviceScopeFactory.CreateScope();
        var repo = scope.ServiceProvider.GetRequiredService<ICommandRepo>();
        var platformPublishDto = JsonSerializer.Deserialize<PlatformPublishDto>(platformPublishedMessage);
        try
        {
            var platform = _mapper.Map<Platform>(platformPublishDto);
            if (repo.ExternalPlatformExists(platform.ExternalId))
                Console.WriteLine("info: Platform already exist!");
            else
            {
                repo.CreatePlatform(platform);
                repo.SaveChanges();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"error: Could not add platform to database: {e.Message}");
        }
    }
}

enum EventType
{
    PlatformPublished,
    Undetermined
}