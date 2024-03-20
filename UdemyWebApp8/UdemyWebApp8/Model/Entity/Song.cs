namespace UdemyWebApp8.Model.Entity
{
    public class Song
    {
        public Guid SongId { get; set; } = Guid.NewGuid();
        public string SongName { get; set; } = "";
    }
}
