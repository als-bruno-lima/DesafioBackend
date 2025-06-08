using System.Net;
using DesafioBackend.Controllers;
using DesafioBackend.Data;
using DesafioBackend.Interfaces;
using DesafioBackend.Models;
using DesafioBackend.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LoginTest.nUnitTests
{
    public class LoginTest
    {
        private User user;
        private ApiDbContext dbContext;
        
     
        //private ApiDbContext _context { get; set; } = null!;


        [SetUp]
        public void setup()
        {
            user = new User() { Id = 5, Email = "usuario@gmail.com", Name = "usuario", Password = "123", status = 0 };


        private IServiceProvider CreateContext(string nameDB)
        {
            var services = new ServiceCollection();
            services.AddDbContext<DbContext>(options => options.UseInMemoryDatabase(databaseName: nameDB),
                ServiceLifetime.Scoped, ServiceLifetime.Scoped);

            return services.BuildServiceProvider();


        }

        

        [Test]
        public async Task AddUser_Service()
        {
            var nameDB = Guid.NewGuid().ToString();
            var serviceProvider = CreateContext(nameDB);
            var db = serviceProvider.GetService<DbContext>();
            db.Add(dbContext);


        }
    }
}