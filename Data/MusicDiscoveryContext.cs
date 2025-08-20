using Microsoft.EntityFrameworkCore;
using MusicDiscoveryAPI.Models;

namespace MusicDiscoveryAPI.Data
{
    public class MusicDiscoveryContext : DbContext
    {
        public MusicDiscoveryContext(DbContextOptions<MusicDiscoveryContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}