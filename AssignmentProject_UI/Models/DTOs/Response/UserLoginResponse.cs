namespace AssignmentProject_UI.Models.DTOs.Response
{
    public class UserLoginResponse
    {
        public int userID { get; set; }
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string userRole { get; set; }
        public string apiKey { get; set; }
    }
}
