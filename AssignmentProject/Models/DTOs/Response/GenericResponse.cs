namespace AssignmentProject.Models.DTOs.Response
{
    public class GenericResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public Object Data { get; set; }
        public List<Error>  Errors { get; set; } = new List<Error>();
    }
    public class Error
    {
        public string ErrorMessage { get; set; }
        public int ErrorID { get; set; }
    }
}
