using DesafioBackend.Data;
using DesafioBackend.Interfaces;
using DesafioBackend.Models;
using DesafioBackend.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesafioBackend.Services
{
    public class BookService : IBookService
    {
        private readonly IApiDbContext _context;
        private readonly ILogger<IBookService> _logger;
        public BookService(IApiDbContext context, ILogger<IBookService> logger)
        {
            _context = context;
            _logger = logger;
        }


        public async Task<string> AddBook(Book book)
        {
            var autor = _context.Autors.Find(book.AutorId);
            var genero = _context.Genres.Find(book.GenreId);

            if (autor == null)
            {
                return "autor no encontrado";
            }
            else if (genero == null) {
                return "genero no encontrado";
            }


            
             await _context.Books.AddAsync(book);
             await _context.Books.AddAsync(book);
            _logger.LogInformation($"Book {book.Title} by {autor.Name} in genre {genero.Name} is being added to the database.");

            await _context.SaveChangesAsync();
            return "Book added";
        }


        public void UpdateBook(int id, BookDto book)
        {
           var newBook =  _context.Books.Find(id);
            if (newBook == null)
            {
                throw new Exception("Book not found");
            }

            newBook.Title = book.Title;
            newBook.AutorId = book.AutorId;
            newBook.GenreId = book.GenreId;
            newBook.Stock = book.Stock;
            newBook.ISBN = book.ISBN;
            newBook.ReleaseYear = book.ReleaseYear;
            newBook.Summary = book.Summary;
            newBook.ImageUrl = book.ImageUrl;


            _context.SaveChanges();
            _logger.LogInformation($"Book with ID {id} has been updated in the database.");
        }

        public async Task DeleteBook(int id)
        {
            var book = _context.Books.Find(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }

            _logger.LogInformation($"Book with ID {id} has been deleted from the database.");

        }


        public Book GetBookById(int id)
        {
            return _context.Books.Include(book=>book.Autor).Include(book=>book.Genre).FirstOrDefault(b=>b.Id == id); 

        }


        public List<Book> GetBooksByTitle(string title) {
            return _context.Books.Where(b => b.Title.Contains(title)).ToList();

        }
        public List<Book> GetBooksByISBN(string isbn)
        {
            return _context.Books.Where(b => b.ISBN == isbn).ToList();

        }
        public List<Book> GetBooksByAuthor(int authorId)
        {
            return _context.Books.Where(b => b.AutorId == authorId).ToList();

        }
        public List<Book> GetBooksByGenre(int genreId)
        {
            return _context.Books.Where(b => b.GenreId == genreId).ToList();

        }

        public List<Book> GetAllBooks()
        {
            return _context.Books.ToList();


        }




    }
}