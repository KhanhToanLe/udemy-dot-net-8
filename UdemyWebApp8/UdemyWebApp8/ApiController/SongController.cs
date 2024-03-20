using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyWebApp8.Model.Dto;
using UdemyWebApp8.Model.Entity;

namespace UdemyWebApp8.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class SongController : ControllerBase
    {
        private List<Song> _songList = new List<Song>();

        [HttpGet]
        public ActionResult GetSongs()
        {
            return Accepted(_songList);
        }

        [HttpPost]
        public ActionResult AddSong([FromBody]AddSongDto songDto)
        {
            Song newSong = new Song()
            {
                SongName = songDto.SongName
            };
            _songList.Add(newSong);
            return Created("/song",newSong);
        }
    }
}
