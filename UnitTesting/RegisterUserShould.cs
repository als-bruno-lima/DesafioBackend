using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioBackend.Interfaces;
using DesafioBackend.Services;
using Xunit;

namespace UnitTesting
{
    public class RegisterUserShould
    {
        private readonly IUserService _userService;
        public RegisterUserShould(IUserService userService) {
            _userService = userService;
        }



        [Fact]
        public void RegisterUser() {
            //arrange

            var registerUser = new UserService();


            //act
            //assert
        
        }
    }
}
