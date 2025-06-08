using DesafioBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioBackend.Data
{
    public class ApiDbContext:DbContext,IApiDbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

        public DbSet<Autor> Autors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
                
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();


        }


    }
}
