namespace API.Response
{
    public class ApiResponse
    {
        public int Status { get; set; }
        public string Message { get; set; } = string.Empty;
        public object? Data { get; set; } = null;

        public ApiResponse(int status, string message, object? data)
        {
            Status = status;
            Message = message;
            Data = data;
        }
    }
}
