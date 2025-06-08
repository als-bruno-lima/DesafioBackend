namespace DesafioBackend.Models
{
    public class Book
    {

        public int Id { get; set; }  
        public string Title { get; set; }
        public string Summary { get; set; }
        public int ReleaseYear { get; set; }
        public string ImageUrl { get; set; }
        public int Stock { get; set; }
        public String ISBN { get; set; }
        public Autor Autor { get; set; }
        public int AutorId { get; set; }

        public Genre Genre { get; set; }
        public int GenreId { get; set; }

    }
}
