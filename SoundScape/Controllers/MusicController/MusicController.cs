
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoundScape.Dto.Music;
using SoundScape.Models.Music;
using SoundScape.Models.ResponseModel;
using SoundScape.Services.Music;

namespace SoundScape.Controllers.MusicController
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly IMusicService _IMusicService;
        public MusicController(IMusicService musicService)
        {
            _IMusicService = musicService;
        }

        [HttpGet("GetAllMusics")]
        public async Task<ActionResult<ResponseModel<List<MusicModel>>>> GetAllMusics()
        {
            var musics = await _IMusicService.GetAllMusics();
            return Ok(musics);
        }

        [HttpPost("AddNewMusic")]
        public async Task<ActionResult<ResponseModel<List<MusicModel>>>> AddNewMusic(CreationMusicDto musicDto)
        {
            var musics = await _IMusicService.AddNewMusic(musicDto);
            return Ok(musics);
        }

        [HttpGet("GetArtistAndSongs/{idArtist}")]
        public async Task<ActionResult<ResponseModel<List<MusicModel>>>> GetArtistAndSongs(int idArtist)
        {
            var musics = await _IMusicService.GetArtistAndSongs(idArtist);
            return Ok(musics);
        }

        [HttpDelete("RemoveMusicById/{idMusic}")]
        public async Task<ActionResult<ResponseModel<List<MusicModel>>>> RemoveMusicById(int idMusic)
        {
            var music = await _IMusicService.RemoveMusicById(idMusic);
            return Ok(music);
        }
    }
}
