namespace PlatformService.Dtos;

public class PlatformPublishDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Event { get; set; }
}