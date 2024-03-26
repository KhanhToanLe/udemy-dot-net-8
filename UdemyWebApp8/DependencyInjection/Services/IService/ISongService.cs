using UdemyWebApp8.Model.Entity;

namespace DependencyInjection.Services.IService
{
    public interface ISongService
    {
        public IEnumerable<Song> GetSong();
    }
}
