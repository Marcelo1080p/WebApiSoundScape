using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoundScape.Data;
using SoundScape.Dto.Artist;
using SoundScape.Models.Artist;
using SoundScape.Models.ResponseModel;
using SoundScape.Services.Artist;

namespace SoundScape.Controllers.ArtistController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistService _artistService;
        public ArtistController(IArtistService artistService)
        {
            _artistService = artistService;
        }

        [HttpGet("GetAllArtist")]
        public async Task<ActionResult<ResponseModel<List<ArtistModel>>>> GetAllArtist()
        {
            var artists = await _artistService.GetAllArtist();
            return Ok(artists);
        }

        [HttpGet("GetArtistById{idArtist}")]
        public async Task<ActionResult<ResponseModel<ArtistModel>>> GetArtistById(int idArtist)
        {
            var artist = await _artistService.GetArtistById(idArtist);
            return Ok(artist);
        }

        [HttpPost("AddNewArtist")]
        public async Task<ActionResult<ResponseModel<List<ArtistModel>>>> AddNewArtist(CreationArtistDto artistDto)
        {
            var artist = await _artistService.AddNewArtist(artistDto);
            return Ok(artist);
        }

        [HttpPut("UpdateArtist")]
        public async Task<ActionResult<ResponseModel<List<ArtistModel>>>> UpdateArtist(EditArtistDto editArtistDto)
        {
            var artist = await _artistService.UpdateArtist(editArtistDto);
            return Ok(artist);
        }

    }
}
