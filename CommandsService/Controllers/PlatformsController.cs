using AutoMapper;
using CommandsService.Data;
using CommandsService.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CommandsService.Controllers;

[ApiController]
[Route("api/c/[controller]")]
public class PlatformsController(ICommandRepo repository, IMapper mapper) : ControllerBase
{
    private readonly ICommandRepo _repository = repository;
    private readonly IMapper _mapper = mapper;

    [HttpGet]
    public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
    {
        Console.WriteLine("info: Getting platforms from CommandsService");
        var platforms = _repository.GetAllPlatforms();
        return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platforms));
    }

    [HttpPost]
    [ProducesResponseType<string>(StatusCodes.Status200OK)]
    public ActionResult TestInBoundConnection()
    {
        Console.WriteLine("info: Inbound POST # Command Service");
        return Ok("Inbound test from platforms controller is ok!");
    }
}