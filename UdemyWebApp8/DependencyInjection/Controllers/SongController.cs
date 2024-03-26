using DependencyInjection.Services.IService;
using DependencyInjection.Services.Service;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SongController : Controller
    {
        private readonly ISongService _songService;
        public SongController([FromServices] ISongService songService)
        {
            _songService = songService;
        }

        [HttpGet]
        public IActionResult GetSong()
        {
            var songs =  _songService.GetSong();
            return new JsonResult(songs)
            {
                ContentType = "application/json"
            };
        }
    }
}
