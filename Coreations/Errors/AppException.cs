namespace COREationsTask.Errors
{
    public class AppException : AppResponse
    {
        public AppException(int statuscode, string message = null, string details = null) : base(statuscode, message)
        {
            Details = details;
        }

        public string Details { get; set; }
    }
}

