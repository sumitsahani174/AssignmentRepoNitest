using AssignmentProject_UI.Models.DTOs.Request;
using AssignmentProject_UI.Models.DTOs.Response;

namespace AssignmentProject_UI.DataAccessLayer.Interface
{
    public interface ILogin
    {
        public UserLoginResponse CheckUserLogin(LoginRequest loginRequest);
    }
}
