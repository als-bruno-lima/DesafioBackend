using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using DesafioBackend.Interfaces;
using DesafioBackend.Models;
using DesafioBackend.Request;
using DesafioBackend.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DesafioBackend.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("/auth/register")]
        public async Task<IActionResult> AddUser([FromBody] UserModelDto user)
        {
            try

            {
                await _userService.AddUser(user.Name, user.Email, user.Password, user.Status);
                return Ok($"User {user.Name} added successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error adding user: {ex}");
            }

        }


        [HttpPost("/auth/login")]
        public async Task<IActionResult> GetToken([FromBody] LoginModelDto login)
        {
            try
            {
                string email = login.Email;
                string password = login.Password;

                var response =  _userService.GetToken(email, password);

                if (response.message == "User not found")  return NotFound(); 


                return Ok(response);

        
            }
            catch (Exception ex) {
                return BadRequest(ex);
            }
        }
    }
}
