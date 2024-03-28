using Autofac;
using Autofac.Core.Lifetime;
using DependencyInjection.Services.IService;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using UdemyWebApp8.Model.Entity;

namespace DependencyInjection.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SongController : Controller
    {
        private readonly ILifetimeScope _lifetimeScope;
        public SongController(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }
        [HttpGet]
        public IActionResult GetSong()
        {
            List<Song> songs = new();
            using (var scope = _lifetimeScope.BeginLifetimeScope())
            {
                var songService = scope.Resolve<ISongService>();
                songs = (List<Song>)songService.GetSong();
            }
            //songs = (List<Song>)_songService.GetSong();
            return new JsonResult(songs)
            {
                ContentType = "application/json"
            };
        }
    }
}
