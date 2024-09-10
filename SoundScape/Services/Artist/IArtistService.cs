using SoundScape.Models.Artist;
using SoundScape.Models.ResponseModel;
using SoundScape.Dto.Artist;

namespace SoundScape.Services.Artist
{
    public interface IArtistService
    {
        Task<ResponseModel<List<ArtistModel>>> GetAllArtist();
        Task<ResponseModel<ArtistModel>> GetArtistById(int idArtist);
        Task<ResponseModel<List<ArtistModel>>> AddNewArtist(CreationArtistDto artistDto);

    }
}
