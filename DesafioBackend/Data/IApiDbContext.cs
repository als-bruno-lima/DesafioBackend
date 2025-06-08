using Microsoft.EntityFrameworkCore;

namespace DesafioBackend.Data
{
    public interface IApiDbContext
    {

        DbSet<Models.Autor> Autors { get; set; }
        DbSet<Models.Book> Books { get; set; }
        DbSet<Models.Genre> Genres { get; set; }
        DbSet<Models.User> Users { get; set; }


        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        


    }
}
