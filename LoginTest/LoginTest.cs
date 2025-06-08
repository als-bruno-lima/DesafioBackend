using DesafioBackend.Controllers;
using DesafioBackend.Data;
using DesafioBackend.Interfaces;
using DesafioBackend.Models;
using DesafioBackend.Request;
using DesafioBackend.Responses;
using DesafioBackend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;

namespace LoginTest
{
    public class LoginTest
    {
        private readonly IConfiguration _configuration;
        private readonly Mock<IUserService> _userServiceMock = new Mock<IUserService>();
        private readonly Mock<IConfiguration> _configurationMock;
        private readonly Mock<ILogger<IUserService>> _loggerMock = new Mock<ILogger<IUserService>>();




        [Fact]
        public async void RegisterUser_Should_Create_A_New_User_In_Database()
        {
        var mockHashService = new Mock<IHashPassword>();

            var password = "123";
            var hashedPassword = "hashed123";

            mockHashService.Setup(h => h.encryptSHA256(password)).Returns(hashedPassword);
            
            var optionsBuilder = new DbContextOptionsBuilder<ApiDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            var context = new ApiDbContext(optionsBuilder.Options);

            var userService = new UserService(context, mockHashService.Object,_configuration,_loggerMock.Object);
            
            var controller = new UserController(userService);

            var user = new UserModelDto() 
            {
                Email="user@gmail.com",
                Name="user",
                Password="123",
                Status=0
            };

                var result = await controller.AddUser(user);
                Assert.IsType<OkObjectResult>(result);
            }

        [Fact]
        public async void LoginUser_Should_Search_For_User_And_Return_a_Token() {

            var user = new LoginModelDto()
            {
                Email = "user@gmail.com",
                Password = "123",
            };

            TokenModelResponse response = new TokenModelResponse {
                email = user.Email,
                message = "User found",
                token = "dummy_token"
            };

            _userServiceMock.Setup(x => x.GetToken(user.Email, user.Password)).Returns(response);

            var controller = new UserController(_userServiceMock.Object);
            
            var result = await controller.GetToken(user);

            Assert.IsType<OkObjectResult>(result);
        }
                   
        }
    }
