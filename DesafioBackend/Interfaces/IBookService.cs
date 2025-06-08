using DesafioBackend.Models;

namespace DesafioBackend.Interfaces
{
    public interface IBookService
    {
        Task<string> AddBook(Book book);
        void UpdateBook(int id, BookDto book);
        Task DeleteBook(int id);
        Book GetBookById(int id);

        List<Book> GetAllBooks();


        List<Book> GetBooksByTitle(string title);
        List<Book> GetBooksByISBN(string isbn);

        List<Book> GetBooksByAuthor(int authorId);
        List<Book> GetBooksByGenre(int genreId);


        //List<Book> GetAllBooks(string title, string ISBN, int authorId, int genreId);


    }
}
