using DesafioBackend.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioBackend.Controllers
{
    public class AuthorController:ControllerBase
    {

        private readonly IAutorService _autorService;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthorController> _logger;
        public AuthorController(IAutorService autorService, IConfiguration configuration, ILogger<AuthorController> logger) {
            _autorService = autorService;
            _logger = logger;
        }


        [HttpGet("/authors")]
        [Authorize]

        public async Task<IActionResult> GetAuthors()
        {
            try
            {
                var authors = _autorService.GetAuthors();
                return Ok(authors);

            }
            catch (Exception ex)
            {
                _logger.LogInformation("error", ex);
                return BadRequest(ex);            
            }
        }

    }
}
