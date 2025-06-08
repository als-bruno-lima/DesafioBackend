using DesafioBackend.Models;
using DesafioBackend.Request;
using DesafioBackend.Responses;

namespace DesafioBackend.Interfaces
{
    public interface IUserService
    {

        Task AddUser(string name, string email, string password, State status);
        TokenModelResponse GetToken(string email,string password);

    }
}
