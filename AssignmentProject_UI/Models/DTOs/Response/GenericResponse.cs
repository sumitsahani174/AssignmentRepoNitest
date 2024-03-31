namespace AssignmentProject_UI.Models.DTOs.Response
{
    public class GenericResponse
    {
        public bool isSuccess { get; set; }
        public string message { get; set; }
        public Object data { get; set; }
        public List<Error> errors { get; set; } = new List<Error>();
    }
    public class Error
    {
        public string errorMessage { get; set; }
        public int errorID { get; set; }
    }
}
