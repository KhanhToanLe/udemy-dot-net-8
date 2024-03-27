using Autofac;
using DependencyInjection.Services.IService;
using Microsoft.AspNetCore.Mvc;
using UdemyWebApp8.Model.Entity;

namespace DependencyInjection.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SongController : Controller
    {
        private static IContainer Container { get; set; }

        [HttpGet]
        public IActionResult GetSong()
        {
            List<Song> songs;
            
            using (var scope = Container.BeginLifetimeScope())
            {
                var songService = scope.Resolve<ISongService>();
                songs = (List<Song>)songService.GetSong();
            }
            return new JsonResult(songs)
            {
                ContentType = "application/json"
            };
        }
    }
}
