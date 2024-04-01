using AssignmentProject_UI.DataAccessLayer.Interface;
using AssignmentProject_UI.Models.DTOs.Request;
using AssignmentProject_UI.Models.DTOs.Response;
using Microsoft.AspNetCore.Http;
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
            UserLoginResponse userLoginResponse = _login.CheckUserLogin(model);
            if(userLoginResponse != null)
            {
                if (!string.IsNullOrEmpty(userLoginResponse.apiKey))
                {
                    HttpContext.Session.SetString("ApiKey", userLoginResponse.apiKey);
                    HttpContext.Session.SetString("UserRole", userLoginResponse.userRole);
                }
                
            }
            return Ok(userLoginResponse);
        }
    }
}
