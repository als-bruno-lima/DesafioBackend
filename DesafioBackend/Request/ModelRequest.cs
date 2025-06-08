using DesafioBackend.Models;

namespace DesafioBackend.Request
{
    public class ModelRequest
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public int ReleaseYear { get; set; }
        public string ImageUrl { get; set; }
        public int Stock { get; set; }
        public string ISBN { get; set; }

        public int AutorId { get; set; }

        public int GenreId { get; set; }



    }
}
