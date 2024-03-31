using AssignmentProject_UI.Models.DTOs.Response;

namespace AssignmentProject_UI.DataAccessLayer.Interface
{
    public interface ILogin
    {
        public void checkUserLogin(LoginRequest loginRequest);
    }
}
