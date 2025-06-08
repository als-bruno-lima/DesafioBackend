using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DesafioBackend.Data;
using DesafioBackend.Interfaces;
using DesafioBackend.Models;
using DesafioBackend.Request;
using DesafioBackend.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace DesafioBackend.Services
{
    public class UserService : IUserService
    {

        private readonly IApiDbContext _context;
        private readonly IHashPassword _hashPassword;
        private readonly IConfiguration _configuration;
        private readonly ILogger<IUserService> _logger;
        public UserService(IApiDbContext context, IHashPassword hashPassword, IConfiguration configuration, ILogger<IUserService> logger)
        {
            _context = context;
            _hashPassword = hashPassword;
            _configuration = configuration;
            _logger = logger;
        }


        public async Task AddUser(string name, string email, string password, State status)
        {

            var user = new User
            {
                Name = name,
                Email = email,
                Password = _hashPassword.encryptSHA256(password),
                status = status
            };

            await _context.Users.AddAsync(user);
            _logger.LogInformation($"User {name} with email {email} is being added to the database.");
            await _context.SaveChangesAsync();



        }

        public TokenModelResponse GetToken(string email, string password) {
            var hashedPassword = _hashPassword.encryptSHA256(password);

             var user =_context.Users.FirstOrDefault(user => user.Email == email && user.Password == hashedPassword);

            if (user == null) {
                TokenModelResponse responseFailed = new TokenModelResponse { 
                email = null,
                message = "User not found",
                token = null,
                };
                return responseFailed;
            }


            var jwt = _configuration.GetSection("jwt").Get<Jwt>();
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("id", user.Id.ToString()),
                new Claim("email", user.Email)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.key));
            var signin = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);



            var token = new JwtSecurityToken(
                jwt.Issuer,
                jwt.Audience,
                claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: signin
                );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            _logger.LogInformation($"User {user.Name} with email {user.Email} has successfully logged in.");
            TokenModelResponse responseSuccess = new TokenModelResponse { 
                message = "usuario encontrado",
                email = user.Email,
                token = tokenString,
            };
            return responseSuccess;

        }
    }
}
