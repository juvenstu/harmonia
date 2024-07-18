using AutoMapper;
using CommandsService.Models;
using Grpc.Net.Client;
using PlatformService;

namespace CommandsService.SyncDataServices.Grpc;

public class PlatformDataClient(IConfiguration configuration, IMapper mapper) : IPlatformDataClient
{
    private readonly IConfiguration _configuration = configuration;
    private readonly IMapper _mapper = mapper;
    public IEnumerable<Platform> ReturnAllPlatforms()
    {
        var grpcPlatform = _configuration["GrpcPlatform"];
        Console.WriteLine($"info: Calling gRPC service {grpcPlatform}");
        var channel = GrpcChannel.ForAddress(grpcPlatform != null ? grpcPlatform : "");
        var client = new GrpcPlatform.GrpcPlatformClient(channel);
        var request = new GetAllRequest();

        try
        {
            var reply = client.GetAllPlatforms(request);
            return _mapper.Map<IEnumerable<Platform>>(reply.Platform);
        }
        catch (Exception e)
        {
            Console.WriteLine($"error: Could not call gRPC server {e.Message}");
            throw;
        }
    }
}