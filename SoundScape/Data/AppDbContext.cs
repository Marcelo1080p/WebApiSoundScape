using Microsoft.EntityFrameworkCore;
using SoundScape.Models.Artist;
using SoundScape.Models.Music;

namespace SoundScape.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
                 
        public DbSet<ArtistModel> Artists { get; set; }
        public DbSet<MusicModel> Musics { get; set; }
    }
}
