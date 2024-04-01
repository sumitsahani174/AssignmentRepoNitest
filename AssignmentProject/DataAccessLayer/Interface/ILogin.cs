using AssignmentProject.Models.DTOs.Request;
using AssignmentProject.Models.DTOs.Response;

namespace AssignmentProject.DataAccessLayer.Interface
{
    public interface ILogin
    {
        GenericResponse UserLogin(LoginRequest model);
    }
}
