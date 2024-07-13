using PlatformService.Models;

namespace PlatformService.Data
{
    public interface IPlatformRepo
    {
        IEnumerable<Platform> GetAllPlatforms();
        Platform? GetPlatformById(int id);
        void CreatePlatform(Platform platform);
        bool SaveChanges();
    }
}