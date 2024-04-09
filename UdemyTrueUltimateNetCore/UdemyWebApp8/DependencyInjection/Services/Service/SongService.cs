using DependencyInjection.Services.IService;
using UdemyWebApp8.Model.Entity;

namespace DependencyInjection.Services.Service
{
    public class SongService : ISongService
    {
        private readonly IEnumerable<Song> _songs = new List<Song>() {
            new()
            {
                SongId = Guid.NewGuid(),
                SongName = "This is what you came for",
                SongAge = 12
            },
            new()
            {
                SongId = Guid.NewGuid(),
                SongName = "Golden Hours",
                SongAge = 878
            }
        };
        public IEnumerable<Song> GetSong()
        {
            return _songs;
        }
    }
}
