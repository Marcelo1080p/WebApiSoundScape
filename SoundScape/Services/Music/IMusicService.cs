using SoundScape.Models.Music;
using SoundScape.Models.ResponseModel;

namespace SoundScape.Services.Music
{
    public interface IMusicService
    {
        public Task<ResponseModel<List<MusicModel>>> GetAllMusics();

    }
}
