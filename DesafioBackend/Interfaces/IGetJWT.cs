namespace DesafioBackend.Interfaces
{
    public interface IGetJWT
    {


        public string GetToken(string email, string password);


    }
}
