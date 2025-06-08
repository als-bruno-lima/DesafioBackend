using DesafioBackend.Data;
using DesafioBackend.Interfaces;
using DesafioBackend.Models;
using DesafioBackend.Responses;
using Microsoft.EntityFrameworkCore;

namespace DesafioBackend.Services
{
    public class AutorService : IAutorService
    {
        private readonly IApiDbContext _context;
        public AutorService(IApiDbContext context)
        {
            _context = context;
        }


        public  object GetAuthors()
        {
            return _context.Autors.Select(autors => new { id = autors.Id, name = autors.Name, country = autors.Country, date = autors.Date, BooksQty = autors.Books.Count() }).ToList();
          
        }
    }
}
