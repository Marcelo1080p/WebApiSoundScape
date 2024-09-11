
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoundScape.Models.Music;
using SoundScape.Models.ResponseModel;
using SoundScape.Services.Music;

namespace SoundScape.Controllers.MusicController
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly IMusicService _musicService;
        public MusicController(IMusicService musicService)
        {
            _musicService = musicService;
        }

        [HttpGet("GetAllMusics")]
        public async Task<ActionResult<ResponseModel<List<MusicModel>>>> GetAllMusics()
        {
            var musics = await _musicService.GetAllMusics();
            return Ok(musics);
        }
    }
}
