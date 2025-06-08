using DesafioBackend.Models;

namespace DesafioBackend.Request
{

    public class UserModelDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public State Status { get; set; }
    }
}
