using AssignmentProject_UI.DataAccessLayer.Interface;
using AssignmentProject_UI.Models.DTOs.Response;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentProject_UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogin _login;
        private readonly IConfiguration _configuration;
        public LoginController(ILogin login, IConfiguration configuration) {
            _login = login;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckUserLogin([FromBody] LoginRequest model)
        {
            _login.CheckUserLogin(model);
            return Ok();
        }
    }
}
