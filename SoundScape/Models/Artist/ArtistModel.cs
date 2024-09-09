using SoundScape.Models.Music;
using System.Text.Json.Serialization;

namespace SoundScape.Models.Artist
{
    public class ArtistModel
    {
        public int Id { get; set; }
        public string Artist { get; set; }
        public string MusicalGenre { get; set; }

        [JsonIgnore]
        public ICollection<MusicModel> Musics { get; set; }
    }
}
