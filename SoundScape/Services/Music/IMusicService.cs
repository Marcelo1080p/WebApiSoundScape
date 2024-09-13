using SoundScape.Dto.Music;
using SoundScape.Models.Music;
using SoundScape.Models.ResponseModel;

namespace SoundScape.Services.Music
{
    public interface IMusicService
    {
        public Task<ResponseModel<List<MusicModel>>> GetAllMusics();
        public Task<ResponseModel<List<MusicModel>>> AddNewMusic(CreationMusicDto musicDto);
        public Task<ResponseModel<List<MusicModel>>> GetArtistAndSongs(int idArtist);
        public Task<ResponseModel<List<MusicModel>>> RemoveMusicById(int idMusic);

    }
}
