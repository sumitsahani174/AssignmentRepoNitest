using AssignmentProject.DataAccessLayer.Interface;
using AssignmentProject.Models.DTOs.Request;
using AssignmentProject.Models.DTOs.Response;
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

        [HttpPost]
        [Route("UserLogin")]
        public  GenericResponse UserLogin(LoginRequest model)
        {
            GenericResponse genericResponse = new GenericResponse();
            genericResponse = _login.UserLogin(model);
            return genericResponse;
        }
    }
}
