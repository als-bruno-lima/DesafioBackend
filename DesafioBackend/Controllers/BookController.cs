using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using DesafioBackend.Interfaces;
using DesafioBackend.Models;
using DesafioBackend.Request;
using DesafioBackend.Responses;
using DesafioBackend.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace DesafioBackend.Controllers
{

    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    [ApiController]

    public class BookController : ControllerBase
    {

        private readonly IBookService _bookService;
        private readonly IConfiguration _configuration;

        private readonly ILogger<BookController> _logger;

        public BookController(IBookService bookService, IConfiguration configuration, ILogger<BookController> logger)
        {
            _bookService = bookService;
            _logger = logger;
           
        
        }

        [HttpGet("/books")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Book>>> getAll(string title = null, string ISBN = null, int authorId=0, int genreId=0)
        {
            try
            {

                if (title != null)
                {
                    var booksByTitle = _bookService.GetBooksByTitle(title)
                        .ToList();
                    return booksByTitle;
                }
                else if (ISBN != null)
                {
                    var booksByISBN = _bookService.GetBooksByISBN(ISBN)
                        .ToList();

                    return booksByISBN;
                }
                else if (authorId != 0)
                {
                    var booksByAuthor = _bookService.GetBooksByAuthor(authorId)
                        .ToList();
                    return booksByAuthor;
                }
                else if (genreId != 0)
                {
                    var booksByGenre = _bookService.GetBooksByGenre(genreId)
                        .ToList();
                    return booksByGenre;
                }
                else
                {
                    var books = _bookService.GetAllBooks().Select(book => new { book.Title, book.ImageUrl, book.ReleaseYear, book.Stock });
                    return Ok(books);

                }

            }
            catch (Exception ex)
            {
                _logger.LogInformation("eror", ex);

                return BadRequest($"Error retrieving books: {ex}");
            }
        }

        [HttpGet("/books/{id}")]
        [Authorize]

        public async Task<IActionResult> GetBook(int id)
        {

            try
            {
                var book = _bookService.GetBookById(id);
                if (book == null)
                {
                    return NotFound($"Book with ID {id} not found.");
                }
                return Ok(book);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("eror", ex);

                return BadRequest($"Error retrieving books: {ex}");

            }

        }



        [HttpPost("/books")]
        [Authorize]

        public async Task<IActionResult> AddBook([FromBody] ModelRequest request)
        {
            try
            {
                var newBook = new Book { Title = request.Title, AutorId = request.AutorId, GenreId = request.GenreId, Stock = request.Stock, ISBN = request.ISBN, ReleaseYear = request.ReleaseYear, Summary = request.Summary, ImageUrl = request.ImageUrl };

                string response = await _bookService.AddBook(newBook);
                if (response == "Autor no encontrado" || response == "Genero no encontrado")
                {
                    return BadRequest(response);
                }
                else {
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("eror", ex);

                return BadRequest($"Error adding book: {ex}");
            }
        }


        [HttpPut("/books/{id}")]
        [Authorize]

        public IActionResult UpdateBooks(BookDto book, int id)
        {
            try
            {

                _bookService.UpdateBook(id, book);
                return Ok($"Entity with ID: {id} Updated");


            }
            catch (Exception ex)
            {
                _logger.LogInformation("eror", ex);

                return BadRequest($"Error updating book: {ex}");
            }

        }



        [HttpDelete("/books/{id}")]
        [Authorize]

        public async Task<IActionResult> DeleteBook(int id)
        {

            try
            {
                await _bookService.DeleteBook(id);
                return Ok($"Book with ID {id} deleted successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogInformation("eror", ex);

                return BadRequest($"Error deleting book: {ex}");
            }

        }

       

    }

}
