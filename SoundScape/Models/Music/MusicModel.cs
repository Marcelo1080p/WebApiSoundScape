using SoundScape.Models.Artist;

namespace SoundScape.Models.Music
{
    public class MusicModel
    {
        public int Id { get; set; }
        public string NameMusic { get; set; }
        public ArtistModel Artist { get; set; }
    }
}
