using AutoMapper;
using CommandsService.Data;
using CommandsService.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CommandsService.Controllers;

[Route("/api/c/platforms/{platformId}/[controller]")]
[ApiController]
public class CommandsController(ICommandRepo repository, IMapper mapper) : ControllerBase
{
    private readonly ICommandRepo _repository = repository;
    private readonly IMapper _mapper = mapper;

    [HttpGet]
    public ActionResult<IEnumerable<CommandReadDto>> GetCommandsForPlatform(int platformId)
    {
        Console.WriteLine($"info: Get commands for platform by ID: {platformId}");
        if (!_repository.PlatformExists(platformId)) return NotFound();
        var commands = _repository.GetCommandsForPlatform(platformId);

        return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commands));
    }

    [HttpGet("{commandId}", Name = "GetCommandForPlatform")]
    public ActionResult<CommandReadDto> GetCommandForPlatform(int platformId, int commandId)
    {
        Console.WriteLine($"info: Get command for platform by both IDs: {platformId} / {commandId}");
        if (!_repository.PlatformExists(platformId)) return NotFound();
        var command = _repository.GetCommand(platformId, commandId);
        if (command == null) return NotFound();

        return Ok(_mapper.Map<CommandReadDto>(command));
    }
}