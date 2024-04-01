namespace AssignmentProject.Models.DTOs.Response
{
    public class UserLoginResponse
    {
        public int UserID { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserRole { get; set; }
        public string ApiKey { get; set; }
    }
}
