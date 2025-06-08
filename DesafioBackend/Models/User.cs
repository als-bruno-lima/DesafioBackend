using System.ComponentModel.DataAnnotations;

namespace DesafioBackend.Models

{
    public enum State
{ 
    Active, 
    Inactive
}


    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public State status { get; set; }


    }
}
