using Microsoft.EntityFrameworkCore;
using SoundScape.Data;
using SoundScape.Dto.Music;
using SoundScape.Models.Music;
using SoundScape.Models.ResponseModel;

namespace SoundScape.Services.Music
{
    public class MusicService : IMusicService
    {
        private readonly AppDbContext _context;
        public MusicService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<MusicModel>>> GetAllMusics()
        {
            ResponseModel<List<MusicModel>> response = new ResponseModel<List<MusicModel>>();
            try
            {
                var musics = await _context.Musics.ToListAsync();
                if (musics == null)
                {
                    response.Menssage = "Musics not found!";

                    return response;
                }
                response.Data = musics;
                response.Menssage = "all musics have been collected";

                return response;
            }
            catch (Exception ex)
            {
                response.Menssage = ex.Message;
                response.Status = false;
                return response;
            }
        }
        public async Task<ResponseModel<List<MusicModel>>> AddNewMusic(CreationMusicDto musicDto)
        {
            ResponseModel<List<MusicModel>> response = new ResponseModel<List<MusicModel>>();
            try
            {
                var artist = await _context.Artists
                    .FirstOrDefaultAsync(artistResponse => artistResponse.Id == musicDto.Artist.Id);
                if (artist == null)
                {
                    response.Menssage = "Artist not found";
                    return response;
                }
                var music = new MusicModel
                {
                    NameMusic = musicDto.NameMusic,
                    Artist = artist,
                };

                _context.Add(music);
                await _context.SaveChangesAsync();

                response.Data = await _context.Musics.Include(a => a.Artist).ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                response.Menssage = ex.Message;
                response.Status = false;
                return response;
            }
        }
        public async Task<ResponseModel<List<MusicModel>>> GetArtistAndSongs(int idArtist)
        {
            ResponseModel<List<MusicModel>> response = new ResponseModel<List<MusicModel>>();
            try
            {
                var artist = await _context.Musics
                    .Include(a => a.Artist)
                    .Where(artistResponse => artistResponse.Id == idArtist)
                    .ToListAsync();

                if(artist == null)
                {
                    response.Menssage = "Artist not found";
                    return response;
                }
                response.Data = await _context.Musics.Include(a => a.Artist).ToListAsync();
                return response;

            }
            catch (Exception ex)
            {
                response.Menssage = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<MusicModel>>> RemoveMusicById(int idMusic)
        {
            ResponseModel<List<MusicModel>> response = new ResponseModel<List<MusicModel>>();
            try
            {
                var music = await _context.Musics
                    .Include(a => a.Artist)
                    .FirstOrDefaultAsync(artistResponse => artistResponse.Id == idMusic);
                if (music == null)
                {
                    response.Menssage = "Artist not found";
                    return response;
                }
                _context.Remove(music);
                await _context.SaveChangesAsync();

                response.Data = await _context.Musics.ToListAsync();
                response.Menssage = "Music removed successfully";
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
