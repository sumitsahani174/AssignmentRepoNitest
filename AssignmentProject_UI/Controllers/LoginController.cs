using AssignmentProject_UI.DataAccessLayer.Interface;
using AssignmentProject_UI.Models.DTOs.Request;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentProject_UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogin _login;
        public LoginController(ILogin login) {
            _login = login;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckUserLogin([FromBody] LoginRequest model)
        {
            _login.checkUserLogin(model);
            return Ok();
        }
    }
}
