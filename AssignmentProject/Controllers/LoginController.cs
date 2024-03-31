using AssignmentProject.DataAccessLayer.Interface;
using AssignmentProject.Models.DTOs.Request;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogin _login;
        public LoginController(ILogin login)
        {
            _login = login;
        }

        [HttpGet]
        [Route("UserLogin")]
        public  void UserLogin([FromBody] LoginRequest model)
        {
            //_login.checkUserLogin(model);
            Console.WriteLine("lll");
        }
    }
}
