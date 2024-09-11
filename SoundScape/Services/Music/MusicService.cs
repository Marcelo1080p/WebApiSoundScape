using Microsoft.EntityFrameworkCore;
using SoundScape.Data;
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
    }
}
