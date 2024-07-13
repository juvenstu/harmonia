using PlatformService.Models;

namespace PlatformService.Data
{
    public class PlatformRepo(AppDbContext context) : IPlatformRepo
    {
        private readonly AppDbContext _context = context;

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return [.. _context.Platforms];
        }

        public Platform? GetPlatformById(int id)
        {
            return _context.Platforms.FirstOrDefault(p => p.Id == id);
        }

        public void CreatePlatform(Platform platform)
        {
            ArgumentNullException.ThrowIfNull(platform);
            _context.Platforms.Add(platform);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}
