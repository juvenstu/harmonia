using PlatformService.Dtos;

namespace PlatformService.AsyncDataServices;

public interface IMessageBusClient
{
    public void PublishNewPlatform(PlatformPublishDto platformPublishDto);
}