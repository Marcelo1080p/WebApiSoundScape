using Azure;
using Microsoft.EntityFrameworkCore;
using SoundScape.Data;
using SoundScape.Dto.Artist;
using SoundScape.Models.Artist;
using SoundScape.Models.ResponseModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SoundScape.Services.Artist
{
    public class ArtistService : IArtistService
    {
        private readonly AppDbContext _context;
        public ArtistService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<ArtistModel>>> AddNewArtist(CreationArtistDto artistDto)
        {
            ResponseModel<List<ArtistModel>> response = new ResponseModel<List<ArtistModel>>();
            try
            {
                var artist = new ArtistModel()
                {
                    Artist = artistDto.Artist,
                    MusicalGenre = artistDto.MusicalGenre,
                };
                _context.Add(artist);
                await _context.SaveChangesAsync();

                response.Data = await _context.Artists.ToListAsync();
                response.Menssage = "new artist created successfully";

                return response;
            }
            catch (Exception ex) 
            {
                response.Menssage = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<ArtistModel>>> DeleteArtist(int idArtist)
        {
            ResponseModel<List<ArtistModel>> response = new ResponseModel<List<ArtistModel>>();
            try
            {
                var artist = await _context.Artists.SingleOrDefaultAsync(artistResponse => artistResponse.Id == idArtist);
                if (artist == null)
                {
                    response.Menssage = "Artists not found";
                    return response;
                }
                _context.Remove(artist);
                await _context.SaveChangesAsync();

                response.Data = await _context.Artists.ToListAsync();
                response.Menssage = "Artist removed successfully";

                return response;
            }
            catch (Exception ex)
            {
                response.Menssage = "Error deleting artist: " + ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<ArtistModel>>> GetAllArtist()
        {
            ResponseModel<List<ArtistModel>> response = new ResponseModel<List<ArtistModel>>();
            try
            {
                var artists = await _context.Artists.ToListAsync();
                if(artists == null)
                {
                    response.Menssage = "no artists found";
                    return response;
                }
                response.Data = artists;
                response.Menssage = "all artists have been collected";
                
                return response;
            }
            catch (Exception ex)
            {
                response.Menssage = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<ArtistModel>> GetArtistById(int idArtist)
        {
            ResponseModel<ArtistModel> response = new ResponseModel<ArtistModel>();
            try
            {
                var artist = await _context.Artists.FirstOrDefaultAsync(artistReturn => artistReturn.Id == idArtist);
                if (artist == null) 
                {
                    response.Menssage = "no artists found";
                    return response ;
                }
                response.Data = artist;
                response.Menssage = "Artist Found";

                return response;
            }
            catch (Exception ex)
            {
                response.Menssage = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<ArtistModel>>> UpdateArtist(EditArtistDto editArtistDto)
        {
            ResponseModel<List<ArtistModel>> response = new ResponseModel<List<ArtistModel>>();
            try
            {
                var artist = await _context.Artists.
                    FirstOrDefaultAsync(artistResponse =>  artistResponse.Id == editArtistDto.Id);
                if (artist == null)
                {
                    response.Menssage = "Artist Not Found";
                    return response ;
                }
                artist.Artist = editArtistDto.Artist;
                artist.MusicalGenre = editArtistDto.MusicalGenre;

                _context.Artists.Update(artist);
                await _context.SaveChangesAsync();

                response.Data = await _context.Artists.ToListAsync();
                response.Menssage = "Update Artist with Success!";

                return response;
            }
            catch (Exception ex) 
            {
                response.Menssage = ex.Message;
                response.Status = false;
                return response;
            }
        }
    }
}
