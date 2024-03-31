using Microsoft.AspNetCore.Identity.Data;

namespace AssignmentProject.DataAccessLayer.Interface
{
    public interface ILogin
    {
        public void CheckUserLogin(LoginRequest loginRequest);
    }
}
